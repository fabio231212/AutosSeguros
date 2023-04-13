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
    public class PaisBLL : IPaisBLL
    {
        public List<Pais> ObtenerPaises()
        {
            IPaisDAL datos = new PaisDAL();
            return datos.ObtenerPaises();
        }

        public Pais ObtenerPorId(int id)
        {
            IPaisDAL datos = new PaisDAL();
            return datos.ObtenerPorId(id);
        }
    }
}
