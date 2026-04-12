using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechKMii.Layers.Entities;

namespace TechKMii.Layers.Interfaces
{
    public interface IProductoDAL
    {
        Task<IEnumerable<Producto>> GetAll();
        //Task<Producto> GetById(string id);
        Task<Producto> GetById(int id);
        Task<IEnumerable<Producto>> GetByFilter(string filtro);
        Task<Producto> Save(Producto producto);
        Task<Producto> Update(Producto producto);
        Task<bool> Delete(string id);
    }
}
