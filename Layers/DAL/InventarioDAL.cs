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
    public class InventarioDAL : IInventarioDAL
    {
        private static readonly ILog _myLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");
        IInventarioBLL inventarioBLL;
        Inventario oInventario;


        public async Task<bool> Delete(string id)
        {
            int rows = 0;
            string msg = "";
            SqlCommand command = new SqlCommand();

            try
            {
                command.CommandText = "dbo.usp_DELETE_Inventario_ByID";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@InventarioID", Convert.ToInt32(id));

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    rows = await db.ExecuteNonQueryAsync(command, IsolationLevel.ReadCommitted);
                }

                return rows > 0;
            }
            catch (SqlException er)
            {
                _myLogControlEventos.ErrorFormat("Error {0}",
                    msg.ToExceptionDetail(MethodBase.GetCurrentMethod(), er, command));
                throw new CustomException(msg.ToSqlServerDetailError(er));
            }
            catch (Exception er)
            {
                msg = msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod());
                _myLogControlEventos.ErrorFormat("Error {0}", msg);
                throw;
            }
        }

        public async Task<IEnumerable<Inventario>> GetAll()
        {
            List<Inventario> lista = new List<Inventario>();
            string msg = "";
            SqlCommand command = new SqlCommand();

            try
            {
                command.CommandText = "dbo.usp_SELECT_Inventario_All";
                command.CommandType = CommandType.StoredProcedure;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    using (IDataReader reader = await db.ExecuteReaderAsync(command))
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Inventario
                            {
                                InventarioID = reader["InventarioID"] != DBNull.Value ? Convert.ToInt32(reader["InventarioID"]) : 0,
                                TipoEntradaSalida = reader["TipoEntradaSalida"] != DBNull.Value
                                     ? (TipoEntradaSalida)Enum.Parse(typeof(TipoEntradaSalida), reader["TipoEntradaSalida"].ToString())
                                     : TipoEntradaSalida.Entrada,
                                Fecha = reader["Fecha"] != DBNull.Value ? Convert.ToDateTime(reader["Fecha"]) : DateTime.Now,
                                Observaciones = reader["Observaciones"] != DBNull.Value ? reader["Observaciones"].ToString() : null,
                                Estado = reader["Estado"] != DBNull.Value
                                     ? (EstadoCatalogos)Convert.ToInt32(reader["Estado"])
                                     : EstadoCatalogos.Activo,
                                Producto = new Producto
                                {
                                    ProductoID = reader["ProductoID"] != DBNull.Value ? Convert.ToInt32(reader["ProductoID"]) : 0
                                }
                            });
                        }
                    }
                }

                return lista;
            }
            catch (SqlException er)
            {
                _myLogControlEventos.ErrorFormat("Error {0}",
                    msg.ToExceptionDetail(MethodBase.GetCurrentMethod(), er, command));
                throw new CustomException(msg.ToSqlServerDetailError(er));
            }
            catch (Exception er)
            {
                msg = msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod());
                _myLogControlEventos.ErrorFormat("Error {0}", msg);
                throw;
            }
        }

        public async Task<Inventario> GetById(int id)
        {
            string msg = "";
            SqlCommand command = new SqlCommand();

            try
            {
                command.CommandText = "dbo.usp_SELECT_Inventario_ByID";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@InventarioID", id);

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    using (IDataReader reader = await db.ExecuteReaderAsync(command))
                    {
                        if (reader.Read())
                        {
                            oInventario = new Inventario
                            {
                                InventarioID = reader["InventarioID"] != DBNull.Value ? Convert.ToInt32(reader["InventarioID"]) : 0,
                                TipoEntradaSalida = reader["TipoEntradaSalida"] != DBNull.Value
                                    ? (TipoEntradaSalida)Enum.Parse(typeof(TipoEntradaSalida), reader["TipoEntradaSalida"].ToString())
                                    : TipoEntradaSalida.Entrada,
                                Fecha = reader["Fecha"] != DBNull.Value ? Convert.ToDateTime(reader["Fecha"]) : DateTime.Now,
                                Observaciones = reader["Observaciones"] != DBNull.Value ? reader["Observaciones"].ToString() : null,
                                Estado = reader["Estado"] != DBNull.Value
                                    ? (EstadoCatalogos)Convert.ToInt32(reader["Estado"])
                                    : EstadoCatalogos.Activo,
                                Producto = new Producto
                                {
                                    ProductoID = reader["ProductoID"] != DBNull.Value ? Convert.ToInt32(reader["ProductoID"]) : 0
                                }
                            };
                        }
                    }
                }
                return oInventario;
            }
            catch (SqlException er)
            {
                _myLogControlEventos.ErrorFormat("Error {0}",
                    msg.ToExceptionDetail(MethodBase.GetCurrentMethod(), er, command));
                throw new CustomException(msg.ToSqlServerDetailError(er));
            }
            catch (Exception er)
            {
                msg = msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod());
                _myLogControlEventos.ErrorFormat("Error {0}", msg);
                throw;
            }
        }

        public async Task<Inventario> Save(Inventario inventario)
        {
            string msg = "";
            SqlCommand command = new SqlCommand();

            try
            {
                command.CommandText = "dbo.usp_INSERT_Inventario";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@TipoEntradaSalida", SqlDbType.VarChar, 20).Value =
                    inventario.TipoEntradaSalida.ToString();

                command.Parameters.Add("@ProductoID", SqlDbType.Int).Value =
                    inventario.Producto != null ? inventario.Producto.ProductoID : (object)DBNull.Value;

                command.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = inventario.Fecha;

                command.Parameters.Add("@Observaciones", SqlDbType.VarChar, 100).Value =
                    (object)inventario.Observaciones ?? DBNull.Value;

                command.Parameters.Add("@Estado", SqlDbType.Int).Value = (int)inventario.Estado;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    using (IDataReader reader = await db.ExecuteReaderAsync(command))
                    {
                        if (reader.Read())
                        {
                            oInventario = new Inventario
                            {
                                InventarioID = reader["InventarioID"] != DBNull.Value ? Convert.ToInt32(reader["InventarioID"]) : 0,
                                TipoEntradaSalida = reader["TipoEntradaSalida"] != DBNull.Value
                                    ? (TipoEntradaSalida)Enum.Parse(typeof(TipoEntradaSalida), reader["TipoEntradaSalida"].ToString())
                                    : TipoEntradaSalida.Entrada,
                                Fecha = reader["Fecha"] != DBNull.Value ? Convert.ToDateTime(reader["Fecha"]) : DateTime.Now,
                                Observaciones = reader["Observaciones"] != DBNull.Value ? reader["Observaciones"].ToString() : null,
                                Estado = reader["Estado"] != DBNull.Value
                                    ? (EstadoCatalogos)Convert.ToInt32(reader["Estado"])
                                    : EstadoCatalogos.Activo,
                                Producto = new Producto
                                {
                                    ProductoID = reader["ProductoID"] != DBNull.Value ? Convert.ToInt32(reader["ProductoID"]) : 0
                                }
                            };
                        }
                    }
                }
                return oInventario;
            }
            catch (SqlException er)
            {
                _myLogControlEventos.ErrorFormat("Error {0}",
                    msg.ToExceptionDetail(MethodBase.GetCurrentMethod(), er, command));
                throw new CustomException(msg.ToSqlServerDetailError(er));
            }
            catch (Exception er)
            {
                msg = msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod());
                _myLogControlEventos.ErrorFormat("Error {0}", msg);
                throw;
            }
        }

        public async Task<Inventario> Update(Inventario inventario)
        {
            string msg = "";
            SqlCommand command = new SqlCommand();

            try
            {
                command.CommandText = "dbo.usp_UPDATE_Inventario";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@InventarioID", SqlDbType.Int).Value = inventario.InventarioID;

                command.Parameters.Add("@TipoEntradaSalida", SqlDbType.VarChar, 20).Value =
                    inventario.TipoEntradaSalida.ToString();

                command.Parameters.Add("@ProductoID", SqlDbType.Int).Value =
                    inventario.Producto != null ? inventario.Producto.ProductoID : (object)DBNull.Value;

                command.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = inventario.Fecha;

                command.Parameters.Add("@Observaciones", SqlDbType.VarChar, 100).Value =
                    (object)inventario.Observaciones ?? DBNull.Value;

                command.Parameters.Add("@Estado", SqlDbType.Int).Value = (int)inventario.Estado;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    using (IDataReader reader = await db.ExecuteReaderAsync(command))
                    {
                        if (reader.Read())
                        {
                            oInventario = new Inventario
                            {
                                InventarioID = reader["InventarioID"] != DBNull.Value ? Convert.ToInt32(reader["InventarioID"]) : 0,
                                TipoEntradaSalida = reader["TipoEntradaSalida"] != DBNull.Value
                                    ? (TipoEntradaSalida)Enum.Parse(typeof(TipoEntradaSalida), reader["TipoEntradaSalida"].ToString())
                                    : TipoEntradaSalida.Entrada,
                                Fecha = reader["Fecha"] != DBNull.Value ? Convert.ToDateTime(reader["Fecha"]) : DateTime.Now,
                                Observaciones = reader["Observaciones"] != DBNull.Value ? reader["Observaciones"].ToString() : null,
                                Estado = reader["Estado"] != DBNull.Value
                                    ? (EstadoCatalogos)Convert.ToInt32(reader["Estado"])
                                    : EstadoCatalogos.Activo,
                                Producto = new Producto
                                {
                                    ProductoID = reader["ProductoID"] != DBNull.Value ? Convert.ToInt32(reader["ProductoID"]) : 0
                                }
                            };
                        }
                    }
                }
                return oInventario;
            }
            catch (SqlException er)
            {
                _myLogControlEventos.ErrorFormat("Error {0}",
                    msg.ToExceptionDetail(MethodBase.GetCurrentMethod(), er, command));
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
