using System;
namespace Laboratorio3cs
{
    public class ContaCorrente
    {
        private decimal saldo;
        public ContaCorrente(decimal val)
        {
            saldo = val;
        }
        public void Depositar(decimal val)
        {
            saldo = saldo + val;
        }
        public void Sacar(decimal val)
        {
            saldo = saldo - val;
        }
        public decimal Saldo
        {
            get
            {
                return saldo;
            }
        }
        public string CpfTitular {get; set;}
    }
}