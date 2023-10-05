using System;

namespace PrimerParcialLabo
{
    internal class SistemaBinario : Numeracion
    {
        // Constructor
        public SistemaBinario(string valor) : base(valor)
        {
        }

        // Propiedad 
        internal override int ValorNumerico
        {
            get
            {
                if (EsSistemaBinarioValido(Valor))
                {
                    int valorDecimal = Convert.ToInt32(Valor, 2);
                    return valorDecimal;
                }
                else
                {
                    return msgError.GetHashCode();
                }
            }
        }

        public int ValorBinario { get; }

        // Métodos
        public override Numeracion CambiarSistemaDeNumeracion(string nuevoSistema)
        {
            if (EsSistemaValido(nuevoSistema))
            {
                if (nuevoSistema.Equals("Binario", StringComparison.OrdinalIgnoreCase))
                {
                    return this;
                }
                else if (nuevoSistema.Equals("Decimal", StringComparison.OrdinalIgnoreCase))
                {
                    int valorDecimal = ValorNumerico;
                    return new SistemaDecimal(valorDecimal.ToString());
                }
            }

            return new SistemaBinario(msgError);
        }

        private bool EsSistemaValido(string nuevoSistema)
        {
            throw new NotImplementedException();
        }
        private bool EsSistemaBinarioValido(string cadena)
        {
            foreach (char caracter in cadena)
            {
                if (caracter != '0' && caracter != '1')
                {
                    return false;
                }
            }
            return true;
        }
        private int BinarioADecimal(string valor)
        {
            if (EsSistemaBinarioValido(valor))
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
        public static implicit operator SistemaBinario(string valor)
        {
            return new SistemaBinario(valor);
        }
    }
}
