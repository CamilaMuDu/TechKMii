using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using log4net;
using Newtonsoft.Json;
using TechKMii.Layers.BLL;
using TechKMii.Layers.DAL;
using TechKMii.Layers.Entities;
using TechKMii.Layers.Interfaces;
using UTN.Winform.Electronics.Extensions;
using UTNLeccion8B.Layer.Entities.PersonaHacienda;

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

            cmbEstado.SelectedIndex = -1;

            pcbFotografia.Image = null;
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtIdentificacion.Text))
                {
                    MessageBox.Show("No existe una identificación para buscar", "Atención",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtIdentificacion.Focus();
                    return;
                }

                PersonaHaciendaDatos datosDatos = new PersonaHaciendaDatos();
                string url = "https://api.hacienda.go.cr/fe/ae?identificacion=" + txtIdentificacion.Text.Trim();

                HttpWebRequest myWebRequest = (HttpWebRequest)WebRequest.Create(url);
                myWebRequest.UserAgent = "Mozilla/5.0";
                myWebRequest.Credentials = CredentialCache.DefaultCredentials;
                myWebRequest.Proxy = null;

                using (HttpWebResponse myHttpWebResponse = (HttpWebResponse)myWebRequest.GetResponse())
                using (Stream myStream = myHttpWebResponse.GetResponseStream())
                using (StreamReader myStreamReader = new StreamReader(myStream))
                {
                    string datos = HttpUtility.HtmlDecode(myStreamReader.ReadToEnd());

                    datosDatos = JsonConvert.DeserializeObject<PersonaHaciendaDatos>(datos);

                    if (datosDatos == null || string.IsNullOrWhiteSpace(datosDatos.nombre))
                    {
                        MessageBox.Show("No se encontraron datos en Hacienda.", "Atención",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    LlenarNombreYApellidos(datosDatos.nombre);
                }
            }
            catch (Exception er)
            {
                string msg = "";
                _myLogControlEventos.ErrorFormat("Error {0}", msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod()));
                MessageBox.Show("Se ha producido el siguiente error: " + er.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Llena el nombre y los dos apellidos por separado
        private void LlenarNombreYApellidos(string nombreCompleto)
        {
            txtNombre.Clear();
            txtApellidos.Clear();

            if (string.IsNullOrWhiteSpace(nombreCompleto))
                return;

            string[] partes = nombreCompleto
                .Trim()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            switch (partes.Length)
            {
                case 1:
                    txtNombre.Text = partes[0];
                    break;

                case 2:
                    txtNombre.Text = partes[0];
                    txtApellidos.Text = partes[1];
                    break;

                case 3:

                    txtNombre.Text = partes[0];
                    txtApellidos.Text = $"{partes[1]} {partes[2]}";
                    break;

                default:
                    txtNombre.Text = string.Join(" ", partes.Take(partes.Length - 2));
                    txtApellidos.Text = string.Join(" ", partes.Skip(partes.Length - 2));
                    break;
            }
        }
    }
}

