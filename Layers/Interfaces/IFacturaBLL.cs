using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechKMii.Layers.Entities;

namespace TechKMii.Layers.Interfaces
{
    public interface IFacturaBLL
    {
        int Save(Factura factura);
        Factura GetById(int id);
        List<Factura> GetAll();
    }
}
