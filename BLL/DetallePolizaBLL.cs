using DAL;
using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DetallePolizaBLL : IDetallePolizaBLL
    {
        public void Actualizar(DetallePoliza detallePoliza)
        {
            IDetallePolizaDAL detallePolizaDAL = new DetallePolizaDAL();
            detallePolizaDAL.Actualizar(detallePoliza);
        }

        public void EliminarByIdTipoPoliza(int idTipoPoliza)
        {
            IDetallePolizaDAL detallePolizaDAL = new DetallePolizaDAL();
            detallePolizaDAL.Eliminar(idTipoPoliza);
        }

        public void EliminarByPolCob(int idTipoPoliza, int idCobertura)
        {
            IDetallePolizaDAL detallePolizaDAL = new DetallePolizaDAL();
            detallePolizaDAL.EliminarByPolCob(idTipoPoliza, idCobertura);
        }

        public void Insertar(DetallePoliza detallePoliza)
        {
            IDetallePolizaDAL detallePolizaDAL = new DetallePolizaDAL();
            detallePolizaDAL.Insertar(detallePoliza);
        }

        public DetallePoliza SeleccionarPorId(int idTipoPoliza, int idCobertura)
        {
            IDetallePolizaDAL detallePolizaDAL = new DetallePolizaDAL();
            return detallePolizaDAL.SeleccionarPorId(idTipoPoliza, idCobertura);
        }

        public List<DetallePoliza> SeleccionarTodas()
        {
            IDetallePolizaDAL detallePolizaDAL = new DetallePolizaDAL();
            return detallePolizaDAL.SeleccionarTodas();
        }
    }
}
