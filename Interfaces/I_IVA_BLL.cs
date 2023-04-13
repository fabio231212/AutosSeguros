using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface I_IVA_BLL
    {

        void Actualizar(IVA iva);
        void Eliminar(int id);
        void Insertar(IVA iva);
        List<IVA> SeleccionarTodas();
        IVA SeleccionarPorId(int id);
        IVA SeleccionarReciente();
    }
}
