using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia;
using Entidades;

namespace Logica
{
    public class LogCiudad
    {
        private PerCiudad perciudad = new PerCiudad();

        public void Editar(Ciudad ciudad)
        {
            try
            {
                perciudad.Editar(ciudad);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Eliminar(Ciudad ciudad)
        {
            try
            {
                perciudad.Eliminar(ciudad);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Ciudad> CiudadesPorPais(Pais pais)
        {
            try
            {
                return perciudad.PorPais(pais);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Crear(Ciudad ciudad)
        {
            try
            {
                perciudad.Agregar(ciudad);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Ciudad Buscar(string codCiudad, string codPais)
        {
            try
            {
                return perciudad.Buscar(codCiudad, codPais);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
