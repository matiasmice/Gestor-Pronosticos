using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia;
using Entidades;

namespace Logica
{
    public class LogPais
    {
        private PerPais perpais = new PerPais();

        public List<Pais> Listar()
        {
            try
            {
                return perpais.Listar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Editar(Pais pais)
        {
            try
            {
                return perpais.Editar(pais);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Eliminar(Pais pais)
        {
            try
            {
                return perpais.Eliminar(pais);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Crear(Pais pais)
        {
            try
            {
                return perpais.Agregar(pais);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Pais Buscar(string codPais)
        {
            try
            {
                return perpais.Buscar(codPais);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
