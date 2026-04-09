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
using TechKMii.Layers.BLL;
using TechKMii.Layers.Entities;
using TechKMii.Layers.Interfaces;

namespace TechKMii.Layers.UI.Mantenimientos.Filtros
{
    public partial class frmProductoFiltro : Form
    {
        private static readonly ILog _myLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");
        public Producto oProducto = null;
        IProductoBLL ProductoBll = new ProductoBLL();
        public frmProductoFiltro()
        {
            InitializeComponent();
        }

        private void frmProductoFiltro_Load(object sender, EventArgs e)
        {

        }

        private void tspSalir_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void tspNuevo_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            dgvBuscar.DataSource = null;
            txtBuscar.Focus();
        }

        private void dgvBuscar_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
