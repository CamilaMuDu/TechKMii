using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
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
        string msg = "";

        public frmMarcaMantenimiento()
        {
            InitializeComponent();
            dgvDatos.CellClick += dgvDatos_CellClick;
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmMarcaMantenimiento_Load(object sender, EventArgs e)
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
                _myLogControlEventos.ErrorFormat("Error {0}",
                    msg.ToExceptionDetail(MethodBase.GetCurrentMethod(), er, command));
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
            dgvDatos.AutoGenerateColumns = false;
            dgvDatos.Columns.Clear();

            dgvDatos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "MarcaID",
                HeaderText = "Codigo",
                DataPropertyName = "MarcaID",
                Width = 80
            });

            dgvDatos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Nombre",
                HeaderText = "Nombre",
                DataPropertyName = "Nombre",
                Width = 180
            });

            dgvDatos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Estado",
                HeaderText = "Estado",
                DataPropertyName = "Estado",
                Width = 120
            });

            dgvDatos.AllowUserToAddRows = false;
            dgvDatos.ReadOnly = true;
            dgvDatos.MultiSelect = false;
            dgvDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
        }

        private void CargarDatos()
        {
            var lista = marcaBll.GetAll().ToList();

            dgvDatos.DataSource = null;
            dgvDatos.DataSource = lista;
        }

        private void CargarEstados()
        {
            cmbEstado.DataSource = Enum.GetValues(typeof(EstadoCatalogos));
            cmbEstado.SelectedIndex = -1;
        }
        private void Limpiar()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            cmbEstado.SelectedIndex = -1;

            txtCodigo.Enabled = false;

            oMarca = null;
        }

        private void btnAgregarMarca_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    MessageBox.Show("Debe ingresar el nombre.");
                    return;
                }

                if (cmbEstado.SelectedItem == null)
                {
                    MessageBox.Show("Debe seleccionar estado.");
                    return;
                }

                Marca marca = new Marca
                {
                    Nombre = txtNombre.Text.Trim(),
                    Estado = (EstadoCatalogos)cmbEstado.SelectedItem
                };

                var resultado = marcaBll.Save(marca);

                if (resultado != null)
                {
                    MessageBox.Show("Marca guardada correctamente.");
                    CargarDatos();
                    Limpiar();
                }
                else
                {
                    MessageBox.Show("Error al guardar.");
                }
            }
            catch (SqlException er)
            {
                _myLogControlEventos.ErrorFormat("Error {0}",
                    msg.ToExceptionDetail(MethodBase.GetCurrentMethod(), er, command));
                throw new CustomException(msg.ToSqlServerDetailError(er));
            }
            catch (Exception er)
            {
                msg = msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod());
                _myLogControlEventos.ErrorFormat("Error {0}", msg);
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
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow fila = dgvDatos.Rows[e.RowIndex];

                    txtCodigo.Text = fila.Cells["MarcaID"].Value?.ToString();
                    txtNombre.Text = fila.Cells["Nombre"].Value?.ToString();

                    if (fila.Cells["Estado"].Value != null)
                    {
                        cmbEstado.SelectedItem = Enum.Parse(
                            typeof(EstadoCatalogos),
                            fila.Cells["Estado"].Value.ToString());
                    }
                }
            }
            catch (SqlException er)
            {
                _myLogControlEventos.ErrorFormat("Error {0}",
                    msg.ToExceptionDetail(MethodBase.GetCurrentMethod(), er, command));
                throw new CustomException(msg.ToSqlServerDetailError(er));
            }
            catch (Exception er)
            {
                msg = msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod());
                _myLogControlEventos.ErrorFormat("Error {0}", msg);
                throw;
            }
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDatos.CurrentRow == null)
                {
                    MessageBox.Show("Seleccione una marca para borrar.");
                    return;
                }

                if (dgvDatos.CurrentRow.Cells["MarcaID"].Value == null)
                {
                    MessageBox.Show("Seleccione una marca válida para borrar.");
                    return;
                }

                int id = Convert.ToInt32(dgvDatos.CurrentRow.Cells["MarcaID"].Value);

                DialogResult r = MessageBox.Show(
                    "¿Desea eliminar la marca seleccionada?",
                    "Confirmación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (r == DialogResult.Yes)
                {
                    bool eliminado = marcaBll.Delete(id);

                    if (eliminado)
                    {
                        MessageBox.Show("Marca eliminada correctamente.");
                        CargarDatos();
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar la marca.");
                    }
                }
            }
            catch (SqlException er)
            {
                _myLogControlEventos.ErrorFormat("Error {0}",
                    msg.ToExceptionDetail(MethodBase.GetCurrentMethod(), er, command));
                throw new CustomException(msg.ToSqlServerDetailError(er));
            }
            catch (Exception er)
            {
                msg = msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod());
                _myLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                throw;
            }
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            string msg = "";
            try
            {
                if (!int.TryParse(txtCodigo.Text, out int id))
                {
                    MessageBox.Show("Seleccione una marca.");
                    return;
                }

                Marca marca = new Marca
                {
                    MarcaID = id,
                    Nombre = txtNombre.Text.Trim(),
                    Estado = (EstadoCatalogos)cmbEstado.SelectedItem
                };

                var resultado = marcaBll.Update(marca);

                if (resultado != null)
                {
                    MessageBox.Show("Actualizado.");
                    CargarDatos();
                    Limpiar();
                }
            }
            catch (SqlException er)
            {
                _myLogControlEventos.ErrorFormat("Error {0}",
                    msg.ToExceptionDetail(MethodBase.GetCurrentMethod(), er, command));
                throw new CustomException(msg.ToSqlServerDetailError(er));
            }
            catch (Exception er)
            {
                msg = msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod());
                _myLogControlEventos.ErrorFormat("Error {0}", msg);
                throw;
            }
        }
    }
}
