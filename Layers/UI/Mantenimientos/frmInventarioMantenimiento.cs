using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
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
    public partial class frmInventarioMantenimiento : Form
    {
        private static readonly ILog _myLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");
        SqlCommand command = new SqlCommand();
        string msg = "";

        IInventarioBLL invertarioBLL = new InventarioBLL();
        Inventario oInventario = null;
        IProductoBLL productoBLL = new ProductoBLL();
        Producto oProducto = null;
        private int idProductoSeleccionado = 0;


        public frmInventarioMantenimiento()
        {
            InitializeComponent();
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmInventarioMantenimiento_Load(object sender, EventArgs e)
        {
            try
            {
                cmbTipoMovimiento.DataSource = Enum.GetValues(typeof(TipoEntradaSalida));
                cmbTipoMovimiento.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbTipoMovimiento.SelectedIndex = -1;

                txtStockActual.ReadOnly = true;
                nudCantidad.Value = 0;
                idProductoSeleccionado = 0;

                CargarGrid();
            }
            catch (SqlException er)
            {
                _myLogControlEventos.ErrorFormat("Error {0}",
                    msg.ToExceptionDetail(MethodBase.GetCurrentMethod(), er, command));
                throw new CustomException(msg.ToSqlServerDetailError(er));
            }
            catch (Exception er)
            {
                msg = msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod());
                _myLogControlEventos.ErrorFormat("Error {0}", msg);
                throw;
            }
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtProducto.Text))
                {
                    MessageBox.Show("Digite el código del producto.");
                    return;
                }

                string filtro = txtProducto.Text.Trim();

                var listaProductos = await productoBLL.GetByFilter(filtro);

                if (listaProductos == null || !listaProductos.Any())
                {
                    MessageBox.Show("No se encontró ningún producto con ese código.");
                    txtProducto.Clear();
                    txtStockActual.Clear();
                    idProductoSeleccionado = 0;
                    oProducto = null;
                    return;
                }

                int codigoDigitado;
                Producto productoEncontrado = null;

                if (int.TryParse(filtro, out codigoDigitado))
                {
                    productoEncontrado = listaProductos
                        .FirstOrDefault(p => p.ProductoID == codigoDigitado && p.Estado == EstadoCatalogos.Activo);
                }

                if (productoEncontrado == null)
                {
                    productoEncontrado = listaProductos
                        .FirstOrDefault(p => p.Estado == EstadoCatalogos.Activo);
                }

                if (productoEncontrado == null)
                {
                    MessageBox.Show("No se encontró un producto activo con ese código.");
                    txtProducto.Clear();
                    txtStockActual.Clear();
                    idProductoSeleccionado = 0;
                    oProducto = null;
                    return;
                }

                oProducto = productoEncontrado;
                idProductoSeleccionado = productoEncontrado.ProductoID;

                txtProducto.Text = productoEncontrado.Nombre;
                txtStockActual.Text = productoEncontrado.CantidadStock.ToString();
            }
            catch (SqlException er)
            {
                _myLogControlEventos.ErrorFormat("Error {0}",
                    msg.ToExceptionDetail(MethodBase.GetCurrentMethod(), er, command));
                throw new CustomException(msg.ToSqlServerDetailError(er));
            }
            catch (Exception er)
            {
                msg = msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod());
                _myLogControlEventos.ErrorFormat("Error {0}", msg);
                throw;
            }
        }
        private void Limpiar()
        {
            txtProducto.Clear();
            txtStockActual.Clear();
            txtMotivo.Clear();
            nudCantidad.Value = 0;
            cmbTipoMovimiento.SelectedIndex = 0;
            dtpFecha.Value = DateTime.Now;

            idProductoSeleccionado = 0;
            oProducto = null;
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                Limpiar();
            }
            catch (SqlException er)
            {
                _myLogControlEventos.ErrorFormat("Error {0}",
                    msg.ToExceptionDetail(MethodBase.GetCurrentMethod(), er, command));
                throw new CustomException(msg.ToSqlServerDetailError(er));
            }
            catch (Exception er)
            {
                msg = msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod());
                _myLogControlEventos.ErrorFormat("Error {0}", msg);
                throw;
            }
        }

        private async void btnGuardarMovimiento_Click(object sender, EventArgs e)
        {
            try
            {
                if (oProducto == null)
                {
                    MessageBox.Show("Debe buscar un producto primero.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtMotivo.Text))
                {
                    MessageBox.Show("Debe ingresar un motivo.");
                    return;
                }

                if (nudCantidad.Value <= 0)
                {
                    MessageBox.Show("La cantidad debe ser mayor a 0.");
                    return;
                }

                TipoEntradaSalida movimiento = (TipoEntradaSalida)cmbTipoMovimiento.SelectedItem;
                int cantidad = Convert.ToInt32(nudCantidad.Value);
                int stockActual = oProducto.CantidadStock;
                int nuevoStock = stockActual;

                if (movimiento == TipoEntradaSalida.Salida)
                {
                    if (cantidad > stockActual)
                    {
                        MessageBox.Show("No hay suficiente stock.");
                        return;
                    }

                    nuevoStock = stockActual - cantidad;
                }
                else
                {
                    nuevoStock = stockActual + cantidad;
                }

                Inventario inv = new Inventario
                {
                    Producto = new Producto { ProductoID = oProducto.ProductoID },
                    TipoEntradaSalida = movimiento,
                    Fecha = dtpFecha.Value,
                    Observaciones = txtMotivo.Text,
                    Estado = EstadoCatalogos.Activo
                };

                await invertarioBLL.Save(inv);

                //manejo del stock del producto
                oProducto.CantidadStock = nuevoStock;
                await productoBLL.Update(oProducto);

                MessageBox.Show("Movimiento guardado correctamente.");

                txtStockActual.Text = nuevoStock.ToString();
                CargarGrid();
                Limpiar();
            }
            catch (SqlException er)
            {
                _myLogControlEventos.ErrorFormat("Error {0}",
                    msg.ToExceptionDetail(MethodBase.GetCurrentMethod(), er, command));
                throw new CustomException(msg.ToSqlServerDetailError(er));
            }
            catch (Exception er)
            {
                msg = msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod());
                _myLogControlEventos.ErrorFormat("Error {0}", msg);
                throw;
            }
        }

        private async void CargarGrid()
        {
            try
            {
                dgvDatosInventario.DataSource = null;
                dgvDatosInventario.DataSource = (await invertarioBLL.GetAll()).ToList();

                dgvDatosInventario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvDatosInventario.ReadOnly = true;
                dgvDatosInventario.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                //moviemirntos 
                foreach (DataGridViewRow row in dgvDatosInventario.Rows)
                {
                    if (row.Cells["TipoEntradaSalida"].Value != null)
                    {
                        string tipo = row.Cells["TipoEntradaSalida"].Value.ToString();

                        if (tipo == "Salida")
                        {
                            row.Cells["TipoEntradaSalida"].Style.ForeColor = Color.Red;
                            row.Cells["TipoEntradaSalida"].Style.Font = new Font("Arial", 10, FontStyle.Bold);
                        }
                        else if (tipo == "Entrada")
                        {
                            row.Cells["TipoEntradaSalida"].Style.ForeColor = Color.Green;
                            row.Cells["TipoEntradaSalida"].Style.Font = new Font("Arial", 10, FontStyle.Bold);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
