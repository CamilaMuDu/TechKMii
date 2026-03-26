using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using log4net;
using TechKMii.Layers.Entities;
using TechKMii.Layers.Interfaces;
using UTN.Winform.Electronics.Extensions;

namespace TechKMii.Layers.DAL
{
    public class UsuarioDAL : IUsuarioDAL
    {
        private static readonly ILog _myLogControlEventos = LogManager.GetLogger("MyControlEventos");

        public bool Delete(string nombre)
        {
            SqlCommand command = new SqlCommand();
            string msg = "";
            double row = 0;
            try
            {
                command.Parameters.AddWithValue("@Nombre", nombre);

                command.CommandText = "dbo.usp_DELETE_Usuario_ByID";
                command.CommandType = CommandType.StoredProcedure;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    row = db.ExecuteNonQuery(command, IsolationLevel.ReadCommitted);
                }
                return row > 0 ? true : false;
            }
            catch (SqlException er)
            {
                _myLogControlEventos.ErrorFormat("Error {0}", msg.ToExceptionDetail(MethodBase.GetCurrentMethod(), er, command));
                throw new CustomException(msg.ToSqlServerDetailError(er));
            }
            catch (Exception er)
            {
                msg = msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod());
                _myLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                throw;
            }
        }

        public IEnumerable<Usuario> GetAll()
        {
            string msg = "";
            SqlCommand command = new SqlCommand();
            IDataReader reader = null;
            Usuario oUsuario = null;
            IList<Usuario> lista = new List<Usuario>();
            try
            {
                command.CommandText = "dbo.usp_SELECT_Usuario_All";
                command.CommandType = CommandType.StoredProcedure;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    reader = db.ExecuteReader(command);

                    while (reader.Read())
                    {
                        oUsuario = new Usuario();
                        oUsuario.UsuarioID = int.Parse(reader["UsuarioID"].ToString());
                        oUsuario.Nombre = reader["Nombre"].ToString();
                        oUsuario.Contrasenna = reader["Contrasenna"].ToString();
                        oUsuario.RolID = new Rol
                        {
                            RolID = int.Parse(reader["RolID"].ToString())
                        };
                        oUsuario.Estado = bool.Parse(reader["Estado"].ToString())? EstadoCatalogos.Activo : EstadoCatalogos.Inactivo;

                        lista.Add(oUsuario);
                    }
                }
                return lista;
            }
            catch (SqlException er)
            {
                _myLogControlEventos.ErrorFormat("Error {0}", msg.ToExceptionDetail(MethodBase.GetCurrentMethod(), er, command));
                throw new CustomException(msg.ToSqlServerDetailError(er));
            }
            catch (Exception er)
            {
                msg = msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod());
                _myLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                throw;
            }
        }

        public Usuario GetById(string nombre)
        {
            SqlCommand command = new SqlCommand();
            IDataReader reader = null;
            Usuario oUsuario = null;
            string msg = "";

            try
            {
                command.CommandText = "dbo.usp_SELECT_Usuario_ByID";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Nombre", nombre);

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    reader = db.ExecuteReader(command);

                    if (reader.Read())
                    {

                        oUsuario = new Usuario();
                        oUsuario.UsuarioID = int.Parse(reader["UsuarioID"].ToString());
                        oUsuario.Nombre = reader["Nombre"].ToString();
                        oUsuario.Contrasenna = reader["Contrasenna"].ToString();
                        oUsuario.RolID = new Rol
                        {
                            RolID = int.Parse(reader["RolID"].ToString())
                        };
                        oUsuario.Estado = bool.Parse(reader["Estado"].ToString()) ? EstadoCatalogos.Activo : EstadoCatalogos.Inactivo;
                    }
                }

                return oUsuario;
            }
            catch (SqlException er)
            {
                _myLogControlEventos.ErrorFormat("Error {0}", msg.ToExceptionDetail(MethodBase.GetCurrentMethod(), er, command));
                throw new CustomException(msg.ToSqlServerDetailError(er));
            }
            catch (Exception er)
            {
                msg = msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod());
                _myLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                throw;
            }
        }

        public Usuario Login(string nombre, string Contrasenna) 
        {
            SqlCommand command = new SqlCommand();
            IDataReader reader = null;
            Usuario oUsuario = null;
            string msg = "";
            try
            {
                command.CommandText = "dbo.usp_SELECT_Usuario_Login";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Nombre", nombre);
                command.Parameters.AddWithValue("@Contrasenna", Contrasenna);

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    reader = db.ExecuteReader(command);

                    while (reader.Read())
                    {
                        oUsuario = new Usuario();
                        oUsuario.UsuarioID = int.Parse(reader["UsuarioID"].ToString());
                        oUsuario.Nombre = reader["Nombre"].ToString();
                        oUsuario.Contrasenna = reader["Contrasenna"].ToString();
                        oUsuario.RolID = new Rol
                        {
                            RolID = int.Parse(reader["RolID"].ToString())
                        };
                        oUsuario.Estado = bool.Parse(reader["Estado"].ToString()) ? EstadoCatalogos.Activo : EstadoCatalogos.Inactivo;
                    }
                }

                return oUsuario;
            }
            catch (SqlException er)
            {
                _myLogControlEventos.ErrorFormat("Error {0}", msg.ToExceptionDetail(MethodBase.GetCurrentMethod(), er, command));
                throw new CustomException(msg.ToSqlServerDetailError(er));
            }
            catch (Exception er)
            {
                msg = msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod());
                _myLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                throw;
            }
        }

        public Usuario Save(Usuario pUsuario)
        {
            string msg = "";
            SqlCommand command = new SqlCommand();
            Usuario oUsuario = null;
            double row = 0;
            try
            {

                command.CommandText = "dbo.usp_INSERT_Usuario";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Nombre", pUsuario.Nombre);
                command.Parameters.AddWithValue("@Contrasenna", pUsuario.Contrasenna);
                command.Parameters.AddWithValue("@RolID", pUsuario.RolID.RolID);
                command.Parameters.AddWithValue("@Estado", pUsuario.Estado == EstadoCatalogos.Activo ? true : false);


                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    row = db.ExecuteNonQuery(command, IsolationLevel.ReadCommitted);
                }

                if (row > 0)
                    oUsuario = GetById(pUsuario.Nombre);

                return oUsuario;
            }
            catch (SqlException er)
            {
                _myLogControlEventos.ErrorFormat("Error {0}", msg.ToExceptionDetail(MethodBase.GetCurrentMethod(), er, command));
                throw new CustomException(msg.ToSqlServerDetailError(er));
            }
            catch (Exception er)
            {
                msg = msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod());
                _myLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                throw;
            }
        }

        public Usuario Update(Usuario pUsuario)
        {
            SqlCommand command = new SqlCommand();
            Usuario oUsuario = null;
            double row = 0;
            string msg = "";
            try
            {
                command.CommandText = "dbo.usp_UPDATE_Usuario";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@UsuarioID", pUsuario.UsuarioID);
                command.Parameters.AddWithValue("@Nombre", pUsuario.Nombre);
                command.Parameters.AddWithValue("@Contrasenna", pUsuario.Contrasenna);
                command.Parameters.AddWithValue("@RolID", pUsuario.RolID.RolID);
                command.Parameters.AddWithValue("@Estado", pUsuario.Estado == EstadoCatalogos.Activo ? true : false);


                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    row = db.ExecuteNonQuery(command, IsolationLevel.ReadCommitted);
                }

                if (row > 0)
                    oUsuario = GetById(pUsuario.Nombre);

                return oUsuario;
            }
            catch (SqlException er)
            {
                _myLogControlEventos.ErrorFormat("Error {0}", msg.ToExceptionDetail(MethodBase.GetCurrentMethod(), er, command));
                throw new CustomException(msg.ToSqlServerDetailError(er));
            }
            catch (Exception er)
            {
                msg = msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod());
                _myLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                throw;
            }
        }
    }
}
