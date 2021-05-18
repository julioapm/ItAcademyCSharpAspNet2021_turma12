using System;

namespace Laboratorio4cs
{
    class Program
    {
        static void Main(string[] args)
        {
            Circulo c1 = new Circulo();
            Console.WriteLine(c1.ToString());
            Object c2 = new Circulo(1,2,3);
            Console.WriteLine(c2.ToString());
            Circulo c3 = new CirculoColorido(1,2,3,"branco");
            Console.WriteLine(c3.ToString());
        }
    }
}
