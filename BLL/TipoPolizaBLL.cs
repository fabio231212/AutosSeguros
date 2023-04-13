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
    public class TipoPolizaBLL : ITipoPolizaBLL
    {


        public void Eliminar(int id)
        {
            ITipoPolizaDAL logica = new TipoPolizaDAL();
            logica.Eliminar(id);
        }

        public void Insertar(TipoPoliza tipoPoliza)
        {
            ITipoPolizaDAL logica = new TipoPolizaDAL();
            if (logica.ObtenerPorId(tipoPoliza.Id) == null)
            {

                logica.Insertar(tipoPoliza);
            }
            else
            {
                logica.Actualizar(tipoPoliza);
            }
        }

        public TipoPoliza ObtenerPorId(int id)
        {
            ITipoPolizaDAL logica = new TipoPolizaDAL();
            return logica.ObtenerPorId(id);
        }

        public List<TipoPoliza> ObtenerTipoPolizas()
        {

            ITipoPolizaDAL logica = new TipoPolizaDAL();
            return logica.ObtenerTipoPolizas();
        }
    }
}
