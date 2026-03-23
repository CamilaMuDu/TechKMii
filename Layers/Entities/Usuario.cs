using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechKMii.Layers.Entities
{
    public class Usuario
    {
        public int UsuarioID { set; get; }
        public string Nombre { set; get; }
        public string Contrasenna { set; get; }
        public int RolID { set; get; }
        public bool Estado { set; get; }
    }
}
