using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Persistencia
{
    public class PerPronosticos
    {
        public List<Pronostico> PorCiudad(Ciudad ciudad)
        {
            //Varible de conexión
            SqlConnection sqlConnection = new SqlConnection(Conexion.connectionString);

            //Instancio una lisa de Pronósticos
            List<Pronostico> pronosticos = new List<Pronostico>();
            try
            {

                //Variable de comando con el nombre del store Proc y el archivo de conexion
                SqlCommand sqlCommand = new SqlCommand("sp_PronosticoPorCiudad", sqlConnection);

                //Especifico que es para consumir un Store Procedure
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                //le paso parametros
                sqlCommand.Parameters.Add(new SqlParameter("CodCiud", ciudad.CodCiudad));
                sqlCommand.Parameters.Add(new SqlParameter("CodPais", ciudad.Pais.CodPais));

                //Instancio la persistencia de usuario, un usuario, persistencia de ciudad y una ciudad.
                PerUsuario perUsuario = new PerUsuario();
                PerCiudad perCiudad = new PerCiudad();
                Pronostico pronostico = null;

                sqlConnection.Open();//Abro la conexion

                //Recorro el resultado del select usando el reader
                SqlDataReader reader = sqlCommand.ExecuteReader();


                while (reader.Read())
                {
                    Usuario usuario = perUsuario.Buscar(reader["Usuario"].ToString());


                    pronostico = new Pronostico(reader["TipodeCielo"].ToString(), usuario, ciudad,
                                               Convert.ToInt32(reader["TempMax"].ToString()),
                                               Convert.ToInt32(reader["TempMin"].ToString()),
                                               Convert.ToInt32(reader["ProbLluvia"].ToString()),
                                               Convert.ToInt32(reader["ProbTormenta"].ToString()),
                                               Convert.ToInt32(reader["VelViento"].ToString()),
                                               Convert.ToDateTime(reader["Fecha"].ToString()),
                                               Convert.ToInt32 (reader["CodAuto"].ToString()));

                    pronosticos.Add(pronostico);
                }
                reader.Close();
                return pronosticos;
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
        public List<Pronostico> PorFecha(DateTime dia)
           {
            //Varible de conexión
            SqlConnection sqlConnection = new SqlConnection(Conexion.connectionString);

            //Instancio una lisa de Pronósticos
            List<Pronostico> pronosticos = new List<Pronostico>();
            try
            {
                //Variable de comando con el nombre del store Proc y el archivo de conexion
                SqlCommand sqlCommand = new SqlCommand("sp_PronosticosParaFecha", sqlConnection);

                //Especifico que es para consumir un Store Procedure
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                //le paso parametros
                sqlCommand.Parameters.Add(new SqlParameter("fecha", dia));

                //Instancio la persistencia de usuario, un usuario, persistencia de ciudad y una ciudad.
                PerUsuario perUsuario = new PerUsuario();
                PerCiudad perCiudad = new PerCiudad();
                Pronostico pronostico = null;


                sqlConnection.Open();//Abro la conexion

                //Recorro el resultado del select usando el reader
                SqlDataReader reader = sqlCommand.ExecuteReader();


                while (reader.Read())
                {
                    Usuario usuario = perUsuario.Buscar(reader["Usuario"].ToString());
                    Ciudad ciudad = perCiudad.Buscar(reader["CodCiudad"].ToString(), reader["CodPais"].ToString());

                    pronostico = new Pronostico(reader["TipodeCielo"].ToString(), usuario, ciudad,
                                               Convert.ToInt32(reader["TempMax"].ToString()),
                                               Convert.ToInt32(reader["TempMin"].ToString()),
                                               Convert.ToInt32(reader["ProbLluvia"].ToString()),
                                               Convert.ToInt32(reader["ProbTormenta"].ToString()),
                                               Convert.ToInt32(reader["VelViento"].ToString()),
                                               Convert.ToDateTime(reader["Fecha"].ToString()),
                                               Convert.ToInt32(reader["CodAuto"].ToString()));                                               

                    pronosticos.Add(pronostico);
                }
                reader.Close();
                return pronosticos;
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

        public void Agregar(Pronostico pronostico) 
        {
            //Varible de conexión
            SqlConnection sqlConnection = new SqlConnection(Conexion.connectionString);

            try
            {
                SqlCommand command = new SqlCommand("sp_AgregarPronostico", sqlConnection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("CodCiud", pronostico.Ciudad.CodCiudad));
                command.Parameters.Add(new SqlParameter("Usr", pronostico.Usuario.User));
                command.Parameters.Add(new SqlParameter("CodPais", pronostico.Ciudad.Pais.CodPais));
                command.Parameters.Add(new SqlParameter("Fecha", pronostico.Fecha));
                command.Parameters.Add(new SqlParameter("VelViento", pronostico.VelViento));
                command.Parameters.Add(new SqlParameter("ProbTormenta", pronostico.ProbTormenta));
                command.Parameters.Add(new SqlParameter("ProbLluvia", pronostico.ProbLluvia));
                command.Parameters.Add(new SqlParameter("TMax", pronostico.TempMax));
                command.Parameters.Add(new SqlParameter("TMin", pronostico.TempMin));
                command.Parameters.Add(new SqlParameter("TipodeCielo", pronostico.TipodeCielo));

                //Creo una variable para capturar el retorno de la BDD
                SqlParameter retorno = new SqlParameter();
                retorno.Direction = System.Data.ParameterDirection.ReturnValue;

                command.Parameters.Add(retorno);

                //ADO CONECTADO
                sqlConnection.Open();

                command.ExecuteNonQuery();

                //Clasifico el retorno 
                switch (Convert.ToInt32(retorno.Value))
                {
                    case -1:
                        {
                            throw new Exception("No se encuentra la ciudad con esos datos");
                            break;
                        }
                    case -2:
                        {
                            throw new Exception("Ya existe un prónostico para esa ciudad y esa fecha-hora");
                            break;
                        }
                    case -3:
                        {
                            throw new Exception("Debe completar todos los datos para ingresar el prónostico");
                            break;
                        }
                    case 1:
                        {
                            throw new Exception("Pronóstico creado con éxito");
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
