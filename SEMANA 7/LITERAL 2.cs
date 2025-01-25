using System;
using System.Collections.Generic;

namespace TorresDeHanoi
{
    class Program
    {
        // Método para resolver las Torres de Hanoi
        static void ResolverTorresDeHanoi(int numDiscos, Stack<int> origen, Stack<int> destino, Stack<int> auxiliar, string nombreOrigen, string nombreDestino, string nombreAuxiliar)
        {
            if (numDiscos == 1)
            {
                // Mover el disco de la torre origen a la torre destino
                int disco = origen.Pop();
                destino.Push(disco);
                Console.WriteLine($"Mover disco {disco} de {nombreOrigen} a {nombreDestino}");
            }
            else
            {
                // Mover n-1 discos de origen a auxiliar
                ResolverTorresDeHanoi(numDiscos - 1, origen, auxiliar, destino, nombreOrigen, nombreAuxiliar, nombreDestino);

                // Mover el disco más grande de origen a destino
                int disco = origen.Pop();
                destino.Push(disco);
                Console.WriteLine($"Mover disco {disco} de {nombreOrigen} a {nombreDestino}");

                // Mover los n-1 discos de auxiliar a destino
                ResolverTorresDeHanoi(numDiscos - 1, auxiliar, destino, origen, nombreAuxiliar, nombreDestino, nombreOrigen);
            }
        }

        static void Main(string[] args)
        {
            Console.Write("Ingrese el número de discos: ");
            string? entrada = Console.ReadLine();

            // Validar que la entrada no sea nula o vacía
            if (string.IsNullOrWhiteSpace(entrada))
            {
                Console.WriteLine("Entrada inválida. Por favor, ingrese un número entero.");
                return;
            }

            // Intentar convertir la entrada a un número entero
            if (!int.TryParse(entrada, out int numDiscos) || numDiscos <= 0)
            {
                Console.WriteLine("Entrada inválida. Por favor, ingrese un número entero positivo.");
                return;
            }

            // Inicializar las pilas para las tres torres
            Stack<int> origen = new Stack<int>();
            Stack<int> auxiliar = new Stack<int>();
            Stack<int> destino = new Stack<int>();

            // Llenar la torre origen con los discos
            for (int i = numDiscos; i >= 1; i--)
            {
                origen.Push(i);
            }

            Console.WriteLine("\nMovimientos necesarios:");
            ResolverTorresDeHanoi(numDiscos, origen, destino, auxiliar, "Origen", "Destino", "Auxiliar");

            Console.WriteLine("\n¡Resolución completa!");
        }
    }
}
