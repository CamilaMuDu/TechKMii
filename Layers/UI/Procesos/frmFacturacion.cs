using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
using TechKMii.Layers.Entities.BCCR;
using TechKMii.Layers.Interfaces;
using UTN.Winform.Electronics.Extensions;

namespace TechKMii.Layers.UI.Procesos
{
    public partial class frmFacturacion : Form
    {
        private static readonly ILog _myLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");

        IDolarBLL Dolarbll = new DolarBLL();
        IFacturaBLL facturaBLL = new FacturaBLL();
        IClienteBLL clienteBLL = new ClienteBLL();
        IProductoBLL productoBLL = new ProductoBLL();
        IFacturaDetalleBLL facturaDetalleBLL = new FacturaDetalleBLL();

        private Cliente clienteSeleccionado = null;
        private Producto productoSeleccionado = null;
        private Usuario usuarioActual = null;   
        private List<FacturaDetalle> listaDetalle = new List<FacturaDetalle>();

        private bool dibujando = false;
        private Point puntoAnterior;
        private Bitmap bitmapFirma;
        private Graphics graphicsFirma;

        public frmFacturacion()
        {
            InitializeComponent();
        }

        public void SetUsuario(Usuario usuario)
        {
            usuarioActual = usuario;
        }   

        private void frmFacturacion_Load(object sender, EventArgs e)
        {
            try
            {
                // Obtener y mostrar el precio del dólar
                StpVentaDolar.Text = "Venta Dolar : " + Dolarbll.GetVentaDolar().ToString("N2");
                if (usuarioActual != null)
                {
                    txtUsuario.Text = usuarioActual.Nombre; 
                }

                CargarCombos();
                GenerarNumeroFactura();
                ConfigurarControlesIniciales();
                ConfigurarMetodoPago();
                InicializarAreaFirma();
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

        private void InicializarAreaFirma()
        {
            bitmapFirma = new Bitmap(ptbFirma.Width, ptbFirma.Height);
            graphicsFirma = Graphics.FromImage(bitmapFirma);
            graphicsFirma.Clear(Color.White);

            ptbFirma.Image = bitmapFirma;
        }

        private void picFirma_MouseDown(object sender, MouseEventArgs e)
        {
            dibujando = true;
            puntoAnterior = e.Location;
        }
        private void picFirma_MouseMove(object sender, MouseEventArgs e)
        {
            if (dibujando && graphicsFirma != null)
            {
                graphicsFirma.DrawLine(Pens.Black, puntoAnterior, e.Location);
                puntoAnterior = e.Location;
                ptbFirma.Invalidate();
            }
        }
        private void picFirma_MouseUp(object sender, MouseEventArgs e)
        {
            dibujando = false;
        }

        private byte[] ObtenerFirmaComoBytes()
        {
            if (bitmapFirma == null)
                return null;

            using (MemoryStream ms = new MemoryStream())
            {
                bitmapFirma.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }
        //fin de los metodos 

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
                cmbBancoTarjeta.Items.Add("BN");
                cmbBancoTarjeta.Items.Add("BCR");
                cmbBancoTarjeta.Items.Add("BAC");

                cmbBancoTransferencia.Items.Clear();
                cmbBancoTransferencia.Items.Add("BN");
                cmbBancoTransferencia.Items.Add("BCR");
                cmbBancoTransferencia.Items.Add("BAC");

                cmbBancoSINPE.Items.Clear();
                cmbBancoSINPE.Items.Add("BN");
                cmbBancoSINPE.Items.Add("BCR");
                cmbBancoSINPE.Items.Add("BAC");
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
            txtUsuario.ReadOnly = true;
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
            catch (Exception er)
            {
                string msg = "";
                _myLogControlEventos.ErrorFormat("Error {0}",
                    msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod()));

                MessageBox.Show("Se ha producido el siguiente error: " + er.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            catch (Exception er)
            {
                string msg = "";
                _myLogControlEventos.ErrorFormat("Error {0}",
                    msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod()));

                MessageBox.Show("Se ha producido el siguiente error: " + er.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            catch (Exception er)
            {
                string msg = "";
                _myLogControlEventos.ErrorFormat("Error {0}",
                    msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod()));

                MessageBox.Show("Se ha producido el siguiente error: " + er.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void grbFacturacion_Enter(object sender, EventArgs e)
        {

        }

        private void btnLimpiarFirma_Click(object sender, EventArgs e)
        {
           InicializarAreaFirma();
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
            catch (Exception er)
            {
                string msg = "";
                _myLogControlEventos.ErrorFormat("Error {0}",
                    msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod()));

                MessageBox.Show("Se ha producido el siguiente error: " + er.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tspGenerarFactura_Click(object sender, EventArgs e)
        {
            try
            {
                if (clienteSeleccionado == null)
                {
                    MessageBox.Show("Debe seleccionar un cliente.");
                    return;
                }

                if (usuarioActual == null)
                {
                    MessageBox.Show("No se encontró el usuario actual.");
                    return;
                }               

                if (listaDetalle.Count == 0)
                {
                    MessageBox.Show("Debe agregar un producto.");
                    return;
                }

                if (!rdbTarjeta.Checked && !rdbTransferencia.Checked && !rdbSINPE.Checked)
                {
                    MessageBox.Show("Debe seleccionar un método de pago.");
                    return;
                }

                TipoMetodoPago metodoPago;

                if (rdbTarjeta.Checked)
                {
                    if (string.IsNullOrWhiteSpace(txtNumeroTarjeta.Text))
                    {
                        MessageBox.Show("Debe digitar el número de tarjeta.");
                        return;
                    }

                    if (cmbBancoTarjeta.SelectedIndex == -1)
                    {
                        MessageBox.Show("Debe seleccionar el banco de la tarjeta.");
                        return;
                    }

                    if (cmbTipoTarjeta.SelectedIndex == -1)
                    {
                        MessageBox.Show("Debe seleccionar el tipo de tarjeta.");
                        return;
                    }

                    metodoPago = TipoMetodoPago.TarjetaCredito;
                }
                else if (rdbTransferencia.Checked)
                {
                    if (string.IsNullOrWhiteSpace(txtNumeroTransfer.Text))
                    {
                        MessageBox.Show("Debe digitar el número de transferencia.");
                        return;
                    }

                    if (cmbBancoTransferencia.SelectedIndex == -1)
                    {
                        MessageBox.Show("Debe seleccionar el banco de la transferencia.");
                        return;
                    }

                    metodoPago = TipoMetodoPago.Transferencia;
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(txtNumeroSinpe.Text))
                    {
                        MessageBox.Show("Debe digitar el número de SINPE.");
                        return;
                    }

                    if (cmbBancoSINPE.SelectedIndex == -1)
                    {
                        MessageBox.Show("Debe seleccionar el banco de SINPE.");
                        return;
                    }

                    metodoPago = TipoMetodoPago.SINPEMovil;
                }

                double tipoCambio = Dolarbll.GetVentaDolar();

                Factura oFactura = new Factura
                {
                    Cliente = clienteSeleccionado,
                    Usuario = usuarioActual,
                    Fecha = dtpFecha.Value,
                    Subtotal = Convert.ToDouble(txtSubtotalCRC.Text),
                    IVA = Convert.ToDouble(txtIVACRC.Text),
                    TotalCRC = Convert.ToDouble(txtTotalCRC.Text),
                    TotalUSD = Convert.ToDouble(txtTotalUSD.Text),
                    TipoCambio = tipoCambio,
                    MetodoPago = metodoPago,
                    EstadoFactura = (EstadoFactura)cmbEstado.SelectedItem,
                    Firma = ObtenerFirmaComoBytes()
                };
                oFactura.ListaDetalle = listaDetalle;

                if (rdbTarjeta.Checked)
                {
                    oFactura.Banco = cmbBancoTarjeta.SelectedItem.ToString();
                    oFactura.TipoTarjeta = (TipoTarjeta)cmbTipoTarjeta.SelectedItem;
                    oFactura.NumeroTarjeta = txtNumeroTarjeta.Text.Trim();
                }
                else if (rdbTransferencia.Checked)
                {
                    oFactura.Banco = cmbBancoTransferencia.SelectedItem.ToString();
                    oFactura.NumeroTransferencia = txtNumeroTransfer.Text.Trim();
                }
                else if (rdbSINPE.Checked)
                {
                    oFactura.Banco = cmbBancoSINPE.SelectedItem.ToString();
                    oFactura.NumeroSinpe = txtNumeroSinpe.Text.Trim();
                }

                //encabezado
                int facturaId = facturaBLL.Save(oFactura);

                if (facturaId <= 0)
                {
                    MessageBox.Show("No se pudo guardar la factura.");
                    return;
                }

                MessageBox.Show("Factura guardada correctamente.");
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            productoSeleccionado = null;
            txtProducto.Text = "";
            txtPrecio.Text = "";
            txtCantidad.Text = "";
            txtCantidadStock.Text = "";
        }
    }
}
