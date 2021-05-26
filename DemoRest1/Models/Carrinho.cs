using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DemoRest1.Models
{
    public class Carrinho
    {
        //Obrigatório
        //11 dígitos
        [Required(ErrorMessage="Cpfcliente é obrigatório")]
        [RegularExpression("^[0-9]{11}$", ErrorMessage="CpfCliente formato inválido")]
        public string CpfCliente {get;set;}
        public IEnumerable<ItemCarrinho> Itens {get;set;}
    }

    public class ItemCarrinho
    {
        //Obrigatório
        //Tamanho máximo 10 caracteres
        [Required]
        [MaxLength(10)]
        public string CodigoProduto {get;set;}
        //Valor > 0
        [Range(1,10)]
        public int Quantidade {get;set;}
    }
}