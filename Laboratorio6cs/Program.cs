using System;

namespace Laboratorio6cs
{
    class Program
    {
        static void Main(string[] args)
        {
            IEstadoBinario[] coisas = new IEstadoBinario[2];
            coisas[0] = new Lampada(110,60);
            coisas[1] = new TermometroEletrico();
            foreach(var coisa in coisas)
            {
                Console.WriteLine(coisa.Estado);
            }
        }
    }
}
