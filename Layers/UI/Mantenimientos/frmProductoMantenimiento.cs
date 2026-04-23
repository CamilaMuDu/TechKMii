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
using TechKMii.Layers.UI.Mantenimientos.Filtros;
using UTN.Winform.Electronics.Extensions;

namespace TechKMii.Layers.UI.Mantenimientos
{
    public partial class frmProductoMantenimiento : Form
    {
        private static readonly ILog _myLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");

        IProductoBLL productoBll = new ProductoBLL();
        Producto producto = null;

        private byte[] fotoBytes = null;
        private byte[] documentoBytes = null;
        private string nombreDocumento = "";
        private int ProductoIdActual = 0;
        private string rutaDocumentoTemporal = "";

        private List<Producto> listaProductos = new List<Producto>();

        ITipoDispositivoBLL tipoDispositivoBLL = new TipoDispositivoBLL();
        IProveedorBLL proveedorBLL = new ProveedorBLL();
        IMarcaBLL marcaBLL = new MarcaBLL();

        public frmProductoMantenimiento()
        {
            InitializeComponent();
        }

        private void frmProductoMantenimiento_Load(object sender, EventArgs e)
        {
            try
            {
                ConfigurarFormulario();
                CargarEstado();

                BeginInvoke(new Action(async () =>
                {
                    await CargarCombos();
                    await CargarProductos();
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
        private Task CargarCombos()
        {
            // combo Tipo Dispositivo
            var listaA = tipoDispositivoBLL.GetAll().ToList();

            cmbTipoDispositivo.DataSource = null;
            cmbTipoDispositivo.DataSource = listaA;
            cmbTipoDispositivo.DisplayMember = "Nombre";
            cmbTipoDispositivo.ValueMember = "TipoID";
            cmbTipoDispositivo.SelectedIndex = -1;

            // combo Proveedor
            var listaB = proveedorBLL.GetAll().ToList();

            cmbProveedor.DataSource = null;
            cmbProveedor.DataSource = listaB;
            cmbProveedor.DisplayMember = "Nombre";
            cmbProveedor.ValueMember = "ProveedorID";
            cmbProveedor.SelectedIndex = -1;

            // combo Marca
            var listaC = marcaBLL.GetAll().ToList();

            cmbMarca.DataSource = null;
            cmbMarca.DataSource = listaC;
            cmbMarca.DisplayMember = "Nombre";
            cmbMarca.ValueMember = "MarcaID";
            cmbMarca.SelectedIndex = -1;

            return Task.CompletedTask;
        }

        private void ConfigurarFormulario()
        {
            dgvDatosProducto.AutoGenerateColumns = false;
            ConfigurarColumnasGrid();

            pcbFoto.SizeMode = PictureBoxSizeMode.Zoom;
            pcbFoto.Image = null;

            nudCantStock.Minimum = 0;
            nudCantStock.Maximum = 100000;

            ProductoIdActual = 0;
            fotoBytes = null;
            documentoBytes = null;
            nombreDocumento = "";

            lblVistaPrevia.Visible = false;
            lblVistaPrevia.ForeColor = Color.Green;
            lblVistaPrevia.Cursor = Cursors.Hand;
        }
        private void ConfigurarColumnasGrid()
        {
            dgvDatosProducto.Columns.Clear();

            dgvDatosProducto.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ProductoID",
                HeaderText = "Producto ID",
                DataPropertyName = "ProductoID",
                Width = 80
            });

            dgvDatosProducto.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Nombre",
                HeaderText = "Nombre",
                DataPropertyName = "Nombre",
                Width = 140
            });

            dgvDatosProducto.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CantidadStock",
                HeaderText = "Stock",
                DataPropertyName = "CantidadStock",
                Width = 70
            });

            dgvDatosProducto.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Proveedor",
                HeaderText = "Proveedor",
                DataPropertyName = "Proveedor",
                Width = 120
            });

            dgvDatosProducto.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Marca",
                HeaderText = "Marca",
                DataPropertyName = "Marca",
                Width = 120
            });

            dgvDatosProducto.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Modelo",
                HeaderText = "Modelo",
                DataPropertyName = "Modelo",
                Width = 120
            });

            dgvDatosProducto.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Precio",
                HeaderText = "Precio",
                DataPropertyName = "Precio",
                Width = 90,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" }
            });

            dgvDatosProducto.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Color",
                HeaderText = "Color",
                DataPropertyName = "Color",
                Width = 90
            });

            dgvDatosProducto.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Estado",
                HeaderText = "Estado",
                DataPropertyName = "Estado",
                Width = 90
            });

            dgvDatosProducto.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDatosProducto.MultiSelect = false;
            dgvDatosProducto.ReadOnly = true;
            dgvDatosProducto.AllowUserToAddRows = false;
            dgvDatosProducto.AllowUserToDeleteRows = false;
        }
        private async Task CargarProductos()
        {
            listaProductos = (await productoBll.GetAll()).ToList();

            var datos = listaProductos.Select(p => new
            {
                p.ProductoID,
                p.Nombre,
                p.CantidadStock,
                Proveedor = p.Proveedor != null ? p.Proveedor.Nombre : "",
                Marca = p.Marca != null ? p.Marca.Nombre : "",
                p.Modelo,
                p.Precio,
                p.Color,
                Estado = p.Estado.ToString()
            }).ToList();

            dgvDatosProducto.DataSource = null;
            dgvDatosProducto.DataSource = datos;
        }
        private void CargarEstado()
        {
            cmbEstado.DataSource = Enum.GetValues(typeof(EstadoCatalogos))
                                      .Cast<EstadoCatalogos>()
                                      .Where(x => x == EstadoCatalogos.Activo || x == EstadoCatalogos.Inactivo)
                                      .ToList();
        }
        private async void tspBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDatosProducto.CurrentRow == null)
                    return;

                int id = Convert.ToInt32(dgvDatosProducto.CurrentRow.Cells["ProductoID"].Value);

                var resp = MessageBox.Show("¿Desea inactivar este producto?",
                    "Confirmación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (resp == DialogResult.Yes)
                {
                    Producto p = listaProductos.FirstOrDefault(x => x.ProductoID == id);

                    if (p == null)
                        return;

                    p.Estado = EstadoCatalogos.Inactivo;

                    await productoBll.Update(p);

                    MessageBox.Show("Producto inactivado correctamente",
                        "Información",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    await CargarProductos();
                    LimpiarFormulario();
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
                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    MessageBox.Show("Debe ingresar el nombre del producto",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNombre.Focus();
                    return;
                }

                if (cmbTipoDispositivo.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar un tipo de dispositivo",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbTipoDispositivo.Focus();
                    return;
                }

                if (cmbProveedor.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar un proveedor",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbProveedor.Focus();
                    return;
                }

                if (cmbMarca.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar una marca",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbMarca.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtModelo.Text))
                {
                    MessageBox.Show("Debe ingresar el modelo",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtModelo.Focus();
                    return;
                }

                if (!double.TryParse(txtPrecio.Text, out double precio) || precio <= 0)
                {
                    MessageBox.Show("Debe ingresar un precio válido mayor a 0",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPrecio.Focus();
                    return;
                }

                if (nudCantStock.Value < 0)
                {
                    MessageBox.Show("La cantidad en stock no puede ser negativa",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtColor.Text))
                {
                    MessageBox.Show("Debe ingresar el color",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtColor.Focus();
                    return;
                }

                if (cmbEstado.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar un estado",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbEstado.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtCodigoIndustria.Text))
                {
                    MessageBox.Show("Debe ingresar el código de industria",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCodigoIndustria.Focus();
                    return;
                }

                if (txtCodigoIndustria.Text.Length > 8)
                {
                    MessageBox.Show("El código no puede tener más de 8 caracteres",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCodigoIndustria.Focus();
                    return;
                }

                if (!txtCodigoIndustria.Text.All(char.IsLetterOrDigit))
                {
                    MessageBox.Show("El código solo puede contener letras y números",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCodigoIndustria.Focus();
                    return;
                }

                if (listaProductos.Any(p => p.CodigoBarras == txtCodigoIndustria.Text))
                {
                    MessageBox.Show("El código de industria ya existe",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCodigoIndustria.Focus();
                    return;
                }

                if (txtCodigoIndustria.Text.Length < 4)
                {
                    MessageBox.Show("El código debe tener al menos 4 caracteres",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (documentoBytes == null || documentoBytes.Length == 0)
                {
                    MessageBox.Show("Debe adjuntar un documento",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Producto oProducto = new Producto
                {
                    Nombre = txtNombre.Text,
                    Modelo = txtModelo.Text,
                    Precio = precio,
                    CantidadStock = Convert.ToInt32(nudCantStock.Value),
                    Color = txtColor.Text,
                    Caracteristicas = txtCaracteristicas.Text,
                    Extras = txtExtras.Text,
                    Estado = (EstadoCatalogos)cmbEstado.SelectedItem,
                    CodigoBarras = txtCodigoIndustria.Text,

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

                    Fotografia = fotoBytes,
                    DocEspecificaciones = documentoBytes
                };

                await productoBll.Save(oProducto);

                MessageBox.Show("Producto guardado correctamente");

                await CargarProductos();

                LimpiarFormulario();
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

        private void dgvDatosProducto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDatosProducto.CurrentRow == null)
                return;

            int id = Convert.ToInt32(dgvDatosProducto.CurrentRow.Cells["ProductoID"].Value);

            Producto p = listaProductos.FirstOrDefault(x => x.ProductoID == id);

            if (p == null)
                return;

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
            txtCodigoIndustria.Text = p.CodigoBarras;

            txtCodigoIndustria.Enabled = false;

            if (p.Fotografia != null)
            {
                using (MemoryStream ms = new MemoryStream(p.Fotografia))
                {
                    pcbFoto.Image = Image.FromStream(ms);
                }
            }
            else
            {
                pcbFoto.Image = null;
            }
        }

        private void tspSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Método para cargar la foto del producto
        private void btnCargarFoto_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog open = new OpenFileDialog())
                {
                    open.Title = "Seleccionar imagen del producto";
                    open.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

                    if (open.ShowDialog() == DialogResult.OK)
                    {
                        // Mostrar imagen en el PictureBox
                        pcbFoto.Image = Image.FromFile(open.FileName);

                        // Convertir a byte 
                        using (MemoryStream ms = new MemoryStream())
                        {
                            pcbFoto.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                            fotoBytes = ms.ToArray();
                        }
                    }
                }
            }
            catch (Exception er)
            {
                string msg = "";
                _myLogControlEventos.ErrorFormat("Error {0}",
                    msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod()));

                MessageBox.Show("No se pudo cargar la imagen: " + er.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void tspEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ProductoIdActual == 0)
                {
                    MessageBox.Show("Debe seleccionar un producto para editar",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }               

                if (listaProductos.Any(p => p.CodigoBarras == txtCodigoIndustria.Text && p.ProductoID != ProductoIdActual))
                {
                    MessageBox.Show("El código ya existe");
                    return;
                }

                if (!double.TryParse(txtPrecio.Text, out double precio))
                {
                    MessageBox.Show("Precio inválido");
                    return;
                }

                Producto oProducto = new Producto
                {
                    ProductoID = ProductoIdActual, 

                    Nombre = txtNombre.Text,
                    Modelo = txtModelo.Text,
                    Precio = precio,
                    CantidadStock = Convert.ToInt32(nudCantStock.Value),
                    Color = txtColor.Text,
                    Caracteristicas = txtCaracteristicas.Text,
                    Extras = txtExtras.Text,
                    Estado = (EstadoCatalogos)cmbEstado.SelectedItem,
                    CodigoBarras = txtCodigoIndustria.Text,


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

                    Fotografia = fotoBytes,
                    DocEspecificaciones = documentoBytes
                };

                txtCodigoIndustria.ReadOnly = true;

                await productoBll.Update(oProducto);

                MessageBox.Show("Producto actualizado correctamente",
                    "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                await CargarProductos();   
                
                LimpiarFormulario();
            }
            catch (Exception er)
            {
                string msg = "";
                _myLogControlEventos.ErrorFormat("Error {0}",
                    msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod()));

                MessageBox.Show("Error: " + er.Message);
            }
        }

        //metodo para adjuntar documento de especificaciones
        private void btnAdjuntarDocumento_Click_1(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog open = new OpenFileDialog())
                {
                    open.Title = "Seleccionar documento";
                    open.Filter = "Documentos|*.pdf;*.doc;*.docx;*.xls;*.xlsx;*.txt;*.csv;*.rtf|Todos los archivos|*.*";

                    if (open.ShowDialog() == DialogResult.OK)
                    {
                        documentoBytes = File.ReadAllBytes(open.FileName);
                        nombreDocumento = Path.GetFileName(open.FileName);
                        rutaDocumentoTemporal = open.FileName;

                        lblVistaPrevia.Text = "Vista Previa";
                        lblVistaPrevia.ForeColor = Color.Green;
                        lblVistaPrevia.Visible = true;

                        MessageBox.Show($"Se agregó el documento '{nombreDocumento}' correctamente",
                            "Documento cargado",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception er)
            {
                string msg = "";
                _myLogControlEventos.ErrorFormat("Error {0}",
                    msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod()));

                MessageBox.Show("No se pudo cargar el documento: " + er.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblVistaPrevia_Click(object sender, EventArgs e)
        {
            try
            {
                if (documentoBytes == null || documentoBytes.Length == 0)
                {
                    MessageBox.Show("No hay documento adjunto para abrir.",
                        "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string extension = Path.GetExtension(nombreDocumento);

                if (string.IsNullOrWhiteSpace(extension))
                    extension = ".tmp";

                string rutaTemporal = Path.Combine(
                    Path.GetTempPath(),
                    Guid.NewGuid().ToString() + extension
                );

                File.WriteAllBytes(rutaTemporal, documentoBytes);

                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                {
                    FileName = rutaTemporal,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo abrir el documento: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarFormulario()
        {
            ProductoIdActual = 0;
            producto = null;

            fotoBytes = null;
            documentoBytes = null;
            nombreDocumento = "";
            rutaDocumentoTemporal = "";

            txtNombre.Clear();
            txtModelo.Clear();
            txtPrecio.Clear();
            txtColor.Clear();
            txtCaracteristicas.Clear();
            txtExtras.Clear();
            txtCodigoIndustria.Clear();

            nudCantStock.Value = 0;

            cmbTipoDispositivo.SelectedIndex = -1;
            cmbProveedor.SelectedIndex = -1;
            cmbMarca.SelectedIndex = -1;

            txtCodigoIndustria.Enabled = true;

            if (cmbEstado.Items.Count > 0)
                cmbEstado.SelectedItem = EstadoCatalogos.Activo;
            else
                cmbEstado.SelectedIndex = -1;

            pcbFoto.Image = null;

            lblVistaPrevia.Visible = false;
            lblVistaPrevia.Text = "Vista Previa";
        }

        private void tspNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                LimpiarFormulario();
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


        private void tspBuscarProduto_Click(object sender, EventArgs e)
        {
            try
            {
                using (frmProductoFiltro frm = new frmProductoFiltro())
                {
                    var result = frm.ShowDialog();

                    if (result == DialogResult.OK && frm.oProducto != null)
                    {
                        CargarProductoSeleccionado(frm.oProducto);
                    }
                }
            }
            catch (Exception er)
            {
                string msg = "";
                _myLogControlEventos.ErrorFormat("Error {0}",
                    msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod()));

                MessageBox.Show("Error: " + er.Message);
            }
        }
        private void CargarProductoSeleccionado(Producto p)
        {
            try
            {
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

                txtCodigoIndustria.Text = p.CodigoBarras;
                txtCodigoIndustria.Enabled = false;

                // Imagen
                if (p.Fotografia != null)
                {
                    using (MemoryStream ms = new MemoryStream(p.Fotografia))
                    {
                        pcbFoto.Image = Image.FromStream(ms);
                    }

                    fotoBytes = p.Fotografia;
                }
                else
                {
                    pcbFoto.Image = null;
                    fotoBytes = null;
                }

                // Documento
                documentoBytes = p.DocEspecificaciones;

                if (documentoBytes != null && documentoBytes.Length > 0)
                {
                    if (string.IsNullOrWhiteSpace(nombreDocumento))
                        nombreDocumento = "DocumentoAdjunto.pdf";

                    lblVistaPrevia.Text = "Vista Previa";
                    lblVistaPrevia.ForeColor = Color.Green;
                    lblVistaPrevia.Visible = true;
                }
                else
                {
                    lblVistaPrevia.Visible = false;
                }

                MessageBox.Show("Producto cargado correctamente",
                    "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception er)
            {
                MessageBox.Show("Error al cargar producto: " + er.Message);
            }
        }

        private void nudCantStock_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
