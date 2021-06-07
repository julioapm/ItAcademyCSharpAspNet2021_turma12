using System;
using System.Collections.Generic;

#nullable disable

namespace DemoEFCore4.Models
{
    public partial class Produto
    {
        public long Codigo { get; set; }
        public string Descricao { get; set; }
        public float Precounitario { get; set; }
        public bool Estadisponivel { get; set; }
        public string CodigoFornecedor { get; set; }

        public virtual Fornecedore CodigoFornecedorNavigation { get; set; }
    }
}
