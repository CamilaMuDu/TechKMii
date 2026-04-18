<?xml version="1.0" encoding="UTF-8"?>

<xsl:stylesheet version="1.0"
    xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

	<xsl:output method="html" indent="yes"/>

	<xsl:template match="/">

		<html>
			<head>
				<title>Factura</title>
				<style>
					body {
					font-family: Arial;
					margin: 30px;
					}

					h1 {
					text-align: center;
					}

					.encabezado, .totales, .pago {
					margin-bottom: 20px;
					}

					table {
					width: 100%;
					border-collapse: collapse;
					}

					th {
					background-color: #004080;
					color: white;
					padding: 8px;
					}

					td {
					padding: 8px;
					border: 1px solid #ccc;
					text-align: center;
					}

					.totales {
					text-align: right;
					}

					.firma {
					margin-top: 50px;
					text-align: center;
					}

					.linea-firma {
					border-top: 1px solid black;
					width: 200px;
					margin: auto;
					}
				</style>
			</head>

			<body>

				<h1>FACTURA</h1>

				<!-- ENCABEZADO -->
				<div class="encabezado">
					<p>
						<b>Número:</b>
						<xsl:value-of select="FACTURA/ENCABEZADO/NUMERO_FACTURA"/>
					</p>
					<p>
						<b>Fecha:</b>
						<xsl:value-of select="FACTURA/ENCABEZADO/FECHA"/>
					</p>
					<p>
						<b>Usuario:</b>
						<xsl:value-of select="FACTURA/ENCABEZADO/USUARIO/NOMBRE"/>
					</p>
					<p>
						<b>Cliente:</b>
						<xsl:value-of select="FACTURA/ENCABEZADO/CLIENTE/NOMBRE"/>
					</p>
					<p>
						<b>Correo:</b>
						<xsl:value-of select="FACTURA/ENCABEZADO/CLIENTE/CORREO"/>
					</p>
				</div>

				<!-- PAGO -->
				<div class="pago">
					<h3>Información de Pago</h3>
					<p>
						<b>Método:</b>
						<xsl:value-of select="FACTURA/PAGO/METODO"/>
					</p>
					<p>
						<b>Banco:</b>
						<xsl:value-of select="FACTURA/PAGO/BANCO"/>
					</p>
				</div>

				<!-- DETALLE -->
				<h3>Detalle de Productos</h3>

				<table>
					<tr>
						<th>Producto</th>
						<th>Cantidad</th>
						<th>Precio</th>
						<th>Subtotal</th>
						<th>IVA</th>
						<th>Total</th>
					</tr>

					<xsl:for-each select="FACTURA/DETALLE/LINEA">
						<tr>
							<td>
								<xsl:value-of select="DESCRIPCION"/>
							</td>
							<td>
								<xsl:value-of select="CANTIDAD"/>
							</td>
							<td>
								<xsl:value-of select="PRECIO"/>
							</td>
							<td>
								<xsl:value-of select="SUBTOTAL"/>
							</td>
							<td>
								<xsl:value-of select="IVA"/>
							</td>
							<td>
								<xsl:value-of select="TOTAL"/>
							</td>
						</tr>
					</xsl:for-each>

				</table>

				<!-- TOTALES -->
				<div class="totales">
					<p>
						<b>Subtotal:</b>
						<xsl:value-of select="FACTURA/TOTALES/SUBTOTAL"/>
					</p>
					<p>
						<b>IVA:</b>
						<xsl:value-of select="FACTURA/TOTALES/IVA"/>
					</p>
					<p>
						<b>Total CRC:</b>
						<xsl:value-of select="FACTURA/TOTALES/TOTAL_CRC"/>
					</p>
					<p>
						<b>Total USD:</b>
						<xsl:value-of select="FACTURA/TOTALES/TOTAL_USD"/>
					</p>
				</div>

				<!-- FIRMA -->
				<div class="firma">
					<div class="linea-firma"></div>
					<p>Firma del Cliente</p>
				</div>

			</body>
		</html>

	</xsl:template>
</xsl:stylesheet>
