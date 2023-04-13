using System;

namespace Entities
{
    public class Usuario
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Correo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Telefono { get; set; }
        public TipoUsuario _TipoUsuario { get; set; }
        public int IdTipoUsuario { get; set; }
        public int IdGenero { get; set; }
        public string Clave { get; set; }
        public byte[] Foto { get; set; }

        public string Direccion { get; set; }

        public int IdPais { get; set; }
        public Pais PaisResidencia { get; set; }
        public string Nacionalidad { get; set; }
        public DateTime FechaLicenciaEx { get; set; }
        public int PuntosLicencia { get; set; }



        public string TipoUsuarioNombre
        {
            get
            {
                return _TipoUsuario.Descripcion;
            }
        }

    }
}
