using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.SqlClient;

namespace Persistencia
{
    public class PerPais
    {
        public List<Pais> Listar()
        {
            SqlConnection sqlConnection = new SqlConnection(Conexion.connectionString);

            List<Pais> paises = new List<Pais>();
            
            try
            {
                //ADO CONECTADO
            
                SqlCommand command = new SqlCommand("sp_TodoslosPaises", sqlConnection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                sqlConnection.Open();

                SqlDataReader reader = command.ExecuteReader();
                Pais pais = null;

                while (reader.Read())
                {
                    pais = new Pais(reader["Nombre"].ToString(), reader["CodPais"].ToString());
                    paises.Add(pais);

                }
                return paises;
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
        public Pais Buscar(string codPais)
        {
            SqlConnection sqlConnection = new SqlConnection(Conexion.connectionString);

            try
            {
                //ADO CONECTADO
             
                SqlCommand command = new SqlCommand("sp_BuscarPais", sqlConnection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("CodPais", codPais));
                sqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();
                Pais pais = null;

                if (reader.Read())
                {
                    pais = new Pais(reader["Nombre"].ToString(), reader["CodPais"].ToString());

                }
                return pais;
                
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
        public bool Editar(Pais pais)
        {
            SqlConnection sqlConnection = new SqlConnection(Conexion.connectionString);

            try
            {
                //ADO CONECTADO

                SqlCommand command = new SqlCommand("sp_EditPais", sqlConnection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("Nom", pais.Nombre));
                command.Parameters.Add(new SqlParameter("Cod", pais.CodPais));


                //variable de retorno
                SqlParameter retorno = new SqlParameter();
                retorno.Direction = System.Data.ParameterDirection.ReturnValue;

                command.Parameters.Add(retorno);
                sqlConnection.Open();
                command.ExecuteNonQuery();

                if (Convert.ToInt32(retorno.Value) == 1)
                    return true;

                switch (Convert.ToInt32(retorno.Value))
                {
                    case -1:
                        {
                            throw new Exception("Ningún dato puede ser vacío");
                            break;
                        }
                    case -2:
                        {
                            throw new Exception("No existe un país con esos datos");
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
        public bool Agregar(Pais pais)
        {
            SqlConnection sqlConnection = new SqlConnection(Conexion.connectionString);

            try
            {
                //ADO CONECTADO
             
                SqlCommand command = new SqlCommand("sp_AltaPais", sqlConnection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("Nom", pais.Nombre));
                command.Parameters.Add(new SqlParameter("Cod", pais.CodPais));
             

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
                            throw new Exception("Ningún dato del país puede ser vacío");
                            break;
                        }
                    case -2:
                        {
                            throw new Exception("No se ha creado ya que ya existe el país con esos datos");
                            break;
                        }
                    case 1:
                        {
                            return true;
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
        public bool Eliminar(Pais pais)
        {
            SqlConnection sqlConnection = new SqlConnection(Conexion.connectionString);

            try
            {
                //ADO CONECTADO
              
                SqlCommand command = new SqlCommand("sp_BajaPais", sqlConnection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("Cod", pais.CodPais));

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
                            throw new Exception("El código del país no puede ser vacío");
                            break;
                        }
                    case -2:
                        {
                            throw new Exception("No existe un país con ese código");
                            break;
                        }
                    case -3:
                        {
                            throw new Exception("No se ha eliminado el país porque tiene pronósticos asociados");
                            break;
                        }
                    case 1:
                        {
                            return true;
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
