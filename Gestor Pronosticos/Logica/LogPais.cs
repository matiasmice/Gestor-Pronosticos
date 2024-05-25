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
        public void Editar(Pais pais)
        {
            try
            {
                perpais.Editar(pais);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Eliminar(Pais pais)
        {
            try
            {
                perpais.Eliminar(pais);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Crear(Pais pais)
        {
            try
            {
                perpais.Agregar(pais);
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
