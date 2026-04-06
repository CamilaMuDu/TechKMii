using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechKMii.Layers.Entities;

namespace TechKMii.Layers.Interfaces
{
    public interface IClienteDAL
    {
        //List<Cliente> GetByFilter(string filtro);
        Task<IEnumerable<Cliente>> GetAll();
        Cliente GetById(int clienteID);
        Cliente GetByIdentificacion(string identificacion);
        Task<Cliente> Save(Cliente pCliente);
        Task<Cliente> Update(Cliente pCliente);
        Task<bool> Delete(int clienteID);
    }
}
