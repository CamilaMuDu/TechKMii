using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechKMii.Layers.Entities;

namespace TechKMii.Layers.Interfaces
{
    public interface ITipoDispositivoBLL
    {
        IEnumerable<TipoDispositivo> GetAll();
        TipoDispositivo GetById(int TipoID);
        TipoDispositivo Save(TipoDispositivo pTipoDispositivo);
        TipoDispositivo Update(TipoDispositivo pTipoDispositivo);
        bool Delete(int TipoID);
    }
}
