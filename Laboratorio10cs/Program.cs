using System;
using System.Collections.Generic;
using System.Linq;

namespace Laboratorio10cs
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<Pessoa> pessoas = new List<Pessoa>
            {
                new Pessoa{Nome="Ana", DataNascimento=new DateTime(1980,3,14), Casada=true},
                new Pessoa{Nome="Paulo", DataNascimento=new DateTime(1978,10,23), Casada=true},
                new Pessoa{Nome="Maria", DataNascimento=new DateTime(2000,1,10), Casada=false},
                new Pessoa{Nome="Carlos", DataNascimento=new DateTime(1999,12,12), Casada=false}
            };
            //forma imperativa
            /*
            IList<Pessoa> casadas = new List<Pessoa>();
            foreach (var pessoa in pessoas)
            {
                if (pessoa.Casada)
                {
                    casadas.Add(pessoa);
                }
            }
            foreach (var pessoa in casadas)
            {
                Console.WriteLine(pessoa);
            }
            */
            /*
            var casadasLinq = from p in pessoas
                              where p.Casada
                              select p;
            foreach (var pessoa in casadasLinq)
            {
                Console.WriteLine(pessoa);
            }
            var casadasLinqv2 = pessoas.Where(p => p.Casada);
            Console.WriteLine(casadasLinqv2.Count());
            var casadasLinqv3 = pessoas
                        .Where(p => p.Casada && p.DataNascimento >= new DateTime(1980,1,1))
                        .Select(p => p.Nome);
            //casadasLinqv3.ToList().ForEach(s => Console.WriteLine(s));
            casadasLinqv3.ToList().ForEach(Console.WriteLine);

            pessoas.OrderBy(p => p.Nome).ToList().ForEach(Console.WriteLine);

            pessoas
            .OrderByDescending(p => p.DataNascimento)
            .ThenBy(p => p.Nome)
            .ToList().ForEach(Console.WriteLine);
            */

            var grupos = pessoas.GroupBy(p => p.Casada);
            foreach(var g in grupos)
            {
                Console.WriteLine($"Casada? {g.Key}");
                Console.WriteLine($"Quantidade: {g.Count()}");
                foreach (var p in g)
                {
                    Console.WriteLine(p);
                }
            }
        }
    }
}
