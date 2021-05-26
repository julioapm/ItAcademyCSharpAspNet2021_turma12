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
            _logger.LogInformation($"POST: CpfCliente {carrinho.CpfCliente}");
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
            return CreatedAtAction(
                nameof(GetPorId),
                new {id = novaVenda.Id},
                novaVenda
            );
        }

        //GET /api/v1/vendas/{id}
        [HttpGet("{id}")]
        public ActionResult<Venda> GetPorId(Guid id)
        {
            _logger.LogInformation($"GET: Id {id}");
            var venda = _vendas.ConsultaPorId(id);
            if (venda == null)
            {
                return NotFound();
            }
            return venda;
        }

        //DELETE: /api/v1/vendas/{id}
        [HttpDelete("{id}")]
        public ActionResult<Venda> DeletePorId(Guid id)
        {
            _logger.LogInformation($"DELETE: Id {id}");
            var venda = _vendas.Remove(id);
            if (venda == null)
            {
                return NotFound();
            }
            return venda;
        }
    }
}