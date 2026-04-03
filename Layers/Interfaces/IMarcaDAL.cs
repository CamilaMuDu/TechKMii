using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechKMii.Layers.Entities;

namespace TechKMii.Layers.Interfaces
{
    public interface IMarcaDAL
    {
        IEnumerable<Marca> GetAll();
        Marca GetById(int MarcaID);
        Marca Save(Marca pMarca);
        Marca Update(Marca pMarca);
        bool Delete(int MarcaID);
    }
}
