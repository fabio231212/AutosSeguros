using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface ITipoPolizaDAL
    {
        void Insertar(TipoPoliza tipoPoliza);
        void Actualizar(TipoPoliza tipoPoliza);
        void Eliminar(int id);
        List<TipoPoliza> ObtenerTipoPolizas();
        TipoPoliza ObtenerPorId(int id);
    }
}
