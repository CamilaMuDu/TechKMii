using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TechKMii.Layers.DAL;
using TechKMii.Layers.Entities;
using TechKMii.Layers.Interfaces;

namespace TechKMii.Layers.BLL
{
    public class UsuarioBLL : IUsuarioBLL
    {
        IUsuarioDAL usuarioDAL = new UsuarioDAL();

        public bool Delete(string UsuarioID)
        {
            return usuarioDAL.Delete(UsuarioID);
        }

        public IEnumerable<Usuario> GetAll()
        {
            return usuarioDAL.GetAll();
        }

        public Usuario GetById(string UsuarioID)
        {
            return usuarioDAL.GetById(UsuarioID);
        }

        public Usuario Login(string UsuarioID, string contrasenna)
        {
            //Encriptar la contraseña
            string cryptedPassword = Cryptography.EncrypthAES(contrasenna);
            return usuarioDAL.Login(UsuarioID, cryptedPassword);
        }

        public Usuario Save(Usuario pUsuario)
        {
            string mensaje = "";
            Usuario oUsuario = null;

            Usuario usuarioExistente = usuarioDAL.GetById(pUsuario.UsuarioID);

            if (usuarioExistente == null)
            {
                if (!IsValidPassword(pUsuario.Contrasenna, ref mensaje))
                {
                    throw new Exception(mensaje);
                }

                pUsuario.Contrasenna = Cryptography.EncrypthAES(pUsuario.Contrasenna);
                oUsuario = usuarioDAL.Save(pUsuario);
            }
            else
            {
                if (string.IsNullOrWhiteSpace(pUsuario.Contrasenna))
                {
                    pUsuario.Contrasenna = usuarioExistente.Contrasenna;
                }
                else
                {
                    if (!IsValidPassword(pUsuario.Contrasenna, ref mensaje))
                    {
                        throw new Exception(mensaje);
                    }

                    pUsuario.Contrasenna = Cryptography.EncrypthAES(pUsuario.Contrasenna);
                }

                oUsuario = usuarioDAL.Update(pUsuario);
            }

            return oUsuario;
        }

        public Usuario Update(Usuario pUsuario)
        {
            return usuarioDAL.Update(pUsuario);
        }

        private bool IsValidPassword(string pContrasenna, ref string pMensaje)
        {
            if (pContrasenna.Trim().Length < 6)
            {
                pMensaje = "La contraseña debe ser mayor o igual a 6 caracteres";
                return false;
            }
            if (pContrasenna.Trim().Length > 10)
            {
                pMensaje = "La contraseña debe ser mayor o igual a 6 caracteres y menor  o igual que 10";
                return false;
            }
            return true;
        }
    }
}
