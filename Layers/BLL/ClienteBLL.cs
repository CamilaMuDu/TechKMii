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
        IClienteDAL dalCliente = new ClienteDAL();
        public Task<bool> Delete(int clienteID)
        {
            return dalCliente.Delete(clienteID);
        }

        public Task<IEnumerable<Cliente>> GetAll()
        {
            return dalCliente.GetAll();
        }

        public Cliente GetById(int clienteID)
        {
            return dalCliente.GetById(clienteID);
        }

        public Cliente GetByIdentificacion(string identificacion)
        {
            return dalCliente.GetByIdentificacion(identificacion);
        }

        public Task<Cliente> Save(Cliente pCliente)
        { 
            Cliente clienteExistente = dalCliente.GetByIdentificacion(pCliente.Identificacion);
            return dalCliente.Save(pCliente);
        }

        public Task<Cliente> Update(Cliente pCliente)
        {
            Cliente clienteExistente = dalCliente.GetByIdentificacion(pCliente.Identificacion);
            return dalCliente.Update(pCliente);
        }

        public IEnumerable<Cliente> GetAllSync()
        {
            IClienteDAL dalCliente = new ClienteDAL();
            return dalCliente.GetAllSync();
        }

        //public List<Cliente> GetByFilter(string filtro)
        //{
        //    IClienteDAL dalCliente = new ClienteDAL();
        //    return dalCliente.GetByFilter(filtro);
        //}
    }
}
