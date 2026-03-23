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
        public byte[] CodigoBarras { set; get; }
        public int TipoID { set; get; }
        public int ProveedorID { set; get; }
        public int MarcaID { set; get; }
        public string Modelo { set; get; }
        public double Precio { set; get; }
        public int CantidadStock { set; get; }
        public string Color { set; get; }
        public string Caracteristicas { set; get; }
        public byte[] DocEspecificaciones { set; get; }
        public string Extras { set; get; }
        public byte[] Fotografia { set; get; }
        public bool Estado { set; get; }

    }
}
