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
using QuestPDF.Infrastructure;
using TechKMii.Layers.BLL;
using TechKMii.Layers.Entities;
using TechKMii.Layers.Interfaces;
using UTN.Winform.Electronics.Extensions;
using IContainer = QuestPDF.Infrastructure.IContainer;


namespace TechKMii.Layers.UI.Reportes
{
    public partial class frmReporteCliente : Form
    {
        private static readonly ILog _myLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");
        IClienteBLL clienteBLL = new ClienteBLL();

        public frmReporteCliente()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmReporteCliente_Load(object sender, EventArgs e)
        {
            txtIdentificacionCliente.Clear();

            grbOrdenamiento.Enabled = false;

            rdbOrdenadoCedula.Checked = false;
            rdbOrdenadoNombre.Checked = false;
        }
        private void txtIentificacionCliente_TextChanged(object sender, EventArgs e)
        {
            bool hayTexto = !string.IsNullOrWhiteSpace(txtIdentificacionCliente.Text);

            grbOrdenamiento.Enabled = hayTexto;

            if (!hayTexto)
            {
                rdbOrdenadoCedula.Checked = false;
                rdbOrdenadoNombre.Checked = false;
            }
        }

        private void btnMostrarReporte_Click(object sender, EventArgs e)
        {
            try
            {
                string textoFiltro = txtIdentificacionCliente.Text.Trim();

                bool filtrarCedula = rdbOrdenadoCedula.Checked;
                bool filtrarNombre = rdbOrdenadoNombre.Checked;

                var lista = clienteBLL.GetAllSync().ToList();


                lista = lista
                    .Where(c => c.Estado == EstadoCatalogos.Activo)
                    .ToList();

                if (string.IsNullOrWhiteSpace(textoFiltro) &&
                    !filtrarCedula &&
                    !filtrarNombre)
                {
                    GenerarPdfClientes(lista);
                    return;
                }

                if (!string.IsNullOrWhiteSpace(textoFiltro) &&
                    !filtrarCedula &&
                    !filtrarNombre)
                {
                    MessageBox.Show("Debe seleccionar un tipo de filtro.",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(textoFiltro) &&
                    (filtrarCedula || filtrarNombre))
                {
                    MessageBox.Show("Debe escribir un valor para filtrar.",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                List<Cliente> listaFiltrada = new List<Cliente>();

                if (filtrarCedula)
                {
                    listaFiltrada = lista
                        .Where(c => c.Identificacion != null &&
                                    c.Identificacion.IndexOf(textoFiltro, StringComparison.OrdinalIgnoreCase) >= 0)
                        .OrderBy(c => c.Identificacion)
                        .ToList();
                }
                else if (filtrarNombre)
                {
                    listaFiltrada = lista
                        .Where(c => c.Nombre != null &&
                                    c.Nombre.IndexOf(textoFiltro, StringComparison.OrdinalIgnoreCase) >= 0)
                        .OrderBy(c => c.Nombre)
                        .ToList();
                }

                if (listaFiltrada.Count == 0)
                {
                    MessageBox.Show("No se encontraron clientes con ese filtro.",
                        "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                GenerarPdfClientes(listaFiltrada);
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

        private void GenerarPdfClientes(List<Cliente> listaClientes)
        {
            try
            {
                string carpeta = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                    "ReportesTechKMii");

                if (!Directory.Exists(carpeta))
                    Directory.CreateDirectory(carpeta);

                string ruta = Path.Combine(carpeta,
                    $"Reporte_Clientes_{DateTime.Now:yyyyMMdd_HHmmss}.pdf");

                string rutaLogo = Path.Combine(Application.StartupPath, "Resources", "Logo.png");

                byte[] logoBytes = null;
                if (File.Exists(rutaLogo))
                    logoBytes = File.ReadAllBytes(rutaLogo);

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

                                row.ConstantItem(70).Height(70).AlignRight().Element(c =>
                                {
                                    if (logoBytes != null)
                                        c.Image(logoBytes).FitArea();
                                });
                            });

                            col.Item().AlignCenter().Text("Reporte de Clientes")
                                .FontSize(18).Bold();

                            col.Item().AlignCenter().Text($"Fecha: {DateTime.Now:dd/MM/yyyy HH:mm}")
                                .FontSize(10);
                        });

                        page.Content().PaddingVertical(10).Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn(2);
                                columns.RelativeColumn(2); 
                                columns.RelativeColumn(2); 
                                columns.RelativeColumn(2); 
                                columns.RelativeColumn(2); 
                                columns.RelativeColumn(2); 
                                columns.ConstantColumn(80); 
                            });

                            table.Header(header =>
                            {
                                header.Cell().Element(EstiloEncabezado).Text("Cédula");
                                header.Cell().Element(EstiloEncabezado).Text("Nombre");
                                header.Cell().Element(EstiloEncabezado).Text("Apellidos");
                                header.Cell().Element(EstiloEncabezado).Text("Teléfono");
                                header.Cell().Element(EstiloEncabezado).Text("Correo");
                                header.Cell().Element(EstiloEncabezado).Text("Provincia");
                                header.Cell().Element(EstiloEncabezado).Text("Imagen");
                            });

                            foreach (var c in listaClientes)
                            {
                                table.Cell().Element(EstiloCelda).Text(c.Identificacion ?? "");
                                table.Cell().Element(EstiloCelda).Text(c.Nombre ?? "");
                                table.Cell().Element(EstiloCelda).Text(c.Apellidos ?? "");
                                table.Cell().Element(EstiloCelda).Text(c.Telefono ?? "");
                                table.Cell().Element(EstiloCelda).Text(c.Correo ?? "");
                                table.Cell().Element(EstiloCelda).Text(c.Provincia ?? "");

                                table.Cell().Element(EstiloCelda).Height(60).AlignCenter().Element(img =>
                                {
                                    if (c.Fotografia != null && c.Fotografia.Length > 0)
                                        img.Image(c.Fotografia).FitArea();
                                    else
                                        img.Text("Sin imagen").FontSize(8);
                                });
                            }
                        });

                        page.Footer().Row(row =>
                        {
                            row.RelativeItem().AlignLeft().Text("TechKMii")
                                .FontSize(10)
                                .Bold()
                                .FontColor("#E75480");

                            row.RelativeItem().AlignRight().Text($"Total clientes: {listaClientes.Count}")
                                .FontSize(10);
                        });
                    });
                })
                .GeneratePdf(ruta);

                MessageBox.Show("PDF generado correctamente",
                    "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Process.Start(new ProcessStartInfo(ruta) { UseShellExecute = true });
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

        private IContainer EstiloEncabezado(IContainer container)
        {
            return container
                .Background("#F8C8DC") 
                .Border(1)
                .Padding(4)
                .AlignCenter();
        }

        private IContainer EstiloCelda(IContainer container)
        {
            return container
                .Border(1)
                .Padding(3)
                .AlignCenter();
        }
    }
}
