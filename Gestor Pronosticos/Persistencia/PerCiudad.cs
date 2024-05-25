using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.SqlClient;

namespace Persistencia
{
    public class PerCiudad
    {
        public List<Ciudad> Listar()
        {
            SqlConnection sqlConnection = new SqlConnection(Conexion.connectionString);

            List<Ciudad> ciudades = new List<Ciudad>();

            try
            {
                //ADO CONECTADO
              
                SqlCommand command = new SqlCommand("sp_TodasLasCiudades", sqlConnection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                sqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();
                Ciudad ciudad = null;
                PerPais perPais = new PerPais();

                while (reader.Read())
                {
                   
                    Pais pais = perPais.Buscar(reader["CodPais"].ToString());
                    ciudad = new Ciudad(reader["Nombre"].ToString(), reader["CodCiud"].ToString(), pais);
                    ciudades.Add(ciudad);

                }
                return ciudades;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problemas con la base de datos:" + ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }

        }
        public void Editar(Ciudad ciudad)
        {
            SqlConnection sqlConnection = new SqlConnection(Conexion.connectionString);

            try
            {
                //ADO CONECTADO
              
                SqlCommand command = new SqlCommand("sp_EditCiudad", sqlConnection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("CodCiud", ciudad.CodCiudad));
                command.Parameters.Add(new SqlParameter("Nom", ciudad.Nombre));
                command.Parameters.Add(new SqlParameter("CodPais",ciudad.Pais.CodPais));
                

                //variable de retorno
                SqlParameter retorno = new SqlParameter();
                retorno.Direction = System.Data.ParameterDirection.ReturnValue;

                command.Parameters.Add(retorno);
                sqlConnection.Open();
                command.ExecuteNonQuery();

                switch (Convert.ToInt32(retorno.Value))
                {
                    case -1:
                        {
                            throw new Exception("Ningún dato puede ser vacío");
                            break;
                        }
                    case -2:
                        {
                            throw new Exception("No existe una ciudad con esos datos");
                            break;
                        }
                    case 1:
                        {
                            throw new Exception("Ciudad editada con éxito");
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

        public Ciudad Buscar(string codCiud, string codPais)
        {
            SqlConnection sqlConnection = new SqlConnection(Conexion.connectionString);

            try
            {
                //ADO CONECTADO
                sqlConnection.Open();
                SqlCommand command = new SqlCommand("sp_BuscarCiudad", sqlConnection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("CodCiud", codCiud));
                command.Parameters.Add(new SqlParameter("CodPais", codPais));

                SqlDataReader reader = command.ExecuteReader();
                Ciudad ciudad = null;
                PerPais perPais = new PerPais();
               

                if (reader.Read()) 
                {
                    Pais pais = perPais.Buscar(reader["CodPais"].ToString());
                    ciudad = new Ciudad(reader["Nombre"].ToString(), reader["CodCiudad"].ToString(), pais);
                }
                return ciudad;
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

        public void Agregar(Ciudad ciudad)
        {
            SqlConnection sqlConnection = new SqlConnection(Conexion.connectionString);

            try
            {
                //ADO CONECTADO
                
                SqlCommand command = new SqlCommand("sp_AltaCiudad", sqlConnection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("CodCiud", ciudad.CodCiudad));
                command.Parameters.Add(new SqlParameter("Nom", ciudad.Nombre));
                command.Parameters.Add(new SqlParameter("CodPais", ciudad.Pais.CodPais));
               

                //Creo una variable para capturar el retorno de la BDD
                SqlParameter retorno = new SqlParameter();
                retorno.Direction = System.Data.ParameterDirection.ReturnValue;

                command.Parameters.Add(retorno);
                sqlConnection.Open();
                command.ExecuteNonQuery();

                //Clasifico el retorno 
                switch (Convert.ToInt32(retorno.Value))
                {
                    case -1:
                        {
                            throw new Exception("Ningún dato de la ciudad puede ser vacío");
                            break;
                        }
                    case -2:
                        {
                            throw new Exception("No se ha creado ya que no existe un país con esos datos");
                            break;
                        }
                    case -3:
                        {
                            throw new Exception("No se ha creado ya que existe una ciudad con esos datos");
                            break;
                        }
                    case 1:
                        {
                            throw new Exception("Ciudad creada con éxito");
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

        public void Eliminar(Ciudad ciudad)
        {
            SqlConnection sqlConnection = new SqlConnection(Conexion.connectionString);

            try
            {
                //ADO CONECTADO
           
                SqlCommand command = new SqlCommand("sp_BajaCiudad", sqlConnection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("CodCiud", ciudad.CodCiudad));
                command.Parameters.Add(new SqlParameter("CodPais", ciudad.Pais.CodPais));
                //Creo una variable para capturar el retorno de la BDD
                SqlParameter retorno = new SqlParameter();
                retorno.Direction = System.Data.ParameterDirection.ReturnValue;

                command.Parameters.Add(retorno);
                sqlConnection.Open();
                command.ExecuteNonQuery();

                //Clasifico el retorno 
                switch (Convert.ToInt32(retorno.Value))
                {
                    case -1:
                        {
                            throw new Exception("Los códigos no pueden ser vacío");
                            break;
                        }
                    case -2:
                        {
                            throw new Exception("No existe una ciudad con esos párametros");
                            break;
                        }
                  
                    case 1:
                        {
                            throw new Exception("Ciudad eliminada con éxito");
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

        public List<Ciudad> PorPais(Pais pais)
        {
            SqlConnection sqlConnection = new SqlConnection(Conexion.connectionString);

            //Instancio una lisa de ciudades
            List<Ciudad> ciudades = new List<Ciudad>();
            try
            {

                //Variable de comando con el nombre del store Proc y el archivo de conexion
                SqlCommand sqlCommand = new SqlCommand("sp_CiudadesPais", sqlConnection);

                //Especifico que es para consumir un Store Procedure
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

              
                sqlCommand.Parameters.Add(new SqlParameter("CodPais", pais.CodPais));

                //Instancio la persistencia de pais
             
                PerPais perPais = new PerPais();
                Ciudad ciudad = null;

                sqlConnection.Open();//Abro la conexion

                //Recorro el resultado del select usando el reader
                SqlDataReader reader = sqlCommand.ExecuteReader();


                while (reader.Read())
                {
                   
                 
                    ciudad = new Ciudad(reader["Nombre"].ToString(), reader["CodCiudad"].ToString(), pais);
                                               

                    ciudades.Add(ciudad);
                }
                reader.Close();
                return ciudades;
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
