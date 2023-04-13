using capa.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IFacturaDAL
    {
        void Insertar(Factura factura);
        void Eliminar(int idFactura);
        List<Factura> SeleccionarTodas();
        Factura SeleccionarPorId(int idFactura);
        List<Factura> SeleccionarFacturaHoy();
        void AnularFactura(int idFactura);

        List<Factura> SeleccionarFacturasAnuladas();



    }
}
