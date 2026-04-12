using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechKMii.Layers.Entities;

namespace TechKMii.Layers.Interfaces
{
    public interface IFacturaDetalleBLL
    {
        void Save(FacturaDetalle detalle);
        List<FacturaDetalle> GetByFacturaId(int facturaId);
    }
}
