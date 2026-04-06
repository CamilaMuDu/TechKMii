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
    public class TipoDispositivoDAL : ITipoDispositivoDAL
    {
        private static readonly ILog _myLogControlEventos = LogManager.GetLogger("MyControlEventos");

        public bool Delete(int TipoID)
        {
            StringBuilder conexion = new StringBuilder();
            SqlCommand command = new SqlCommand();
            string msg = "";
            double row = 0;
            try
            {
                command.CommandText = "dbo.usp_DELETE_TipoDispositivo_ByID";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@TipoID", TipoID);

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

        public IEnumerable<TipoDispositivo> GetAll()
        {
            List<TipoDispositivo> lista = new List<TipoDispositivo>();
            SqlCommand command = new SqlCommand();
            string msg = "";

            try
            {
                command.CommandText = "dbo.usp_SELECT_TipoDispositivo_All";
                command.CommandType = CommandType.StoredProcedure;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    using (IDataReader reader = db.ExecuteReader(command))
                    {
                        while (reader.Read())
                        {
                            TipoDispositivo oTipoDispositivo = new TipoDispositivo();

                            oTipoDispositivo.TipoID = Convert.ToInt32(reader["TipoID"]);
                            oTipoDispositivo.Nombre = reader["Nombre"].ToString();
                            oTipoDispositivo.Estado = (EstadoCatalogos)Convert.ToInt32(reader["Estado"]);

                            lista.Add(oTipoDispositivo);
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
                _myLogControlEventos.ErrorFormat("Error {0}", msg);
                throw;
            }
        }

        public TipoDispositivo GetById(int TipoID)
        {
            TipoDispositivo oTipoDispositivo = null;
            SqlCommand command = new SqlCommand();
            string msg = "";

            try
            {
                command.CommandText = "dbo.usp_SELECT_TipoDispositivo_ByID";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@TipoID", TipoID);

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    using (IDataReader reader = db.ExecuteReader(command))
                    {
                        if (reader.Read())
                        {
                            oTipoDispositivo = new TipoDispositivo
                            {
                                TipoID = Convert.ToInt32(reader["TipoID"]),
                                Nombre = reader["Nombre"].ToString(),
                                Estado = (EstadoCatalogos)Convert.ToInt32(reader["Estado"])
                            };
                        }
                    }
                }

                return oTipoDispositivo;
            }
            catch (SqlException er)
            {
                _myLogControlEventos.ErrorFormat("Error {0}", msg.ToExceptionDetail(MethodBase.GetCurrentMethod(), er, command));
                throw new CustomException(msg.ToSqlServerDetailError(er));
            }
            catch (Exception er)
            {
                msg = msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod());
                _myLogControlEventos.ErrorFormat("Error {0}", msg);
                throw;
            }
        }

        public TipoDispositivo Save(TipoDispositivo pTipoDispositivo)
        {
            SqlCommand command = new SqlCommand();
            string msg = "";

            try
            {
                command.CommandText = "dbo.usp_INSERT_TipoDispositivo";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Nombre", pTipoDispositivo.Nombre);
                command.Parameters.AddWithValue("@Estado", (int)pTipoDispositivo.Estado);

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    db.ExecuteNonQuery(command, IsolationLevel.ReadCommitted);
                }

                return pTipoDispositivo;
            }
            catch (SqlException er)
            {
                _myLogControlEventos.ErrorFormat("Error {0}", msg.ToExceptionDetail(MethodBase.GetCurrentMethod(), er, command));
                throw new CustomException(msg.ToSqlServerDetailError(er));
            }
            catch (Exception er)
            {
                msg = msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod());
                _myLogControlEventos.ErrorFormat("Error {0}", msg);
                throw;
            }
        }

        public TipoDispositivo Update(TipoDispositivo pTipoDispositivo)
        {
            SqlCommand command = new SqlCommand();
            string msg = "";

            try
            {
                command.CommandText = "dbo.usp_UPDATE_TipoDispositivo";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@TipoID", pTipoDispositivo.TipoID);
                command.Parameters.AddWithValue("@Nombre", pTipoDispositivo.Nombre);
                command.Parameters.AddWithValue("@Estado", (int)pTipoDispositivo.Estado);

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    db.ExecuteNonQuery(command, IsolationLevel.ReadCommitted);
                }

                return pTipoDispositivo;
            }
            catch (SqlException er)
            {
                _myLogControlEventos.ErrorFormat("Error {0}", msg.ToExceptionDetail(MethodBase.GetCurrentMethod(), er, command));
                throw new CustomException(msg.ToSqlServerDetailError(er));
            }
            catch (Exception er)
            {
                msg = msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod());
                _myLogControlEventos.ErrorFormat("Error {0}", msg);
                throw;
            }      
        }
    }
}
