using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechKMii.Layers.Entities
{
    public class Cliente
    {
        public int ClienteID { set; get; }
        public string Nombre { set; get; }
        public string Apellidos { set; get; }
        public Sexo Sexo { set; get; }
        public string Telefono { set; get; }
        public string Correo { set; get; }
        public string Direccion { set; get; }
        public TipoIdentificacion TipoIdentificacion { set; get; }
        public Provincia ProvinciaID { set; get; }
        public byte[] Fotografia { set; get; }
        public EstadoCatalogos Estado { set; get; }

    }
}
