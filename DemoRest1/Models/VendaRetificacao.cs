using System;
using System.Collections.Generic;

namespace DemoRest1.Models
{
    public class VendaRetificacao
    {
        public Guid Id {get; set;}
        public string CpfCliente {get;set;}
        public IEnumerable<ItemVendaRetificacao> Itens {get;set;}
    }

    public class ItemVendaRetificacao
    {
        public string CodigoProduto {get;set;}
        public int Quantidade {get;set;}
    }
}