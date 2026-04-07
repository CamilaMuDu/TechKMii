using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using log4net.Util;
using TechKMii.Layers.DAL;
using TechKMii.Layers.Entities;
using TechKMii.Layers.Interfaces;

namespace TechKMii.Layers.BLL
{
    public class ProveedorBLL : IProveedorBLL
    {
        IProveedorDAL proveedorDAL = new ProveedorDAL();
        public bool Delete(int ProveedorID)
        {
           return proveedorDAL.Delete(ProveedorID);
        }

        public IEnumerable<Proveedor> GetAll()
        {
            return proveedorDAL.GetAll();
        }

        public Proveedor GetById(int ProveedorID)
        {
            return proveedorDAL.GetById(ProveedorID);
        }

        public Proveedor Save(Proveedor pProveedor)
        {
            return proveedorDAL.Save(pProveedor);
        }

        public Proveedor Update(Proveedor pProveedor)
        {
            return proveedorDAL.Update(pProveedor);
        }
    }
}
