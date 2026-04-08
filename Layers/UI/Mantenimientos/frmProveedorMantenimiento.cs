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
using System.Windows.Forms;
using log4net;
using TechKMii.Layers.BLL;
using TechKMii.Layers.Entities;
using TechKMii.Layers.Interfaces;
using UTN.Winform.Electronics.Extensions;

namespace TechKMii.Layers.UI.Mantenimientos
{
    public partial class frmProveedorMantenimiento : Form
    {
        private static readonly ILog _myLogControlEventos = LogManager.GetLogger("MyControlEventos");
        SqlCommand command = new SqlCommand();
        Proveedor oProveedor = null;
        private IProveedorBLL proveedorBll = new ProveedorBLL();
        string msg = "";
        private int _idProveedorSeleccionado = 0;

        public frmProveedorMantenimiento()
        {
            InitializeComponent();
        }

        private void frmProveedorMantenimiento_Load(object sender, EventArgs e)
        {
            try
            {
                ConfigurarGrid();
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

        private void ConfigurarGrid()
        {
            dgvDatos.AutoGenerateColumns = true;
            dgvDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDatos.MultiSelect = false;
            dgvDatos.ReadOnly = true;
            dgvDatos.AllowUserToAddRows = false;
            dgvDatos.AllowUserToDeleteRows = false;
            dgvDatos.AllowUserToResizeRows = false;
        }

        private void CargarEstados()
        {
            cmbEstado.DataSource = Enum.GetValues(typeof(EstadoCatalogos))
            .Cast<EstadoCatalogos>()
            .Where(x => x != EstadoCatalogos.Eliminado)
            .ToList();
        }

        private void CargarDatos()
        {
            dgvDatos.DataSource = null;
            dgvDatos.DataSource = proveedorBll.GetAll().ToList();

            if (dgvDatos.Columns["ProveedorID"] != null)
                dgvDatos.Columns["ProveedorID"].HeaderText = "ID";

            if (dgvDatos.Columns["Nombre"] != null)
                dgvDatos.Columns["Nombre"].HeaderText = "Nombre";

            if (dgvDatos.Columns["Estado"] != null)
                dgvDatos.Columns["Estado"].HeaderText = "Estado";
        }
        private void Limpiar()
        {
            _idProveedorSeleccionado = 0;
            txtNombre.Clear();
            cmbEstado.SelectedIndex = -1;
            txtNombre.Focus();
        }

        private void btnAgregarProveedor_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    MessageBox.Show("Debe ingresar el nombre del proveedor", "Atención",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNombre.Focus();
                    return;
                }

                if (cmbEstado.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar el estado", "Atención",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbEstado.Focus();
                    return;
                }

                if (_idProveedorSeleccionado != 0)
                {
                    MessageBox.Show("Para agregar un proveedor nuevo, presione Nuevo primero", "Atención",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                oProveedor = new Proveedor();
                oProveedor.Nombre = txtNombre.Text.Trim();
                oProveedor.Estado = (EstadoCatalogos)cmbEstado.SelectedItem;

                oProveedor = proveedorBll.Save(oProveedor);

                MessageBox.Show("Proveedor agregado correctamente", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;

                if (dgvDatos.Rows[e.RowIndex].Cells["ProveedorID"].Value == null)
                    return;

                _idProveedorSeleccionado = Convert.ToInt32(dgvDatos.Rows[e.RowIndex].Cells["ProveedorID"].Value);
                txtNombre.Text = dgvDatos.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                cmbEstado.SelectedItem = (EstadoCatalogos)Convert.ToInt32(dgvDatos.Rows[e.RowIndex].Cells["Estado"].Value);

                txtNombre.Focus();
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

        private void tspNuevo_Click(object sender, EventArgs e)
        {
            try
            {
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

        private void tspEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_idProveedorSeleccionado == 0)
                {
                    MessageBox.Show("Debe seleccionar un proveedor para editar", "Atención",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    MessageBox.Show("Debe ingresar el nombre del proveedor", "Atención",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNombre.Focus();
                    return;
                }

                if (cmbEstado.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar el estado", "Atención",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbEstado.Focus();
                    return;
                }

                oProveedor = new Proveedor();
                oProveedor.ProveedorID = _idProveedorSeleccionado;
                oProveedor.Nombre = txtNombre.Text.Trim();
                oProveedor.Estado = (EstadoCatalogos)cmbEstado.SelectedItem;

                oProveedor = proveedorBll.Update(oProveedor);

                if (oProveedor != null)
                {
                    MessageBox.Show("Proveedor actualizado correctamente", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarDatos();
                    Limpiar();
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el proveedor", "Atención",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void tspBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDatos.CurrentRow == null)
                {
                    MessageBox.Show("Debe seleccionar un proveedor para borrar", "Atención",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int id = Convert.ToInt32(dgvDatos.CurrentRow.Cells["ProveedorID"].Value);
                string nombre = dgvDatos.CurrentRow.Cells["Nombre"].Value.ToString();

                DialogResult respuesta = MessageBox.Show(
                    "¿Desea eliminar el proveedor " + nombre + "?",
                    "Confirmación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (respuesta == DialogResult.Yes)
                {
                    bool eliminado = proveedorBll.Delete(id);

                    if (eliminado)
                    {
                        MessageBox.Show("Proveedor eliminado correctamente", "Información",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        CargarDatos();
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el proveedor o ya estaba eliminado", "Atención",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
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

        private void tspSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
