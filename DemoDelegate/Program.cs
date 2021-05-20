using System;

namespace DemoDelegate
{
    public delegate int PerformCalculation(int x, int y);
    class Program
    {
        static void Main(string[] args)
        {
            PerformCalculation refMetodo;
            refMetodo = Somar;
            int r = refMetodo(3,7);
            Console.WriteLine(r);
            refMetodo = Multiplicar;
            r = refMetodo(3,7);
            Console.WriteLine(r);
            PerformCalculation refMetodos = Somar;
            refMetodos += Multiplicar;
            Console.WriteLine(refMetodos.GetInvocationList().GetLength(0));
            PerformCalculation refAnonimo = delegate(int a, int b) { return a - b;};
            PerformCalculation refLambda = (a, b) => a/b;
            r = refLambda(5,2);
            Console.WriteLine(r);
            AplicarCalculo((x,y)=>x-y,10,7);
            Func<int,double> funcao = x => Math.Pow(x,2);
        }
        static int Somar(int a, int b)
        {
            return a + b;
        }
        static int Multiplicar(int a, int b)
        {
            return a * b;
        }
        static void AplicarCalculo(PerformCalculation calculation, int a, int b)
        {
            Console.WriteLine(calculation(a,b));
        }
    }
}
