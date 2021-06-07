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
                /*
                Console.WriteLine("Inserindo produtos:");
                var novoProduto = new Produto{Descricao="Novo Produto", PrecoUnitario=10.99F, EstaDisponivel=true};
                await bd.Produtos.AddAsync(novoProduto);
                await bd.SaveChangesAsync();
                */

                /*
                Console.WriteLine("Alterando um produto:");
                var umProduto = await bd.Produtos.FindAsync(4L);
                if (umProduto != null)
                {
                    umProduto.PrecoUnitario = 15F;
                    await bd.SaveChangesAsync();
                }
                */

                Console.WriteLine("Removendo um produto:");
                var umProduto = await bd.Produtos.FindAsync(4L);
                bd.Remove(umProduto);
                await bd.SaveChangesAsync();
                
                /*
                Console.WriteLine("Consultando todos os produtos:");
                var produtos = await bd.Produtos
                            .OrderBy(p => p.PrecoUnitario)
                            .ToListAsync();
                produtos.ForEach(p => Console.WriteLine($"{p.Codigo} : {p.PrecoUnitario}"));
                */
            }
        }
    }
}
