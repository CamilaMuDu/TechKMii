using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TechKMii.Layers.BLL;
using TechKMii.Layers.Entities.BCCR;
using TechKMii.Layers.Interfaces;

namespace TechKMii.Layers.UI.Procesos
{
    public partial class frmFacturacion : Form
    {
        IDolarBLL Dolarbll = new DolarBLL();
        public frmFacturacion()
        {
            InitializeComponent();
        }

        private void frmFacturacion_Load(object sender, EventArgs e)
        {
            StpVentaDolar.Text = "Venta Dolar : " + Dolarbll.GetVentaDolar().ToString("N2"); 
        }

        private void tlpAgrupamiento_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
