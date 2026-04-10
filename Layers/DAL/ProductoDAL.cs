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
    public class ProductoDAL : IProductoDAL
    {
        private static readonly ILog _myLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");
        public async Task<bool> Delete(string id)
        {
            int rows = 0;
            string msg = "";
            SqlCommand command = new SqlCommand();

            try
            {
                command.CommandText = "dbo.usp_DELETE_Producto_ByID";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ProductoID", Convert.ToInt32(id));

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
       
        public async Task<IEnumerable<Producto>> GetAll()
        {
            List<Producto> lista = new List<Producto>();
            string msg = "";
            SqlCommand command = new SqlCommand();

            try
            {
                command.CommandText = "dbo.usp_SELECT_Producto_All";
                command.CommandType = CommandType.StoredProcedure;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    using (IDataReader reader = await db.ExecuteReaderAsync(command))
                    {
                        while (reader.Read())
                        {
                            lista.Add(MapProducto(reader));
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

        public async Task<IEnumerable<Producto>> GetByFilter(string filtro)
        {
            List<Producto> lista = new List<Producto>();
            string msg = "";
            SqlCommand command = new SqlCommand();

            try
            {
                command.CommandText = "dbo.usp_SELECT_Producto_ByFilter";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Filtro", filtro);

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    using (IDataReader reader = await db.ExecuteReaderAsync(command))
                    {
                        while (reader.Read())
                        {
                            lista.Add(MapProducto(reader));
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

        public async Task<Producto> GetById(string id)
        {
            Producto oProducto = null;
            string msg = "";
            SqlCommand command = new SqlCommand();

            try
            {
                command.CommandText = "dbo.usp_SELECT_Producto_ByID";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ProductoID", Convert.ToInt32(id));

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    using (IDataReader reader = await db.ExecuteReaderAsync(command))
                    {
                        if (reader.Read())
                        {
                            oProducto = MapProducto(reader);
                        }
                    }
                }

                return oProducto;
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

        public async Task<Producto> Save(Producto producto)
        {
            Producto oProducto = null;
            string msg = "";
            SqlCommand command = new SqlCommand();

            try
            {
                command.CommandText = "dbo.usp_INSERT_Producto";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@Nombre", SqlDbType.VarChar, 100).Value = (object)producto.Nombre ?? DBNull.Value;

                command.Parameters.Add("@CodigoBarras", SqlDbType.VarChar, 20).Value =
                    (object)producto.CodigoBarras ?? DBNull.Value;

                command.Parameters.Add("@TipoID", SqlDbType.Int).Value =
                    producto.Tipo != null ? producto.Tipo.TipoID : (object)DBNull.Value;

                command.Parameters.Add("@ProveedorID", SqlDbType.Int).Value =
                    producto.Proveedor != null ? producto.Proveedor.ProveedorID : (object)DBNull.Value;

                command.Parameters.Add("@MarcaID", SqlDbType.Int).Value =
                    producto.Marca != null ? producto.Marca.MarcaID : (object)DBNull.Value;

                command.Parameters.Add("@Modelo", SqlDbType.VarChar, 100).Value =
                    (object)producto.Modelo ?? DBNull.Value;

                command.Parameters.Add("@Precio", SqlDbType.Decimal).Value = producto.Precio;

                command.Parameters.Add("@CantidadStock", SqlDbType.Int).Value = producto.CantidadStock;

                command.Parameters.Add("@Color", SqlDbType.VarChar, 50).Value =
                    (object)producto.Color ?? DBNull.Value;

                command.Parameters.Add("@Caracteristicas", SqlDbType.VarChar).Value =
                    (object)producto.Caracteristicas ?? DBNull.Value;

                command.Parameters.Add("@DocEspecificaciones", SqlDbType.VarBinary, -1).Value =
                    (object)producto.DocEspecificaciones ?? DBNull.Value;

                command.Parameters.Add("@Extras", SqlDbType.VarChar).Value =
                    (object)producto.Extras ?? DBNull.Value;

                command.Parameters.Add("@Fotografia", SqlDbType.VarBinary, -1).Value =
                    (object)producto.Fotografia ?? DBNull.Value;

                command.Parameters.Add("@Estado", SqlDbType.Int).Value = (int)producto.Estado;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    using (IDataReader reader = await db.ExecuteReaderAsync(command))
                    {
                        if (reader.Read())
                        {
                            oProducto = MapProductoInsertUpdate(reader);
                        }
                    }
                }

                return oProducto;
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

        public async Task<Producto> Update(Producto producto)
        {
            Producto oProducto = null;
            string msg = "";
            SqlCommand command = new SqlCommand();

            try
            {
                command.CommandText = "dbo.usp_UPDATE_Producto";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@ProductoID", SqlDbType.Int).Value = producto.ProductoID;

                command.Parameters.Add("@Nombre", SqlDbType.VarChar, 100).Value =
                    (object)producto.Nombre ?? DBNull.Value;

                command.Parameters.Add("@CodigoBarras", SqlDbType.VarChar, 20).Value =
                    (object)producto.CodigoBarras ?? DBNull.Value;

                command.Parameters.Add("@TipoID", SqlDbType.Int).Value =
                    producto.Tipo != null ? producto.Tipo.TipoID : (object)DBNull.Value;

                command.Parameters.Add("@ProveedorID", SqlDbType.Int).Value =
                    producto.Proveedor != null ? producto.Proveedor.ProveedorID : (object)DBNull.Value;

                command.Parameters.Add("@MarcaID", SqlDbType.Int).Value =
                    producto.Marca != null ? producto.Marca.MarcaID : (object)DBNull.Value;

                command.Parameters.Add("@Modelo", SqlDbType.VarChar, 100).Value =
                    (object)producto.Modelo ?? DBNull.Value;

                command.Parameters.Add("@Precio", SqlDbType.Decimal).Value = producto.Precio;

                command.Parameters.Add("@CantidadStock", SqlDbType.Int).Value = producto.CantidadStock;

                command.Parameters.Add("@Color", SqlDbType.VarChar, 50).Value =
                    (object)producto.Color ?? DBNull.Value;

                command.Parameters.Add("@Caracteristicas", SqlDbType.VarChar).Value =
                    (object)producto.Caracteristicas ?? DBNull.Value;

                command.Parameters.Add("@DocEspecificaciones", SqlDbType.VarBinary, -1).Value =
                    (object)producto.DocEspecificaciones ?? DBNull.Value;

                command.Parameters.Add("@Extras", SqlDbType.VarChar).Value =
                    (object)producto.Extras ?? DBNull.Value;

                command.Parameters.Add("@Fotografia", SqlDbType.VarBinary, -1).Value =
                    (object)producto.Fotografia ?? DBNull.Value;

                command.Parameters.Add("@Estado", SqlDbType.Int).Value = (int)producto.Estado;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    using (IDataReader reader = await db.ExecuteReaderAsync(command))
                    {
                        if (reader.Read())
                        {
                            oProducto = MapProductoInsertUpdate(reader);
                        }
                    }
                }

                return oProducto;
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
        private Producto MapProducto(IDataReader reader)
        {
            Producto oProducto = new Producto
            {
                ProductoID = reader["ProductoID"] != DBNull.Value ? Convert.ToInt32(reader["ProductoID"]) : 0,
                Nombre = reader["Nombre"] != DBNull.Value ? reader["Nombre"].ToString() : null,
                CodigoBarras = reader["CodigoBarras"] != DBNull.Value ? reader["CodigoBarras"].ToString(): null,
                Modelo = reader["Modelo"] != DBNull.Value ? reader["Modelo"].ToString() : null,
                Precio = reader["Precio"] != DBNull.Value ? Convert.ToDouble(reader["Precio"]) : 0,
                CantidadStock = reader["CantidadStock"] != DBNull.Value ? Convert.ToInt32(reader["CantidadStock"]) : 0,
                Color = reader["Color"] != DBNull.Value ? reader["Color"].ToString() : null,
                Caracteristicas = reader["Caracteristicas"] != DBNull.Value ? reader["Caracteristicas"].ToString() : null,
                DocEspecificaciones = reader["DocEspecificaciones"] != DBNull.Value ? (byte[])reader["DocEspecificaciones"] : null,
                Extras = reader["Extras"] != DBNull.Value ? reader["Extras"].ToString() : null,
                Fotografia = reader["Fotografia"] != DBNull.Value ? (byte[])reader["Fotografia"] : null
            };

            oProducto.Tipo = new TipoDispositivo
            {
                TipoID = reader["TipoID"] != DBNull.Value ? Convert.ToInt32(reader["TipoID"]) : 0,
                Nombre = reader["NombreTipoDispositivo"] != DBNull.Value ? reader["NombreTipoDispositivo"].ToString() : null
            };

            oProducto.Proveedor = new Proveedor
            {
                ProveedorID = reader["ProveedorID"] != DBNull.Value ? Convert.ToInt32(reader["ProveedorID"]) : 0,
                Nombre = reader["NombreProveedor"] != DBNull.Value ? reader["NombreProveedor"].ToString() : null
            };

            oProducto.Marca = new Marca
            {
                MarcaID = reader["MarcaID"] != DBNull.Value ? Convert.ToInt32(reader["MarcaID"]) : 0,
                Nombre = reader["NombreMarca"] != DBNull.Value ? reader["NombreMarca"].ToString() : null
            };
        
             oProducto.Estado = reader["Estado"] != DBNull.Value ? (EstadoCatalogos)Convert.ToInt32(reader["Estado"]) : EstadoCatalogos.Activo;
            
            return oProducto;
        }

        private Producto MapProductoInsertUpdate(IDataReader reader)
        {
            Producto oProducto = new Producto
            {
                ProductoID = reader["ProductoID"] != DBNull.Value ? Convert.ToInt32(reader["ProductoID"]) : 0,
                Nombre = reader["Nombre"] != DBNull.Value ? reader["Nombre"].ToString() : null,
                CodigoBarras = reader["CodigoBarras"] != DBNull.Value ? reader["CodigoBarras"].ToString() : null,
                Modelo = reader["Modelo"] != DBNull.Value ? reader["Modelo"].ToString() : null,
                Precio = reader["Precio"] != DBNull.Value ? Convert.ToDouble(reader["Precio"]) : 0,
                CantidadStock = reader["CantidadStock"] != DBNull.Value ? Convert.ToInt32(reader["CantidadStock"]) : 0,
                Color = reader["Color"] != DBNull.Value ? reader["Color"].ToString() : null,
                Caracteristicas = reader["Caracteristicas"] != DBNull.Value ? reader["Caracteristicas"].ToString() : null,
                DocEspecificaciones = reader["DocEspecificaciones"] != DBNull.Value ? (byte[])reader["DocEspecificaciones"] : null,
                Extras = reader["Extras"] != DBNull.Value ? reader["Extras"].ToString() : null,
                Fotografia = reader["Fotografia"] != DBNull.Value ? (byte[])reader["Fotografia"] : null
            };

            oProducto.Tipo = new TipoDispositivo
            {
                TipoID = reader["TipoID"] != DBNull.Value ? Convert.ToInt32(reader["TipoID"]) : 0
            };

            oProducto.Proveedor = new Proveedor
            {
                ProveedorID = reader["ProveedorID"] != DBNull.Value ? Convert.ToInt32(reader["ProveedorID"]) : 0
            };

            oProducto.Marca = new Marca
            {
                MarcaID = reader["MarcaID"] != DBNull.Value ? Convert.ToInt32(reader["MarcaID"]) : 0
            };

            oProducto.Estado = reader["Estado"] != DBNull.Value ? (EstadoCatalogos)Convert.ToInt32(reader["Estado"]) : EstadoCatalogos.Activo;

            return oProducto;
        }
    }
}
