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
    public class RolDAL : IRolDAL
    {
        private static readonly ILog _myLogControlEventos = LogManager.GetLogger("MyControlEventos");
        public List<Rol> GetAll()
        {
            List<Rol> lista = new List<Rol>();
            SqlCommand command = new SqlCommand();
            string msg = "";

            command.CommandText = "dbo.usp_SELECT_Rol_All";
            command.CommandType = CommandType.StoredProcedure;
            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    using (IDataReader reader = db.ExecuteReader(command))
                    {
                        while (reader.Read())
                        {
                            Rol oRol = new Rol
                            {
                               RolID = Convert.ToInt32(reader["RolID"]),
                               Descripcion = reader["Descripcion"].ToString(),
                               Estado = (EstadoCatalogos) Convert.ToInt32(reader["Estado"])
                            };
                            lista.Add(oRol);
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
    }
}
