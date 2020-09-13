using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Validar y realizar la operación entre dos numeros
        /// </summary>
        /// <param name="num1">Primer numero a operar</param>
        /// <param name="num2">Segundo numero a operar</param>
        /// <param name="operador">Operación matematica(+, *, - o /) a realizar, por defecto es suma</param>
        /// <returns>El resultado de la operación</returns>
        public static double Operar(Numero num1, Numero num2, string operador) 
        {
            double resultado = 0;
            switch (ValidarOperador(operador[0])) 
            {
                case "+":
                    resultado = num1 + num2;
                    break;
                case "-":
                    resultado = num1 - num2;
                    break;
                case "/":
                    resultado = num1 / num2;
                    break;
                case "*":
                    resultado = num1 * num2;
                    break;
            }

            return resultado;
        }

        private static string ValidarOperador(char operador)
        {
            if(operador == '+' | operador == '-' | operador == '*' | operador == '/')
            {
                return operador.ToString();
            }
            else
            {
                return "+";
            }
        }
    }
}
