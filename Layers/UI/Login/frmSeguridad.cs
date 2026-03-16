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

        }

        private void toolStripBtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
