using System;

namespace Laboratorio10cs
{
    public class Pessoa
    {
        public string Nome {get;set;}
        public bool Casada {get;set;}
        public DateTime DataNascimento {get;set;}
        public override string ToString()
        {
            return base.ToString() + $"[Nome={Nome}, Casada={Casada}, DataNascimento={DataNascimento:d}]";
        }
    }
}