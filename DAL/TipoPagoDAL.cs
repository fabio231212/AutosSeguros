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
    public class TipoPagoDAL : ITipoPagoDAL
    {
        public TipoPago ObtenerPorId(int id)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "usp_SELECT_TipoPago_ByID";
                comando.Parameters.AddWithValue("@Id", id);

                IDataReader reader = db.ExecuteReader(comando);

                while (reader.Read())
                {
                    TipoPago tipoPago = new TipoPago();
                    tipoPago.Id = (int)reader["Id"];
                    tipoPago.Descripcion = reader["Descripcion"].ToString();
                    tipoPago.Porcentaje = (Decimal)reader["Porcentaje"];
                    return tipoPago;
                }
            }

            return null;
        }

        public List<TipoPago> ObtenerTipoPago()
        {
            List<TipoPago> lista = new List<TipoPago>();
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "usp_SELECT_TipoPago_All";

                DataSet ds = db.ExecuteDataSet(comando);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    TipoPago tipoPago = new TipoPago();
                    tipoPago.Id = (int)dr["Id"];
                    tipoPago.Descripcion = dr["Descripcion"].ToString();
                    tipoPago.Porcentaje = (Decimal) dr["Porcentaje"];
                    lista.Add(tipoPago);
                }
            }

            return lista;
        }
    }
}
