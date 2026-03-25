using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechKMii.Layers.DAL;
using TechKMii.Layers.Entities;
using TechKMii.Layers.Interfaces;

namespace TechKMii.Layers.BLL
{
    public class UsuarioBLL : IUsuarioBLL
    {
        public bool Delete(int usuarioID)
        {
            IUsuarioDAL dalUsuario = new UsuarioDAL();
            return dalUsuario.Delete(usuarioID);
        }

        public IEnumerable<Usuario> GetAll()
        {
            IUsuarioDAL dalUsuario = new UsuarioDAL();
            return dalUsuario.GetAll();
        }

        public Usuario GetById(int usuarioID)
        {
            IUsuarioDAL usuarioDAL = new UsuarioDAL();  
            return usuarioDAL.GetById(usuarioID);
        }

        public Usuario Login(int usuarioID, string contrasenna)
        {
            IUsuarioDAL usuarioDAL = new UsuarioDAL();
            //para encriptar la contraseña
            string crytpPassword = Cryptography.EncrypthAES(contrasenna);
            return usuarioDAL.Login(usuarioID, crytpPassword);
        }

        public Usuario Save(Usuario pUsuario)
        {
            IUsuarioDAL dalUsuario = new UsuarioDAL();
            string mensaje = "";
            Usuario oUsuario = null;

            if (!IsValidPassword(pUsuario.Contrasenna, ref mensaje))
            {
                throw new Exception(mensaje);
            }

            // Encriptar la contraseña.
            pUsuario.Contrasenna = Cryptography.EncrypthAES(pUsuario.Contrasenna);

            if (dalUsuario.GetById(pUsuario.UsuarioID) != null)
                oUsuario = dalUsuario.Update(pUsuario);
            else
                oUsuario = dalUsuario.Save(pUsuario);
            return oUsuario;
        }

        private bool IsValidPassword(string pPassword, ref string pMensaje)
        {
            if (pPassword.Trim().Length <= 6)
            {
                pMensaje = "La contraseña debe ser mayor o igual a 6 caracteres";
                return false;
            }

            if (pPassword.Trim().Length > 10)
            {
                pMensaje = "La contraseña debe ser mayor o igual a 6 caracteres y menor  o igual que 10";
                return false;
            }

            return true;
        }
    }
}
