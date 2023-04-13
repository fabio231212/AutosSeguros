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
    public class CoberturaDAL : ICoberturaDAL
    {
        public void Actualizar(Cobertura cobertura)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "usp_UPDATE_Cobertura";
                comando.Parameters.AddWithValue("@Id", cobertura.Id);
                comando.Parameters.AddWithValue("@Descripcion", cobertura.Descripcion);
                comando.Parameters.AddWithValue("@Precio", cobertura.Precio);
                comando.Parameters.AddWithValue("@Total", cobertura.Total);


                db.ExecuteNonQuery(comando);
            }
        }

        public List<Cobertura> CoberturasAgregadas(int idTipoPoliza)
        {
            List<Cobertura> lista = new List<Cobertura>();
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "usp_coberturasAgregadas";
                comando.Parameters.AddWithValue("@IdTipoPoliza", idTipoPoliza);

                DataSet ds = db.ExecuteDataSet(comando);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Cobertura cobertura = new Cobertura();
                    cobertura.Id = (int)dr["IdCobertura"];
                    cobertura.Descripcion = dr["Descripcion"].ToString();
                    cobertura.Precio = (decimal)dr["Precio"];
                    cobertura.Total = (decimal)dr["Total"];


                    lista.Add(cobertura);
                }
            }

            return lista;
        }

        public void Eliminar(int id)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "usp_DELETE_Cobertura_ByID";
                comando.Parameters.AddWithValue("@Id", id);

                db.ExecuteNonQuery(comando);
            }
        }

        public void Insertar(Cobertura cobertura)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "usp_INSERT_Cobertura";
                comando.Parameters.AddWithValue("@Descripcion", cobertura.Descripcion);
                comando.Parameters.AddWithValue("@Precio", cobertura.Precio);
                comando.Parameters.AddWithValue("@Total", cobertura.Total);

                db.ExecuteNonQuery(comando);
            }
        }

        public Cobertura SeleccionarPorId(int id)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "usp_SELECT_Cobertura_ByID";
                comando.Parameters.AddWithValue("@Id", id);

                IDataReader dr = db.ExecuteReader(comando);

                while (dr.Read())
                {
                    Cobertura cobertura = new Cobertura();
                    cobertura.Id =(int) dr["Id"];
                    cobertura.Descripcion = dr["Descripcion"].ToString();
                    cobertura.Precio =(decimal) dr["Precio"];
                    cobertura.Total = (decimal)dr["Total"];

                    return cobertura;
                }
            }

            return null;
        }

        public List<Cobertura> SeleccionarTodas()
        {
            List<Cobertura> lista = new List<Cobertura>();
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "usp_SELECT_Cobertura_All";

                DataSet ds = db.ExecuteDataSet(comando);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Cobertura cobertura = new Cobertura();
                    cobertura.Id = (int)dr["Id"];
                    cobertura.Descripcion = dr["Descripcion"].ToString();
                    cobertura.Precio = (decimal)dr["Precio"];
                    cobertura.Total = (decimal)dr["Total"];


                    lista.Add(cobertura);
                }
            }

            return lista;
        }
    }
}
