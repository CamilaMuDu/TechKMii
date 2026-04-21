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
        public TipoEntradaSalida TipoEntradaSalida { set; get; }
        public Producto Producto { set; get; }
        public DateTime Fecha { set; get; }
        public string Observaciones { set; get; }
        public EstadoCatalogos Estado { set; get; }
    }
}
