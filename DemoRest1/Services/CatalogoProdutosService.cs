using System.Collections.Generic;
using DemoRest1.Models;
using System.Linq;

namespace DemoRest1.Services
{
    public class CatalogoProdutosService
    {
        private readonly Dictionary<string,Produto> dados;
        public CatalogoProdutosService()
        {
            dados = new Dictionary<string, Produto>();
            dados.Add("p1",new Produto{Codigo="p1", Descricao="Produto 1", ValorUnitario=1.99M, Disponivel=true});
            dados.Add("p2",new Produto{Codigo="p2", Descricao="Produto 2", ValorUnitario=10.55M, Disponivel=true});
            dados.Add("p3",new Produto{Codigo="p3", Descricao="Produto 3", ValorUnitario=5.99M, Disponivel=false});
        }
        public IEnumerable<Produto> ConsultaTodos()
        {
            return dados.Values.OrderBy(p => p.Codigo);
        }
        public Produto ConsultaPorCodigo(string codigo)
        {
            Produto produto;
            dados.TryGetValue(codigo, out produto);
            return produto;
        }
    }
}