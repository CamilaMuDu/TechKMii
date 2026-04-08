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
    public class ProveedorDAL : IProveedorDAL
    {
        private static readonly ILog _myLogControlEventos = LogManager.GetLogger("MyControlEventos");
        public bool Delete(int ProveedorID)
        {
            SqlCommand command = new SqlCommand();
            string msg = "";
            double row = 0;

            try
            {
                command.CommandText = "dbo.usp_DELETE_Proveedor_ByID";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ProveedorID", ProveedorID);

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    row = db.ExecuteNonQuery(command, IsolationLevel.ReadCommitted);
                }

                return row > 0;
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

        public IEnumerable<Proveedor> GetAll()
        {
            List<Proveedor> lista = new List<Proveedor>();
            SqlCommand command = new SqlCommand();
            string msg = "";

            try
            {
                command.CommandText = "dbo.usp_SELECT_Proveedor_All";
                command.CommandType = CommandType.StoredProcedure;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    using (IDataReader reader = db.ExecuteReader(command))
                    {
                        while (reader.Read())
                        {                         
                            Proveedor oProveedor = new Proveedor
                            {
                                ProveedorID = Convert.ToInt32(reader["ProveedorID"]),
                                Nombre = reader["Nombre"].ToString(),
                                Estado = (EstadoCatalogos)Convert.ToInt32(reader["Estado"])
                            };
                            lista.Add(oProveedor);
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

        public Proveedor GetById(int ProveedorID)
        {
            Proveedor oProveedor = null;
            SqlCommand command = new SqlCommand();
            string msg = "";

            command.CommandText = "dbo.usp_SELECT_Proveedor_ByID";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@ProveedorID", ProveedorID);

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    using (IDataReader reader = db.ExecuteReader(command))
                    {
                        if (reader.Read())
                        {
                            oProveedor = new Proveedor
                            {
                                ProveedorID = Convert.ToInt32(reader["ProveedorID"]),
                                Nombre = reader["Nombre"].ToString(),
                                Estado = (EstadoCatalogos)Convert.ToInt32(reader["Estado"])
                            };
                        }
                    }
                }
                return oProveedor;
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

        public Proveedor Save(Proveedor pProveedor)
        {
            Proveedor oProveedor = null;
            SqlCommand command = new SqlCommand();
            string msg = "";

            command.CommandText = "dbo.usp_INSERT_Proveedor";
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Nombre", pProveedor.Nombre);
            command.Parameters.AddWithValue("@Estado", (int)pProveedor.Estado);
            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    object result = db.ExecuteScalar(command);
                    int nuevoId = Convert.ToInt32(result);

                    oProveedor = GetById(nuevoId);
                }
                return oProveedor;
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

        public Proveedor Update(Proveedor pProveedor)
        {
            Proveedor oProveedor = null;
            SqlCommand command = new SqlCommand();
            int row = 0;
            string msg = "";

            command.CommandText = "dbo.usp_UPDATE_Proveedor";
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@ProveedorID", pProveedor.ProveedorID);
            command.Parameters.AddWithValue("@Nombre", pProveedor.Nombre);
            command.Parameters.AddWithValue("@Estado", (int)pProveedor.Estado);

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    row = Convert.ToInt32(db.ExecuteNonQuery(command));
                }

                if (row > 0)
                    oProveedor = GetById(pProveedor.ProveedorID);

                return oProveedor;
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
