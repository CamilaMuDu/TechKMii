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
    public class MarcaDAL : IMarcaDAL
    {
        private static readonly ILog _myLogControlEventos = LogManager.GetLogger("MyControlEventos");
        public bool Delete(int MarcaID)
        {
            StringBuilder conexion = new StringBuilder();
            SqlCommand command = new SqlCommand();
            string msg = "";
            double row = 0;
            try
            {
                command.CommandText = "dbo.usp_DELETE_Marca_ByID";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@MarcaID", MarcaID);

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

        public IEnumerable<Marca> GetAll()
        {
            List<Marca> lista = new List<Marca>();
            SqlCommand command = new SqlCommand();
            string msg = "";

            try
            {
                command.CommandText = "dbo.usp_SELECT_Marca_All";
                command.CommandType = CommandType.StoredProcedure;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    using (IDataReader reader = db.ExecuteReader(command))
                    {
                        while (reader.Read())
                        {
                            Marca oMarca = new Marca
                            {
                                MarcaID = Convert.ToInt32(reader["MarcaID"]),
                                Nombre = reader["Nombre"].ToString(),
                                Estado = (EstadoCatalogos)Convert.ToInt32(reader["Estado"])
                            };
                            lista.Add(oMarca);
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

        public Marca GetById(int MarcaID)
        {
            Marca oMarca = null;
            SqlCommand command = new SqlCommand();
            string msg = "";

            command.CommandText = "dbo.usp_SELECT_Marca_ByID";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@MarcaID", MarcaID);

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    using (IDataReader reader = db.ExecuteReader(command))
                    {
                        if (reader.Read())
                        {
                            oMarca = new Marca
                            {
                                MarcaID = Convert.ToInt32(reader["MarcaID"]),
                                Nombre = reader["Nombre"].ToString(),
                                Estado = (EstadoCatalogos)Convert.ToInt32(reader["Estado"])
                            };
                        }
                    }
                }
                return oMarca;
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

        public Marca Save(Marca pMarca)
        {
            Marca oMarca = null;
            SqlCommand command = new SqlCommand();
            int row = 0;
            string msg = "";

            command.CommandText = "dbo.usp_INSERT_Marca";
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Nombre", pMarca.Nombre);
            command.Parameters.AddWithValue("@Estado", (int)pMarca.Estado);
            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    object result = db.ExecuteScalar(command);
                    int nuevoId = Convert.ToInt32(result);

                    oMarca = GetById(nuevoId);
                }
                return oMarca;
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

        public Marca Update(Marca pMarca)
        {
            Marca oMarca = null;
            SqlCommand command = new SqlCommand();
            int row = 0;
            string msg = "";

            command.CommandText = "dbo.usp_UPDATE_Marca";
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@MarcaID", pMarca.MarcaID);
            command.Parameters.AddWithValue("@Nombre", pMarca.Nombre);
            command.Parameters.AddWithValue("@Estado", (int)pMarca.Estado);

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    row = Convert.ToInt32(db.ExecuteNonQuery(command));
                }

                if (row > 0)
                    oMarca = GetById(pMarca.MarcaID);

                return oMarca;
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
