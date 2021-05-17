using System;

namespace Laboratorio3cs
{
    class Program
    {
        static void Main(string[] args)
        {
            ContaCorrente minhaConta = new ContaCorrente();
            minhaConta.Depositar(100M);
            Console.WriteLine(minhaConta.Saldo);
        }
    }
}
