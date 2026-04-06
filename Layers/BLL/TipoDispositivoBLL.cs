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
    public class TipoDispositivoBLL : ITipoDispositivoBLL
    {
        ITipoDispositivoDAL tipoDispositivoDAL = new TipoDispositivoDAL();
        public bool Delete(int TipoID)
        {
            return tipoDispositivoDAL.Delete(TipoID);
        }

        public IEnumerable<TipoDispositivo> GetAll()
        {
            return tipoDispositivoDAL.GetAll();
        }

        public TipoDispositivo GetById(int TipoID)
        {
            return tipoDispositivoDAL.GetById(TipoID);
        }

        public TipoDispositivo Save(TipoDispositivo pTipoDispositivo)
        {
            return tipoDispositivoDAL.Save(pTipoDispositivo);
        }

        public TipoDispositivo Update(TipoDispositivo pTipoDispositivo)
        {
            return tipoDispositivoDAL.Update(pTipoDispositivo);
        }
    }
}
