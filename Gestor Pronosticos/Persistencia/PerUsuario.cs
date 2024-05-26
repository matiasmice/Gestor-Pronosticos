using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.SqlClient;

namespace Persistencia
{
    public class PerUsuario
    {
        public bool Editar(Usuario usuario)
        {
            SqlConnection sqlConnection = new SqlConnection(Conexion.connectionString);

            try
            {
                //ADO CONECTADO

                SqlCommand command = new SqlCommand("sp_EditUsuario", sqlConnection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("Usr", usuario.User));
                command.Parameters.Add(new SqlParameter("Nom", usuario.Nombre));
                command.Parameters.Add(new SqlParameter("Ape", usuario.Apellido));
                command.Parameters.Add(new SqlParameter("Ctr", usuario.Contrasenia));
                sqlConnection.Open();
                //Creo una variable para capturar el retorno de la BDD
                SqlParameter retorno = new SqlParameter();
                retorno.Direction = System.Data.ParameterDirection.ReturnValue;

                command.Parameters.Add(retorno);

                command.ExecuteNonQuery();

                //Clasifico el retorno 
                if (Convert.ToInt32(retorno.Value) == 1)
                    return true;       
                

                switch (Convert.ToInt32(retorno.Value))
                {
                    case -1:
                        {
                            throw new Exception("Ningún dato del usuario puede ser vacío");
                            break;
                        }
                    case -2:
                        {
                            throw new Exception("No existe un usuario con ese nombre de usuario");
                            break;
                        }
                    default:
                        {
                            throw new Exception("Error desconocido");
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public Usuario Logueo(string usr,string ctr)
        {
            SqlConnection sqlConnection = new SqlConnection(Conexion.connectionString);

            try
            {

                SqlCommand command = new SqlCommand("sp_LogueoUsuario", sqlConnection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("Usr", usr));
                command.Parameters.Add(new SqlParameter("Ctr", ctr));

                Usuario usuario= null;

                //ADO CONECTADO

                sqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    usuario = new Usuario(reader["Nombre"].ToString(), reader["Apellido"].ToString(),
                                            reader["Usuario"].ToString(), reader["Contrasenia"].ToString());
                }

                if (usuario == null)
                    throw new Exception("Usuario y contraseña no válido");

                return usuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public Usuario Buscar(string usr)
        {
            SqlConnection sqlConnection = new SqlConnection(Conexion.connectionString);

            try
            {

                SqlCommand command = new SqlCommand("sp_BuscarUsuario", sqlConnection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("Usr", usr));

                Usuario usuario = null;

                //ADO CONECTADO
                sqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    usuario = new Usuario(reader["Nombre"].ToString(), reader["Apellido"].ToString(),
                                            reader["Usuario"].ToString(), reader["Contrasenia"].ToString());
                }
                return usuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public bool Crear(Usuario usuario)
        {
            SqlConnection sqlConnection = new SqlConnection(Conexion.connectionString);

            try
            {
                SqlCommand command = new SqlCommand("sp_AltaUsuario", sqlConnection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("Usr", usuario.User));
                command.Parameters.Add(new SqlParameter("Nom", usuario.Nombre));
                command.Parameters.Add(new SqlParameter("Ape", usuario.Apellido));
                command.Parameters.Add(new SqlParameter("Ctr", usuario.Contrasenia));

                //Creo una variable para capturar el retorno de la BDD
                SqlParameter retorno = new SqlParameter();
                retorno.Direction = System.Data.ParameterDirection.ReturnValue;

                command.Parameters.Add(retorno);

                //ADO CONECTADO
                sqlConnection.Open();

                command.ExecuteNonQuery();

                //Clasifico el retorno 
                if (Convert.ToInt32(retorno.Value) == 1)
                    return true;

                switch (Convert.ToInt32(retorno.Value))
                {
                    case -1:
                        {
                            throw new Exception("Ningún dato del usuario puede ser vacío");
                            break;
                        }
                    case -2:
                        {
                            throw new Exception("No se ha creado ya que existe un usuario con ese nombre de usuario");
                            break;
                        }
                    
                    default:
                        {
                            throw new Exception("Error desconocido");
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public bool Eliminar(Usuario usuario)
        {
            SqlConnection sqlConnection = new SqlConnection(Conexion.connectionString);

            try
            {
                SqlCommand command = new SqlCommand("sp_BajaUsuario", sqlConnection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("Usr", usuario.User));

                //Creo una variable para capturar el retorno de la BDD
                SqlParameter retorno = new SqlParameter();
                retorno.Direction = System.Data.ParameterDirection.ReturnValue;

                command.Parameters.Add(retorno);

                //ADO CONECTADO
                sqlConnection.Open();

                command.ExecuteNonQuery();

                //Clasifico el retorno 
                if (Convert.ToInt32(retorno.Value) == 1)
                    return true;

                switch (Convert.ToInt32(retorno.Value))
                {
                    case -1:
                        {
                            throw new Exception("El nombre de usuario puede ser vacío");
                            break;
                        }
                    case -2:
                        {
                            throw new Exception("No existe un usuario con ese nombre de usuario");
                            break;
                        }
                    case -3:
                        {
                            throw new Exception("No se ha eliminado el usuario porque tiene pronósticos asosciados");
                            break;
                        }
                    default:
                        {
                            throw new Exception("Error desconocido");
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}
