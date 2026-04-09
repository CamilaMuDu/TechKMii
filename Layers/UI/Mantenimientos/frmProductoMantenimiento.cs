using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;
using TechKMii.Layers.BLL;
using TechKMii.Layers.Entities;
using TechKMii.Layers.Interfaces;
using UTN.Winform.Electronics.Extensions;

namespace TechKMii.Layers.UI.Mantenimientos
{
    public partial class frmProductoMantenimiento : Form
    {
        private static readonly ILog _myLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");

        IProductoBLL productoBll = new ProductoBLL();
        Producto producto = null;
        private byte[] fotoBytes = null;
        private int ProductoIdActual = 0;
        public frmProductoMantenimiento()
        {
            InitializeComponent();
        }

        private void frmProductoMantenimiento_Load(object sender, EventArgs e)
        {
            try
            {
                CargarEstado();

                BeginInvoke(new Action(async () =>
                {
                    try
                    {
                        await CargarProductos();
                    }
                    catch (Exception er)
                    {
                        string msg = "";
                        _myLogControlEventos.ErrorFormat("Error {0}",
                            msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod()));

                        MessageBox.Show("Se ha producido el siguiente error: " + er.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }));
            }
            catch (Exception er)
            {
                string msg = "";
                _myLogControlEventos.ErrorFormat("Error {0}",
                    msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod()));

                MessageBox.Show("Se ha producido el siguiente error: " + er.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task CargarProductos()
        {
            var lista = await productoBll.GetAll();

            dgvDatosProducto.DataSource = lista.ToList();
        }
        private void CargarEstado()
        {
            cmbEstado.DataSource = Enum.GetValues(typeof(EstadoCatalogos));
        }
        private async void tspBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDatosProducto.CurrentRow == null)
                    return;

                int id = Convert.ToInt32(dgvDatosProducto.CurrentRow.Cells["ProductoID"].Value);

                var resp = MessageBox.Show("¿Desea eliminar este producto?",
                    "Confirmación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (resp == DialogResult.Yes)
                {
                    await productoBll.Delete(id.ToString());

                    MessageBox.Show("Producto eliminado correctamente",
                        "Información",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    await CargarProductos();
                }
            }
            catch (Exception er)
            {
                string msg = "";
                _myLogControlEventos.ErrorFormat("Error {0}",
                    msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod()));

                MessageBox.Show("Se ha producido el siguiente error: " + er.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                Producto oProducto = new Producto
                {
                    Nombre = txtNombre.Text,
                    Modelo = txtModelo.Text,
                    Precio = Convert.ToDouble(txtPrecio.Text),
                    CantidadStock = Convert.ToInt32(nudCantStock.Value),
                    Color = txtColor.Text,
                    Caracteristicas = txtCaracteristicas.Text,
                    Extras = txtExtras.Text,
                    Estado = (EstadoCatalogos)cmbEstado.SelectedItem,

                    Tipo = new TipoDispositivo
                    {
                        TipoID = (int)cmbTipoDispositivo.SelectedValue
                    },
                    Proveedor = new Proveedor
                    {
                        ProveedorID = (int)cmbProveedor.SelectedValue
                    },
                    Marca = new Marca
                    {
                        MarcaID = (int)cmbMarca.SelectedValue
                    },

                    Fotografia = fotoBytes
                };

                await productoBll.Save(oProducto);

                MessageBox.Show("Producto guardado correctamente");

                await CargarProductos();
            }
            catch (Exception er)
            {
                string msg = "";
                _myLogControlEventos.ErrorFormat("Error {0}",
                    msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod()));

                MessageBox.Show("Se ha producido el siguiente error: " + er.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDatosProducto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvDatosProducto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDatosProducto.CurrentRow == null)
                return;

            Producto p = (Producto)dgvDatosProducto.CurrentRow.DataBoundItem;

            ProductoIdActual = p.ProductoID;

            txtNombre.Text = p.Nombre;
            txtModelo.Text = p.Modelo;
            txtPrecio.Text = p.Precio.ToString();
            txtColor.Text = p.Color;
            txtCaracteristicas.Text = p.Caracteristicas;
            txtExtras.Text = p.Extras;

            nudCantStock.Value = p.CantidadStock;

            cmbTipoDispositivo.SelectedValue = p.Tipo.TipoID;
            cmbProveedor.SelectedValue = p.Proveedor.ProveedorID;
            cmbMarca.SelectedValue = p.Marca.MarcaID;

            cmbEstado.SelectedItem = p.Estado;

            if (p.Fotografia != null)
            {
                using (MemoryStream ms = new MemoryStream(p.Fotografia))
                {
                    pcbFoto.Image = Image.FromStream(ms);
                }
            }
        }

        private void tspSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
