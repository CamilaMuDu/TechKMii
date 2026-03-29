using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TechKMii.Layers.BLL;
using TechKMii.Layers.DAL;
using TechKMii.Layers.Entities;
using TechKMii.Layers.Interfaces;
using UTN.Winform.Electronics.Extensions;

namespace TechKMii.Layers.UI.Mantenimientos
{
    public partial class frmClienteMantenimiento : Form
    {
        private static readonly ILog _myLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");

        IProvinciaBLL provinciaBLL = new BLLProvincia();
        Provincia provincia = new Provincia();

        public frmClienteMantenimiento()
        {
            InitializeComponent();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmClienteMantenimiento_Load(object sender, EventArgs e)
        {

            try
            {
                List<Provincia> listaP = new List<Provincia>();
                listaP = provinciaBLL.GetProvinciaFromInternet();
                cmbProvincia.DataSource = listaP;
                cmbProvincia.DisplayMember = "Descripcion";
                cmbProvincia.SelectedIndex = -1;
            }
            catch (Exception er)
            {
                string msg = "";
                _myLogControlEventos.ErrorFormat("Error {0}", msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod()));
                MessageBox.Show("Se ha producido el siguiente error: " + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {

        }
    }
}
