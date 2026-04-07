using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechKMii.Layers.Entities;

namespace TechKMii.Layers.Interfaces
{
    public interface IProveedorBLL
    {
        IEnumerable<Proveedor> GetAll();
        Proveedor GetById(int ProveedorID);
        Proveedor Save(Proveedor pProveedor);
        Proveedor Update(Proveedor pProveedor);
        bool Delete(int ProveedorID);
    }
}
