using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechKMii.Layers.Entities
{
        public class Factura
        {
            public int FacturaID { get; set; }
            public Cliente Cliente { get; set; }
            public Usuario Usuario { get; set; }
            public DateTime Fecha { get; set; }
            public double Subtotal { get; set; }
            public double IVA { get; set; }
            public double TotalCRC { get; set; }
            public double TotalUSD { get; set; }
            public double TipoCambio { get; set; }
            public TipoMetodoPago MetodoPago { get; set; }
            public string Banco { get; set; }
            public string NumeroTarjeta { get; set; }
            public TipoTarjeta TipoTarjeta { get; set; }
            public string NumeroTransferencia { get; set; }
            public string NumeroSinpe { get; set; }
            public byte[] Documento { get; set; }
            public string FacturaXML { get; set; }
            public byte[] Firma { get; set; }
            public EstadoFactura EstadoFactura { get; set; }

            public List<FacturaDetalle> ListaDetalle = new List<FacturaDetalle>();
        }
}
