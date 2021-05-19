using System;

namespace Laboratorio7cs
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            string[] lista = {"Julio", "Lucia", "Daniel", "Joao"};
            foreach (var item in lista)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            Array.Sort(lista);
            foreach (var item in lista)
            {
                Console.WriteLine(item);
            }
            */
            Pessoa[] pessoas = {
                new Pessoa("Jose", 25),
                new Pessoa("Ana", 28),
                new Pessoa("Paulo", 20),
                null
            };
            Array.Sort(pessoas);
            foreach (var item in pessoas)
            {
                Console.WriteLine(item.Nome);
            }
        }
    }
}
