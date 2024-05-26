using System;
namespace Entidades
{
    public class Ciudad
    {
        #region Atributos

        private string _nombre;
        private string _codciudad;
        private Pais _pais;

        #endregion

        #region Propiedades

        public Pais Pais
        {
            get { return _pais; }
            set
            {
                if (value == null)
                    throw new Exception("Debe indicar un país válido");
                else
                    _pais = value;
            }
        }
        public string Nombre
        {
            get { return _nombre; }
            set
            {
                if (value.Trim() == string.Empty)
                    throw new Exception("Debe indicar el nombre de la ciudad");
                else if (value.Length > 30)
                    throw new Exception("El nombre de la ciudad no puede tener más de 30 caracteres");
                else
                    _nombre = value;
            }
        }
        public string CodCiudad
        {
            get { return _codciudad; }
            set
            {
                if (value.Trim() == string.Empty)
                    throw new Exception("Debe ingresar un código de ciudad");

                else if (value.Length != 3)
                    throw new Exception("Debe indicar un código de tres letras");
                else
                    _codciudad = value;
            }
        }

        
        #endregion




        #region Constructores

        //Completo con relación de vida con País
        public Ciudad(string nombre, string codCiudad, Pais pais)

        {
            Pais = pais;
            Nombre = nombre;
            CodCiudad = codCiudad;
        }

        #endregion

        #region "Metodos"

        public override string ToString()
        {
            return "Ciudad: " + Nombre + " Codigo: " + CodCiudad + "\t" + Pais.ToString() + "\n";
        }
        #endregion



    }
}