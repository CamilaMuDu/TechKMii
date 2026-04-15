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
                // Obtener y mostrar el precio del dólar
                StpVentaDolar.Text = "Venta Dolar : " + Dolarbll.GetVentaDolar().ToString("N2");
                
                CargarCombos();
                GenerarNumeroFactura();
                ConfigurarControlesIniciales();
                ConfigurarMetodoPago();

            }
            catch (Exception ex)
            {
                _myLogControlEventos.Error("Error al cargar el formulario de facturación: " + ex.Message);
                MessageBox.Show("Ocurrió un error al cargar el formulario. Por favor, intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //metodo para cargar los combos del formulario
        private void CargarCombos()
        {
            try
            {
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

        //metodo para generar un numero de factura unico
        private void GenerarNumeroFactura()
        {
            txtNoFactura.Text = "FAC-" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
        }
        private void ConfigurarControlesIniciales()
        {
            txtNoFactura.ReadOnly = true;
            txtCorreo.ReadOnly = true;
            txtPrecio.ReadOnly = true;            
            txtCantidadStock.ReadOnly = true;
        }

        private void tlpAgrupamiento_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        //metodo para buscar un cliente por su identificacion
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

        private void tspSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //metodo para buscar un producto por su codigo
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

                if (producto.Estado != EstadoCatalogos.Activo)
                {
                    MessageBox.Show("El producto está inactivo y no puede ser facturado.");
                    return;
                }

                productoSeleccionado = producto;

                txtProducto.Text = producto.Nombre;
                txtPrecio.Text = producto.Precio.ToString("N2");
                txtCantidadStock.Text = producto.CantidadStock.ToString();
                txtCantidad.Text = "";
                txtCantidad.Focus();
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

                double precio = productoSeleccionado.Precio;
                double subtotal = cantidad * precio;
                double iva = subtotal * 0.13;
                double total = subtotal + iva;

                FacturaDetalle detalle = new FacturaDetalle
                {
                    Producto = productoSeleccionado,
                    Cantidad = cantidad,
                    Precio = precio,
                    Subtotal = subtotal,
                    IVA = iva,
                    Total = total
                };

                listaDetalle.Add(detalle);

                CargarGrid();
                CalcularTotales();

                productoSeleccionado = null;
                txtProducto.Text = "";
                txtPrecio.Text = "";
                txtCantidad.Text = "";
                txtCantidadStock.Text = "";
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
                Precio = x.Precio
            }).ToList();
        }

        private void CalcularTotales()
        {
            double subtotal = listaDetalle.Sum(x => x.Subtotal);
            double iva = listaDetalle.Sum(x => x.IVA);
            double totalCRC = listaDetalle.Sum(x => x.Total);

            double tipoCambio = Dolarbll.GetVentaDolar();
            double totalUSD = 0;

            if (tipoCambio > 0)
            {
                totalUSD = totalCRC / tipoCambio;
            }

            txtSubtotalCRC.Text = subtotal.ToString("N2");
            txtIVACRC.Text = iva.ToString("N2");
            txtTotalCRC.Text = totalCRC.ToString("N2");
            txtTotalUSD.Text = totalUSD.ToString("N2");
        }

        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            productoSeleccionado = null;
            txtProducto.Text = "";
            txtPrecio.Text = "";
            txtCantidad.Text = "";
            txtCantidadStock.Text = "";
        }

        private void grbFacturacion_Enter(object sender, EventArgs e)
        {

        }

        private void btnLimpiarFirma_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminarProducto_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (dgvProductos.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Debe seleccionar un producto del detalle.");
                    return;
                }

                int index = dgvProductos.SelectedRows[0].Index;

                if (index >= 0 && index < listaDetalle.Count)
                {
                    listaDetalle.RemoveAt(index);
                }

                CargarGrid();

                CalcularTotales();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar producto. " + ex.Message);
            }
        }
    }
}
