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

        public bool Delete(string UsuarioID)
        {
            StringBuilder conexion = new StringBuilder();
            SqlCommand command = new SqlCommand();
            string msg = "";
            double row = 0;
            try
            {
                command.CommandText = "dbo.usp_DELETE_Usuario_ByID";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@UsuarioID", UsuarioID);

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
            List<Usuario> lista = new List<Usuario>();
            SqlCommand command = new SqlCommand();
            string msg = "";

            command.CommandText = "dbo.usp_SELECT_Usuario_All";
            command.CommandType = CommandType.StoredProcedure;

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    using (IDataReader reader = db.ExecuteReader(command))
                    {
                        while (reader.Read())
                        {
                            Usuario oUsuario = new Usuario
                            {
                                UsuarioID = reader["UsuarioID"].ToString(),
                                Nombre = reader["Nombre"].ToString(),
                                Contrasenna = reader["Contrasenna"].ToString(),
                                Estado = Convert.ToInt32(reader["Estado"]) == 1
                                    ? EstadoCatalogos.Activo
                                    : EstadoCatalogos.Inactivo,
                                RolID = new Rol
                                {
                                    RolID = Convert.ToInt32(reader["RolID"]),
                                    Descripcion = reader["Descripcion"].ToString(),
                                    Estado = Convert.ToInt32(reader["RolEstado"]) == 1
                                        ? EstadoCatalogos.Activo
                                        : EstadoCatalogos.Inactivo
                                }
                            };

                            lista.Add(oUsuario);
                        }
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

        public Usuario GetById(string UsuarioID)
        {
            Usuario oUsuario = null;
            SqlCommand command = new SqlCommand();
            string msg = "";

            command.CommandText = "dbo.usp_SELECT_Usuario_ByID";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@UsuarioID", UsuarioID);

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    using (IDataReader reader = db.ExecuteReader(command))
                    {
                        if (reader.Read())
                        {
                            oUsuario = new Usuario();
                            oUsuario.UsuarioID = reader["UsuarioID"].ToString();
                            oUsuario.Nombre = reader["Nombre"].ToString();
                            oUsuario.Contrasenna = reader["Contrasenna"].ToString();
                            oUsuario.Estado = Convert.ToInt32(reader["Estado"]) == 1
                                ? EstadoCatalogos.Activo
                                : EstadoCatalogos.Inactivo;

                            oUsuario.RolID = new Rol
                            {
                                RolID = Convert.ToInt32(reader["RolID"]),
                                Descripcion = reader["Descripcion"].ToString(),
                                Estado = Convert.ToInt32(reader["RolEstado"]) == 1
                                    ? EstadoCatalogos.Activo
                                    : EstadoCatalogos.Inactivo
                            };
                        }
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

        public Usuario Login(string UsuarioID, string contrasenna)
        {
            SqlCommand command = new SqlCommand();
            IDataReader reader = null;
            Usuario oUsuario = null;
            string msg = "";
            try
            {
                command.CommandText = "dbo.sp_LoginUsuario";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@UsuariioID", UsuarioID);
                command.Parameters.AddWithValue("@Contrasenna", contrasenna);

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    reader = db.ExecuteReader(command);
                    while (reader.Read())
                    {
                        oUsuario = new Usuario();
                        oUsuario.UsuarioID = reader["UsuarioID"].ToString();
                        oUsuario.Nombre = reader["Nombre"].ToString();
                        oUsuario.Contrasenna = reader["Contrasenna"].ToString();
                        oUsuario.RolID = new Rol
                        {
                            RolID = int.Parse(reader["RolID"].ToString()),
                            Descripcion = reader["Descripcion"].ToString(),
                            Estado = (EstadoCatalogos)Enum.Parse(typeof(EstadoCatalogos), reader["RolEstado"].ToString())
                        };
                        oUsuario.Estado = (EstadoCatalogos)Enum.Parse(typeof(EstadoCatalogos), reader["Estado"].ToString());
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
            Usuario oUsuario = null;
            SqlCommand command = new SqlCommand();
            int row = 0;
            string msg = "";

            command.CommandText = "dbo.usp_INSERT_Usuario";
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@UsuarioID", pUsuario.UsuarioID);
            command.Parameters.AddWithValue("@Nombre", pUsuario.Nombre);
            command.Parameters.AddWithValue("@Contrasenna", pUsuario.Contrasenna);
            command.Parameters.AddWithValue("@RolID", pUsuario.RolID.RolID);
            command.Parameters.AddWithValue("@Estado", (int)pUsuario.Estado);

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    row = Convert.ToInt32(db.ExecuteNonQuery(command));
                }

                if (row > 0)
                    oUsuario = GetById(pUsuario.UsuarioID);

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
            Usuario oUsuario = null;
            SqlCommand command = new SqlCommand();
            int row = 0;
            string msg = "";

            command.CommandText = "dbo.usp_UPDATE_Usuario";
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@UsuarioID", pUsuario.UsuarioID);
            command.Parameters.AddWithValue("@Nombre", pUsuario.Nombre);
            command.Parameters.AddWithValue("@Contrasenna", pUsuario.Contrasenna);
            command.Parameters.AddWithValue("@RolID", pUsuario.RolID.RolID);
            command.Parameters.AddWithValue("@Estado", (int)pUsuario.Estado);

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    row = Convert.ToInt32(db.ExecuteNonQuery(command));
                }

                if (row > 0)
                    oUsuario = GetById(pUsuario.UsuarioID);

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
