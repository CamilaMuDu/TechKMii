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

namespace TechKMii.Layers.UI.Login
{
    public partial class frmLogin : Form
    {
        private static readonly ILog _myLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");
        private int contador = 0;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            frmMenúPrincipal frmMenúPrincipal = new frmMenúPrincipal();
            frmMenúPrincipal.Show();

            epError.Clear();
            try
            {

            }
            catch (Exception er)
            {
                
            }
        }
    }
}
