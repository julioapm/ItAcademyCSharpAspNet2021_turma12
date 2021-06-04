using System;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DemoEFCore3.Models;

namespace DemoEFCore3
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (var bd = new BaseDadosContext())
            {
                Console.WriteLine("Inserindo produtos:");
                var novoProduto = new Produto{Descricao="Novo Produto", PrecoUnitario=10.99F, EstaDisponivel=true};
                await bd.Produtos.AddAsync(novoProduto);
                await bd.SaveChangesAsync();

                Console.WriteLine("Consultando todos os produtos:");
                var produtos = await bd.Produtos
                            .OrderBy(p => p.PrecoUnitario)
                            .ToListAsync();
                produtos.ForEach(p => Console.WriteLine($"{p.Codigo} : {p.PrecoUnitario}"));
            }
        }
    }
}
