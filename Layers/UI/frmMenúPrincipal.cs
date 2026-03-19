using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TechKMii.Layers.UI.Login;
using TechKMii.Layers.UI.Mantenimientos;

namespace TechKMii
{
    public partial class frmMenúPrincipal : Form
    {
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
            frmTipoDispositivo tipoDispositivo = new frmTipoDispositivo();
            tipoDispositivo.ShowDialog();
        }

        private void frmMenúPrincipal_Load(object sender, EventArgs e)
        {

        }
    }
}
