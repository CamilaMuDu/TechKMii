using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechKMii.Layers.Entities;

namespace TechKMii.Layers.Interfaces
{
    public interface IUsuarioDAL
    {
        Usuario Login(string nombre, string contrasenna);
        IEnumerable<Usuario> GetAll();
        Usuario Save(Usuario pUsuario);
        Usuario Update(Usuario pUsuario);
        Usuario GetById(string nombre );
        bool Delete(string nombre);
    }
}
