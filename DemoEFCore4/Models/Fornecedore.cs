using System;
using System.Collections.Generic;

#nullable disable

namespace DemoEFCore4.Models
{
    public partial class Fornecedore
    {
        public Fornecedore()
        {
            Produtos = new HashSet<Produto>();
        }

        public string Codigo { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }
    }
}
