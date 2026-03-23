using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechKMii.Layers.Entities
{
    public class TipoDispositivo
    {
        public int TipoID { set; get; }
        public string Nombre { set; get; }
        public EstadoCatalogos Estado { set; get; }
    }
}
