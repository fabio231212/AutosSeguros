using System;

namespace Entities
{
    public static class CacheUsuario
    {
        public static string Id { get; set; }
        public static string Nombre { get; set; }
        public static string Apellido1 { get; set; }
        public static string Apellido2 { get; set; }
        public static string Correo { get; set; }
        public static DateTime FechaNacimiento { get; set; }
        public static int Telefono { get; set; }
        public static TipoUsuario _TipoUsuario { get; set; }
        public static int IdTipoUsuario { get; set; }
        public static int IdGenero { get; set; }
        public static string Clave { get; set; }
        public static byte[] Foto { get; set; }

        public static string Direccion { get; set; }
        public static int IdPais { get; set; }
        public static Pais PaisResidencia { get; set; }
        public static string Nacionalidad { get; set; }
        public static DateTime FechaLicenciaExp { get; set; }
        public static int PuntosLicencia { get; set; }
    }
}
