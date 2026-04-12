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
using TechKMii.Layers.Entities.BCCR;
using TechKMii.Layers.Interfaces;

namespace TechKMii.Layers.UI.Procesos
{
    public partial class frmFacturacion : Form
    {
        private static readonly ILog _myLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");

        IDolarBLL Dolarbll = new DolarBLL();
        IFacturaBLL facturaBLL = new FacturaBLL();
        IClienteBLL clienteBLL = new ClienteBLL();
        IProductoBLL productoBLL = new ProductoBLL();

        private Cliente clienteSeleccionado = null;
        private Producto productoSeleccionado = null;
        private List<FacturaDetalle> listaDetalle = new List<FacturaDetalle>();
        public frmFacturacion()
        {
            InitializeComponent();
        }

        private void frmFacturacion_Load(object sender, EventArgs e)
        {
            try
            {
                StpVentaDolar.Text = "Venta Dolar : " + Dolarbll.GetVentaDolar().ToString("N2");

                CargarCombos();
                GenerarNumeroFactura();
                ConfigurarControlesIniciales();
                ConfigurarMetodoPago();

                DeshabilitarCamposTemporales();
            }
            catch (Exception ex)
            {
                _myLogControlEventos.Error("Error al cargar el formulario de facturación: " + ex.Message);
                MessageBox.Show("Ocurrió un error al cargar el formulario. Por favor, intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarCombos()
        {
            try
            {
                cmbTipoMoneda.Items.Clear();
                cmbTipoMoneda.Items.Add("CRC");
                cmbTipoMoneda.Items.Add("USD");
                cmbTipoMoneda.SelectedIndex = 0;

                cmbEstado.Items.Clear();
                cmbEstado.Items.Add(EstadoFactura.Pendiente);
                cmbEstado.Items.Add(EstadoFactura.Cancelada);
                cmbEstado.Items.Add(EstadoFactura.Eliminada);
                cmbEstado.SelectedItem = EstadoFactura.Pendiente;

                cmbTipoTarjeta.Items.Clear();
                cmbTipoTarjeta.Items.Add(TipoTarjeta.VISA);
                cmbTipoTarjeta.Items.Add(TipoTarjeta.MASTERCARD);
                cmbTipoTarjeta.Items.Add(TipoTarjeta.AMEX);

                cmbBancoTarjeta.Items.Clear();
                cmbBancoTarjeta.Items.Add("BNCR");
                cmbBancoTarjeta.Items.Add("BCR");
                cmbBancoTarjeta.Items.Add("BAC");

                cmbBancoTransferencia.Items.Clear();
                cmbBancoTransferencia.Items.Add("BNCR");
                cmbBancoTransferencia.Items.Add("BCR");
                cmbBancoTransferencia.Items.Add("BAC");

                cmbBancoSINPE.Items.Clear();
                cmbBancoSINPE.Items.Add("BNCR");
                cmbBancoSINPE.Items.Add("BCR");
                cmbBancoSINPE.Items.Add("BAC");
            }
            catch (Exception ex)
            {
                _myLogControlEventos.Error("Error al cargar los combos en el formulario de facturación: " + ex.Message);
                MessageBox.Show("Ocurrió un error al cargar los combos. Por favor, intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenerarNumeroFactura()
        {
            txtNoFactura.Text = "FAC-" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
        }
        private void ConfigurarControlesIniciales()
        {
            txtNoFactura.ReadOnly = true;
            txtCorreo.ReadOnly = true;
            txtPrecio.ReadOnly = true;
            txtCantidad.ReadOnly = true;
        }

        private void tlpAgrupamiento_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                string filtro = txtCliente.Text.Trim();

                if (string.IsNullOrEmpty(filtro))
                {
                    MessageBox.Show("Digite el nombre del cliente a buscar.");
                    return;
                }

                Cliente cliente = clienteBLL.GetByIdentificacion(filtro);

                if (cliente == null)
                {
                    MessageBox.Show("No se encontró el cliente.");
                    return;
                }

                clienteSeleccionado = cliente;
                txtCliente.Text = cliente.Nombre + " " + cliente.Apellidos;
                txtCorreo.Text = cliente.Correo;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar cliente. " + ex.Message);
            }
        }

        private void ConfigurarMetodoPago()
        {
            txtNumeroTarjeta.Text = "";
            cmbBancoTarjeta.SelectedIndex = -1;
            cmbTipoTarjeta.SelectedIndex = -1;

            txtNumeroTransfer.Text = "";
            cmbBancoTransferencia.SelectedIndex = -1;

            txtNumeroSinpe.Text = "";
            cmbBancoSINPE.SelectedIndex = -1;

            txtNumeroTarjeta.Enabled = false;
            cmbBancoTarjeta.Enabled = false;
            cmbTipoTarjeta.Enabled = false;

            txtNumeroTransfer.Enabled = false;
            cmbBancoTransferencia.Enabled = false;

            txtNumeroSinpe.Enabled = false;
            cmbBancoSINPE.Enabled = false;

            if (rdbTarjeta.Checked)
            {
                txtNumeroTarjeta.Enabled = true;
                cmbBancoTarjeta.Enabled = true;
                cmbTipoTarjeta.Enabled = true;
            }
            else if (rdbTransferencia.Checked)
            {
                txtNumeroTransfer.Enabled = true;
                cmbBancoTransferencia.Enabled = true;
            }
            else if (rdbSINPE.Checked)
            {
                txtNumeroSinpe.Enabled = true;
                cmbBancoSINPE.Enabled = true;
            }
        }

        private void btnEliminarCliente_Click(object sender, EventArgs e)
        {
            clienteSeleccionado = null;
            txtCliente.Text = "";
            txtCorreo.Text = "";
            txtCliente.Tag = null;
        }

        private void rdbTarjeta_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbTarjeta.Checked)
            {
                ConfigurarMetodoPago();
            }
        }

        private void rdbTransferencia_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbTransferencia.Checked)
            {
                ConfigurarMetodoPago();
            }
        }

        private void rdbSINPE_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbSINPE.Checked)
            {
                ConfigurarMetodoPago();
            }
        }

        private void DeshabilitarCamposTemporales()
        {
            tspNuevo.Enabled = false;
            tspGenerarFactura.Enabled = false;
            tspEnviarPorCorreo.Enabled = false;
            tspVistaPDF.Enabled = false;

            txtFirma.Enabled = false;
            btnLimpiarFirma.Enabled = false;

            txtSubtotalCRC.Enabled = false;
            txtIVACRC.Enabled = false;
            txtTotalCRC.Enabled = false;
            txtTotalUSD.Enabled = false;
        }

        private void tspSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtProducto.Text))
                {
                    MessageBox.Show("Digite el código del producto.");
                    return;
                }

                int productoId;
                if (!int.TryParse(txtProducto.Text.Trim(), out productoId))
                {
                    MessageBox.Show("El código del producto debe ser numérico.");
                    return;
                }

                Producto producto = await productoBLL.GetById(productoId);

                if (producto == null)
                {
                    MessageBox.Show("No se encontró el producto.");
                    return;
                }

                productoSeleccionado = producto;

                txtProducto.Text = producto.Nombre;
                txtPrecio.Text = producto.Precio.ToString("N2");
                txtCantidad.Text = producto.CantidadStock.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar producto. " + ex.Message);
            }
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                if (productoSeleccionado == null)
                {
                    MessageBox.Show("Debe seleccionar un producto.");
                    return;
                }

                int cantidad;
                if (!int.TryParse(txtCantidad.Text, out cantidad) || cantidad <= 0)
                {
                    MessageBox.Show("Cantidad inválida.");
                    return;
                }

                if (cantidad > productoSeleccionado.CantidadStock)
                {
                    MessageBox.Show("No hay suficiente stock.");
                    return;
                }

                FacturaDetalle detalle = new FacturaDetalle
                {
                    Producto = productoSeleccionado,
                    Cantidad = cantidad,
                    Precio = productoSeleccionado.Precio
                };

                listaDetalle.Add(detalle);

                CargarGrid();

                productoSeleccionado = null;
                txtProducto.Text = "";
                txtPrecio.Text = "";
                txtCantidad.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar producto. " + ex.Message);
            }
        }

        private void CargarGrid()
        {
            dgvProductos.DataSource = null;

            dgvProductos.DataSource = listaDetalle.Select(x => new
            {
                Codigo = x.Producto.ProductoID,
                Descripcion = x.Producto.Nombre,
                Cantidad = x.Cantidad,
                Precio = x.Precio,
                Total = x.Cantidad * x.Precio
            }).ToList();
        }

        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            productoSeleccionado = null;
            txtProducto.Text = "";
            txtPrecio.Text = "";
            txtCantidad.Text = "";
        }
    }
}
