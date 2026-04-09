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
    public class ProductoBLL : IProductoBLL
    {
        IProductoDAL productoDAL = new ProductoDAL();
        public async Task<bool> Delete(string id)
        {
            return await productoDAL.Delete(id);
        }

        public async Task<IEnumerable<Producto>> GetAll()
        {
            return await productoDAL.GetAll();
        }

        public async Task<IEnumerable<Producto>> GetByFilter(string filtro)
        {
            return await productoDAL.GetByFilter(filtro);
        }

        public async Task<Producto> GetById(string id)
        {
            return await productoDAL.GetById(id);
        }

        public async Task<Producto> Save(Producto producto)
        {
            return await productoDAL.Save(producto);
        }

        public async Task<Producto> Update(Producto producto)
        {
            return await productoDAL.Update(producto);
        }
    }
}
