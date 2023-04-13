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
    public class TarjetaDAL : ITarjetaDAL
    {
        public Tarjeta ObtenerPorId(int id)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "usp_SELECT_Tarjeta_ByID";
                comando.Parameters.AddWithValue("@Id", id);

                IDataReader reader = db.ExecuteReader(comando);

                while (reader.Read())
                {
                    Tarjeta tarjeta = new Tarjeta();
                    tarjeta.Id = (int)reader["Id"];
                    tarjeta.Nombre = reader["Descripcion"].ToString();
                    return tarjeta;
                }
            }

            return null;
        }

        public List<Tarjeta> ObtenerTarjeta()
        {
            List<Tarjeta> lista = new List<Tarjeta>();
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "usp_SELECT_Tarjeta_All";

                DataSet ds = db.ExecuteDataSet(comando);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Tarjeta tarjeta = new Tarjeta();
                    tarjeta.Id = (int)dr["Id"];
                    tarjeta.Nombre = dr["Descripcion"].ToString();
                    lista.Add(tarjeta);
                }
            }

            return lista;
        }
    }
}
