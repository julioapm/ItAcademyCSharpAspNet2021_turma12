using System;
using System.Collections.Generic;

namespace DemoRest1.Models
{
    public class Venda
    {
        public Guid Id {get; set;}
        public string CpfCliente {get;set;}
        public IEnumerable<ItemVenda> Itens {get;set;}
    }

    public class ItemVenda
    {
        public Produto Produto {get;set;}
        public int Quantidade {get;set;}
    }
}