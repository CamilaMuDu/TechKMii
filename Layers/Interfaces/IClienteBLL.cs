using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechKMii.Layers.Entities;

namespace TechKMii.Layers.Interfaces
{
    public interface IClienteBLL
    {
        List<Cliente> GetByFilter(string filtro);
        Cliente GetById(int clienteID);
        Task<IEnumerable<Cliente>> GetAll();
        Task<Cliente> Save(Cliente pCliente);
        Task<bool> Delete(int clienteID);
    }
}
