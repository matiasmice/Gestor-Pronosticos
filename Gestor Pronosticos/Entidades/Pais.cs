using System;
namespace Entidades
{
    public class Pais
    {
        #region Atributos

        private string _nombre;
        private string _codpais;

        #endregion

        #region Propiedades

        public string Nombre
        {
            get { return _nombre; }
            set
            {
                if (value.Trim() == string.Empty)
                    throw new Exception("Debe indicar el nombre del país");
                else if (value.Length > 30)
                    throw new Exception("El nombre del país no puede tener más de 30 caracteres");
                else
                    _nombre = value;
            }
        }
        public string CodPais
        {
            get { return _codpais; }
            set
            {
                if (value.Trim() == string.Empty)
                    throw new Exception("Debe ingresar un código de país");

                else if (value.Length != 3)
                    throw new Exception("Debe indicar un código de tres letras");
                else
                    _codpais = value;
            }
        }

        //Se crea una propiedad que devuelva el ToString para poder agregarla en la DropDounList
        public string Dato
        {
            get { return ToString(); }
        }


        #endregion

        #region Constructores

        //Constructor completo
        public Pais(string nombre, string codPais)
        {
            Nombre = nombre;
            CodPais = codPais;
        }

        #endregion

        #region "Metodos"

        public override string ToString()
        {
            return "País: " + Nombre + " Codigo: " + CodPais +  "\n";
        }
        #endregion
    }
}
