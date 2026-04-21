using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using TechKMii.Layers.Entities;


namespace TechKMii.Util
{
    public class FacturaDocumento
    {
        public static string GenerarFacturaXML(Factura factura, string numeroFactura, string nombreCliente, string correoCliente, string nombreUsuario)
        {
            XmlDocument xmlDoc = new XmlDocument();

            XmlElement raiz = xmlDoc.CreateElement("FACTURA");
            xmlDoc.AppendChild(raiz);


            XmlElement nEncabezado = xmlDoc.CreateElement("ENCABEZADO");

            XmlElement nNumeroFactura = xmlDoc.CreateElement("NUMERO_FACTURA");
            nNumeroFactura.InnerText = numeroFactura;

            XmlElement nFecha = xmlDoc.CreateElement("FECHA");
            nFecha.InnerText = factura.Fecha.ToString("dd/MM/yyyy HH:mm:ss");

            XmlElement nUsuario = xmlDoc.CreateElement("USUARIO");

            XmlElement nUsuarioId = xmlDoc.CreateElement("ID");
            nUsuarioId.InnerText = factura.Usuario != null ? factura.Usuario.UsuarioID : "";

            XmlElement nUsuarioNombre = xmlDoc.CreateElement("NOMBRE");
            nUsuarioNombre.InnerText = nombreUsuario ?? "";

            nUsuario.AppendChild(nUsuarioId);
            nUsuario.AppendChild(nUsuarioNombre);

            XmlElement nCliente = xmlDoc.CreateElement("CLIENTE");

            XmlElement nClienteId = xmlDoc.CreateElement("ID");
            nClienteId.InnerText = factura.Cliente != null ? factura.Cliente.ClienteID.ToString() : "0";

            XmlElement nClienteNombre = xmlDoc.CreateElement("NOMBRE");
            nClienteNombre.InnerText = nombreCliente ?? "";

            XmlElement nClienteCorreo = xmlDoc.CreateElement("CORREO");
            nClienteCorreo.InnerText = correoCliente ?? "";

            nCliente.AppendChild(nClienteId);
            nCliente.AppendChild(nClienteNombre);
            nCliente.AppendChild(nClienteCorreo);

            nEncabezado.AppendChild(nNumeroFactura);
            nEncabezado.AppendChild(nFecha);
            nEncabezado.AppendChild(nUsuario);
            nEncabezado.AppendChild(nCliente);


            XmlElement nPago = xmlDoc.CreateElement("PAGO");

            XmlElement nMetodo = xmlDoc.CreateElement("METODO");
            nMetodo.InnerText = factura.MetodoPago.ToString();

            XmlElement nBanco = xmlDoc.CreateElement("BANCO");
            nBanco.InnerText = factura.Banco ?? "";

            XmlElement nNumeroTarjeta = xmlDoc.CreateElement("NUMERO_TARJETA");
            nNumeroTarjeta.InnerText = factura.NumeroTarjeta ?? "";

            XmlElement nNumeroTransferencia = xmlDoc.CreateElement("NUMERO_TRANSFERENCIA");
            nNumeroTransferencia.InnerText = factura.NumeroTransferencia ?? "";

            XmlElement nNumeroSinpe = xmlDoc.CreateElement("NUMERO_SINPE");
            nNumeroSinpe.InnerText = factura.NumeroSinpe ?? "";

            XmlElement nTipoTarjeta = xmlDoc.CreateElement("TIPO_TARJETA");
            nTipoTarjeta.InnerText = factura.TipoTarjeta.ToString();

            nPago.AppendChild(nMetodo);
            nPago.AppendChild(nBanco);
            nPago.AppendChild(nNumeroTarjeta);
            nPago.AppendChild(nNumeroTransferencia);
            nPago.AppendChild(nNumeroSinpe);
            nPago.AppendChild(nTipoTarjeta);


            XmlElement nDetalle = xmlDoc.CreateElement("DETALLE");

            foreach (FacturaDetalle item in factura.ListaDetalle)
            {
                XmlElement nLinea = xmlDoc.CreateElement("LINEA");

                XmlElement nProductoId = xmlDoc.CreateElement("PRODUCTO_ID");
                nProductoId.InnerText = item.Producto != null ? item.Producto.ProductoID.ToString() : "0";

                XmlElement nDescripcion = xmlDoc.CreateElement("DESCRIPCION");
                nDescripcion.InnerText = item.Producto != null ? item.Producto.Nombre : "";

                XmlElement nCantidad = xmlDoc.CreateElement("CANTIDAD");
                nCantidad.InnerText = item.Cantidad.ToString();

                XmlElement nPrecio = xmlDoc.CreateElement("PRECIO");
                nPrecio.InnerText = item.Precio.ToString(CultureInfo.InvariantCulture);

                XmlElement nSubtotalLinea = xmlDoc.CreateElement("SUBTOTAL");
                nSubtotalLinea.InnerText = item.Subtotal.ToString(CultureInfo.InvariantCulture);

                XmlElement nIvaLinea = xmlDoc.CreateElement("IVA");
                nIvaLinea.InnerText = item.IVA.ToString(CultureInfo.InvariantCulture);

                XmlElement nTotalLinea = xmlDoc.CreateElement("TOTAL");
                nTotalLinea.InnerText = item.Total.ToString(CultureInfo.InvariantCulture);

                nLinea.AppendChild(nProductoId);
                nLinea.AppendChild(nDescripcion);
                nLinea.AppendChild(nCantidad);
                nLinea.AppendChild(nPrecio);
                nLinea.AppendChild(nSubtotalLinea);
                nLinea.AppendChild(nIvaLinea);
                nLinea.AppendChild(nTotalLinea);

                nDetalle.AppendChild(nLinea);
            }


            XmlElement nTotales = xmlDoc.CreateElement("TOTALES");

            XmlElement nSubtotal = xmlDoc.CreateElement("SUBTOTAL");
            nSubtotal.InnerText = factura.Subtotal.ToString(CultureInfo.InvariantCulture);

            XmlElement nIVA = xmlDoc.CreateElement("IVA");
            nIVA.InnerText = factura.IVA.ToString(CultureInfo.InvariantCulture);

            XmlElement nTotalCRC = xmlDoc.CreateElement("TOTAL_CRC");
            nTotalCRC.InnerText = factura.TotalCRC.ToString(CultureInfo.InvariantCulture);

            XmlElement nTotalUSD = xmlDoc.CreateElement("TOTAL_USD");
            nTotalUSD.InnerText = factura.TotalUSD.ToString(CultureInfo.InvariantCulture);

            XmlElement nTipoCambio = xmlDoc.CreateElement("TIPO_CAMBIO");
            nTipoCambio.InnerText = factura.TipoCambio.ToString(CultureInfo.InvariantCulture);

            nTotales.AppendChild(nSubtotal);
            nTotales.AppendChild(nIVA);
            nTotales.AppendChild(nTotalCRC);
            nTotales.AppendChild(nTotalUSD);
            nTotales.AppendChild(nTipoCambio);


            raiz.AppendChild(nEncabezado);
            raiz.AppendChild(nPago);
            raiz.AppendChild(nDetalle);
            raiz.AppendChild(nTotales);

            return xmlDoc.OuterXml;
        }

        public static string GenerarPDF(Factura factura, string numeroFactura, string nombreCliente, string correoCliente, string nombreUsuario, string codigoQrTexto)
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string carpetaFacturas = Path.Combine(basePath, "FacturasGeneradas");

            if (!Directory.Exists(carpetaFacturas))
                Directory.CreateDirectory(carpetaFacturas);

            string rutaPdf = Path.Combine(carpetaFacturas, $"Factura_{numeroFactura}.pdf");

            QuestPDF.Settings.License = LicenseType.Community;

            byte[] qrBytes = null;
            byte[] firmaBytes = factura.Firma;
            byte[] logoBytes = null;

            // QR
            var qrImage = QuickResponse.QuickResponseGenerador(codigoQrTexto, 53);
            MemoryStream msQr = new MemoryStream();
            qrImage.Save(msQr, System.Drawing.Imaging.ImageFormat.Png);

            // LOGO
            string rutaLogo = Path.Combine(basePath, "Logo.png");
            if (File.Exists(rutaLogo))
            {
                logoBytes = File.ReadAllBytes(rutaLogo);
            }

            var pdfBytes = Document.Create(document =>
            {
                document.Page(page =>
                {
                    page.Size(PageSizes.Letter);
                    page.Margin(25);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(11));

                    page.Content().Column(col =>
                    {
                        col.Spacing(10);

                        // ENCABEZADO SUPERIOR
                        col.Item().Row(row =>
                        {
                            row.RelativeItem().AlignCenter().Column(c =>
                            {
                                c.Item().PaddingTop(8).Text("FACTURA ELECTRÓNICA")
                                    .FontSize(24)
                                    .Bold()
                                    .AlignCenter();
                            });

                            row.ConstantItem(95).Height(95).AlignRight().Element(e =>
                            {
                                if (logoBytes != null)
                                    e.Image(logoBytes).FitArea();
                            });
                        });

                        // DATOS PRINCIPALES
                        col.Item().PaddingTop(5).Column(info =>
                        {
                            info.Spacing(3);
                            info.Item().Text($"No. Factura: {numeroFactura}");
                            info.Item().Text($"Fecha: {factura.Fecha:dd/MM/yyyy HH:mm:ss}");
                            info.Item().Text($"Cliente: {nombreCliente}");
                            info.Item().Text($"Correo: {correoCliente}");
                            info.Item().Text($"Tipo de Pago: {factura.MetodoPago}");
                            info.Item().Text($"Estado: {factura.EstadoFactura}");

                            info.Item().PaddingTop(8).Text($"Usuario: {nombreUsuario}");
                            info.Item().Text($"Banco: {factura.Banco ?? ""}");

                            if (!string.IsNullOrWhiteSpace(factura.NumeroTarjeta))
                                info.Item().Text($"Tarjeta: {factura.NumeroTarjeta}");

                            if (!string.IsNullOrWhiteSpace(factura.NumeroTransferencia))
                                info.Item().Text($"Transferencia: {factura.NumeroTransferencia}");

                            if (!string.IsNullOrWhiteSpace(factura.NumeroSinpe))
                                info.Item().Text($"SINPE: {factura.NumeroSinpe}");
                        });

                        // TABLA DETALLE
                        col.Item().PaddingTop(10).Table(tabla =>
                        {
                            tabla.ColumnsDefinition(columns =>
                            {
                                columns.ConstantColumn(30);
                                columns.RelativeColumn(3);
                                columns.RelativeColumn(1);
                                columns.RelativeColumn(1.3f);
                                columns.RelativeColumn(1.3f);
                                columns.RelativeColumn(2);
                            });

                            tabla.Header(header =>
                            {
                                header.Cell().Element(EstiloHeaderTabla).Text("#").Bold();
                                header.Cell().Element(EstiloHeaderTabla).Text("Producto").Bold();
                                header.Cell().Element(EstiloHeaderTabla).Text("Cantidad").Bold();
                                header.Cell().Element(EstiloHeaderTabla).Text("Precio").Bold();
                                header.Cell().Element(EstiloHeaderTabla).Text("Total Línea").Bold();
                                header.Cell().Element(EstiloHeaderTabla).Text("Detalle Compra").Bold();
                            });

                            int linea = 1;
                            foreach (var item in factura.ListaDetalle)
                            {
                                tabla.Cell().Element(EstiloCeldaTabla).Text(linea.ToString());
                                tabla.Cell().Element(EstiloCeldaTabla).Text(item.Producto?.Nombre ?? "");
                                tabla.Cell().Element(EstiloCeldaTabla).Text(item.Cantidad.ToString());
                                tabla.Cell().Element(EstiloCeldaTabla).Text(item.Precio.ToString("N2"));
                                tabla.Cell().Element(EstiloCeldaTabla).Text(item.Total.ToString("N2"));
                                tabla.Cell().Element(EstiloCeldaTabla).Text("Compra");
                                linea++;
                            }
                        });

                        // TOTALES
                        col.Item().PaddingTop(10).Row(row =>
                        {
                            row.RelativeItem();

                            row.ConstantItem(240).Table(tabla =>
                            {
                                tabla.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn();
                                    columns.RelativeColumn();
                                });

                                void fila(string titulo, string valor)
                                {
                                    tabla.Cell()
                                        .Border(1)
                                        .BorderColor("#BFA7B0")
                                        .Padding(5)
                                        .Text(titulo)
                                        .FontSize(9)
                                        .Bold();

                                    tabla.Cell()
                                        .Border(1)
                                        .BorderColor("#BFA7B0")
                                        .Padding(5)
                                        .AlignRight()
                                        .Text(valor)
                                        .FontSize(9);
                                }

                                fila("Subtotal (CR)", factura.Subtotal.ToString("N2"));
                                fila("Impuesto (CR)", factura.IVA.ToString("N2"));
                                fila("Total (CR)", factura.TotalCRC.ToString("N2"));
                                fila("Total (USD)", factura.TotalUSD.ToString("N2"));
                            });
                        });

                        // QR ABAJO DE LA TABLA Y CENTRADO
                        col.Item().PaddingTop(20).AlignCenter().Row(e =>
                        {
                            if (msQr != null)
                                e.ConstantItem(90).Image(msQr.ToArray());
                        });

                        // EMPUJA EL PIE HACIA ABAJO
                        col.Item().ExtendVertical();
                    });

                    page.Footer().Column(col =>
                    {
                        col.Item().Row(row =>
                        {
                            row.RelativeItem().Column(c =>
                            {
                                c.Item().Text("Firma de validación").FontSize(9);

                                if (firmaBytes != null && firmaBytes.Length > 0)
                                    c.Item().PaddingTop(3).Height(35).Image(firmaBytes);
                            });

                            row.RelativeItem().AlignRight().AlignBottom().Text("TechKMii").FontSize(9);
                        });

                        col.Item().PaddingTop(5).AlignCenter().Text(txt =>
                        {
                            txt.Span("Página ");
                            txt.CurrentPageNumber();
                        });
                    });
                });
            }).GeneratePdf();

            File.WriteAllBytes(rutaPdf, pdfBytes);
            Process.Start(rutaPdf);
            return rutaPdf;
        }
        private static IContainer EstiloHeaderTabla(IContainer container)
        {
            return container
                .Background("#F6D6E0")
                .Border(1)
                .BorderColor("#BFA7B0")
                .Padding(5)
                .AlignMiddle();
        }

        private static IContainer EstiloCeldaTabla(IContainer container)
        {
            return container
                .Border(1)
                .BorderColor("#999999")
                .Padding(4)
                .AlignMiddle();
        }
        public static string GuardarXMLEnDisco(string xmlString, string numeroFactura)
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string carpetaFacturas = Path.Combine(basePath, "FacturasGeneradas");

            if (!Directory.Exists(carpetaFacturas))
                Directory.CreateDirectory(carpetaFacturas);

            string rutaXml = Path.Combine(carpetaFacturas, $"Factura_{numeroFactura}.xml");

            File.WriteAllText(rutaXml, xmlString, Encoding.UTF8);

            return rutaXml;
        }
    }
}
