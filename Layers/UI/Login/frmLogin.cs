using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;
using TechKMii.Layers.BLL;
using TechKMii.Layers.Entities;
using TechKMii.Layers.Interfaces;
using TechKMii.Properties;
using UTN.Winform.Electronics.Extensions;

namespace TechKMii.Layers.UI.Login
{
    public partial class frmLogin : Form
    {
        private static readonly ILog _myLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");
        private int contador = 0;
        IUsuarioBLL usuariobll = new UsuarioBLL();

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private async void btnAceptar_Click(object sender, EventArgs e)
        {
            epError.Clear();
            Usuario oUsuario = null;

            try
            {
                if (string.IsNullOrEmpty(this.txtNombre.Text))
                {
                    epError.SetError(txtNombre, "El usuario es requerido");
                    this.txtNombre.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(this.txtContrasenna.Text))
                {
                    epError.SetError(txtContrasenna, "La contraseña es requerida");
                    this.txtContrasenna.Focus();
                    return;
                }

                oUsuario = usuariobll.Login(this.txtNombre.Text, this.txtContrasenna.Text);

                if (oUsuario == null)
                {
                    ++contador;
                    MessageBox.Show("Error en el acceso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    if (contador == 3)
                    {
                        MessageBox.Show("Se equivocó en 3 ocasiones, el Sistema se cerrará por seguridad",
                                        "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        _myLogControlEventos.WarnFormat("Se equivocó + de 3 ocasiones Login: {0}", this.txtNombre.Text);
                        this.DialogResult = DialogResult.Cancel;
                        Application.Exit();
                    }
                    return;
                }
                else
                {
                    Settings.Default.Usuario = oUsuario.UsuarioID;
                    Settings.Default.Nombre = oUsuario.Nombre.Trim();
                    Settings.Default.Rol = oUsuario.RolID.RolID.ToString();
                    Settings.Default.Save();

                    bool respuesta = await EfectoConexion();

                    _myLogControlEventos.InfoFormat("Accedió a la aplicación :{0}", Settings.Default.Nombre);

                    frmMenúPrincipal frmMenuPrincipal = new frmMenúPrincipal();

                    this.Hide();
                    frmMenuPrincipal.ShowDialog();

                    if (frmMenuPrincipal.CerrarSesion)
                    {
                        this.txtNombre.Clear();
                        this.txtContrasenna.Clear();
                        this.txtNombre.Focus();
                        this.Show();
                    }
                    else
                    {
                        this.Close();
                    }
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

        //metodo para que se llene el progressbar.
        private async Task<bool> EfectoConexion()
        {
            toolStripProgressBar1.Visible = true;
            toolStripProgressBar1.Minimum = 0;
            toolStripProgressBar1.Maximum = 100;
            toolStripProgressBar1.Value = 0;

            for (int i = 0; i < 10; i++)
            {
                await Task.Delay(150);

                if (toolStripProgressBar1.Value + 10 <= toolStripProgressBar1.Maximum)
                {
                    toolStripProgressBar1.Value += 10;
                }

                this.sttBarraInferior.Refresh();
            }

            toolStripProgressBar1.Value = 0;
            toolStripProgressBar1.Visible = false;

            return true;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {          
            try
            {
                this.Text = $"{this.Text}. Versión TechKMii : {Application.ProductVersion}";
                _myLogControlEventos.InfoFormat("Inicio Login");

                this.txtNombre.Clear();
                this.txtContrasenna.Clear();
            }
            catch (Exception er)
            {
                string msg = "";
                _myLogControlEventos.ErrorFormat("Error {0}", msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod()));
                MessageBox.Show("Se ha producido el siguiente error: " + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtContrasenna_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

