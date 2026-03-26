using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechKMii.Layers.Entities;

namespace TechKMii.Layers.Interfaces
{
    public interface IUsuarioBLL
    {
        Usuario Login(string Nombre, string contrasenna);
        IEnumerable<Usuario> GetAll();
        Usuario GetById(string nombre);
        Usuario Save(Usuario pUsuario);
        bool Delete(string nombre);
    }
}
