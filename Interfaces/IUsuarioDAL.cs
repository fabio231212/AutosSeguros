using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IUsuarioDAL
    {
        void Insertar(Usuario user);
        void Actualizar(Usuario user);
        void Eliminar(string id);
        List<Usuario> SeleccionarTodas();
        Usuario SeleccionarPorId(string id);
        bool VerificarLogin(string correo, string clave);
        List<Usuario> GetUsuarioByFiltro(string filtro);
        string ObtenerUsuarioIdByIdFac(int idFactura);
    }
}
