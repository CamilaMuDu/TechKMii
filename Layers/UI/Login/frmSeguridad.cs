using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;
using TechKMii.Layers.BLL;
using TechKMii.Layers.Entities;
using TechKMii.Layers.Interfaces;
using UTN.Winform.Electronics.Extensions;

namespace TechKMii.Layers.UI.Login
{
    public partial class frmSeguridad : Form
    {
        private static readonly ILog _myLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");

        public frmSeguridad()
        {
            InitializeComponent();
        }

        private void frmSeguridad_Load(object sender, EventArgs e)
        {
            IRolBLL rolBll;
            List<Rol> listaRol;
            try
            {
                rolBll = new RolBLL();
                listaRol = rolBll.GetAll();

                cmbRol.DataSource = listaRol;
                cmbRol.DisplayMember = "Descripcion";
                cmbRol.ValueMember = "RolID";
              
                if (cmbRol.Items.Count > 0)
                    this.cmbRol.SelectedIndex = 0;

                LlenarUsuarios();
            }
            catch (Exception er)
            {
                string msg = "";
                _myLogControlEventos.ErrorFormat("Error {0}", msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod()));
                MessageBox.Show("Se ha producido el siguiente error: " + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LlenarUsuarios()
        {
            IUsuarioBLL usuarioBll = new UsuarioBLL();
            IEnumerable<Usuario> lista;
            TreeNode raiz;
            try
            {
                this.trvUsuarios.Invoke((MethodInvoker)delegate
                {
                    trvUsuarios.Nodes.Clear();
                    lista = usuarioBll.GetAll();
                    raiz = trvUsuarios.Nodes.Add("Usuarios", "Usuarios", 0, 0);
                    foreach (var item in lista)
                    {
                        TreeNode nodo = new TreeNode(item.ToString(), 1, 1);
                        nodo.Tag = item;
                        trvUsuarios.Nodes[0].Nodes.Add(nodo);
                    }
                    trvUsuarios.ExpandAll();
                });
            }
            catch (Exception er)
            {
                string msg = "";
                _myLogControlEventos.ErrorFormat("Error {0}", msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod()));
                MessageBox.Show("Se ha producido el siguiente error: " + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Paralelo()
        {
            try
            {
                Parallel.Invoke(
                                () => TaskBarMensaje(),
                                () => LlenarUsuarios()
                                );
            }
            catch (Exception er)
            {
                string msg = "";
                _myLogControlEventos.ErrorFormat("Error {0}", msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod()));
                MessageBox.Show("Se ha producido el siguiente error: " + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void TaskBarMensaje()
        {
            ntfMensaje.Visible = true;
            ntfMensaje.BalloonTipIcon = ToolTipIcon.Info;
            ntfMensaje.BalloonTipText = "Usuario creado correctamente";
            ntfMensaje.BalloonTipTitle = "Atención";
            ntfMensaje.Text = "";
            ntfMensaje.ShowBalloonTip(3000);
            ntfMensaje.Visible = false;
        }

        private void toolStripBtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripBtnGuardarUsuario_Click(object sender, EventArgs e)
        {
            IUsuarioBLL usuarioBll = new UsuarioBLL();
            try
            {
                if (string.IsNullOrEmpty(txtLogin.Text))
                {
                    epError.SetError(txtLogin, "El usuario es requerido");
                    txtLogin.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(txtContrasenna.Text))
                {
                    epError.SetError(txtContrasenna, "La contraseña es requerida");
                    txtContrasenna.Focus();
                    return;
                }

                Usuario oUsuario = new Usuario();
                oUsuario.UsuarioID = txtLogin.Text;
                oUsuario.Nombre = txtNombre.Text;
                oUsuario.Contrasenna = txtContrasenna.Text;
                oUsuario.RolID = (Rol)cmbRol.SelectedItem;
                oUsuario.Estado = EstadoCatalogos.Activo;

                oUsuario = usuarioBll.Save(oUsuario);

                MessageBox.Show("Usuario guardado con éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LlenarUsuarios();


                this.txtContrasenna.Clear();
                this.txtLogin.Clear();
                this.txtNombre.Clear();
                cmbRol.SelectedIndex = 0;
                txtLogin.Focus();

            }
            catch (Exception er)
            {
                string msg = "";
                _myLogControlEventos.ErrorFormat("Error {0}", msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod()));
                MessageBox.Show("Se ha producido el siguiente error: " + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripBtnNuevo_Click(object sender, EventArgs e)
        {
            this.txtContrasenna.Clear();
            this.txtLogin.Clear();
            this.txtNombre.Clear();
            cmbRol.SelectedIndex = 0;
            txtLogin.Focus();
        }

        private void trvUsuarios_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Usuario oUsuario = null;
            try
            {
                if (e.Action == TreeViewAction.ByMouse)
                {
                    if (e.Node == null || e.Node.Tag == null)
                        return;

                    oUsuario = e.Node.Tag as Usuario;

                    txtLogin.Text = oUsuario.UsuarioID.ToString();
                    txtNombre.Text = oUsuario.Nombre;
                    txtContrasenna.Text = Cryptography.DecrypthAES(oUsuario.Contrasenna);
                    cmbRol.SelectedValue = oUsuario.RolID.RolID;
                }
            }
            catch (Exception er)
            {
                string msg = "";
                _myLogControlEventos.ErrorFormat("Error {0}", msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod()));
                MessageBox.Show("Se ha producido el siguiente error: " + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void sttBarraInferior_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void borrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (trvUsuarios.SelectedNode == null || trvUsuarios.SelectedNode.Tag == null)
                    return;

                if (trvUsuarios.SelectedNode.Level == 0)
                    return;

                Usuario oUsuario = trvUsuarios.SelectedNode.Tag as Usuario;

                if (oUsuario == null)
                    return;

                DialogResult respuesta = MessageBox.Show(
                    $"¿Desea eliminar el usuario {oUsuario.UsuarioID}?",
                    "Confirmación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (respuesta == DialogResult.No)
                    return;

                IUsuarioBLL usuarioBLL = new UsuarioBLL();
                bool eliminado = usuarioBLL.Delete(oUsuario.UsuarioID);

                if (eliminado)
                {
                    MessageBox.Show("Usuario eliminado con éxito",
                        "Información",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    LlenarUsuarios();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el usuario",
                        "Atención",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
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

        private void trvUsuarios_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            trvUsuarios.SelectedNode = e.Node;
        }
    }
}
