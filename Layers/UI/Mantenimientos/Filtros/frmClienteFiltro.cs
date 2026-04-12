using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;
using TechKMii.Layers.BLL;
using TechKMii.Layers.DAL;
using TechKMii.Layers.Entities;
using TechKMii.Layers.Interfaces;
using UTN.Winform.Electronics.Extensions;

namespace TechKMii.Layers.UI.Mantenimientos.Filtros
{
    public partial class frmClienteFiltro : Form
    {
        private static readonly ILog _myLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");
        public Cliente oCliente = null;
        IClienteBLL ClienteBll = new ClienteBLL();
        public frmClienteFiltro()
        {
            InitializeComponent();
        }

        private void frmClienteFiltro_Load(object sender, EventArgs e)
        {

        }

        private void tspSalir_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        //metodo para buscar clientes por filtro
        private void tspBuscarCliente_Click(object sender, EventArgs e)
        {
            ClienteBll = new ClienteBLL(); 
            string filtro = string.Empty;
            try
            {
                if (string.IsNullOrWhiteSpace(txtBuscar.Text))
                {
                    MessageBox.Show("Debe digitar un nombre o una cédula.",
                        "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBuscar.Focus();
                    return;
                }

                filtro = txtBuscar.Text.Trim();
                filtro = filtro.Replace(' ', '%');
                filtro = "%" + filtro + "%";

                dgvBuscar.AutoGenerateColumns = true;
                dgvBuscar.DataSource = ClienteBll.GetByFilter(filtro);

                if (dgvBuscar.Rows.Count == 0)
                {
                    MessageBox.Show("No se encontraron clientes con ese filtro.",
                        "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception er)
            {
                string msg = "";
                _myLogControlEventos.ErrorFormat("Error {0}", msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod()));
                MessageBox.Show("Se ha producido el siguiente error: " + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tspNuevo_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            dgvBuscar.DataSource = null;
            txtBuscar.Focus();
        }

        private void dgvBuscar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;

                oCliente = dgvBuscar.Rows[e.RowIndex].DataBoundItem as Cliente;

                if (oCliente != null)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception er)
            {
                string msg = "";
                _myLogControlEventos.ErrorFormat("Error {0}",
                    msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod()));

                MessageBox.Show("Se ha producido el siguiente error: " + er.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
