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
    public class TipoUsuarioBLL : ITipoUsuarioBLL
    {
        public TipoUsuario ObtenerPorId(int id)
        {
            ITipoUsuarioDAL logica = new TipoUsuarioDAL();
            return logica.ObtenerPorId(id);
        }

        public List<TipoUsuario> ObtenerTiposUsuarios()
        {
            ITipoUsuarioDAL logica = new TipoUsuarioDAL();
            return logica.ObtenerTiposUsuarios();
        }
    }
}
