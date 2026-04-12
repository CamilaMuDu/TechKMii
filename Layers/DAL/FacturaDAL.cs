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
    public class FacturaDAL : IFacturaDAL
    {
        private static readonly ILog _myLogControlEventos = LogManager.GetLogger("MyControlEventos");

        public List<Factura> GetAll()
        {
            List<Factura> lista = new List<Factura>();
            SqlCommand command = new SqlCommand();
            string msg = "";

            try
            {               
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.usp_SELECT_Factura_All";

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    using (IDataReader reader = db.ExecuteReader(command))
                    {
                        while (reader.Read())
                        {
                            Factura oFactura = new Factura
                            {
                                FacturaID = Convert.ToInt32(reader["FacturaID"]),
                                Fecha = Convert.ToDateTime(reader["Fecha"]),
                                Subtotal = Convert.ToDouble(reader["Subtotal"]),
                                IVA = Convert.ToDouble(reader["IVA"]),
                                TotalCRC = Convert.ToDouble(reader["TotalCRC"]),
                                TotalUSD = Convert.ToDouble(reader["TotalUSD"]),
                                TipoCambio = Convert.ToDouble(reader["TipoCambio"]),
                                MetodoPago = (TipoMetodoPago)Enum.Parse(typeof(TipoMetodoPago), reader["MetodoPago"].ToString()),
                                EstadoFactura = (EstadoFactura)Convert.ToInt32(reader["EstadoFactura"])
                            };
                            lista.Add(oFactura);
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

        public Factura GetById(int id)
        {
            Factura oFactura = null;
            SqlCommand command = new SqlCommand();
            string msg = "";

            try
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.usp_SELECT_Factura_ByID";
                command.Parameters.AddWithValue("@FacturaID", id);

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    using (IDataReader reader = db.ExecuteReader(command))
                    {
                        if (reader.Read())
                        {
                            oFactura = new Factura
                            {
                                FacturaID = Convert.ToInt32(reader["FacturaID"]),
                                Fecha = Convert.ToDateTime(reader["Fecha"]),
                                Subtotal = Convert.ToDouble(reader["Subtotal"]),
                                IVA = Convert.ToDouble(reader["IVA"]),
                                TotalCRC = Convert.ToDouble(reader["TotalCRC"]),
                                TotalUSD = Convert.ToDouble(reader["TotalUSD"]),
                                TipoCambio = Convert.ToDouble(reader["TipoCambio"]),
                                MetodoPago = (TipoMetodoPago)Enum.Parse(typeof(TipoMetodoPago), reader["MetodoPago"].ToString()),
                                Banco = reader["Banco"] == DBNull.Value ? null : reader["Banco"].ToString(),
                                TipoTarjeta = reader["TipoTarjeta"] == DBNull.Value
                                    ? default(TipoTarjeta)
                                    : (TipoTarjeta)Enum.Parse(typeof(TipoTarjeta), reader["TipoTarjeta"].ToString()),
                                FacturaXML = reader["FacturaXML"] == DBNull.Value ? null : reader["FacturaXML"].ToString(),
                                Documento = reader["Documento"] == DBNull.Value ? null : (byte[])reader["Documento"],
                                Firma = reader["Firma"] == DBNull.Value ? null : (byte[])reader["Firma"],
                                EstadoFactura = (EstadoFactura)Convert.ToInt32(reader["EstadoFactura"]),
                                Cliente = new Cliente
                                {
                                    ClienteID = reader["ClienteID"] == DBNull.Value ? 0 : Convert.ToInt32(reader["ClienteID"])
                                },
                                Usuario = new Usuario
                                {
                                    UsuarioID = reader["UsuarioID"] == DBNull.Value ? null : reader["UsuarioID"].ToString()
                                }
                            };
                        }
                    }
                }
                return oFactura;
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

        public int Save(Factura factura)
        {
            int idGenerado = 0;
            SqlCommand command = new SqlCommand();
            string msg = "";
            try
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.usp_INSERT_Factura";

                command.Parameters.AddWithValue("@ClienteID", factura.Cliente.ClienteID);
                command.Parameters.AddWithValue("@UsuarioID", factura.Usuario.UsuarioID);
                command.Parameters.AddWithValue("@Fecha", factura.Fecha);
                command.Parameters.AddWithValue("@Subtotal", factura.Subtotal);
                command.Parameters.AddWithValue("@IVA", factura.IVA);
                command.Parameters.AddWithValue("@TotalCRC", factura.TotalCRC);
                command.Parameters.AddWithValue("@TotalUSD", factura.TotalUSD);
                command.Parameters.AddWithValue("@TipoCambio", factura.TipoCambio);
                command.Parameters.AddWithValue("@MetodoPago", factura.MetodoPago.ToString());
                command.Parameters.AddWithValue("@Banco", (object)factura.Banco ?? DBNull.Value);
                command.Parameters.AddWithValue("@TipoTarjeta",factura.MetodoPago == TipoMetodoPago.TarjetaCredito ? (object)factura.TipoTarjeta.ToString(): DBNull.Value);
                command.Parameters.AddWithValue("@FacturaXML", (object)factura.FacturaXML ?? DBNull.Value);
                command.Parameters.AddWithValue("@Documento", (object)factura.Documento ?? DBNull.Value);
                command.Parameters.AddWithValue("@NumeroTarjeta", (object)factura.NumeroTarjeta ?? DBNull.Value);
                command.Parameters.AddWithValue("@NumeroTransferencia", (object)factura.NumeroTransferencia ?? DBNull.Value);
                command.Parameters.AddWithValue("@NumeroSinpe", (object)factura.NumeroSinpe ?? DBNull.Value);
                command.Parameters.AddWithValue("@Firma", (object)factura.Firma ?? DBNull.Value);
                command.Parameters.AddWithValue("@EstadoFactura", (int)factura.EstadoFactura);

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    object resultado = db.ExecuteScalar(command);

                    if (resultado != null)
                        idGenerado = Convert.ToInt32(resultado);
                }
                return idGenerado;
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
