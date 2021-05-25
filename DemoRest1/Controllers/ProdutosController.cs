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
    public class ProdutosController : ControllerBase
    {
        private readonly ILogger<ProdutosController> _logger;
        private readonly CatalogoProdutosService _catalogo;

        public ProdutosController(ILogger<ProdutosController> logger, CatalogoProdutosService catalogo)
        {
            _logger = logger;
            _catalogo = catalogo;
        }

        //GET /api/v1/produtos
        [HttpGet]
        public IEnumerable<Produto> GetProdutos()
        {
            _logger.LogInformation("get /api/v1/produtos");
            return _catalogo.ConsultaTodos();
        }

        //GET /api/v1/produtos/{codigo}
        [HttpGet("{codigo}")]
        public ActionResult<Produto> GetProduto(string codigo)
        {
            _logger.LogInformation($"get /api/v1/produtos/{codigo}");
            if (codigo == null)
            {
                return BadRequest();
            }
            var produto = _catalogo.ConsultaPorCodigo(codigo);
            if (produto == null)
            {
                return NotFound();
            }
            return produto; //implicitamente 200 OK
        }

        [HttpGet("erro")]
        [ProducesResponseType(500)]
        public void GetErro()
        {
            throw new Exception("Ocorreu um erro");
        }
    }
}
