using System;

namespace Laboratorio7cs
{
    public class Pessoa : IComparable<Pessoa>
    {
        public string Nome {get;}
        public int Idade {get; private set;}
        public Pessoa(string n, int i)
        {
            Nome = n;
            Idade = i;
        }
        public int CompareTo(Pessoa other)
        {
            if (other == null) return 1;
            return Nome.CompareTo(other.Nome);
        }
    }
}