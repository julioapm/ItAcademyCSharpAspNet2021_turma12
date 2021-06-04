using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DemoEFCore2.Models
{
    [Keyless]
    public partial class Filme
    {
        [Column("titulo")]
        [StringLength(250)]
        public string Titulo { get; set; }
        [Column("ano", TypeName = "numeric(4, 0)")]
        public decimal? Ano { get; set; }
        [Column("diretor")]
        [StringLength(100)]
        public string Diretor { get; set; }
        [Column("genero")]
        [StringLength(80)]
        public string Genero { get; set; }
        [Column("atoresPrincipais")]
        [StringLength(1000)]
        public string AtoresPrincipais { get; set; }
        [Column("duracao", TypeName = "numeric(4, 0)")]
        public decimal? Duracao { get; set; }
        [Column("valorIngresso", TypeName = "numeric(5, 2)")]
        public decimal? ValorIngresso { get; set; }
        [Column("codigo")]
        public long? Codigo { get; set; }
    }
}
