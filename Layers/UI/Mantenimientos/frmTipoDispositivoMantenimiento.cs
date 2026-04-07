using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;
using TechKMii.Layers.BLL;
using TechKMii.Layers.Entities;
using TechKMii.Layers.Interfaces;

namespace TechKMii.Layers.UI.Mantenimientos
{
    public partial class frmTipoDispositivoMantenimiento : Form
    {
        private static readonly ILog _myLogControlEventos = LogManager.GetLogger("MyControlEventos");
        private TipoDispositivo tipo = new TipoDispositivo();
        private ITipoDispositivoBLL tipoDispositivoBLL = new TipoDispositivoBLL();

        public frmTipoDispositivoMantenimiento()
        {
            InitializeComponent();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmTipoDispositivoMantenimiento_Load(object sender, EventArgs e)
        {
            try
            {
                CargarEstados();
                CargarDatos();
                Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el formulario: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargarEstados()
        {
            cmbEstado.DataSource = Enum.GetValues(typeof(EstadoCatalogos));
            cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void CargarDatos()
        {
            dgvDatos.DataSource = null;
            dgvDatos.DataSource = tipoDispositivoBLL.GetAll().ToList();

            dgvDatos.AutoGenerateColumns = true;
            dgvDatos.ClearSelection();

            if (dgvDatos.Columns["TipoID"] != null)
                dgvDatos.Columns["TipoID"].HeaderText = "ID";

            if (dgvDatos.Columns["Nombre"] != null)
                dgvDatos.Columns["Nombre"].HeaderText = "Nombre";

            if (dgvDatos.Columns["Estado"] != null)
                dgvDatos.Columns["Estado"].HeaderText = "Estado";
        }
        private void Limpiar()
        {
            tipo = new TipoDispositivo();
            txtNombre.Clear();
            cmbEstado.SelectedIndex = 0;
            dgvDatos.ClearSelection();
            txtNombre.Focus();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (tipo.TipoID == 0)
                {
                    MessageBox.Show("Debe seleccionar un registro para editar.", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    MessageBox.Show("Debe ingresar el nombre.", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNombre.Focus();
                    return;
                }

                if (cmbEstado.SelectedItem == null)
                {
                    MessageBox.Show("Debe seleccionar un estado.", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbEstado.Focus();
                    return;
                }

                DialogResult r = MessageBox.Show("¿Desea editar el registro seleccionado?", "Confirmación",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (r == DialogResult.Yes)
                {
                    tipo.Nombre = txtNombre.Text.Trim();
                    tipo.Estado = (EstadoCatalogos)cmbEstado.SelectedItem;

                    tipoDispositivoBLL.Update(tipo);

                    MessageBox.Show("Tipo de dispositivo actualizado correctamente.", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarDatos();
                    Limpiar();
                    tipo = new TipoDispositivo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al editar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDatos.CurrentRow == null)
                {
                    MessageBox.Show("Debe seleccionar un registro para eliminar.", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int id = Convert.ToInt32(dgvDatos.CurrentRow.Cells["TipoID"].Value);

                DialogResult r = MessageBox.Show("¿Desea eliminar el registro seleccionado?", "Confirmación",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (r == DialogResult.Yes)
                {
                    bool eliminado = tipoDispositivoBLL.Delete(id);

                    if (eliminado)
                    {
                        MessageBox.Show("Registro eliminado correctamente.", "Información",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarDatos();
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el registro.", "Atención",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    MessageBox.Show("Debe ingresar el nombre.", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNombre.Focus();
                    return;
                }

                if (cmbEstado.SelectedItem == null)
                {
                    MessageBox.Show("Debe seleccionar un estado.", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbEstado.Focus();
                    return;
                }

                if (tipo.TipoID != 0)
                {
                    MessageBox.Show("Para modificar un registro, use el botón Editar.", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                tipo.Nombre = txtNombre.Text.Trim();
                tipo.Estado = (EstadoCatalogos)cmbEstado.SelectedItem;

                tipoDispositivoBLL.Save(tipo);

                MessageBox.Show("Tipo de dispositivo guardado correctamente.", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarDatos();
                Limpiar();
                tipo = new TipoDispositivo();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }       
        }

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    tipo.TipoID = Convert.ToInt32(dgvDatos.Rows[e.RowIndex].Cells["TipoID"].Value);
                    txtNombre.Text = dgvDatos.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();

                    int estadoValor = Convert.ToInt32(dgvDatos.Rows[e.RowIndex].Cells["Estado"].Value);
                    cmbEstado.SelectedItem = (EstadoCatalogos)estadoValor;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al seleccionar fila: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
