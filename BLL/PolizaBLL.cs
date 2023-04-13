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
    public class PolizaBLL : IPolizaBLL
    {
        

        public int GetCurrentNumeroPoliza()
        {
            IPolizaDAL polizaDAL = new PolizaDAL();
          return  polizaDAL.GetCurrentNumeroPoliza();
        }

        public int GetNextNumeroPoliza()
        {
            IPolizaDAL polizaDAL = new PolizaDAL();
            return polizaDAL.GetNextNumeroPoliza();
        }

    }
}
