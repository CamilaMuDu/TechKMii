using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using log4net;
using TechKMii.Layers.Entities;
using TechKMii.Layers.Interfaces;
using UTN.Winform.Electronics.Extensions;

namespace TechKMii.Layers.DAL
{
    public class ClienteDAL : IClienteDAL
    {
        private static readonly ILog _myLogControlEventos = LogManager.GetLogger("MyControlEventos");

        public async Task<bool> Delete(int clienteID)
        {

            String msg = "";
            bool retorno = false;
            double rows = 0d;

            SqlCommand command = new SqlCommand();
            try
            {
                command.CommandText = "dbo.usp_DELETE_Cliente_ByID";    
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@ClienteID", clienteID);

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    rows = await db.ExecuteNonQueryAsync(command, IsolationLevel.ReadCommitted);
                }

                if (rows > 0)
                    retorno = true;

                return retorno;
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

        public async Task<IEnumerable<Cliente>> GetAll()
        {
            List<Cliente> lista = new List<Cliente>();
            SqlCommand command = new SqlCommand();
            string msg = "";
            try
            {
                command.CommandText = "dbo.usp_SELECT_Cliente_All";
                command.CommandType = CommandType.StoredProcedure;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    using (SqlDataReader reader = await db.ExecuteReaderAsync(command))
                    {
                        while (await reader.ReadAsync())
                        {
                            Cliente oCliente = new Cliente();

                            oCliente.ClienteID = Convert.ToInt32(reader["IdCliente"]);
                            oCliente.Nombre = reader["Nombre"].ToString();
                            oCliente.Apellidos = reader["Apellidos"].ToString();
                            oCliente.Sexo = (Sexo)reader["Sexo"];
                            oCliente.Telefono = reader["Telefono"].ToString();
                            oCliente.Correo = reader["Correo"].ToString();
                            oCliente.Direccion = reader["Direccion"].ToString();
                            oCliente.TipoIdentificacion = (TipoIdentificacion)reader["TipoIdentificacion"];
                            oCliente.Provincia = reader["ProvinciaID"].ToString();

                            if (reader["Fotografia"] != DBNull.Value)
                                oCliente.Fotografia = (byte[])reader["Fotografia"];
                            oCliente.Estado = (EstadoCatalogos)reader["Estado"];

                            lista.Add(oCliente);
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

        public List<Cliente> GetByFilter(string filtro)
        {

            DataSet ds = null;
            List<Cliente> lista = new List<Cliente>();
            SqlCommand command = new SqlCommand();
            string msg = "";
            try
            {
                command.CommandText = "dbo.usp_SELECT_Cliente_ByFilter";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Filtro", filtro);

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    ds = db.ExecuteReader(command, "query");
                }

                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Cliente oCliente = new Cliente();

                        oCliente.ClienteID = Convert.ToInt32(dr["IdCliente"]);
                        oCliente.Nombre = dr["Nombre"].ToString();
                        oCliente.Apellidos = dr["Apellidos"].ToString();
                        oCliente.Sexo = (Sexo)dr["Sexo"];
                        oCliente.Telefono = dr["Telefono"].ToString();
                        oCliente.Correo = dr["Correo"].ToString();
                        oCliente.Direccion = dr["Direccion"].ToString();
                        oCliente.TipoIdentificacion = (TipoIdentificacion)dr["TipoIdentificacion"];
                        oCliente.Provincia = dr["ProvinciaID"].ToString();

                        if (dr["Fotografia"] != DBNull.Value)
                            oCliente.Fotografia = (byte[])dr["Fotografia"];
                        oCliente.Estado = (EstadoCatalogos)dr["Estado"];

                        lista.Add(oCliente);
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

        public Cliente GetById(int clienteID)
        {

        }

        public Task<Cliente> Save(Cliente pCliente)
        {
            throw new NotImplementedException();
        }

        public Task<Cliente> Update(Cliente pCliente)
        {
            throw new NotImplementedException();
        }
    }
}
