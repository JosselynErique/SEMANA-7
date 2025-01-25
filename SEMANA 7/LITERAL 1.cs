using System;
using System.Collections.Generic;

namespace VerificacionBalanceo
{
    class Program
    {
        // Método para verificar si una fórmula matemática está balanceada
        static bool EsFormulaBalanceada(string formula)
        {
            Stack<char> pila = new Stack<char>();

            foreach (char c in formula)
            {
                // Si es un paréntesis de apertura, agregarlo a la pila
                if (c == '(' || c == '{' || c == '[')
                {
                    pila.Push(c);
                }
                // Si es un paréntesis de cierre, verificar balanceo
                else if (c == ')' || c == '}' || c == ']')
                {
                    if (pila.Count == 0)
                    {
                        // Si no hay paréntesis de apertura para balancear
                        return false;
                    }

                    char top = pila.Pop();
                    if ((c == ')' && top != '(') ||
                        (c == '}' && top != '{') ||
                        (c == ']' && top != '['))
                    {
                        // Si no hay coincidencia entre apertura y cierre
                        return false;
                    }
                }
            }

            // Si la pila está vacía, la fórmula está balanceada
            return pila.Count == 0;
        }

        static void Main(string[] args)
        {
            // Fórmula de ejemplo
            string formula = "{7+(8*5)-[(9-7)+(4+1)]}";

            // Verificar si la fórmula está balanceada
            bool resultado = EsFormulaBalanceada(formula);
            Console.WriteLine(resultado ? "Fórmula balanceada" : "Fórmula no balanceada");
        }
    }
}
