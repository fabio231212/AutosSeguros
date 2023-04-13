using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public  interface ITipoUsuarioDAL
    {
        TipoUsuario ObtenerPorId(int id);
        List<TipoUsuario> ObtenerTiposUsuarios();
    }
}
