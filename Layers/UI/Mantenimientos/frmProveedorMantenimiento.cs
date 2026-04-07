using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;
using TechKMii.Layers.BLL;
using TechKMii.Layers.Entities;
using TechKMii.Layers.Interfaces;

namespace TechKMii.Layers.UI.Mantenimientos
{
    public partial class frmProveedorMantenimiento : Form
    {
        private static readonly ILog _myLogControlEventos = LogManager.GetLogger("MyControlEventos");
        IProveedorBLL proveedorBLL = new ProveedorBLL();
        Proveedor oProveedor = null;
        string msg = "";
        SqlCommand command = new SqlCommand();
        public frmProveedorMantenimiento()
        {
            InitializeComponent();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmProveedorMantenimiento_Load(object sender, EventArgs e)
        {

        }
    }
}
