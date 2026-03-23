using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechKMii.Layers.Entities
{
    public class Inventario
    {
        public int InventarioID { set; get; }
        public string TipoEntradaSalida { set; get; }
        public int ProductoID { set; get; }
        public DateTime Fecha { set; get; }
        public string Observaciones { set; get; }
        public bool Estado { set; get; }
        public byte[] Documento { set; get; }
    }
}
