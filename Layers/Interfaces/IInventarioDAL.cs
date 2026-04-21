using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechKMii.Layers.Entities;

namespace TechKMii.Layers.Interfaces
{
    public interface IInventarioDAL
    {
        Task<bool> Delete(string id);
        Task<IEnumerable<Inventario>> GetAll();
        Task<Inventario> GetById(int id);
        Task<Inventario> Save(Inventario inventario);
        Task<Inventario> Update(Inventario inventario);
    }
}
