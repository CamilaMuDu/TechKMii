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
    public class MarcaBLL : IMarcaBLL
    {
        public bool Delete(int MarcaID)
        {
           IMarcaDAL marcaDAL = new MarcaDAL();
            return marcaDAL.Delete(MarcaID);
        }

        public IEnumerable<Marca> GetAll()
        {
            IMarcaDAL marcaDAL = new MarcaDAL();
            return marcaDAL.GetAll();
        }

        public Marca GetById(int MarcaID)
        {
           IMarcaDAL marcaDAL = new MarcaDAL();
            return marcaDAL.GetById(MarcaID);
        }

        public Marca Save(Marca pMarca)
        {
            IMarcaDAL marcaDAL = new MarcaDAL();
            if(pMarca.MarcaID == 0)
            {
                return marcaDAL.Save(pMarca);
            }
            else
            {
                return marcaDAL.Update(pMarca);
            }
        }

        public Marca Update(Marca pMarca)
        {
            IMarcaDAL marcaDAL = new MarcaDAL();
            return marcaDAL.Update(pMarca);
        }
    }
}
