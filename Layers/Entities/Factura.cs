using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace TechKMii.Layers.Entities
{
    public class Factura
    {
        public int FacturaID { set; get; }
        public int ClienteID { set; get; }
        public int UsuarioID { set; get; }
        public DateTime Fecha { set; get; }
        public double Subtotal { set; get; }
        public double IVA { set; get; }
        public double TotalCRC { set; get; }
        public double TotalURD { set; get; }
        public double TipoCambio { set; get; }
        public string MetodoPago { set; get; }
        public byte[] Documento { set; get; }
        public string Banco { set; get; }
        public string TipoTarjeta { set; get; }
        public Xml FacturaXML { set; get; }
        public byte[] Firma { set; get; }
        public bool EstadoFactura { set; get; }
    }
}
