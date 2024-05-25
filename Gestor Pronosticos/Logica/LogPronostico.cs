using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Persistencia;

namespace Logica
{
    public class LogPronostico
    {
        PerPronosticos perPronosticos = new PerPronosticos();
        public List <Pronostico> PorFecha(DateTime dia)
        {
            List<Pronostico> pronosticos = new List<Pronostico>();
            try
            {
                pronosticos = perPronosticos.PorFecha(dia);
                return pronosticos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Pronostico> PorCiudad(Ciudad ciudad )
        {
            List<Pronostico> pronosticos = new List<Pronostico>();
            try
            {
                pronosticos = perPronosticos.PorCiudad(ciudad);
                return pronosticos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
