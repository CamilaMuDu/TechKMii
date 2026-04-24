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

        private int inventarioIdActual = 0;
        private bool editando = false;


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
            cmbTipoMovimiento.SelectedIndex = -1;
            dtpFecha.Value = DateTime.Now;

            idProductoSeleccionado = 0;
            inventarioIdActual = 0;
            editando = false;
            oProducto = null;
            oInventario = null;

            txtProducto.ReadOnly = false;
            btnBuscar.Enabled = true;
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

                if (cmbTipoMovimiento.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar un tipo de movimiento.");
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

                TipoEntradaSalida movimientoNuevo = (TipoEntradaSalida)cmbTipoMovimiento.SelectedItem;
                int cantidadNueva = Convert.ToInt32(nudCantidad.Value);

                Producto productoActualizado = await productoBLL.GetById(oProducto.ProductoID);

                if (productoActualizado == null)
                {
                    MessageBox.Show("No se encontró el producto.");
                    return;
                }

                int stockBase = productoActualizado.CantidadStock;

                if (editando)
                {
                    if (oInventario.TipoEntradaSalida == TipoEntradaSalida.Entrada)
                        stockBase -= oInventario.Cantidad;
                    else
                        stockBase += oInventario.Cantidad;
                }

                int nuevoStock = stockBase;

                if (movimientoNuevo == TipoEntradaSalida.Salida)
                {
                    if (cantidadNueva > stockBase)
                    {
                        MessageBox.Show("No hay suficiente stock.");
                        return;
                    }

                    nuevoStock = stockBase - cantidadNueva;
                }
                else
                {
                    nuevoStock = stockBase + cantidadNueva;
                }

                if (!editando)
                {
                    Inventario inv = new Inventario
                    {
                        Producto = new Producto { ProductoID = oProducto.ProductoID },
                        TipoEntradaSalida = movimientoNuevo,
                        Fecha = dtpFecha.Value,
                        Observaciones = txtMotivo.Text,
                        Estado = EstadoCatalogos.Activo,
                        Cantidad = cantidadNueva
                    };

                    await invertarioBLL.Save(inv);
                    MessageBox.Show("Movimiento guardado correctamente.");
                }
                else
                {
                    Inventario inv = new Inventario
                    {
                        InventarioID = inventarioIdActual,
                        Producto = new Producto { ProductoID = oProducto.ProductoID },
                        TipoEntradaSalida = movimientoNuevo,
                        Fecha = dtpFecha.Value,
                        Observaciones = txtMotivo.Text,
                        Estado = EstadoCatalogos.Activo,
                        Cantidad = cantidadNueva
                    };

                    await invertarioBLL.Update(inv);
                    MessageBox.Show("Movimiento actualizado correctamente.");
                }

                productoActualizado.CantidadStock = nuevoStock;
                await productoBLL.Update(productoActualizado);

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
                var lista = (await invertarioBLL.GetAll()).ToList();

                var datos = lista.Select(x => new
                {
                    x.InventarioID,
                    ProductoID = x.Producto != null ? x.Producto.ProductoID : 0,
                    TipoEntradaSalida = x.TipoEntradaSalida.ToString(),
                    x.Cantidad,
                    x.Fecha,
                    Motivo = x.Observaciones,
                    Estado = x.Estado.ToString()
                }).ToList();

                dgvDatosInventario.DataSource = null;
                dgvDatosInventario.DataSource = datos;

                dgvDatosInventario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvDatosInventario.ReadOnly = true;
                dgvDatosInventario.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvDatosInventario.AllowUserToAddRows = false;
                dgvDatosInventario.AllowUserToDeleteRows = false;
                dgvDatosInventario.DefaultCellStyle.SelectionBackColor = Color.LightBlue;

                if (dgvDatosInventario.Columns["InventarioID"] != null)
                    dgvDatosInventario.Columns["InventarioID"].HeaderText = "ID";

                if (dgvDatosInventario.Columns["ProductoID"] != null)
                    dgvDatosInventario.Columns["ProductoID"].HeaderText = "Producto ID";

                if (dgvDatosInventario.Columns["TipoEntradaSalida"] != null)
                    dgvDatosInventario.Columns["TipoEntradaSalida"].HeaderText = "Movimiento";

                if (dgvDatosInventario.Columns["Cantidad"] != null)
                    dgvDatosInventario.Columns["Cantidad"].HeaderText = "Cantidad";

                if (dgvDatosInventario.Columns["Fecha"] != null)
                    dgvDatosInventario.Columns["Fecha"].HeaderText = "Fecha";

                if (dgvDatosInventario.Columns["Motivo"] != null)
                    dgvDatosInventario.Columns["Motivo"].HeaderText = "Motivo";

                if (dgvDatosInventario.Columns["Estado"] != null)
                    dgvDatosInventario.Columns["Estado"].Visible = false;

                foreach (DataGridViewRow row in dgvDatosInventario.Rows)
                {
                    if (row.Cells["TipoEntradaSalida"].Value != null)
                    {
                        string tipo = row.Cells["TipoEntradaSalida"].Value.ToString();

                        if (tipo == "Salida")
                        {
                            row.Cells["TipoEntradaSalida"].Style.ForeColor = Color.Red;
                            row.Cells["TipoEntradaSalida"].Style.SelectionForeColor = Color.Red;
                            row.Cells["TipoEntradaSalida"].Style.Font = new Font("Arial", 10, FontStyle.Bold);
                        }
                        else if (tipo == "Entrada")
                        {
                            row.Cells["TipoEntradaSalida"].Style.ForeColor = Color.Green;
                            row.Cells["TipoEntradaSalida"].Style.SelectionForeColor = Color.Green;
                            row.Cells["TipoEntradaSalida"].Style.Font = new Font("Arial", 10, FontStyle.Bold);
                        }
                    }
                }
            }
            catch (Exception er)
            {
                msg = msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod());
                _myLogControlEventos.ErrorFormat("Error {0}", msg);
                throw;
            }
        }

        private async void tsbEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!editando || inventarioIdActual == 0)
                {
                    MessageBox.Show("Debe seleccionar una fila del grid para editar.");
                    return;
                }

                if (oProducto == null)
                {
                    MessageBox.Show("No se encontró el producto asociado.");
                    return;
                }

                if (cmbTipoMovimiento.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar un tipo de movimiento.");
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

                TipoEntradaSalida movimientoNuevo = (TipoEntradaSalida)cmbTipoMovimiento.SelectedItem;
                int cantidadNueva = Convert.ToInt32(nudCantidad.Value);

                Producto productoActualizado = await productoBLL.GetById(oProducto.ProductoID);

                if (productoActualizado == null)
                {
                    MessageBox.Show("No se encontró el producto.");
                    return;
                }

                int stockBase = productoActualizado.CantidadStock;

                if (oInventario.TipoEntradaSalida == TipoEntradaSalida.Entrada)
                    stockBase -= oInventario.Cantidad;
                else
                    stockBase += oInventario.Cantidad;

                int nuevoStock = stockBase;

                if (movimientoNuevo == TipoEntradaSalida.Salida)
                {
                    if (cantidadNueva > stockBase)
                    {
                        MessageBox.Show("No hay suficiente stock.");
                        return;
                    }

                    nuevoStock = stockBase - cantidadNueva;
                }
                else
                {
                    nuevoStock = stockBase + cantidadNueva;
                }

                Inventario inv = new Inventario
                {
                    InventarioID = inventarioIdActual,
                    Producto = new Producto { ProductoID = oProducto.ProductoID },
                    TipoEntradaSalida = movimientoNuevo,
                    Fecha = dtpFecha.Value,
                    Observaciones = txtMotivo.Text,
                    Estado = EstadoCatalogos.Activo,
                    Cantidad = cantidadNueva
                };

                await invertarioBLL.Update(inv);

                productoActualizado.CantidadStock = nuevoStock;
                await productoBLL.Update(productoActualizado);

                MessageBox.Show("Movimiento actualizado correctamente.");

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

        private void dgvDatosInventario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void dgvDatosInventario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvDatosInventario.CurrentRow == null)
                    return;

                if (dgvDatosInventario.CurrentRow.Cells["InventarioID"] == null ||
                    dgvDatosInventario.CurrentRow.Cells["InventarioID"].Value == null)
                    return;

                inventarioIdActual = Convert.ToInt32(dgvDatosInventario.CurrentRow.Cells["InventarioID"].Value);

                oInventario = await invertarioBLL.GetById(inventarioIdActual);

                if (oInventario == null)
                {
                    MessageBox.Show("No se encontró el movimiento seleccionado.");
                    return;
                }

                oProducto = await productoBLL.GetById(oInventario.Producto.ProductoID);

                if (oProducto == null)
                {
                    MessageBox.Show("No se encontró el producto asociado.");
                    return;
                }

                idProductoSeleccionado = oProducto.ProductoID;
                editando = true;

                txtProducto.Text = oProducto.Nombre;
                txtStockActual.Text = oProducto.CantidadStock.ToString();
                txtMotivo.Text = oInventario.Observaciones;
                nudCantidad.Value = oInventario.Cantidad;
                dtpFecha.Value = oInventario.Fecha;
                cmbTipoMovimiento.SelectedItem = oInventario.TipoEntradaSalida;

                txtProducto.ReadOnly = true;
                btnBuscar.Enabled = false;
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

        private async void tsbBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDatosInventario.CurrentRow == null)
                {
                    MessageBox.Show("Debe seleccionar un movimiento.");
                    return;
                }

                int id = Convert.ToInt32(dgvDatosInventario.CurrentRow.Cells["InventarioID"].Value);

                var resp = MessageBox.Show(
                    "¿Desea borrar este movimiento?",
                    "Confirmación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (resp != DialogResult.Yes)
                    return;

                bool resultado = await invertarioBLL.Delete(id.ToString());

                if (!resultado)
                {
                    MessageBox.Show("No se pudo borrar el movimiento.");
                    return;
                }

                MessageBox.Show("Movimiento borrado correctamente.");

                CargarGrid();
                Limpiar();
            }
            catch (Exception er)
            {
                msg = msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod());
                _myLogControlEventos.ErrorFormat("Error {0}", msg);
                throw;
            }
        }
    }
}
