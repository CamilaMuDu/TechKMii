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
    public class FacturaDetalleBLL : IFacturaDetalleBLL
    {
        IFacturaDetalleDAL facturaDetalleDAL = new FacturaDetalleDAL(); 
        public List<FacturaDetalle> GetByFacturaId(int facturaId)
        {
            return facturaDetalleDAL.GetByFacturaId(facturaId);
        }

        public void Save(FacturaDetalle detalle)
        {
            facturaDetalleDAL.Save(detalle);
        }
    }
}
