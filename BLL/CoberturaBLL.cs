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
    public class CoberturaBLL : ICoberturaBLL
    {
        public void Actualizar(Cobertura cobertura)
        {
            ICoberturaDAL logica = new CoberturaDAL();
            logica.Actualizar(cobertura);
        }

        public List<Cobertura> CoberturasAgregadas(int idTipoPoliza)
        {
            ICoberturaDAL logica = new CoberturaDAL();
            return logica.CoberturasAgregadas(idTipoPoliza);
        }

        public void Eliminar(int id)
        {
            ICoberturaDAL logica = new CoberturaDAL();
            logica.Eliminar(id);
        }

        public void Insertar(Cobertura cobertura)
        {
            I_IVA_BLL logicaIva = new IVABLL();
            Decimal porcIva = logicaIva.SeleccionarReciente().Porcentaje;
            cobertura.Total = cobertura.Precio * porcIva + cobertura.Precio;
            ICoberturaDAL logica = new CoberturaDAL();
            if (logica.SeleccionarPorId(cobertura.Id) == null)
            {

                logica.Insertar(cobertura);
            }
            else
            {
                logica.Actualizar(cobertura);
            }
        }

        public Cobertura SeleccionarPorId(int id)
        {
            ICoberturaDAL logica = new CoberturaDAL();
            return logica.SeleccionarPorId(id);
        }

        public List<Cobertura> SeleccionarTodas()
        {
            ICoberturaDAL logica = new CoberturaDAL();
            return logica.SeleccionarTodas();
        }
    }
}
