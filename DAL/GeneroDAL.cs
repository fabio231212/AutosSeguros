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
    public class GeneroDAL : IGeneroDAL
    {
        public List<Genero> ObtenerGenero()
        {
            List<Genero> lista = new List<Genero>();
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "usp_SELECT_Genero_All";

                DataSet ds = db.ExecuteDataSet(comando);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Genero genero = new Genero();
                    genero.Id = (int)dr["Id"];
                    genero.Descripcion = dr["Descripcion"].ToString();
                    lista.Add(genero);
                }
            }

            return lista;
        }

        public Genero ObtenerPorId(int id)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "usp_SELECT_Genero_ByID";
                comando.Parameters.AddWithValue("@Id", id);

                IDataReader reader = db.ExecuteReader(comando);

                while (reader.Read())
                {
                    Genero genero = new Genero();
                    genero.Id = (int)reader["Id"];
                    genero.Descripcion = reader["Descripcion"].ToString();
                    return genero;
                }
            }

            return null;
        }
    }
}
