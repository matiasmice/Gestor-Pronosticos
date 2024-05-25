using System;
namespace Entidades
{
    public class Usuario
    {
        #region Atributos

        private string _nombre;
        private string _apellido;
        private string _user;
        private string _contrasenia;

        #endregion

        #region Propiedades

        public string Nombre
        {
            get { return _nombre; }
            set
            {
                if (value.Trim() == string.Empty)
                    throw new Exception("Debe indicar el nombre del Usuario");
                else if (value.Length >30)
                    throw new Exception("El nombre de usuario no puede tener más de 30 caracteres");
                else
                    _nombre = value;
            }
        }

        public string Apellido
        {
            get { return _apellido; }
            set
            {
                if (value.Trim() == string.Empty)
                    throw new Exception("Debe indicar el apellido del Usuario");
                else if (value.Length > 30)
                    throw new Exception("El apellido de usuario no puede tener más de 30 caracteres");
                else
                    _apellido = value;
            }
        }

        public string User
        {
            get { return _user; }
            set
            {
                if (value.Trim() == string.Empty)
                    throw new Exception("Debe indicar un nombre de usuario");
                else if (value.Length > 30)
                    throw new Exception("El nombre de usuario no puede tener más de 30 caracteres");
                else
                    _user = value;
            }
        }


        public string Contrasenia
        {
            get { return _contrasenia; }
            set
            {
                if (value.Trim() == string.Empty)
                    throw new Exception("Debe indicar una contraseña");
                else if (value.Length > 8)
                    throw new Exception("La contraseña no puede superar 8 caracteres");
                else
                    _contrasenia = value;
            }
        }
        #endregion

        #region Constructores

        //Constructor completo
        public Usuario(string nombre,string apellido, string usuario, string contrasenia)
        {
            Nombre = nombre;
            Apellido = apellido;
            User = usuario;
            Contrasenia = contrasenia;
        }

        #endregion

        #region "Métodos"

        public override string ToString()
        {
            return "Nombre Completo: " + Nombre +" "+ Apellido + "\n "+ " Usuario: " + User;
        }

        #endregion

    }
}

