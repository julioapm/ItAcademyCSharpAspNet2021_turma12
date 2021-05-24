using System;
using System.Threading.Tasks;

namespace DemoAsync
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var tarefa = FazCalculoDemoradoAsync(10);
            Console.WriteLine("Disparar o cálculo");
            int resultado = await tarefa;
            Console.WriteLine(resultado);
        }

        static async Task<int> FazCalculoDemoradoAsync(int x)
        {
            Console.WriteLine("Vou fazer o cálculo demorado...");
            await Task.Delay(5000);
            return (int)Math.Pow(2,x);
        }
    }
}
