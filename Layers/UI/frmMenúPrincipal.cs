using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;
using TechKMii.Layers.UI;
using TechKMii.Layers.UI.Login;
using TechKMii.Layers.UI.Mantenimientos;
using TechKMii.Layers.UI.Procesos;
using TechKMii.Properties;
using UTN.Winform.Electronics.Extensions;

namespace TechKMii
{
    public partial class frmMenúPrincipal : Form
    {
        private static readonly ILog _myLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");

        public frmMenúPrincipal()
        {
            InitializeComponent();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSeguridad frmSeguridad = new frmSeguridad();
            frmSeguridad.ShowDialog();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmClienteMantenimiento cliente = new frmClienteMantenimiento();
            cliente.ShowDialog();
        }

        private void marcaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMarcaMantenimiento marca = new frmMarcaMantenimiento();
            marca.ShowDialog();
        }

        private void productoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProductoMantenimiento producto = new frmProductoMantenimiento();
            producto.ShowDialog();
        }

        private void proveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProveedorMantenimiento proveedor = new frmProveedorMantenimiento();
            proveedor.ShowDialog();
        }

        private void tipoDeDispositivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTipoDispositivoMantenimiento tipoDispositivo = new frmTipoDispositivoMantenimiento();
            tipoDispositivo.ShowDialog();   
        }

        private void frmMenúPrincipal_Load(object sender, EventArgs e)
        {
            try
            {
                Utils.CultureInfo();
                this.Text = ConfigurationManager.AppSettings["TechKMii"] + " " + Application.ProductName + " Versión:  " + Application.ProductVersion;
                toolStripStatusLabel1.Text = "Usuario Conectado: " + Settings.Default.Usuario + "/" + Settings.Default.Nombre;
                if (!Directory.Exists(@"C:\temp"))
                    Directory.CreateDirectory(@"C:\temp");
                _myLogControlEventos.InfoFormat("Conectado al Form Principal");
                // Activar Seguridad
                //Seguridad();
            }
            catch (Exception er)
            {
                string msg = "";
                _myLogControlEventos.ErrorFormat("Error {0}", msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod()));
                MessageBox.Show("Se ha producido el siguiente error: " + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void Seguridad()
        //{
        //    List<string> menus = new List<string>();
        //    // Se deshabilita TODO primero
        //    foreach (ToolStripItem opcionMenu in this.menuStrip1.Items) //para cada opción de la barra de menú
        //    {
        //        // deshabita todos !
        //        ((ToolStripItem)(opcionMenu)).Enabled = false;
        //    }
        //    // Tabla Rol
        //    // IdRol DescripcionRol
        //    // 1   	Administrador
        //    // 2   	Vendedor
        //    // 3   	Reportes
        //    // Siempre permitir el MENU Acercade para todos los usuarios y salir si se requiere 
        //    menus.Add("toolStripMenuItemAcercaDe");
        //   // Recordemos que los datos están en el usuario o bien son modificados en el Settings para mejor acceso al sistema
        //    // Admin
        //    if (Settings.Default.Rol.Equals("1"))
        //    {
        //        menus.Add("toolStripMenuItemMantenimientos");
        //        menus.Add("toolStripMenuItemProcesos");
        //        menus.Add("reportesToolStripMenuItemReportes");
        //        menus.Add("administracionToolStripMenuItem");
        //    }

        //    // Vendedor
        //    if (Settings.Default.Rol.Equals("2"))
        //    {
        //        menus.Add("toolStripMenuItemMantenimientos");
        //        menus.Add("toolStripMenuItemProcesos");
        //    }

        //    // Reportes
        //    if (Settings.Default.Rol.Equals("3"))
        //    {
        //        menus.Add("reportesToolStripMenuItemReportes");
        ////    }

        //    foreach (ToolStripItem opcionMenu in this.menuStrip1.Items) //para cada opción de la barra de menú
        //    {
        //        if (opcionMenu is ToolStripDropDownButton)
        //        {
        //            foreach (ToolStripMenuItem oToolStripMenuItem in ((ToolStripDropDownButton)opcionMenu).DropDownItems)
        //            {
        //                oToolStripMenuItem.Enabled = menus.Exists(p => p.Equals(oToolStripMenuItem.Name, StringComparison.InvariantCultureIgnoreCase));
        //            }
        //        }
        //        // Habilita solo las opciones que se encuentrna en la lista "menu"
        //        opcionMenu.Enabled = menus.Exists(p => p.Equals(opcionMenu.Name, StringComparison.InvariantCultureIgnoreCase));
        //    }
        //}

        private void facturacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFacturacion facturacion = new frmFacturacion();
            facturacion.ShowDialog();

        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAcercaDe frmAcerca = new frmAcercaDe();
            frmAcerca.ShowDialog();
        }
    }
}
