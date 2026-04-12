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
    public class FacturaDetalleDAL : IFacturaDetalleDAL
    {
        private static readonly ILog _myLogControlEventos = LogManager.GetLogger("MyControlEventos");

        public List<FacturaDetalle> GetByFacturaId(int facturaId)
        {
            List<FacturaDetalle> lista = new List<FacturaDetalle>();
            SqlCommand command = new SqlCommand();
            string msg = "";
            try
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.usp_SELECT_FacturaDetalle_ByFacturaID";
                command.Parameters.AddWithValue("@FacturaID", facturaId);

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    using (IDataReader reader = db.ExecuteReader(command))
                    {
                        while (reader.Read())
                        {
                            FacturaDetalle oDetalle = new FacturaDetalle
                            {
                                DetalleID = Convert.ToInt32(reader["DetalleID"]),
                                Cantidad = Convert.ToInt32(reader["Cantidad"]),
                                Precio = Convert.ToDouble(reader["Precio"]),
                                Subtotal = Convert.ToDouble(reader["Subtotal"]),
                                IVA = Convert.ToDouble(reader["IVA"]),
                                Total = Convert.ToDouble(reader["Total"]),
                                Factura = new Factura
                                {
                                    FacturaID = Convert.ToInt32(reader["FacturaID"])
                                },
                                Producto = new Producto
                                {
                                    ProductoID = Convert.ToInt32(reader["ProductoID"]),
                                    Nombre = reader["Nombre"].ToString()  
                                }
                            };
                            lista.Add(oDetalle);
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

        public void Save(FacturaDetalle detalle)
        {
            SqlCommand command = new SqlCommand();
            string msg = "";
            try
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.usp_INSERT_FacturaDetalle";

                command.Parameters.AddWithValue("@FacturaID", detalle.Factura.FacturaID);
                command.Parameters.AddWithValue("@ProductoID", detalle.Producto.ProductoID);
                command.Parameters.AddWithValue("@Cantidad", detalle.Cantidad);
                command.Parameters.AddWithValue("@Precio", detalle.Precio);
                command.Parameters.AddWithValue("@Subtotal", detalle.Subtotal);
                command.Parameters.AddWithValue("@IVA", detalle.IVA);
                command.Parameters.AddWithValue("@Total", detalle.Total);

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    db.ExecuteNonQuery(command);
                }
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
