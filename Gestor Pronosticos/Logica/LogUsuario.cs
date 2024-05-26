using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia;
using Entidades;

namespace Logica
{
    public class LogUsuario
    {
        private PerUsuario perusr = new PerUsuario();

        public bool Editar(Usuario usuario)
        {
            try
            {
                return perusr.Editar(usuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Eliminar(Usuario usr)
        {
            try
            {
                return perusr.Eliminar(usr);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Crear(Usuario usuario)
        {
            try
            {
               return perusr.Crear(usuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Usuario Buscar (string usr)
        {
            try
            {
                return perusr.Buscar(usr);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Usuario Logueo (string usr,string ctr)
        {
            try
            {
                return perusr.Logueo(usr,ctr);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
