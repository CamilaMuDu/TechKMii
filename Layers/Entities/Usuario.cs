using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechKMii.Layers.Entities
{
    public class Usuario
    {
        public String UsuarioID { set; get; }
        public string Nombre { set; get; }
        public string Contrasenna { set; get; }
        public Rol RolID { set; get; }
        public EstadoCatalogos Estado { set; get; }

        public override string ToString()
        {
            return $"{UsuarioID} - {Nombre.Trim()}";
        }
    }
}
