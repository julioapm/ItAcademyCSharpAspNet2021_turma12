using System;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DemoEFCore4.Models;
using System.Collections.Generic;

namespace DemoEFCore4
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (var bd = new BaseDadosContext())
            {
                /*
                var novoFornecedor = new Fornecedor
                {
                    Codigo = "XYZ",
                    Nome = "Novo",
                    Produtos = new List<Produto>
                    {
                        new Produto
                        {
                            Descricao = "Mouse",
                            PrecoUnitario = 50F,
                            EstaDisponivel = false
                        },
                        new Produto
                        {
                            Descricao = "Teclado",
                            PrecoUnitario = 100F,
                            EstaDisponivel = true
                        }
                    }
                };
                await bd.Fornecedores.AddAsync(novoFornecedor);
                await bd.SaveChangesAsync();
                */

                var umFornecedor = await bd.Fornecedores
                                    .Where(f => f.Codigo == "ABD")
                                    .Include(f => f.Produtos)
                                    .FirstOrDefaultAsync();
                if (umFornecedor != null)
                {
                    umFornecedor.Produtos.Add(new Produto
                    {
                        Descricao = "Livro",
                        EstaDisponivel = true,
                        PrecoUnitario = 25.90F
                    });
                    await bd.SaveChangesAsync();
                }

                /*
                //Consulta eager
                var fornecedores = await bd.Fornecedores
                                    .Include(f => f.Produtos)
                                    .ToListAsync();
                fornecedores.ForEach(f =>
                        Console.WriteLine($"{f.Nome} ({f.Codigo}): {f.Produtos.Count}")
                );
                */
                /*
                //Explicit loading
                var fornecedores = bd.Fornecedores.ToList();
                fornecedores.ForEach(f =>
                    {
                        Console.WriteLine($"{f.Nome} ({f.Codigo}):");
                        bd.Entry(f).Collection(f => f.Produtos).Load();
                        foreach (var p in f.Produtos)
                        {
                            Console.WriteLine($"{p.Descricao} ({p.Codigo})");
                        }
                    }
                );
                */
            }

        }
    }
}
