using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Configuration;
using System.Text;
using System.Threading.Tasks;
using TechKMii.Layers.Entities.BCCR;
using TechKMii.Layers.Interfaces;

namespace TechKMii.Layers.BLL
{
    class DolarBLL : IDolarBLL
    {
        public double GetVentaDolar()
        {
            try
            {
                double tipoCambioVenta = 1;
                ServicesBCCR services = new ServicesBCCR();
                List<Dolar> cambioDolar = services.GetDolar(DateTime.Today, DateTime.Today, "v").ToList();
                if (cambioDolar != null)
                {
                    tipoCambioVenta = cambioDolar[0].Monto;
                }
                return tipoCambioVenta;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return 0;
            }  
        }
    }
}
