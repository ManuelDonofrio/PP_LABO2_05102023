using System;

namespace PrimerParcialLabo
{
    internal class SistemaDecimal : Numeracion
    {
        // Constructor 
        public SistemaDecimal(string valor) : base(valor)
        {
        }

        // Propiedad
        internal override int ValorNumerico
        {
            get
            {
                if (int.TryParse(Valor, out int resultado))
                {
                    return resultado;
                }
                else
                {
                    return msgError.GetHashCode();
                }
            }
        }
        // Métodos
        public override Numeracion CambiarSistemaDeNumeracion(string nuevoSistema)
        {
            if (EsSistemaValido(nuevoSistema))
            {
                if (nuevoSistema.Equals("Decimal", StringComparison.OrdinalIgnoreCase))
                {
                    return new SistemaDecimal(Valor);
                }
                else if (nuevoSistema.Equals("Binario", StringComparison.OrdinalIgnoreCase))
                {
                    if (int.TryParse(Valor, out int valorDecimal))
                    {
                        return new SistemaBinario(DecimalABinario(valorDecimal));
                    }
                }
            }
            return new SistemaDecimal(msgError);
        }


        private int DecimalABinario(string valor)
        {
            if (EsSistemaValido(valor))
            {
                int valorDecimal = 0;
                int longitud = valor.Length;

                for (int i = 0; i < longitud; i++)
                {
                    char bit = valor[longitud - 1 - i];

                    if (bit == '1')
                    {
                        valorDecimal += (int)Math.Pow(2, i);
                    }
                }

                return valorDecimal;
            }
            else
            {
                return int.MinValue;

            }
        }

        private bool EsSistemaValido(string sistema)
        {
            if (string.Equals(sistema, "Decimal", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool EsSistemaDecimalValido(string cadena)
        {
            double valorDouble;
            return double.TryParse(cadena, out valorDouble);
        }


        private string DecimalABinario(int valorDecimal)
        {
            if (valorDecimal > 0)
            {
                string valorBinario = string.Empty;

                while (valorDecimal > 0)
                {
                    int bit = valorDecimal % 2;
                    valorBinario = bit.ToString() + valorBinario;
                    valorDecimal /= 2;
                }

                return valorBinario;
            }
            else if (valorDecimal == 0)
            {
                return "0"; // Devolver "0" si el valorDecimal es 0
            }
            else
            {
                return msgError;
            }
        }



        public static implicit operator SistemaDecimal(double valorDouble)
        {
            return new SistemaDecimal(valorDouble.ToString());
        }

        public static implicit operator SistemaDecimal(string valor)
        {
            return new SistemaDecimal(valor);
        }
    }
}


