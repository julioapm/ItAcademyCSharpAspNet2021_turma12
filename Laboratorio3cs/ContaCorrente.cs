using System;
namespace Laboratorio3cs
{
    public class ContaCorrente
    {
        private decimal saldo;
        public void Depositar(decimal val)
        {
            saldo = saldo + val;
        }
        public decimal Saldo
        {
            get
            {
                return saldo;
            }
        }
    }
}