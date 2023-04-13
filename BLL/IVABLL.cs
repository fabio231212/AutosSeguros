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
    public class IVABLL : I_IVA_BLL
    {
        public void Actualizar(IVA iva)
        {
            I_IVA_DAL logica = new IVADAL();
            logica.Actualizar(iva);
        }

        public void Eliminar(int id)
        {
            I_IVA_DAL logica = new IVADAL();
            logica.Eliminar(id);
        }

        public void Insertar(IVA iva)
        {
            I_IVA_DAL logica = new IVADAL();
            if (logica.SeleccionarPorId(iva.Id) == null)
            {

                logica.Insertar(iva);
            }
            else
            {
                logica.Actualizar(iva);
            }
        }

        public IVA SeleccionarPorId(int id)
        {
            I_IVA_DAL logica = new IVADAL();
            return logica.SeleccionarPorId(id);
        }

        public IVA SeleccionarReciente()
        {
            I_IVA_DAL logica = new IVADAL();
            return logica.SeleccionarReciente();
        }

        public List<IVA> SeleccionarTodas()
        {
            I_IVA_DAL logica = new IVADAL();
            return logica.SeleccionarTodas();
        }
    }
}
