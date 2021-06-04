using System;
using System.Collections.Generic;

#nullable disable

namespace DemoEFCore1.Models
{
    public partial class Filme
    {
        public string Titulo { get; set; }
        public decimal? Ano { get; set; }
        public string Diretor { get; set; }
        public string Genero { get; set; }
        public string AtoresPrincipais { get; set; }
        public decimal? Duracao { get; set; }
        public decimal? ValorIngresso { get; set; }
    }
}
