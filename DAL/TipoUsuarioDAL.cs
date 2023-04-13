using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TipoUsuarioDAL : ITipoUsuarioDAL
    {
        public TipoUsuario ObtenerPorId(int id)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "usp_SELECT_TipoUsuario_ByID";
                comando.Parameters.AddWithValue("@Id", id);

                IDataReader reader = db.ExecuteReader(comando);

                while (reader.Read())
                {
                    TipoUsuario tipoUsuario = new TipoUsuario();
                    tipoUsuario.Id = (int)reader["Id"];
                    tipoUsuario.Descripcion = reader["Descripcion"].ToString();

                    return tipoUsuario;
                }
            }

            return null;
        }

        public List<TipoUsuario> ObtenerTiposUsuarios()
        {
            List<TipoUsuario> lista = new List<TipoUsuario>();
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "usp_SELECT_TipoUsuario_All";

                IDataReader reader = db.ExecuteReader(comando);

                while (reader.Read())
                {
                    TipoUsuario tipoUsuario = new TipoUsuario();
                    tipoUsuario.Id = (int)reader["Id"];
                    tipoUsuario.Descripcion = reader["Descripcion"].ToString();

                    lista.Add(tipoUsuario);
                }
            }

            return lista;
        }
    }
}
