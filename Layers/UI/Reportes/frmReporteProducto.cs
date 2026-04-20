using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;
using QuestPDF.Fluent;
using TechKMii.Layers.BLL;
using TechKMii.Layers.Entities;
using TechKMii.Layers.Interfaces;
using UTN.Winform.Electronics.Extensions;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using IContainer = QuestPDF.Infrastructure.IContainer;




namespace TechKMii.Layers.UI.Reportes
{
    public partial class frmReporteProducto : Form
    {
        private static readonly ILog _myLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");


        private IProductoBLL productoBLL = new ProductoBLL();

        public frmReporteProducto()
        {
            InitializeComponent();
        }

        private void rdbOrdenadoCedula_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void frmReporteProducto_Load(object sender, EventArgs e)
        {
            txtDescripcionProducto.Clear();
            grbOrdenamiento.Enabled = false;

            rdbOrdenadoMarca.Checked = false;
            rdbOrdenadoTipoDispositivo.Checked = false;
            rdbOrdenadoProveedor.Checked = false;

            txtDescripcionProducto.Clear();

        }

        private void txtDescripcionProducto_TextChanged(object sender, EventArgs e)
        {
            bool hayTexto = !string.IsNullOrWhiteSpace(txtDescripcionProducto.Text);

            grbOrdenamiento.Enabled = hayTexto;

            if (!hayTexto)
            {
                rdbOrdenadoMarca.Checked = false;
                rdbOrdenadoTipoDispositivo.Checked = false;
                rdbOrdenadoProveedor.Checked = false;
            }
        }

        private void btnMostrarReporte_Click(object sender, EventArgs e)
        {
            try
            {
                CargarYGenerarReporte();
            }
            catch (Exception er)
            {
                string msg = "";
                _myLogControlEventos.ErrorFormat("Error {0}",
                    msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod()));

                MessageBox.Show("Se produjo un error: " + er.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void CargarYGenerarReporte()
        {
            try
            {
                string textoFiltro = txtDescripcionProducto.Text.Trim();

                bool filtrarPorMarca = rdbOrdenadoMarca.Checked;
                bool filtrarPorTipo = rdbOrdenadoTipoDispositivo.Checked;
                bool filtrarPorProveedor = rdbOrdenadoProveedor.Checked;

                var lista = (await productoBLL.GetAll()).ToList();

                lista = lista
                    .Where(p => p.Estado == EstadoCatalogos.Activo)
                    .ToList();

                if (string.IsNullOrWhiteSpace(textoFiltro) &&
                    !filtrarPorMarca &&
                    !filtrarPorTipo &&
                    !filtrarPorProveedor)
                {
                    if (lista.Count == 0)
                    {
                        MessageBox.Show("No hay productos activos para mostrar.",
                            "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    GenerarPdfProductos(lista);
                    return;
                }

                if (!string.IsNullOrWhiteSpace(textoFiltro) &&
                    !filtrarPorMarca &&
                    !filtrarPorTipo &&
                    !filtrarPorProveedor)
                {
                    MessageBox.Show("Debe seleccionar una opción de ordenamiento para filtrar.",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(textoFiltro) &&
                    (filtrarPorMarca || filtrarPorTipo || filtrarPorProveedor))
                {
                    MessageBox.Show("Debe escribir un valor en la descripción del producto.",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                List<Producto> listaFiltrada = new List<Producto>();

                if (filtrarPorMarca)
                {
                    listaFiltrada = lista
                        .Where(p => p.Marca != null &&
                                    !string.IsNullOrWhiteSpace(p.Marca.Nombre) &&
                                    p.Marca.Nombre.IndexOf(textoFiltro, StringComparison.OrdinalIgnoreCase) >= 0)
                        .OrderBy(p => p.Marca.Nombre)
                        .ThenBy(p => p.Nombre)
                        .ToList();
                }
                else if (filtrarPorTipo)
                {
                    listaFiltrada = lista
                        .Where(p => p.Tipo != null &&
                                    !string.IsNullOrWhiteSpace(p.Tipo.Nombre) &&
                                    p.Tipo.Nombre.IndexOf(textoFiltro, StringComparison.OrdinalIgnoreCase) >= 0)
                        .OrderBy(p => p.Tipo.Nombre)
                        .ThenBy(p => p.Nombre)
                        .ToList();
                }
                else if (filtrarPorProveedor)
                {
                    listaFiltrada = lista
                        .Where(p => p.Proveedor != null &&
                                    !string.IsNullOrWhiteSpace(p.Proveedor.Nombre) &&
                                    p.Proveedor.Nombre.IndexOf(textoFiltro, StringComparison.OrdinalIgnoreCase) >= 0)
                        .OrderBy(p => p.Proveedor.Nombre)
                        .ThenBy(p => p.Nombre)
                        .ToList();
                }

                if (listaFiltrada.Count == 0)
                {
                    MessageBox.Show("No se encontraron productos activos con ese filtro.",
                        "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                GenerarPdfProductos(listaFiltrada);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el reporte: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenerarPdfProductos(List<Producto> listaProductos)
        {
            try
            {
                string carpeta = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                    "ReportesTechKMii");

                if (!Directory.Exists(carpeta))
                    Directory.CreateDirectory(carpeta);

                string ruta = Path.Combine(carpeta,
                    $"Reporte_Productos_{DateTime.Now:yyyyMMdd_HHmmss}.pdf");

                string rutaLogo = Path.Combine(Application.StartupPath, "Resources", "Logo.png");

                byte[] logoBytes = null;

                if (File.Exists(rutaLogo))
                {
                    logoBytes = File.ReadAllBytes(rutaLogo);
                }
                else
                {
                    MessageBox.Show("No se encontró el logo en: " + rutaLogo);
                }

                QuestPDF.Settings.License = LicenseType.Community;

                Document.Create(container =>
                {
                    container.Page(page =>
                    {
                        page.Margin(20);

                        page.Header().Column(col =>
                        {
                            col.Item().Row(row =>
                            {
                                row.RelativeItem();

                                row.ConstantItem(70).Height(70).AlignRight().AlignTop().Element(c =>
                                {
                                    if (logoBytes != null)
                                        c.Image(logoBytes).FitArea();
                                });
                            });

                            col.Item().AlignCenter().Text("Reporte de Productos")
                                .FontSize(18).Bold();

                            col.Item().AlignCenter().Text($"Fecha: {DateTime.Now:dd/MM/yyyy HH:mm}")
                                .FontSize(10);
                        });

                        page.Content().PaddingVertical(10).Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.ConstantColumn(45);
                                columns.RelativeColumn(2);
                                columns.RelativeColumn(1.5f);
                                columns.RelativeColumn(1.5f);
                                columns.RelativeColumn(1.5f);
                                columns.RelativeColumn(1.3f);
                                columns.ConstantColumn(65);
                                columns.ConstantColumn(55);
                                columns.ConstantColumn(75);
                            });

                            table.Header(header =>
                            {
                                header.Cell().Element(EstiloEncabezado).Text("ID");
                                header.Cell().Element(EstiloEncabezado).Text("Nombre");
                                header.Cell().Element(EstiloEncabezado).Text("Marca");
                                header.Cell().Element(EstiloEncabezado).Text("Tipo");
                                header.Cell().Element(EstiloEncabezado).Text("Proveedor");
                                header.Cell().Element(EstiloEncabezado).Text("Modelo");
                                header.Cell().Element(EstiloEncabezado).Text("Precio");
                                header.Cell().Element(EstiloEncabezado).Text("Stock");
                                header.Cell().Element(EstiloEncabezado).Text("Imagen");
                            });

                            foreach (var p in listaProductos)
                            {
                                table.Cell().Element(EstiloCelda).Text(p.ProductoID.ToString());
                                table.Cell().Element(EstiloCelda).Text(p.Nombre ?? "");
                                table.Cell().Element(EstiloCelda).Text(p.Marca?.Nombre ?? "");
                                table.Cell().Element(EstiloCelda).Text(p.Tipo?.Nombre ?? "");
                                table.Cell().Element(EstiloCelda).Text(p.Proveedor?.Nombre ?? "");
                                table.Cell().Element(EstiloCelda).Text(p.Modelo ?? "");
                                table.Cell().Element(EstiloCelda).Text(p.Precio.ToString("N2"));
                                table.Cell().Element(EstiloCelda).Text(p.CantidadStock.ToString());

                                table.Cell().Element(EstiloCelda).Height(60).AlignMiddle().AlignCenter().Element(c =>
                                {
                                    if (p.Fotografia != null && p.Fotografia.Length > 0)
                                        c.Image(p.Fotografia).FitArea();
                                    else
                                        c.Text("Sin imagen").FontSize(8);
                                });
                            }
                        });

                        page.Footer().Row(row =>
                        {
                            row.RelativeItem().AlignLeft().Text("TechKMii")
                                .FontSize(10)
                                .Bold()
                                .FontColor("#E75480");

                            row.RelativeItem().AlignRight().Text($"Total productos: {listaProductos.Count}")
                                .FontSize(10);
                        });
                    });
                })
                .GeneratePdf(ruta);

                MessageBox.Show("PDF generado correctamente.",
                    "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Process.Start(new ProcessStartInfo(ruta) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generando PDF: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private IContainer EstiloEncabezado(IContainer container)
        {
            return container
                .Background("#F4C2D7")
                .Border(1)
                .BorderColor(Colors.Grey.Lighten2)
                .Padding(4)
                .AlignCenter()
                .AlignMiddle();
        }

        private IContainer EstiloCelda(IContainer container)
        {
            return container
                .Border(1)
                .BorderColor(Colors.Grey.Lighten2)
                .Padding(3)
                .AlignCenter()
                .AlignMiddle();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
