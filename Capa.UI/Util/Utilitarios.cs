using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Capa.UI.Util
{
    class Utilitarios
    {
        /// <summary>
        /// Colocar Cultura Estandar para Costa Rica
        /// </summary>
        public static void CultureInfo()
        {
            // Colocar Cultura Estandar para Costa Rica
            // esto me permite no tener problemas con (.) de los decimales
            CultureInfo Micultura = new CultureInfo("es-CR", false);
            Micultura.NumberFormat.CurrencySymbol = "¢";
            Micultura.NumberFormat.CurrencyDecimalDigits = 2;
            Micultura.NumberFormat.CurrencyDecimalSeparator = ".";
            Micultura.NumberFormat.CurrencyGroupSeparator = ",";
            int[] grupo = new int[] { 3, 3, 3 };
            Micultura.NumberFormat.CurrencyGroupSizes = grupo;
            Micultura.NumberFormat.NumberDecimalDigits = 2;
            Micultura.NumberFormat.NumberGroupSeparator = ",";
            Micultura.NumberFormat.NumberDecimalSeparator = ".";
            Micultura.NumberFormat.NumberGroupSizes = grupo;
            //Micultura.DateTimeFormat.
            Thread.CurrentThread.CurrentCulture = Micultura;
        }

        /// <summary>
        /// Método que calcula el total en colones por medio del valor obtenido de la página de indicadores económicos
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        public static decimal  ConsumoDolar(decimal valor)
        {
            string correoRegistrado = "pipiticaseguros@hotmail.com";
            string token = "EMIIOAPI1R";
            string nombreRegistrado = "Seguros Pipitica";
            try
            {
                // Habilitar TLS12
                System.Net.ServicePointManager.SecurityProtocol =
                                              SecurityProtocolType.Tls12;
                // wsindicadoreseconomicosSoap12 Binding tomado del app.Config
                Agente.wsindicadoreseconomicosSoapClient cliente =
                     new Agente.wsindicadoreseconomicosSoapClient("wsindicadoreseconomicosSoap12");

                DataSet dolar = cliente.ObtenerIndicadoresEconomicos("317",    /* 317 Compra / 318 Venta */
                                                                  "06/01/2020",      /* Fecha Inicial */
                                                                  "08/01/2020",      /* Fecha Final */
                                                                  nombreRegistrado,  /* Su Nombre Registrado   BCCR */
                                                                  "N",
                                                                  correoRegistrado, /* Correo Registrado BCCR */
                                                                  token             /* Token enviado por el BCCR */
                                                                 );
                decimal cambio = (decimal)dolar.Tables[0].Rows[2].Field<decimal>("NUM_VALOR");
                return valor*cambio;
            }
            catch (Exception)
            {
                throw new ApplicationException("Error al obtener el tipo de cambio");
            }

        }
        public static string Desencriptar(string clave)
        {
            string result = string.Empty;
            byte[] decryted = Convert.FromBase64String(clave);
            result = System.Text.Encoding.Unicode.GetString(decryted);
            return result;
        }

        public  static string EncriptaClave(string clave)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(clave);
            result = Convert.ToBase64String(encryted);
            return result;
        }
    }
}
