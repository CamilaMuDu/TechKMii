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
using log4net;
using TechKMii.Layers.BLL;
using TechKMii.Layers.DAL;
using TechKMii.Layers.Entities;
using TechKMii.Layers.Interfaces;
using UTN.Winform.Electronics.Extensions;

namespace TechKMii.Layers.UI.Mantenimientos.Filtros
{
    public partial class frmProductoFiltro : Form
    {
        private static readonly ILog _myLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");
        public Producto oProducto = null;
        IProductoBLL ProductoBll = new ProductoBLL();
        private List<Producto> listaProductos = new List<Producto>();
        public frmProductoFiltro()
        {
            InitializeComponent();
        }

        private async void frmProductoFiltro_Load(object sender, EventArgs e)
        {
            try
            {
                ConfigurarColumnasGrid();
                txtBuscar.Focus();

                listaProductos = (await ProductoBll.GetAll())
                    .Where(p => p.Estado == EstadoCatalogos.Activo)
                    .ToList();

                var datos = listaProductos.Select(p => new
                {
                    p.ProductoID,
                    p.Nombre,
                    p.CodigoBarras,
                    p.Modelo,
                    Proveedor = p.Proveedor != null ? p.Proveedor.Nombre : "",
                    Marca = p.Marca != null ? p.Marca.Nombre : "",
                    Estado = p.Estado.ToString()
                }).ToList();

                dgvBuscar.DataSource = null;
                dgvBuscar.DataSource = datos;
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

        private void tspSalir_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }
        private async void tspNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                txtBuscar.Clear();

                listaProductos = (await ProductoBll.GetAll())
                    .Where(p => p.Estado == EstadoCatalogos.Activo)
                    .ToList();

                var datos = listaProductos.Select(p => new
                {
                    p.ProductoID,
                    p.Nombre,
                    p.CodigoBarras,
                    p.Modelo,
                    Proveedor = p.Proveedor != null ? p.Proveedor.Nombre : "",
                    Marca = p.Marca != null ? p.Marca.Nombre : "",
                    Estado = p.Estado.ToString()
                }).ToList();

                dgvBuscar.DataSource = null;
                dgvBuscar.DataSource = datos;

                txtBuscar.Focus();
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

        private void ConfigurarColumnasGrid()
        {
            dgvBuscar.AutoGenerateColumns = false;
            dgvBuscar.Columns.Clear();

            dgvBuscar.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ProductoID",
                HeaderText = "Producto ID",
                DataPropertyName = "ProductoID",
                Width = 80
            });

            dgvBuscar.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Nombre",
                HeaderText = "Nombre",
                DataPropertyName = "Nombre",
                Width = 150
            });

            dgvBuscar.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CodigoBarras",
                HeaderText = "Código Industria",
                DataPropertyName = "CodigoBarras",
                Width = 120
            });

            dgvBuscar.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Modelo",
                HeaderText = "Modelo",
                DataPropertyName = "Modelo",
                Width = 120
            });

            dgvBuscar.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Proveedor",
                HeaderText = "Proveedor",
                DataPropertyName = "Proveedor",
                Width = 120
            });

            dgvBuscar.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Marca",
                HeaderText = "Marca",
                DataPropertyName = "Marca",
                Width = 120
            });

            dgvBuscar.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Estado",
                HeaderText = "Estado",
                DataPropertyName = "Estado",
                Width = 90
            });

            dgvBuscar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBuscar.MultiSelect = false;
            dgvBuscar.ReadOnly = true;
            dgvBuscar.AllowUserToAddRows = false;
            dgvBuscar.AllowUserToDeleteRows = false;
        }

        private void dgvBuscar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvBuscar.CurrentRow == null)
                    return;

                int id = Convert.ToInt32(dgvBuscar.CurrentRow.Cells["ProductoID"].Value);

                oProducto = listaProductos.FirstOrDefault(p => p.ProductoID == id);

                if (oProducto != null)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }

                if (listaProductos.Count == 0)
                {
                    dgvBuscar.DataSource = null;

                    dgvBuscar.Rows.Clear();
                    dgvBuscar.Columns.Clear();

                    dgvBuscar.Columns.Add("Mensaje", "Resultado");
                    dgvBuscar.Rows.Add("No se encontraron productos");

                    return;
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
        private async void tspBuscarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                string filtro = txtBuscar.Text.Trim();

                if (string.IsNullOrWhiteSpace(filtro))
                {
                    listaProductos = (await ProductoBll.GetAll())
                        .Where(p => p.Estado == EstadoCatalogos.Activo)
                        .ToList();
                }
                else
                {
                    //Codigo que trae solo los productos activos que coincidan con el filtro
                    listaProductos = (await ProductoBll.GetByFilter(filtro))
                        .Where(p => p.Estado == EstadoCatalogos.Activo)
                        .ToList();
                }

                var datos = listaProductos.Select(p => new
                {
                    p.ProductoID,
                    p.Nombre,
                    p.CodigoBarras,
                    p.Modelo,
                    Proveedor = p.Proveedor != null ? p.Proveedor.Nombre : "",
                    Marca = p.Marca != null ? p.Marca.Nombre : "",
                    Estado = p.Estado.ToString()
                }).ToList();

                dgvBuscar.DataSource = null;
                dgvBuscar.DataSource = datos;

                if (listaProductos.Count == 0)
                {
                    MessageBox.Show("No se encontraron productos.",
                        "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}
