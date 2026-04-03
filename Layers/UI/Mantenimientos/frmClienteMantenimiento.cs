using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

namespace TechKMii.Layers.UI.Mantenimientos
{
    public partial class frmClienteMantenimiento : Form
    {
        private static readonly ILog _myLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");

        IProvinciaBLL provinciaBLL = new BLLProvincia();
        Provincia provincia = new Provincia();

        public frmClienteMantenimiento()
        {
            InitializeComponent();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmClienteMantenimiento_Load(object sender, EventArgs e)
        {

            try
            {
                List<Provincia> listaP = new List<Provincia>();
                listaP = provinciaBLL.GetProvinciaFromInternet();
                cmbProvincia.DataSource = listaP;
                cmbProvincia.DisplayMember = "Descripcion";
                cmbProvincia.SelectedIndex = -1;
            }
            catch (Exception er)
            {
                string msg = "";
                _myLogControlEventos.ErrorFormat("Error {0}", msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod()));
                MessageBox.Show("Se ha producido el siguiente error: " + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                IClienteBLL clienteBLL = new ClienteBLL();

                Cliente cliente = new Cliente();

                cliente.Nombre = txtNombre.Text.Trim();
                cliente.Apellidos = txtApellidos.Text.Trim();

                // Sexo
                if (rdbFemenino.Checked)
                    cliente.Sexo = Sexo.Femenino;
                else
                    cliente.Sexo = Sexo.Masculino;

                cliente.Telefono = mskTelefono.Text.Trim();
                cliente.Correo = txtCorreo.Text.Trim();
                cliente.Direccion = txtDireccion.Text.Trim();

                // Tipo Identificación
                cliente.TipoIdentificacion = (TipoIdentificacion)cmbTipoIdentificacion.SelectedItem;

                // Provincia
                cliente.Provincia = cmbProvincia.Text;

                // Estado
                cliente.Estado = chkEstado.Checked ? EstadoCatalogos.Activo : EstadoCatalogos.Inactivo;

                // Fotografía
                if (pcbFotografia.Image != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        pcbFotografia.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        cliente.Fotografia = ms.ToArray();
                    }
                }

                await clienteBLL.Save(cliente);

                MessageBox.Show("Cliente guardado con éxito", "OK",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarFormulario();
            }
            catch (Exception er)
            {
                MessageBox.Show("Error: " + er.Message);
            }
        }

        private void LimpiarFormulario()
        {
            txtNombre.Clear();
            txtApellidos.Clear();
            mskTelefono.Clear();
            txtCorreo.Clear();
            txtDireccion.Clear();

            cmbProvincia.SelectedIndex = -1;
            cmbTipoIdentificacion.SelectedIndex = -1;

            rdbFemenino.Checked = false;
            rdbMasculino.Checked = false;

            chkEstado.Checked = false;

            pcbFotografia.Image = null;
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {

        }
    }
}
