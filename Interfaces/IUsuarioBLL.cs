using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IUsuarioBLL
    {
        void Guardar(Usuario user);
        void Eliminar(string id);
        List<Usuario> ObtenerUsuarios();
        bool VerificarAcceso(string correo, string clave);
        Usuario GetUsuarioById(string id);
        List<Usuario> GetUsuarioByFiltro(string filtro);
        string ObtenerUsuarioIdByIdFac(int idFactura);
    }
}
