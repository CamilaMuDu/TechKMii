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
            try
            {
                txtBuscar.Focus();

                var lista = ClienteBll.GetByFilter("")
                    .Where(c => c.Estado == EstadoCatalogos.Activo)
                    .ToList();

                dgvBuscar.AutoGenerateColumns = true;
                dgvBuscar.DataSource = null;
                dgvBuscar.DataSource = lista;

                ConfigurarColumnasGrid(dgvBuscar);
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

        private void tspSalir_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void tspBuscarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                string filtro = txtBuscar.Text.Trim();

                if (string.IsNullOrWhiteSpace(filtro))
                {
                    filtro = "";
                }

                //Codigo que trae solo los clientes activos que coincidan con el filtro
                var lista = ClienteBll.GetByFilter(filtro)
                    .Where(c => c.Estado == EstadoCatalogos.Activo)
                    .ToList();

                dgvBuscar.AutoGenerateColumns = true;
                dgvBuscar.DataSource = null;
                dgvBuscar.DataSource = lista;

                ConfigurarColumnasGrid(dgvBuscar);

                if (lista.Count == 0)
                {
                    MessageBox.Show("No se encontraron clientes.",
                        "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void tspNuevo_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();

            var lista = ClienteBll.GetByFilter("")
                .Where(c => c.Estado == EstadoCatalogos.Activo)
                .ToList();

            dgvBuscar.AutoGenerateColumns = true;
            dgvBuscar.DataSource = null;
            dgvBuscar.DataSource = lista;

            ConfigurarColumnasGrid(dgvBuscar);

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

        private void ConfigurarColumnasGrid(DataGridView dgv)
        {
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                col.Visible = false;
            }

            string[] columnasVisibles =
            {
            "Identificacion",
            "Nombre",
            "Apellidos",
            "Sexo",
            "Telefono",
            "Correo",
            "Provincia",
            "Estado"
            };

            foreach (string nombreColumna in columnasVisibles)
            {
                if (dgv.Columns[nombreColumna] != null)
                    dgv.Columns[nombreColumna].Visible = true;
            }

            if (dgv.Columns["Identificacion"] != null)
                dgv.Columns["Identificacion"].HeaderText = "Identificación";

            if (dgv.Columns["Telefono"] != null)
                dgv.Columns["Telefono"].HeaderText = "Teléfono";
        }
    }
}
