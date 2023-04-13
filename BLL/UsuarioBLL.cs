using DAL;
using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UsuarioBLL : IUsuarioBLL
    {
        public void Eliminar(string id)
        {
            IUsuarioDAL datos = new UsuarioDAL ();
            if (datos.SeleccionarPorId(id) == null)
                throw new ApplicationException("El código no existe");

            datos.Eliminar(id);
        }

        public List<Usuario> GetUsuarioByFiltro(string filtro)
        {
            IUsuarioDAL datos = new UsuarioDAL();
            return datos.GetUsuarioByFiltro (filtro);
        }

        public Usuario GetUsuarioById(string id)
        {
            IUsuarioDAL datos = new UsuarioDAL();
            return datos.SeleccionarPorId(id);
        }

        /// <summary>
        /// Si el usuario ya existe, actualiza, si no inserta. También valida que el usuario procesos no pueda crear usuarios
        /// </summary>
        /// <param name="user"></param>
        /// <exception cref="ApplicationException"></exception>
        public void Guardar(Usuario user)
        {
            IUsuarioDAL datos = new UsuarioDAL();
            if (datos.SeleccionarPorId(user.Id) == null)
            {
                if (CacheUsuario.IdTipoUsuario == 4)
                {
                    throw new ApplicationException("Un usuario con rol de procesos no puede crear usuarios");
                }
                datos.Insertar(user);
            }
            else
            {
                datos.Actualizar(user);
            }
        }

        public string ObtenerUsuarioIdByIdFac(int idFactura)
        {
            IUsuarioDAL datos = new UsuarioDAL();
            return datos.ObtenerUsuarioIdByIdFac(idFactura);
        }

        public List<Usuario> ObtenerUsuarios()
        {
            IUsuarioDAL datos = new UsuarioDAL();
            return datos.SeleccionarTodas();
        }

        public bool VerificarAcceso(string correo, string clave)
        {
            IUsuarioDAL datos = new UsuarioDAL();
            return datos.VerificarLogin(correo, clave);
        }
    }
    }

