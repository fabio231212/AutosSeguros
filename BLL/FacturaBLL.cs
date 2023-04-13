using capa.Entidades;
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
    public class FacturaBLL : IFacturaBLL
    {
        public void AnularFactura(int idFactura)
        {
            IFacturaDAL logica = new FacturaDAL();
            logica.AnularFactura(idFactura);
        }

        public void Eliminar(int idFactura)
        {
            IFacturaDAL logica = new FacturaDAL();
            logica.Eliminar(idFactura);
        }
        /// <summary>
        /// Validaciones para ver si el usuario cumple con los requisitos mínimos para obtener una poliza
        /// </summary>
        /// <param name="factura"></param>
        /// <exception cref="ApplicationException"></exception>
        public void Insertar(Factura factura)
        {
            IFacturaDAL logica = new FacturaDAL();
            IUsuarioBLL logicaUsuario = new UsuarioBLL();
            Usuario usuario = logicaUsuario.GetUsuarioById(factura.IdUsuario);

            //valida que el usuario a contratar la poliza sea mayor de edad
            if ((DateTime.Now.Year - usuario.FechaNacimiento.Year) < 18) {
                throw new ApplicationException("Debe ser mayor de 18 años");
             
            }
            //máximo de puntos 12
            if (usuario.PuntosLicencia >= 12)
            {
                throw new ApplicationException("Cantidad de puntos por arriba de lo permitido");
            }

            logica.Insertar(factura);
        }

        public List<Factura> SeleccionarFacturaHoy()
        {
            IFacturaDAL logica = new FacturaDAL();
            return (List<Factura>)logica.SeleccionarFacturaHoy();
        }

        public List<Factura> SeleccionarFacturasAnuladas()
        {
            IFacturaDAL logica = new FacturaDAL();
            return (List<Factura>)logica.SeleccionarFacturasAnuladas();
        }

        public Factura SeleccionarPorId(int idFactura)
        {
            IFacturaDAL logica = new FacturaDAL();
            return logica.SeleccionarPorId(idFactura);
        }

        public List<Factura> SeleccionarTodas()
        {
            IFacturaDAL logica = new FacturaDAL();
            return (List<Factura>)logica.SeleccionarTodas();
        }
    }
}
