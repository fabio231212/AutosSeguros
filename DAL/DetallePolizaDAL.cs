using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DetallePolizaDAL : IDetallePolizaDAL
    {
        public void Actualizar(DetallePoliza detallePoliza)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "usp_UPDATE_DetallePoliza";
                comando.Parameters.AddWithValue("@IdPoliza", detallePoliza.IdTipoPoliza);
                comando.Parameters.AddWithValue("@IdCobertura", detallePoliza.IdCobertura);


                db.ExecuteNonQuery(comando);
            }
        }

        public void Eliminar(int idTipoPoliza)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "usp_DELETE_DetallePolizaByIdTipoPoliza";
                comando.Parameters.AddWithValue("@IdTipoPoliza", idTipoPoliza);

                db.ExecuteNonQuery(comando);
            }
        }

        public void EliminarByPolCob(int idTipoPoliza, int idCobertura)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "usp_DELETE_DetallePoliza_ByIDCobPol";
                comando.Parameters.AddWithValue("@IdTipoPoliza", idTipoPoliza);
                comando.Parameters.AddWithValue("@IdCobertura", idCobertura);
                db.ExecuteNonQuery(comando);
            }
        }

        public void Insertar(DetallePoliza detallePoliza)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "usp_INSERT_DetallePoliza";
                comando.Parameters.AddWithValue("@IdTipoPoliza", detallePoliza.IdTipoPoliza);
                comando.Parameters.AddWithValue("@IdCobertura", detallePoliza.IdCobertura);


                db.ExecuteNonQuery(comando);
            }
        }

        public DetallePoliza SeleccionarPorId(int idTipoPoliza, int idCobertura)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "usp_SELECT_DetallePoliza_ByID";
                comando.Parameters.AddWithValue("@IdTipoPoliza", idTipoPoliza);
                comando.Parameters.AddWithValue("@IdCobertura", idCobertura);



                IDataReader reader = db.ExecuteReader(comando);

                while (reader.Read())
                {
                    DetallePoliza detallePoliza = new DetallePoliza();
                    detallePoliza.IdTipoPoliza = (int)reader["IdTipoPoliza"];
                    detallePoliza.IdCobertura = (int)reader["IdCobertura"];

                    return detallePoliza;
                }
            }
            return null;
        }

        public List<DetallePoliza> SeleccionarTodas()
        {
            List<DetallePoliza> lista = new List<DetallePoliza>();
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "usp_SELECT_DetallePoliza_All";

                DataSet ds = db.ExecuteDataSet(comando);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    DetallePoliza detallePoliza = new DetallePoliza();
                    detallePoliza.IdTipoPoliza = (int)dr["IdTipoPoliza"];
                    detallePoliza.IdCobertura = (int)dr["IdCobertura"];



                    lista.Add(detallePoliza);
                }
            }

            return lista;
        }
    }
}
