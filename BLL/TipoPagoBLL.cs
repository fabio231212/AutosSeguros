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
    public class TipoPagoBLL : ITipoPagoBLL
    {
        public TipoPago ObtenerPorId(int id)
        {
            ITipoPagoDAL tipoPagoDal = new TipoPagoDAL();
            return tipoPagoDal.ObtenerPorId(id);
        }

        public List<TipoPago> ObtenerTipoPago()
        {
            ITipoPagoDAL tipoPagoDal = new TipoPagoDAL();
            return tipoPagoDal.ObtenerTipoPago();
        }
    }
}
