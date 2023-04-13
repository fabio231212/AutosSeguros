using capa.Entidades;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DAL
{
    public class FacturaDAL : IFacturaDAL
    {
        public void AnularFactura(int idFactura)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "usp_UPDATE_ActivoFactura";
                comando.Parameters.AddWithValue("@IdFactura", idFactura);

                db.ExecuteNonQuery(comando);
            }
        }

        public void Eliminar(int idFactura)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "usp_DELETE_Factura_ByID";
                comando.Parameters.AddWithValue("@Id", idFactura);

                db.ExecuteNonQuery(comando);
            }
        }


        public void Insertar(Factura factura)
        {
            List<IDbCommand> listaCommands = new List<IDbCommand>();
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {



                SqlCommand comandoPoliza = new SqlCommand();
                SqlCommand comando = new SqlCommand();


                comandoPoliza.CommandType = System.Data.CommandType.StoredProcedure;
                comandoPoliza.CommandText = "usp_INSERT_Poliza";
                comandoPoliza.Parameters.AddWithValue("@Id", factura._Poliza.Id);
                comandoPoliza.Parameters.AddWithValue("@Descripcion", factura._Poliza.Descripcion);
                comandoPoliza.Parameters.AddWithValue("@FechaVencimiento", factura._Poliza.FechaVencimiento);
                comandoPoliza.Parameters.AddWithValue("@IdTipoPoliza", factura._Poliza.IdTipoPoliza);

                listaCommands.Add(comandoPoliza);


                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "usp_INSERT_Factura";
                comando.Parameters.AddWithValue("@Id", factura.IdFactura);
                comando.Parameters.AddWithValue("@IdTarjeta", factura.IdTarjeta);
                comando.Parameters.AddWithValue("@IdUsuario", factura.IdUsuario);
                comando.Parameters.AddWithValue("@FechaFacturacion", factura.FechaFacturacion);
                comando.Parameters.AddWithValue("@NumeroTarjeta", factura.NumeroTarjeta);
                comando.Parameters.AddWithValue("@IdTipoPago", factura.IdTipoPago);
                comando.Parameters.AddWithValue("@TotalDolares", factura.TotalDolares);
                comando.Parameters.AddWithValue("@TotalColones", factura.TotalColones);
                comando.Parameters.AddWithValue("@Activo", factura.Activo);
                comando.Parameters.AddWithValue("@IdPoliza", factura._Poliza.Id);


                listaCommands.Add(comando);
             


               db.ExecuteNonQuery(listaCommands,IsolationLevel.ReadCommitted);
            }
        }

        public List<Factura> SeleccionarFacturaHoy()
        {
            List<Factura> lista = new List<Factura>();
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "usp_ObtenerFacturaHoy";
                comando.Parameters.AddWithValue("@Desde", new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0));
                comando.Parameters.AddWithValue("@Hasta", new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59));

                DataSet ds = db.ExecuteDataSet(comando);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Factura factura = new Factura();
                    factura.IdFactura = (int)dr["Id"];
                    factura.IdUsuario = dr["IdUsuario"].ToString();
                    factura.FechaFacturacion = DateTime.Parse(dr["FechaFacturacion"].ToString());
                    factura.IdTipoPago = (int)dr["IdTipoPago"];
                    factura.IdTarjeta = (int)dr["IdTarjeta"];
                    factura.NumeroTarjeta = (int)dr["NumeroTarjeta"];
                    factura.TotalDolares = decimal.Parse(dr["TotalDolares"].ToString());
                    factura.TotalColones = decimal.Parse(dr["TotalColones"].ToString());
                    factura.Activo = (bool)dr["Activo"];
                    factura.IdPoliza = (int)dr["IdPoliza"];

                    lista.Add(factura);
                }
            }

            return lista;
        }

        public List<Factura> SeleccionarFacturasAnuladas()
        {
            List<Factura> lista = new List<Factura>();
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "usp_SELECT_FacturasAnuladas";

                DataSet ds = db.ExecuteDataSet(comando);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Factura factura = new Factura();
                    factura.IdFactura = (int)dr["Id"];
                    factura.IdUsuario = dr["IdUsuario"].ToString();
                    factura.FechaFacturacion = DateTime.Parse(dr["FechaFacturacion"].ToString());
                    factura.IdTipoPago = (int)dr["IdTipoPago"];
                    factura.IdTarjeta = (int)dr["IdTarjeta"];
                    factura.NumeroTarjeta = (int)dr["NumeroTarjeta"];
                    factura.TotalDolares = decimal.Parse(dr["TotalDolares"].ToString());
                    factura.TotalColones = decimal.Parse(dr["TotalColones"].ToString());
                    factura.Activo = (bool)dr["Activo"];
                    factura.IdPoliza = (int)dr["IdPoliza"];

                    lista.Add(factura);
                }
            }
            return lista;
        }

        public Factura SeleccionarPorId(int idFactura)
        {
            Factura oEncFactura = new Factura();
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "usp_";
                comando.Parameters.AddWithValue("@Id", idFactura);

                DataSet ds = db.ExecuteDataSet(comando);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables[0].Rows[0];
                    oEncFactura = new Factura()
                    {
                        IdFactura = (int)dr["Id"],
                        IdUsuario = dr["IdUsuario"].ToString(),
                        FechaFacturacion = DateTime.Parse(dr["FechaFacturacion"].ToString()),
                        IdTipoPago = (int)dr["IdTipoPago"],
                        TotalDolares = decimal.Parse(dr["TotalDolares"].ToString()),
                        TotalColones = decimal.Parse(dr["TotalColones"].ToString()),
                        Activo = (bool)dr["Activo"],
                        IdPoliza =(int) dr["IdPoliza"]
                        
                    };
                    IUsuarioDAL datosUsuario = new UsuarioDAL();
                    oEncFactura._Usuario = datosUsuario.SeleccionarPorId(oEncFactura.IdUsuario);
                    
                }
            }
            return oEncFactura;
        }

        public List<Factura> SeleccionarTodas()
        {
            List<Factura> lista = new List<Factura>();
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "usp_ObtenerFacturaHoy";
                comando.Parameters.AddWithValue("@Desde", new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day,0,0,0));
                comando.Parameters.AddWithValue("@Hasta", new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59));

                DataSet ds = db.ExecuteDataSet(comando);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Factura factura = new Factura();
                    factura.IdFactura = (int)dr["Id"];
                    factura.IdUsuario = dr["IdUsuario"].ToString();
                        factura.FechaFacturacion = DateTime.Parse(dr["FechaFacturacion"].ToString());
                    factura.IdTipoPago = (int)dr["IdTipoPago"];
                    factura.TotalDolares = decimal.Parse(dr["TotalDolares"].ToString());
                    factura.TotalColones = decimal.Parse(dr["TotalColones"].ToString());
                    factura.Activo = (bool)dr["Activo"];
                        factura.IdPoliza = (int)dr["IdPoliza"];

                    lista.Add(factura);
                }
            }

            return lista;
        }
    }
}
