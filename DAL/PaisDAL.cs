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
    public class PaisDAL : IPaisDAL
    {
        public List<Pais> ObtenerPaises()
        {
            List<Pais> lista = new List<Pais>();
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "usp_SELECT_Pais_All";

                IDataReader reader = db.ExecuteReader(comando);

                while (reader.Read())
                {
                    Pais pais = new Pais();
                    pais.Id = (int)reader["Id"];
                    pais.Nombre = reader["Nombre"].ToString();

                    lista.Add(pais);
                }
            }

            return lista;
        }

        public Pais ObtenerPorId(int id)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "usp_SELECT_Pais_ByID";
                comando.Parameters.AddWithValue("@Id", id);

                IDataReader reader = db.ExecuteReader(comando);

                while (reader.Read())
                {
                    Pais pais = new Pais();
                    pais.Id = (int)reader["Id"];
                    pais.Nombre = reader["Nombre"].ToString();

                    return pais;
                }
            }

            return null;
        }
    }
}
