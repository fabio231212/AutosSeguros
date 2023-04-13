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
    public class TarjetaBLL : ITarjetaBLL
    {
        public Tarjeta ObtenerPorId(int id)
        {
            ITarjetaDAL tarjetaDal = new TarjetaDAL();
            return tarjetaDal.ObtenerPorId((int)id);
        }

        public List<Tarjeta> ObtenerTarjeta()
        {
            ITarjetaDAL tarjetaDal = new TarjetaDAL();
            return tarjetaDal.ObtenerTarjeta();
        }
    }
}
