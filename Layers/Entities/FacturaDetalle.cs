using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechKMii.Layers.Entities
{
    public class FacturaDetalle
    {
        public int DetalleID { set; get; }
        public int FacturaID { set; get; }
        public int ProductoID { set; get; }
        public int Cantidad { set; get; }
        public double Precio { set; get; }
        public double Subtotal { set; get; }
        public double IVA { set; get; }
        public double Total { set; get; }
    }
}
