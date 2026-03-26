using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechKMii.Layers.DAL;
using TechKMii.Layers.Entities;
using TechKMii.Layers.Interfaces;

namespace TechKMii.Layers.BLL
{
    public class ClienteBLL : IClienteBLL
    {
        public Task<bool> Delete(int clienteID)
        {
            IClienteDAL dalCliente = new ClienteDAL();
            return dalCliente.Delete(clienteID);
        }

        public Task<IEnumerable<Cliente>> GetAll()
        {
            IClienteDAL dalCliente = new ClienteDAL();
            return dalCliente.GetAll();
        }

        public List<Cliente> GetByFilter(string filtro)
        {
            IClienteDAL dalCliente = new ClienteDAL();
            return dalCliente.GetByFilter(filtro);
        }

        public Cliente GetById(int clienteID)
        {
            IClienteDAL dalCliente = new ClienteDAL();
            return dalCliente.GetById(clienteID);
        }

        public Task<Cliente> Save(Cliente pCliente)
        {
            IClienteDAL dalCliente = new ClienteDAL();
            Task<Cliente> oCliente = null;

            if (dalCliente.GetById(pCliente.ClienteID) == null)
                oCliente = dalCliente.Save(pCliente);
            else
                oCliente = dalCliente.Update(pCliente);

            return oCliente;
        }
    }
}
