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
        IMarcaDAL marcaDAL = new MarcaDAL();
        public bool Delete(int MarcaID)
        {
            return marcaDAL.Delete(MarcaID);
        }

        public IEnumerable<Marca> GetAll()
        {
            return marcaDAL.GetAll();
        }

        public Marca GetById(int MarcaID)
        {
            return marcaDAL.GetById(MarcaID);
        }

        public Marca Save(Marca pMarca)
        {
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
            return marcaDAL.Update(pMarca);
        }
    }
}
