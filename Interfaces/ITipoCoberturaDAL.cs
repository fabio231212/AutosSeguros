using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public  interface ITipoCoberturaDAL
    {
        List<TipoCobertura> ObtenerTipoCobertura();
        TipoCobertura ObtenerPorId(int id);
    }
}
