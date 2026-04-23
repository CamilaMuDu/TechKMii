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
using TechKMii.Layers.Entities;
using TechKMii.Layers.UI;
using TechKMii.Layers.UI.Login;
using TechKMii.Layers.UI.Mantenimientos;
using TechKMii.Layers.UI.Procesos;
using TechKMii.Layers.UI.Reportes;
using TechKMii.Properties;
using UTN.Winform.Electronics.Extensions;

namespace TechKMii
{
    public partial class frmMenúPrincipal : Form
    {
        private static readonly ILog _myLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");

        public bool CerrarSesion { get; set; } = false;
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

                Seguridad();
            }
            catch (Exception er)
            {
                string msg = "";
                _myLogControlEventos.ErrorFormat("Error {0}", msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod()));
                MessageBox.Show("Se ha producido el siguiente error: " + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Seguridad()
        {
            List<string> menus = new List<string>();

            foreach (ToolStripItem opcionMenu in this.menuStrip1.Items)
            {
                opcionMenu.Enabled = false;

                if (opcionMenu is ToolStripMenuItem menuPadre)
                {
                    foreach (ToolStripItem subItem in menuPadre.DropDownItems)
                    {
                        subItem.Enabled = false;
                    }
                }
            }

            menus.Add("acercaDeToolStripMenuItem");
            menus.Add("administraciónToolStripMenuItem"); 

            // Rol Administrador
            if (Settings.Default.Rol.Equals("1"))
            {
                menus.Add("mantenimientosToolStripMenuItem");
                menus.Add("procesosToolStripMenuItem");
                menus.Add("reportesToolStripMenuItem");
            }

            // Rol Vendedor
            if (Settings.Default.Rol.Equals("2"))
            {
                menus.Add("mantenimientosToolStripMenuItem");
                menus.Add("procesosToolStripMenuItem");
                menus.Add("reportesToolStripMenuItem");
            }

            // Rol Reportes
            if (Settings.Default.Rol.Equals("3"))
            {
                menus.Add("reportesToolStripMenuItem");
            }

            foreach (ToolStripItem opcionMenu in this.menuStrip1.Items)
            {
                bool menuPermitido = menus.Exists(p =>
                    p.Equals(opcionMenu.Name, StringComparison.InvariantCultureIgnoreCase));

                opcionMenu.Enabled = menuPermitido;

                if (opcionMenu is ToolStripMenuItem menuPadre)
                {
                    foreach (ToolStripItem subItem in menuPadre.DropDownItems)
                    {
                        subItem.Enabled = menuPermitido;
                    }
                }
            }

            if (administraciónToolStripMenuItem.Enabled)
            {
                cerrarSesiónToolStripMenuItem.Enabled = true;
                usuariosToolStripMenuItem.Enabled = Settings.Default.Rol.Equals("1");
            }
        }

        private void facturacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFacturacion facturacion = new frmFacturacion();

            Usuario usuario = new Usuario
            {
                UsuarioID = Settings.Default.Usuario,
                Nombre = Settings.Default.Nombre
            };

            facturacion.SetUsuario(usuario);

            facturacion.ShowDialog();

        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAcercaDe frmAcerca = new frmAcercaDe();
            frmAcerca.ShowDialog();
        }

        private void inventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInventarioMantenimiento inventario = new frmInventarioMantenimiento();
            inventario.ShowDialog();
        }

        private void reporteDePorductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReporteProducto reporteProducto = new frmReporteProducto();
            reporteProducto.ShowDialog();
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult r = MessageBox.Show(
                    "¿Desea cerrar la sesión actual?",
                    "Confirmación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (r == DialogResult.No)
                    return;

                Settings.Default.Usuario = string.Empty;
                Settings.Default.Nombre = string.Empty;
                Settings.Default.Rol = string.Empty;
                Settings.Default.Save();

                _myLogControlEventos.Info("El usuario cerró sesión.");

                CerrarSesion = true;
                this.Close();
            }
            catch (Exception er)
            {
                string msg = "";
                _myLogControlEventos.ErrorFormat("Error {0}", msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod()));
                MessageBox.Show("Se ha producido el siguiente error: " + er.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void reporteDeClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReporteCliente reporteCliente = new frmReporteCliente();
            reporteCliente.ShowDialog();
        }

        private void reporteDeVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReporteGrafico ReporteGrafico = new frmReporteGrafico();
            ReporteGrafico.ShowDialog();
        }

        private void reporteDeFacturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReporteFacturas reporteFacturas = new frmReporteFacturas();
            reporteFacturas.ShowDialog();
        }
    }
}
