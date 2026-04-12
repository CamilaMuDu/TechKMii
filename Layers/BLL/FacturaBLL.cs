using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TechKMii.Layers.DAL;
using TechKMii.Layers.Entities;
using TechKMii.Layers.Interfaces;

namespace TechKMii.Layers.BLL
{
    public class FacturaBLL : IFacturaBLL
    {
        IFacturaDAL facturaDAL = new FacturaDAL();
        IFacturaDetalleDAL facturaDetalleDAL = new FacturaDetalleDAL();
        public List<Factura> GetAll()
        {
            return facturaDAL.GetAll();
        }

        public Factura GetById(int id)
        {
            Factura factura = facturaDAL.GetById(id);
            if (factura != null)
            {
                factura.ListaDetalle = facturaDetalleDAL.GetByFacturaId(id);
            }
            return factura;
        }

        public int Save(Factura factura)
        {
            CalcularTotales(factura);

            int facturaId = facturaDAL.Save(factura);
            factura.FacturaID = facturaId;
            foreach (FacturaDetalle item in factura.ListaDetalle)
            {
                item.Factura = factura;
                facturaDetalleDAL.Save(item);
            }
            return facturaId;
        }
        private void CalcularTotales(Factura factura)
        {
            double subtotal = 0;
            double iva = 0;
            double total = 0;

            if (factura == null)
                MessageBox.Show("La factura no puede ser nula.");

            if (factura.ListaDetalle == null || factura.ListaDetalle.Count == 0)
                MessageBox.Show("La factura no tiene detalle.");

            foreach (FacturaDetalle item in factura.ListaDetalle)
            {
                item.Subtotal = item.Cantidad * item.Precio;
                item.IVA = item.Subtotal * 0.13;
                item.Total = item.Subtotal + item.IVA;

                subtotal += item.Subtotal;
                iva += item.IVA;
                total += item.Total;
            }

            factura.Subtotal = subtotal;
            factura.IVA = iva;
            factura.TotalCRC = total;

            if (factura.TipoCambio <= 0)
                throw new Exception("El tipo de cambio debe ser mayor a cero.");

            factura.TotalUSD = total / factura.TipoCambio;
        }
    }
}
