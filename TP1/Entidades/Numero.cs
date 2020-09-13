using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        public string SetNumero
        {
            set 
            { 
                numero = ValidarNumero(value);
            }
        }

        /// <summary>
        /// Convierte un numero binario almacenado en una cadena de caracteres
        /// a un numero entero. Devuelve "Valor invalido" si la cadena contiene
        /// caracteres que no sean 1 o 0.
        /// </summary>
        /// <param name="binario">numero binario a convertir</param>
        /// <returns>numero convertido o "Valor invalido"</returns>
        public string BinarioDecimal(string binario)
        {
            if (!EsBinario(binario))
            {
                return "Valor invalido";
            }
            else
            {
                int multiplicadorBinario = 1;
                int resultado = 0;
                //revisamos si tiene algo que no sea 1 ó 0
                for (int digito = binario.Length - 1; digito >= 0; digito--)
                {
                    if (binario[digito] == '1')
                    {
                        resultado += multiplicadorBinario;
                    }
                    multiplicadorBinario *= 2;
                }
                return resultado.ToString();
            }
            
        }

        /// <summary>
        /// Convierte un numero decimal (redondeado para abajo) a binario, devuelve "Valor invalido"
        /// si el numero es negativo.
        /// </summary>
        /// <param name="numero">Numero a convertir</param>
        /// <returns>Numero convertido o "Valor invalido"</returns>
        public string DecimalBinario(double numero)
        {
            //redondea el numero para abajo antes de pasar el string a la otra funcion DecimalBinario
            return DecimalBinario(Math.Floor(numero).ToString());
        }

        public string DecimalBinario(string numero)
        {
            string resultado = "";
            try
            {
                double num = double.Parse(numero);
                if (num < 0)
                {
                    //error si es negativo
                    return "Valor invalido";
                }
                //convierte de string binario a int y luego de int a string
                for (int i = 0; num >=1; i++)
                {
                    resultado = Math.Floor(num % 2).ToString() + resultado;
                    num = num / 2;
                }
                return resultado;
            }
            catch (Exception)
            {
                //error si no es numero
                return "Valor invalido";
            }
        }
        /// <summary>
        /// Revisa si la cadena es un numero binario
        /// </summary>
        /// <param name="binario">Numero binario</param>
        /// <returns>Verdadero si es un binario valido</returns>
        bool EsBinario(string binario)
        {
            for (int digito = binario.Length - 1; digito >= 0; digito--)
            {
                if (binario[digito] != '1' & binario[digito] != '0')
                {
                    return false;
                }
            }
            return true;
        }
        
        #region CONSTRUCTORES
        public Numero()
        {
            this.numero = 0;
        }

        public Numero(double numero)
        {
            this.numero = numero;
        }

        public Numero(string strnumero)
        {
            SetNumero = strnumero;
        }
        #endregion

        #region OPERADORES
        /// <summary>
        /// Suma de dos numeros
        /// </summary>
        /// <param name="n1">numero 1</param>
        /// <param name="n2">numero 2</param>
        /// <returns>Total de la suma</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }
        /// <summary>
        /// Resta de dos numeros
        /// </summary>
        /// <param name="n1">numero 1</param>
        /// <param name="n2">numero 2</param>
        /// <returns>Total de la resta</returns>
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }
        /// <summary>
        /// Producto de dos numeros
        /// </summary>
        /// <param name="n1">numero 1</param>
        /// <param name="n2">numero 2</param>
        /// <returns>Total de la multiplicación</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }
        /// <summary>
        /// División de dos numeros, retorna 0 
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator /(Numero n1, Numero n2)
        {
            double resultado;
            //revisa si es posible dividir. Si no devuelve 0
            try
            {
                resultado = n1.numero / n2.numero;
            }
            catch (Exception)
            {
                resultado = double.MinValue;
            }
            return resultado;
        }
        #endregion

        private double ValidarNumero(string strNumero)
        {
            try
            {
                return double.Parse(strNumero);
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
