using System;
using System.Collections.Generic;

#nullable disable

namespace DemoEFCore3.Models
{
    public partial class Produto
    {
        public long Codigo { get; set; }
        public string Descricao { get; set; }
        public float PrecoUnitario { get; set; }
        public bool EstaDisponivel { get; set; }
    }
}
