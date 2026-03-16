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
    }
}
