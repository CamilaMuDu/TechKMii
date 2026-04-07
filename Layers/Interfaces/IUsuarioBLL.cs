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
        Usuario Login(string UsuarioID, string contrasenna);
        IEnumerable<Usuario> GetAll();
        Usuario GetById(String UsuarioID);
        Usuario Save(Usuario pUsuario);
        Usuario Update(Usuario pUsuario);
        bool Delete(String UsuarioID);
    }
}
