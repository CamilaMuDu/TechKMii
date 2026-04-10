using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechKMii.Layers.Entities
{
    public class Producto
    {
        public int ProductoID { set; get; }
        public string Nombre { set; get; }
        public string CodigoBarras { set; get; }
        public TipoDispositivo Tipo { set; get; }
        public Proveedor Proveedor { set; get; }
        public Marca Marca { set; get; }
        public string Modelo { set; get; }
        public double Precio { set; get; }
        public int CantidadStock { set; get; }
        public string Color { set; get; }
        public string Caracteristicas { set; get; }
        public byte[] DocEspecificaciones { set; get; }
        public string Extras { set; get; }
        public byte[] Fotografia { set; get; }
        public EstadoCatalogos Estado { set; get; }
    }
}
