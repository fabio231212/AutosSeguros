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
    public class GeneroBLL : IGeneroBLL
    {
        public List<Genero> ObtenerGenero()
        {
            IGeneroDAL datos = new GeneroDAL();
            return datos.ObtenerGenero();
        }

        public Genero ObtenerPorId(int id)
        {
            IGeneroDAL datosGenero = new GeneroDAL();
            return datosGenero.ObtenerPorId(id);
        }
    }
}
