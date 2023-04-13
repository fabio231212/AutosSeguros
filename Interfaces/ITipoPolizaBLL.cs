using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface ITipoPolizaBLL
    {
        void Insertar(TipoPoliza tipoPoliza);

        void Eliminar(int id);
        List<TipoPoliza> ObtenerTipoPolizas();
        TipoPoliza ObtenerPorId(int id);
    }
}
