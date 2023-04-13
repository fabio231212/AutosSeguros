using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface ICoberturaBLL
    {
        void Insertar(Cobertura cobertura);
        void Actualizar(Cobertura cobertur);
        void Eliminar(int id);
        List<Cobertura> SeleccionarTodas();
        Cobertura SeleccionarPorId(int id);

        List<Cobertura> CoberturasAgregadas(int idTipoPoliza);
    }
}
