using System;
using System.Collections.Generic;
using System.Linq;

namespace Laboratorio8cs
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<string> listaStrings = new List<string>();
            listaStrings.Add("UmPalavrao");
            listaStrings.Add("Hello");
            listaStrings.Add("World");
            Console.WriteLine(listaStrings.Count);
            Console.WriteLine(listaStrings[0]);
            foreach(var item in listaStrings)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(listaStrings.Max());
            IList<string> outraLista = new List<string>(){"Outra", "MaisUma"};
            var resultado = listaStrings.Concat(outraLista);
            Console.WriteLine(listaStrings);
            Console.WriteLine(outraLista);
            Console.WriteLine(resultado);
            Console.WriteLine(resultado.GetType().Name);
            
        }
    }
}
