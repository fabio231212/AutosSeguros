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
    public class IVADAL : I_IVA_DAL
    {
        public void Actualizar(IVA iva)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "usp_UPDATE_IVA";
                comando.Parameters.AddWithValue("@Id", iva.Id);
                comando.Parameters.AddWithValue("@Porcentaje", iva.Porcentaje);
                comando.Parameters.AddWithValue("@Fecha", iva.Fecha);


                db.ExecuteNonQuery(comando);
            }
        }

        public void Eliminar(int id)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "usp_DELETE_IVA_ByID";
                comando.Parameters.AddWithValue("@Id", id);

                db.ExecuteNonQuery(comando);
            }
        }

        public void Insertar(IVA iva)
        {

            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "usp_INSERT_IVA";
                comando.Parameters.AddWithValue("@Porcentaje", iva.Porcentaje);
                comando.Parameters.AddWithValue("@Fecha", iva.Fecha);

                db.ExecuteNonQuery(comando);
            }
        }

        public IVA SeleccionarPorId(int id)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "usp_SELECT_IVA_ByID";
                comando.Parameters.AddWithValue("@Id", id);

                IDataReader dr = db.ExecuteReader(comando);

                while (dr.Read())
                {
                    IVA iva = new IVA();
                    iva.Id = (int)dr["Id"];
                    iva.Fecha = DateTime.Parse(dr["Fecha"].ToString());
                    iva.Porcentaje = (decimal)dr["Porcentaje"];

                    return iva;
                }
            }

            return null;
        }

        public IVA SeleccionarReciente()
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "usp_SELECT_IVA_Reciente";


                IDataReader dr = db.ExecuteReader(comando);

                while (dr.Read())
                {
                    IVA iva = new IVA();
                    iva.Id = (int)dr["Id"];
                    iva.Fecha = DateTime.Parse(dr["Fecha"].ToString());
                    iva.Porcentaje = (decimal)dr["Porcentaje"];

                    return iva;
                }
            }

            return null;
        }

        public List<IVA> SeleccionarTodas()
        {
            List<IVA> lista = new List<IVA>();
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "usp_SELECT_IVA_All";

                DataSet ds = db.ExecuteDataSet(comando);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    IVA iva = new IVA();
                    iva.Id = (int)dr["Id"];
                    iva.Fecha = DateTime.Parse(dr["Fecha"].ToString());
                    iva.Porcentaje = (decimal)dr["Porcentaje"];


                    lista.Add(iva);
                }
            }

            return lista;
        }
    }
}
