using System;
using System.Collections.Generic;
using System.Text;
using static PrimerParcialLabo.Numeracion;

namespace PrimerParcialLabo
{
    public class Calculadora
    {
        // Atributos privados
        private ESistema sistema;
        private List<string> operaciones;
        private Numeracion primerOperando;
        private double resultado;
        private Numeracion segundoOperando;
        private string nombreAlumno;

        // Atributo de clase
        private static ESistema sistemaPorDefecto = ESistema.Decimal;

        // Constructor
        public Calculadora()
        {
            sistema = sistemaPorDefecto;
            operaciones = new List<string>();
            primerOperando = new SistemaDecimal("0"); 
            segundoOperando = new SistemaDecimal("0"); 
            nombreAlumno = ""; 
        }

        // Propiedades
        public string NombreAlumno { get; set; }

        public IReadOnlyList<string> Operaciones
        {
            get { return operaciones.AsReadOnly(); }
        }

        public Numeracion PrimerOperando
        {
            get { return primerOperando; }
            set { primerOperando = value; }
        }

        public double Resultado
        {
            get { return resultado; }
        }

        public Numeracion SegundoOperando
        {
            get { return segundoOperando; }
            set { segundoOperando = value; }
        }

        public ESistema Sistema
        {
            get { return sistemaPorDefecto; }
            set { sistemaPorDefecto = value; }
        }

        // Métodos
        public void Calcular(string operador = "+")
        {
            if (primerOperando.GetType() == segundoOperando.GetType())
            {
                double valor1 = Convert.ToDouble(primerOperando.ValorNumerico);
                double valor2 = Convert.ToDouble(segundoOperando.ValorNumerico);

                switch (operador)
                {
                    case "+":
                        resultado = valor1 + valor2;
                        break;
                    case "-":
                        resultado = valor1 - valor2;
                        break;
                    case "*":
                        resultado = valor1 * valor2;
                        break;
                    case "/":
                        if (valor2 != 0)
                        {
                            resultado = valor1 / valor2;
                        }
                        else
                        {
                            resultado = double.MinValue;
                        }
                        break;
                    default:
                        resultado = double.MinValue;
                        break;
                }
            }
            else
            {
                resultado = double.MinValue;
            }

            string operacion = ActualizaHistorialDeOperaciones(operador);
            operaciones.Add(operacion);
        }

        public Numeracion MapeaResultado()
        {
            switch (sistema)
            {
                case ESistema.Decimal:
                    return new SistemaDecimal(resultado.ToString());
                case ESistema.Binario:
                    return new SistemaBinario(resultado.ToString());
                default:
                    return new SistemaDecimal(resultado.ToString());
            }
        }

        private string ActualizaHistorialDeOperaciones(string operador)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Sistema: {sistema}");
            sb.AppendLine($"Primer Operando: {primerOperando.Valor}");
            sb.AppendLine($"Segundo Operando: {segundoOperando.Valor}");
            sb.AppendLine($"Operador: {operador}");
            return sb.ToString();
        }

        public void EliminarHistorialDeOperaciones()
        {
            operaciones.Clear();
        }
    }
}
