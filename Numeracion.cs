using System;

namespace PrimerParcialLabo
{
    public abstract class Numeracion
    {
        public enum ESistema
        {
            Decimal,
            Binario
        }

        protected static string msgError = "Numero Invalido";
        protected string valor;

        protected Numeracion(string valor)
        {
            InicializaValor(valor);
        }

        public string Valor
        {
            get { return valor; }
        }

        internal abstract int ValorNumerico { get; }

        public abstract Numeracion CambiarSistemaDeNumeracion(string nuevoSistema);

        private void InicializaValor(string valor)
        {
            if (EsNumeracionValida(valor))
            {
                this.valor = valor;
            }
            else
            {
                this.valor = msgError;
            }
        }

        protected bool EsNumeracionValida(string cadena)
        {
            return !string.IsNullOrWhiteSpace(cadena);
        }

        public static bool SonIguales(Numeracion numeracion1, Numeracion numeracion2)
        {
            return numeracion1 != null && numeracion2 != null && numeracion1.GetType() == numeracion2.GetType();
        }

        public static explicit operator double(Numeracion numeracion)
        {
            // Convierte la numeración a double y devuelve su valor numérico
            double resultado;
            if (double.TryParse(numeracion.Valor, out resultado))
            {
                return resultado;
            }
            else
            {
                return double.NaN;
            }
        }
    }

}
