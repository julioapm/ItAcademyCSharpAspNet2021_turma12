using System;

namespace Laboratorio3cs
{
    class Program
    {
        static void Main(string[] args)
        {
            ContaCorrente minhaConta = new ContaCorrente(1.99M);
            minhaConta.CpfTitular = "12345678901";
            minhaConta.Depositar(100M);
            minhaConta.Sacar(50M);
            Console.WriteLine(minhaConta.Saldo);
            Console.WriteLine(minhaConta.CpfTitular);
        }
    }
}
