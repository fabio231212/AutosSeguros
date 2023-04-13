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
    public class UsuarioDAL : IUsuarioDAL
    {
        public void Actualizar(Usuario user)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "usp_UPDATE_Usuario";
                comando.Parameters.AddWithValue("@Id", user.Id);
                comando.Parameters.AddWithValue("@Nombre", user.Nombre);
                comando.Parameters.AddWithValue("@Apellido1", user.Apellido1);
                comando.Parameters.AddWithValue("@Apellido2", user.Apellido2);
                comando.Parameters.AddWithValue("@Correo", user.Correo);
                comando.Parameters.AddWithValue("@Clave", user.Clave);
                comando.Parameters.AddWithValue("@FechaNacimiento", user.FechaNacimiento);
                comando.Parameters.AddWithValue("@Telefono", user.Telefono);
                comando.Parameters.AddWithValue("@IdGenero", user.IdGenero);
                comando.Parameters.AddWithValue("@IdPais", user.IdPais);
                comando.Parameters.AddWithValue("@Nacionalidad", user.Nacionalidad);
                comando.Parameters.AddWithValue("@FechaLicenciaEx", user.FechaLicenciaEx);
                comando.Parameters.AddWithValue("@PuntosLicencia", user.PuntosLicencia);
                comando.Parameters.AddWithValue("@IdTipoUsuario", user.IdTipoUsuario);
                comando.Parameters.AddWithValue("@Foto", user.Foto);
                comando.Parameters.AddWithValue("@Direccion", user.Direccion);

                db.ExecuteNonQuery(comando);
            }
        }

        public void Eliminar(string id)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "usp_DELETE_Usuario_ByID";
                comando.Parameters.AddWithValue("@Id", id);

                db.ExecuteNonQuery(comando);
            }
        }

        public List<Usuario> GetUsuarioByFiltro(string filtro)
        {
            DataSet ds = null;
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            List<Usuario> lista = new List<Usuario>();
            comando.CommandText = "usp_ObtenerUsuarioByFiltro";
            // Pasar Parámetro
            comando.Parameters.AddWithValue("@filtro", filtro);

            // Ejecutar
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                ds = db.ExecuteDataSet(comando, "query");
            }

            // Si devolvió valores
            if (ds.Tables[0].Rows.Count > 0)
            {
                // Itetarar en las filas
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Usuario user = new Usuario();
                    user.Id = dr["Id"].ToString();
                    user.Nombre = dr["Nombre"].ToString();
                    user.Apellido1 = dr["Apellido1"].ToString();
                    user.Apellido2 = dr["Apellido2"].ToString();
                    user.Correo = dr["Correo"].ToString();
                    user.Clave = dr["Clave"].ToString();
                    user.FechaNacimiento = (DateTime)dr["FechaNacimiento"];
                    user.Telefono = (int)dr["Telefono"];
                    user.IdTipoUsuario = (int)dr["IdTipoUsuario"];
                    user.Foto = (byte[])dr["Foto"];
                    user.IdGenero = (int)dr["IdGenero"];
                    user.IdPais = (int)dr["IdPais"];
                    user.Nacionalidad = dr["Nacionalidad"].ToString();
                    user.FechaLicenciaEx = (DateTime)dr["FechaLicenciaEx"];
                    user.PuntosLicencia = (int)dr["PuntosLicencia"];
                    user.Direccion = dr["Direccion"].ToString();

                    IPaisDAL datosPais = new PaisDAL();
                    user.PaisResidencia = datosPais.ObtenerPorId(user.IdPais);

                    ITipoUsuarioDAL datosTipoUsuario = new TipoUsuarioDAL();
                    user._TipoUsuario = datosTipoUsuario.ObtenerPorId(user.IdTipoUsuario);

                    lista.Add(user);

                }

            }
            return lista;
        }

        public void Insertar(Usuario user)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "usp_INSERT_Usuario";
                comando.Parameters.AddWithValue("@Id", user.Id);
                comando.Parameters.AddWithValue("@Nombre", user.Nombre);
                comando.Parameters.AddWithValue("@Apellido1", user.Apellido1);
                comando.Parameters.AddWithValue("@Apellido2", user.Apellido2);
                comando.Parameters.AddWithValue("@Correo", user.Correo);
                comando.Parameters.AddWithValue("@Clave", user.Clave);
                comando.Parameters.AddWithValue("@FechaNacimiento", user.FechaNacimiento);
                comando.Parameters.AddWithValue("@Telefono", user.Telefono);
                comando.Parameters.AddWithValue("@IdGenero", user.IdGenero);
                comando.Parameters.AddWithValue("@IdPais", user.IdPais);
                comando.Parameters.AddWithValue("@Nacionalidad", user.Nacionalidad);
                comando.Parameters.AddWithValue("@FechaLicenciaEx", user.FechaLicenciaEx);
                comando.Parameters.AddWithValue("@PuntosLicencia", user.PuntosLicencia);
                comando.Parameters.AddWithValue("@IdTipoUsuario", user.IdTipoUsuario);
                comando.Parameters.AddWithValue("@Foto", user.Foto);
                comando.Parameters.AddWithValue("@Direccion", user.Direccion);

                db.ExecuteNonQuery(comando);
            }
        }

        public string ObtenerUsuarioIdByIdFac(int idFactura)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "usp_UsuarioByFactura";
                comando.Parameters.AddWithValue("@IdFactura", idFactura);

                IDataReader reader = db.ExecuteReader(comando);

                while (reader.Read())
                {
                    string idUsuario = reader["Id"].ToString();


                    return idUsuario;
                }
            }

            return null;
        }

        public Usuario SeleccionarPorId(string id)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "usp_SELECT_Usuario_ByID";
                comando.Parameters.AddWithValue("@Id", id);

                IDataReader dr = db.ExecuteReader(comando);

                while (dr.Read())
                {
                    Usuario user = new Usuario();
                    user.Id = dr["Id"].ToString();
                    user.Nombre = dr["Nombre"].ToString();
                    user.Apellido1 = dr["Apellido1"].ToString();
                    user.Apellido2 = dr["Apellido2"].ToString();
                    user.Correo = dr["Correo"].ToString();
                    user.Clave = dr["Clave"].ToString();
                    user.FechaNacimiento = (DateTime)dr["FechaNacimiento"];
                    user.Telefono = (int)dr["Telefono"];
                    user.IdTipoUsuario = (int)dr["IdTipoUsuario"];
                      user.Foto = (byte[])dr["Foto"];
                    user.IdGenero = (int)dr["IdGenero"];
                    user.IdPais = (int)dr["IdPais"];
                    user.Nacionalidad = dr["Nacionalidad"].ToString();
                    user.FechaLicenciaEx = (DateTime)dr["FechaLicenciaEx"];
                    user.PuntosLicencia = (int)dr["PuntosLicencia"];
                    user.Direccion = dr["Direccion"].ToString();

                    ITipoUsuarioDAL datosUsuario = new TipoUsuarioDAL();
                    user._TipoUsuario = datosUsuario.ObtenerPorId(user.IdTipoUsuario);

                    IPaisDAL datosPais = new PaisDAL();
                    user.PaisResidencia = datosPais.ObtenerPorId(user.IdPais);

                    return user;
                }
            }

            return null;
        }

        public List<Usuario> SeleccionarTodas()
        {
            List<Usuario> lista = new List<Usuario>();
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "usp_SELECT_Usuario_All";

                DataSet ds = db.ExecuteDataSet(comando);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Usuario user = new Usuario();
                    user.Id = dr["Id"].ToString();
                    user.Nombre = dr["Nombre"].ToString();
                    user.Apellido1 = dr["Apellido1"].ToString();
                    user.Apellido2 = dr["Apellido2"].ToString();
                    user.Correo = dr["Correo"].ToString();
                 //   user.Clave = dr["Clave"].ToString();
                    user.FechaNacimiento = (DateTime)dr["FechaNacimiento"];
                    user.Telefono = (int)dr["Telefono"];
                    user.IdTipoUsuario = (int)dr["IdTipoUsuario"];
                    user.Foto = (byte[])dr["Foto"];
                    user.IdGenero = (int)dr["IdGenero"];
                    user.IdPais=(int) dr["IdPais"];
                    user.Nacionalidad = dr["Nacionalidad"].ToString();
                    user.FechaLicenciaEx = (DateTime)dr["FechaLicenciaEx"];
                    user.PuntosLicencia = (int)dr["PuntosLicencia"];
                    user.Direccion = dr["Direccion"].ToString();

                    IPaisDAL datosPais = new PaisDAL();
                    user.PaisResidencia = datosPais.ObtenerPorId(user.IdPais);

                    ITipoUsuarioDAL datosTipoUsuario = new TipoUsuarioDAL();
                    user._TipoUsuario = datosTipoUsuario.ObtenerPorId(user.IdTipoUsuario);

                    lista.Add(user);
                }
            }

            return lista;
        }

        public bool VerificarLogin(string correo, string clave)
        {
            bool resultado = false;
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "usp_Verificar_Login";
                comando.Parameters.AddWithValue("@Correo", correo);
                comando.Parameters.AddWithValue("@Clave", clave);

                IDataReader reader = db.ExecuteReader(comando);

                while (reader.Read())
                {
                   
                    
                 
                        CacheUsuario.Id = reader["Id"].ToString();
                        CacheUsuario.Nombre = reader["Nombre"].ToString();
                        CacheUsuario.Apellido1 = reader["Apellido1"].ToString();
                        CacheUsuario.Apellido2 = reader["Apellido2"].ToString();
                        CacheUsuario.Correo = reader["Correo"].ToString();
                        CacheUsuario.Clave = reader["Clave"].ToString();
                        CacheUsuario.FechaNacimiento = (DateTime)reader["FechaNacimiento"];
                        CacheUsuario.Telefono = (int)reader["Telefono"];
                        CacheUsuario.IdTipoUsuario = (int)reader["IdTipoUsuario"];
                        CacheUsuario.Foto = (byte[])reader["Foto"];
                        CacheUsuario.IdGenero = (int)reader["IdGenero"];
                        CacheUsuario.IdPais = (int) reader["IdPais"];
                        CacheUsuario.Nacionalidad = reader["Nacionalidad"].ToString();
                        CacheUsuario.FechaLicenciaExp = (DateTime)reader["FechaLicenciaEx"];
                        CacheUsuario.Direccion = reader["Direccion"].ToString();
                        var a = reader["Foto"];
                        if (!a.GetType().ToString().Equals("System.DBNull"))
                        {
                            CacheUsuario.Foto = (byte[])reader["Foto"];
                        }
                        else
                        {
                            CacheUsuario.Foto = null;
                        }

                    if (correo != CacheUsuario.Correo || clave != CacheUsuario.Clave)
                    {
                        throw new Exception("Correo o Clave incorrectos");
                    }
                    resultado = true;



                }
            }
            return resultado;
        }
    }
}
