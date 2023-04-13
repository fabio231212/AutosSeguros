using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface ICoberturaDAL
    {
        void Insertar(Cobertura cobertura);
        void Actualizar(Cobertura cobertura);
        void Eliminar(int id);
        List<Cobertura> SeleccionarTodas();
        Cobertura SeleccionarPorId(int id);
        List<Cobertura> CoberturasAgregadas(int idTipoPoliza);
    }
}
