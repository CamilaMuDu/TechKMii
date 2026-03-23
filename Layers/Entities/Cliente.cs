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
        public string Sexo { set; get; }
        public string Telefono { set; get; }
        public string Correo { set; get; }
        public string Direccion { set; get; }
        public string TipoIdentificacion { set; get; }
        public int ProvinciaID { set; get; }
        public byte[] Fotografia { set; get; }
        public bool Estado { set; get; }

    }
}
