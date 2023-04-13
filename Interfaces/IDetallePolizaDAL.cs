using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IDetallePolizaDAL
    {
        void Insertar(DetallePoliza detallePoliza);
        void Actualizar(DetallePoliza detallePoliza);
        void Eliminar(int idTipoPoliza);
        void EliminarByPolCob(int idTipoPoliza, int idCobertura);
        List<DetallePoliza> SeleccionarTodas();
        DetallePoliza SeleccionarPorId(int idTipoPoliza, int idCobertura);
    }
}
