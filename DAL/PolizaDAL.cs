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
    public class PolizaDAL : IPolizaDAL
    {
     

        public int GetCurrentNumeroPoliza()
        {
            DataSet ds = null;
            IDbCommand command = new SqlCommand();
            int numeroFactura = 0;
            string sql = @"SELECT current_value FROM sys.sequences WHERE name = 'secuenciaPoliza'  ";
            DataTable dt = null;
            try
            {
                command.CommandText = sql;
                command.CommandType = CommandType.Text;

                using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
                {
                    ds = db.ExecuteDataSet(command);
                }

                // Extraer la tabla
                dt = ds.Tables[0];
                //Extraer el valor que viene en el DataTable
                numeroFactura = int.Parse(dt.Rows[0][0].ToString());
                return numeroFactura;
            }
            catch (Exception er)
            {
                throw;
            }
        }

        public int GetNextNumeroPoliza()
        {
            DataSet ds = null;
            IDbCommand command = new SqlCommand();
            int numeroFactura = 0;
            string sql = @"SELECT NEXT VALUE FOR secuenciaPoliza";

            DataTable dt = null;
            try
            {
                command.CommandText = sql;
                command.CommandType = CommandType.Text;

                using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
                {
                    ds = db.ExecuteDataSet(command);
                }

                // Extraer la tabla
                dt = ds.Tables[0];
                //Extraer el valor que viene en el DataTable
                numeroFactura = int.Parse(dt.Rows[0][0].ToString());
                return numeroFactura;
            }
            catch (Exception er)
            {
                throw;
            }
        }

     
    }
}
