using System;
namespace Entidades
{
    public class Pronostico
    {
        #region Atributos

        private DateTime _fecha;
        private Usuario _usuario;
        private Ciudad _ciudad;
        private string _tipodecielo;
        private int _tempmin;
        private int _tempmax;
        private int _problluvia;
        private int _probtormenta;
        private int _velviento;
        private int _codauto;


        #endregion

        #region Propiedades

        public string TipodeCielo //validamos que sea una de las tres opciones
        {
            get { return _tipodecielo; }
            set
            {
                if ((value.ToLower() != "nuboso") && (value.ToLower() != "parcialmente nuboso") && (value.ToLower() != "despejado"))
                    throw new Exception("Debe ingresar un tipo de cielo válido (nuboso,parcialmente nuboso o despejado");

                else
                    _tipodecielo = value;
            }

        }

        public int TempMin
        {
            get { return _tempmin; }
            set
            {
                if (value < -100 || value > 60)
                    throw new Exception("Ingrese un valor válido de temperatura mínima válido");
                else
                    _tempmin = value;
            }
        }
        public int TempMax //¿Habría que chequear que Tmax sea mayor a Tmin?
        {
            get { return _tempmax; }
            set
            {
                if (value < -100 || value > 60)
                    throw new Exception("Ingrese un valor de temperatura máxima válido");
                else
                    _tempmax = value;
            }
        }
        public int ProbLluvia
        {
            get { return _problluvia; }
            set
            {
                if (value < 0 || value > 100)
                    throw new Exception("Ingrese un valor de probabilidad de lluvia válido");
                else
                    _problluvia = value;

            }
        }
        public int ProbTormenta
        {
            get { return _probtormenta; }
            set
            {
                if (value < 0 || value > 100)
                    throw new Exception("Ingrese un valor de probabilidad de tormenta válido");
                else
                    _probtormenta = value;

            }
        }
        public int VelViento
        {
            get { return _velviento; }
            set
            {
                if (value < 0 || value > 500)
                    throw new Exception("Ingrese un valor de velocidad de viento válido");
                else
                    _velviento = value;

            }
        }

        public DateTime Fecha //¿acá hay que validar formato de fecha o algo más?
        {
            get { return _fecha; }
            set
            {
                if (value.Day < DateTime.Now.Day)
                    throw new Exception("La fecha y hora no pueden ser anterior a la actual");
                _fecha = value;
            }
        }


        public int CodAuto
       {
           get { return _codauto; }
           set { _codauto = value; }

        }

        public Ciudad Ciudad
        {
            get { return _ciudad; }
            set
            {
                if (value == null)
                    throw new Exception("Debe indicar una ciudad");
                else
                    _ciudad = value;
            }
        }
        public Usuario Usuario
        {
            get { return _usuario; }
            set
            {
                if (value == null)
                    throw new Exception("Debe indicar un usuario");
                _usuario = value;
            }
        }

        #endregion

        #region Constructores

        //sin auto
        public Pronostico(string tipodecielo, Usuario usuario, Ciudad ciudad, int tempmax, int tempmin, int problluvia, int probtormenta, int velviento, DateTime fecha) 
        {
            TipodeCielo = tipodecielo;
            Usuario = usuario;
            Ciudad = ciudad;
            TempMax = tempmax;
            TempMin = tempmin;
            ProbLluvia = problluvia;
            ProbTormenta = probtormenta;
            VelViento = velviento;
            Fecha = fecha;
           
        }
        //completo
        public Pronostico(string tipodecielo, Usuario usuario, Ciudad ciudad, int tempmax, int tempmin, int problluvia, int probtormenta, int velviento, DateTime fecha,int codAuto)
        {
            TipodeCielo = tipodecielo;
            Usuario = usuario;
            Ciudad = ciudad;
            TempMax = tempmax;
            TempMin = tempmin;
            ProbLluvia = problluvia;
            ProbTormenta = probtormenta;
            VelViento = velviento;
            Fecha = fecha;
            CodAuto = codAuto;
        }
        #endregion

        #region "Metodos"

        public override string ToString() //Hay que convertir los int a string?
        {
            return "Código de prónostico: " + Convert.ToString(CodAuto) + "\t Fecha y hora: " + Fecha.Date.ToShortDateString() + "\t" + Ciudad.ToString() + "\nTipo de cielo: " +
            TipodeCielo + "\nTemperatura Máx.(ºC): " + Convert.ToString(TempMax) + "\nTemperatura Mín.(ºC): " + Convert.ToString(TempMin) +
            "\nProbabilidad de lluvias(%): " + Convert.ToString(ProbLluvia) + "\nProbabilidad de tormentas(%): " + Convert.ToString(ProbTormenta) + "\nVelocidad del Viento(km/h): " + Convert.ToString(VelViento) + "\n" + Usuario.ToString();
        }
        #endregion
    }
}
