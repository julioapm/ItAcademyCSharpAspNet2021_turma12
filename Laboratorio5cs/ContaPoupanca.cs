using System;

namespace Laboratorio5cs
{
    public class ContaPoupanca : Conta
    {
        private decimal taxaJuros;
        private DateTime dataAniversario;
        public ContaPoupanca(string t, decimal j, DateTime d) : base(t)
        {
            taxaJuros = j;
            dataAniversario = d;
        }
        public override string Id
        {
            get {return $"{Titular}(CP)";}
        }
    }
}