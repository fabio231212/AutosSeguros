
using Entities;
using System;
using System.Collections.Generic;

namespace capa.Entidades
{
    public class Factura
    {
        public int IdFactura { get; set; }
        public decimal TotalDolares { get; set; }
        public decimal TotalColones { get; set; }
        public int IdTarjeta { get; set; }
        public string IdUsuario { get; set; }
        public Usuario _Usuario { get; set; }
        public DateTime FechaFacturacion { get; set; }
        public int NumeroTarjeta { get; set; }
        public int IdTipoPago { get; set; }
        public int IdPoliza { get; set; }
        public Poliza _Poliza { get; set; }
        public bool Activo { get; set; }

        public Factura() {
            Activo = true;
        }

        //public int IdMulta { get; set; }
        //public DetFactura FacturaDetalle { get; set; }


        /// <summary>
        /// Método que añade detalles de factura
        /// </summary>
        /// <param name="pFacturaDetalle"></param>
        //public void AddDetalle(DetFactura pFacturaDetalle)
        //{
        //    FacturaDetalle = pFacturaDetalle;
        //}

        /// <summary>
        /// Método que calcula el impuesto
        /// </summary>
        /// <returns></returns>


        /// <summary>
        /// Método que calcula el subtotal
        /// </summary>
        /// <returns></returns>



        /// <summary>
        /// Método que calcula el total según el tipo de pago. Tiene un recargo por ser trimestral,semestral o mensual y con base a eso
        /// sacamos el total a pagar en la factura
        /// </summary>
        /// <returns></returns>
        public void CalculaCosto(decimal porcentaje,decimal total, string tipoPago)
        {
            int divMeses = 0;

            switch (tipoPago)
            {
                case "Semestral":
                    divMeses = 2;
                    break;
                case "Anual":
                    divMeses = 1;
                    break;
                case "Trimestral":
                    divMeses = 4;
                    break;
                case "Mensual":
                    divMeses = 12;
                    break;
                default:
                    break;

            }

            TotalDolares = (((total / divMeses) * porcentaje) + (total / divMeses));



        }
    }
}
