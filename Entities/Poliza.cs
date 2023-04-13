using System;

namespace Entities
{
    public class Poliza
    {
        public int Id { get; set; }
        public int IdFactura { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public int IdTipoPoliza { get; set; }
        public TipoPoliza _TipoPoliza { get; set; }
        public int IdUsuario { get; set; }

        public string TipoPolizaNombre
        {
            get
            {
                return _TipoPoliza.Descripcion;

            }
        }

       
       
    }
}
