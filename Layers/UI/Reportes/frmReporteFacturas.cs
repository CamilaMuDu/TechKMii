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
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using TechKMii.Layers.BLL;
using TechKMii.Layers.Entities;
using TechKMii.Layers.Interfaces;
using UTN.Winform.Electronics.Extensions;
using IContainer = QuestPDF.Infrastructure.IContainer;

namespace TechKMii.Layers.UI.Reportes
{
    public partial class frmReporteFacturas : Form
    {
        private static readonly ILog _myLogControlEventos = LogManager.GetLogger("MyControlEventos");
        private readonly IFacturaBLL facturaBLL = new FacturaBLL();

        public frmReporteFacturas()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmReporteFacturas_Load(object sender, EventArgs e)
        {
            dtpFechaInicio.Value = DateTime.Today;
            dtpFechaFin.Value = DateTime.Today;
        }

        private void btnMostrarReporte_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fechaInicio = dtpFechaInicio.Value.Date;
                DateTime fechaFin = dtpFechaFin.Value.Date;

                if (fechaInicio > fechaFin)
                {
                    MessageBox.Show("La fecha inicial no puede ser mayor que la fecha final.",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var lista = facturaBLL.GetAll().ToList();

                var listaFiltrada = lista
                    .Where(f => f.Fecha.Date >= fechaInicio && f.Fecha.Date <= fechaFin)
                    .OrderBy(f => f.Fecha)
                    .ToList();

                if (listaFiltrada.Count == 0)
                {
                    MessageBox.Show("No se encontraron facturas en ese rango de fechas.",
                        "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                GenerarPdfFacturas(listaFiltrada);
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

        private void GenerarPdfFacturas(List<Factura> listaFacturas)
        {
            try
            {
                string carpeta = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                    "ReportesTechKMii");

                if (!Directory.Exists(carpeta))
                    Directory.CreateDirectory(carpeta);

                string ruta = Path.Combine(carpeta,
                    $"Reporte_Facturas_{DateTime.Now:yyyyMMdd_HHmmss}.pdf");

                string rutaLogo = Path.Combine(Application.StartupPath, "Resources", "Logo.png");

                byte[] logoBytes = null;
                if (File.Exists(rutaLogo))
                    logoBytes = File.ReadAllBytes(rutaLogo);

                QuestPDF.Settings.License = LicenseType.Community;

                decimal subtotalGeneral = Convert.ToDecimal(listaFacturas.Sum(f => f.Subtotal));
                decimal ivaGeneral = Convert.ToDecimal(listaFacturas.Sum(f => f.IVA));
                decimal totalCRCGeneral = Convert.ToDecimal(listaFacturas.Sum(f => f.TotalCRC));
                decimal totalUSDGeneral = Convert.ToDecimal(listaFacturas.Sum(f => f.TotalUSD));

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

                                row.ConstantItem(70).Height(70).AlignRight().Element(c =>
                                {
                                    if (logoBytes != null)
                                        c.Image(logoBytes).FitArea();
                                });
                            });

                            col.Item().AlignCenter().Text("Reporte de Facturas")
                                .FontSize(18).Bold();

                            col.Item().AlignCenter().Text($"Fecha de generación: {DateTime.Now:dd/MM/yyyy HH:mm}")
                                .FontSize(10);

                            col.Item().AlignCenter().Text(
                                $"Rango consultado: {dtpFechaInicio.Value:dd/MM/yyyy} - {dtpFechaFin.Value:dd/MM/yyyy}")
                                .FontSize(10);
                        });

                        page.Content().PaddingVertical(10).Column(col =>
                        {
                            col.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.ConstantColumn(70); 
                                    columns.ConstantColumn(75); 
                                    columns.RelativeColumn(2);  
                                    columns.RelativeColumn(2);
                                    columns.ConstantColumn(70); 
                                    columns.ConstantColumn(60);  
                                    columns.ConstantColumn(80); 
                                    columns.ConstantColumn(80); 
                                });

                                table.Header(header =>
                                {
                                    header.Cell().Element(EstiloEncabezado).Text("Factura");
                                    header.Cell().Element(EstiloEncabezado).Text("Fecha");
                                    header.Cell().Element(EstiloEncabezado).Text("Cliente");
                                    header.Cell().Element(EstiloEncabezado).Text("Usuario");
                                    header.Cell().Element(EstiloEncabezado).Text("Subtotal");
                                    header.Cell().Element(EstiloEncabezado).Text("IVA");
                                    header.Cell().Element(EstiloEncabezado).Text("Total CRC");
                                    header.Cell().Element(EstiloEncabezado).Text("Total USD");
                                });

                                foreach (var f in listaFacturas)
                                {
                                    table.Cell().Element(EstiloCelda).Text(f.FacturaID.ToString());
                                    table.Cell().Element(EstiloCelda).Text(f.Fecha.ToString("dd/MM/yyyy"));
                                    table.Cell().Element(EstiloCelda).Text(
                                        f.Cliente != null ? $"{f.Cliente.Nombre} {f.Cliente.Apellidos}" : "");
                                    table.Cell().Element(EstiloCelda).Text(
                                        f.Usuario != null ? f.Usuario.Nombre : "");
                                    table.Cell().Element(EstiloCelda).Text(f.Subtotal.ToString("N2"));
                                    table.Cell().Element(EstiloCelda).Text(f.IVA.ToString("N2"));
                                    table.Cell().Element(EstiloCelda).Text(f.TotalCRC.ToString("N2"));
                                    table.Cell().Element(EstiloCelda).Text(f.TotalUSD.ToString("N2"));
                                }
                            });

                            col.Item().PaddingTop(15).AlignRight().Column(tot =>
                            {
                                tot.Item().Text($"Cantidad de facturas: {listaFacturas.Count}")
                                    .FontSize(10).Bold();

                                tot.Item().Text($"Subtotal general: {subtotalGeneral:N2}")
                                    .FontSize(10);

                                tot.Item().Text($"IVA general: {ivaGeneral:N2}")
                                    .FontSize(10);

                                tot.Item().Text($"Total CRC general: {totalCRCGeneral:N2}")
                                    .FontSize(10).Bold();

                                tot.Item().Text($"Total USD general: {totalUSDGeneral:N2}")
                                    .FontSize(10).Bold();
                            });
                        });

                        page.Footer().Row(row =>
                        {
                            row.RelativeItem().AlignLeft().Text("TechKMii")
                                .FontSize(10)
                                .Bold()
                                .FontColor("#E75480");

                            row.RelativeItem().AlignRight().Text($"Total registros: {listaFacturas.Count}")
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
                .Background("#F8C8DC")
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
    }
}
