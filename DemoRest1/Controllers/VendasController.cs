using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DemoRest1.Services;
using DemoRest1.Models;

namespace DemoRest1.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class VendasController : ControllerBase
    {
        private readonly ILogger<VendasController> _logger;
        private readonly IVendasService _vendas;
        private readonly CatalogoProdutosService _catalogo;
        public VendasController(ILogger<VendasController> logger, IVendasService vendas, CatalogoProdutosService catalogo)
        {
            _logger = logger;
            _vendas = vendas;
            _catalogo = catalogo;
        }

        //POST /api/v1/vendas
        [HttpPost]
        public ActionResult<Venda> PostComprar(Carrinho carrinho)
        {
            _logger.LogInformation($"POST: {carrinho.CpfCliente}");
            //Melhor fazer em outro objeto
            Venda venda = new Venda();
            venda.CpfCliente = carrinho.CpfCliente;
            var itensVenda = carrinho.Itens.Select(item => {
                var produto = _catalogo.ConsultaPorCodigo(item.CodigoProduto);
                return new ItemVenda() {
                    Produto = produto,
                    Quantidade = item.Quantidade
                };
            });
            venda.Itens = itensVenda;
            Venda novaVenda = _vendas.Adiciona(venda);
            return venda;
        }
    }
}