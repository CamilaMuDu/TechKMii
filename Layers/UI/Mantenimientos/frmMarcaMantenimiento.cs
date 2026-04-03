using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using log4net;
using TechKMii.Layers.BLL;
using TechKMii.Layers.Entities;
using TechKMii.Layers.Interfaces;
using UTN.Winform.Electronics.Extensions;

namespace TechKMii.Layers.UI.Mantenimientos
{
    public partial class frmMarcaMantenimiento : Form
    {
        private static readonly ILog _myLogControlEventos = LogManager.GetLogger("MyControlEventos");
        SqlCommand command = new SqlCommand();
        Marca oMarca = null;
        private IMarcaBLL marcaBll = new MarcaBLL();
        public frmMarcaMantenimiento()
        {
            InitializeComponent();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmMarcaMantenimiento_Load(object sender, EventArgs e)
        {
            string msg = "";
            try
            {
                txtCodigo.ReadOnly = true;
                dgvDatos.AutoGenerateColumns = true;
                dgvDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvDatos.MultiSelect = false;
                dgvDatos.ReadOnly = true;
                dgvDatos.AllowUserToAddRows = false;
                dgvDatos.AllowUserToDeleteRows = false;
                CargarEstados();
                CargarDatos();
                Limpiar();
            }
            catch (SqlException er)
            {
                _myLogControlEventos.ErrorFormat("Error {0}", msg.ToExceptionDetail(MethodBase.GetCurrentMethod(), er, command));
                throw new CustomException(msg.ToSqlServerDetailError(er));
            }
            catch (Exception er)
            {
                msg = msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod());
                _myLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                throw;
            }
        }
        private void CargarDatos()
        {
            List<Marca> lista = marcaBll.GetAll().ToList();

            dgvDatos.DataSource = null;
            dgvDatos.DataSource = lista;

            if (dgvDatos.Columns["MarcaID"] != null)
                dgvDatos.Columns["MarcaID"].HeaderText = "Código";

            if (dgvDatos.Columns["Nombre"] != null)
                dgvDatos.Columns["Nombre"].HeaderText = "Nombre";

            if (dgvDatos.Columns["Estado"] != null)
                dgvDatos.Columns["Estado"].HeaderText = "Estado";
        }
        private void CargarEstados()
        {
            cmbEstado.SelectedIndex = -1;
            cmbEstado.DataSource = Enum.GetValues(typeof(EstadoCatalogos));
        }
        private void Limpiar()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            cmbEstado.SelectedIndex = -1;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string msg = "";
            try
            {
                //validaciones

                if (string.IsNullOrWhiteSpace(txtCodigo.Text))
                {
                    MessageBox.Show("Debe ingresar el nombre de la marca.");
                    txtNombre.Focus();
                }
                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    MessageBox.Show("Debe ingresar el nombre de la marca.");
                    txtNombre.Focus();
                }
                if (cmbEstado.SelectedItem == null)
                {
                    MessageBox.Show("Debe seleccionar un estado.");
                    cmbEstado.Focus();
                }



            }
            catch (SqlException er)
            {
                _myLogControlEventos.ErrorFormat("Error {0}", msg.ToExceptionDetail(MethodBase.GetCurrentMethod(), er, command));
                throw new CustomException(msg.ToSqlServerDetailError(er));
            }
            catch (Exception er)
            {
                msg = msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod());
                _myLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                throw;
            }
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string msg = "";
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow fila = dgvDatos.Rows[e.RowIndex];

                    Marca oMarca = new Marca();
                    oMarca.MarcaID = int.Parse(fila.Cells["MarcaID"].Value.ToString());
                    oMarca.Nombre = fila.Cells["Nombre"].Value.ToString();
                    oMarca.Estado = (EstadoCatalogos)Enum.Parse(
                        typeof(EstadoCatalogos),
                        fila.Cells["Estado"].Value.ToString());
                }
            }
            catch (SqlException er)
            {
                _myLogControlEventos.ErrorFormat("Error {0}", msg.ToExceptionDetail(MethodBase.GetCurrentMethod(), er, command));
                throw new CustomException(msg.ToSqlServerDetailError(er));
            }
            catch (Exception er)
            {
                msg = msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod());
                _myLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                throw;
            }
        }
    }
}
