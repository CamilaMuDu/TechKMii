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
    public class InventarioBLL : IInventarioBLL
    {
        IInventarioDAL inventarioDAL = new InventarioDAL();
        public async Task<bool> Delete(string id)
        {
            return await inventarioDAL.Delete(id);
        }

        public async Task<IEnumerable<Inventario>> GetAll()
        {
            return await inventarioDAL.GetAll();
        }

        public async Task<Inventario> GetById(int id)
        {
            return await inventarioDAL.GetById(id);
        }

        public async Task<Inventario> Save(Inventario inventario)
        {
            return await inventarioDAL.Save(inventario);
        }

        public async Task<Inventario> Update(Inventario inventario)
        {
            return await inventarioDAL.Update(inventario);
        }
    }
}
