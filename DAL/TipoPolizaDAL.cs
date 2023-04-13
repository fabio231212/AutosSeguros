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
    public class TipoPolizaDAL : ITipoPolizaDAL
    {
        public List<TipoPoliza> ObtenerTipoPolizas()
        {
            List<TipoPoliza> lista = new List<TipoPoliza>();
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "usp_SELECT_TipoPoliza_All";

                DataSet ds = db.ExecuteDataSet(comando);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    TipoPoliza tipoPoliza = new TipoPoliza();
                    tipoPoliza.Id = (int)dr["Id"];
                    tipoPoliza.Descripcion = dr["Descripcion"].ToString();
                    tipoPoliza.Costo =(decimal) dr["Costo"];
                    lista.Add(tipoPoliza);
                }
            }

            return lista;
        }

        public TipoPoliza ObtenerPorId(int id)
        {

            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "usp_SELECT_TipoPoliza_ByID";
                comando.Parameters.AddWithValue("@Id", id);

                IDataReader reader = db.ExecuteReader(comando);

                while (reader.Read())
                {
                    TipoPoliza tipoPoliza = new TipoPoliza();
                    tipoPoliza.Id = (int)reader["Id"];
                    tipoPoliza.Descripcion = reader["Descripcion"].ToString();
                    tipoPoliza.Costo = (decimal)reader["Costo"];
                    return tipoPoliza;
                }
            }
            return null;
        }

        public void Insertar(TipoPoliza tipoPoliza)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "usp_INSERT_TipoPoliza";
                comando.Parameters.AddWithValue("@Id", tipoPoliza.Id);
                comando.Parameters.AddWithValue("@Descripcion", tipoPoliza.Descripcion);
                comando.Parameters.AddWithValue("@Costo", tipoPoliza.Costo);

                db.ExecuteNonQuery(comando);
            }
        }

        public void Actualizar(TipoPoliza tipoPoliza)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "usp_UPDATE_TipoPoliza";
                comando.Parameters.AddWithValue("@Id", tipoPoliza.Id);
                comando.Parameters.AddWithValue("@Descripcion", tipoPoliza.Descripcion);
                comando.Parameters.AddWithValue("@Costo", tipoPoliza.Costo);

                db.ExecuteNonQuery(comando);
            }
        }

        public void Eliminar(int id)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "usp_DELETE_TipoPoliza_ByID";
                comando.Parameters.AddWithValue("@Id", id);

                db.ExecuteNonQuery(comando);
            }
        }
    }
}

