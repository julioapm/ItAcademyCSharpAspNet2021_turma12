using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using DemoRest1.Models;
using System.Linq;

namespace DemoRest1.Services
{
    public class VendasMemoriaService : IVendasService
    {
        private readonly ConcurrentDictionary<Guid,Venda> dados
        = new ConcurrentDictionary<Guid, Venda>();

        public Venda Adiciona(Venda venda)
        {
            venda.Id = Guid.NewGuid();
            if (dados.TryAdd(venda.Id, venda))
            {
                return venda;
            }
            throw new Exception("Falha de inserção. Id já existe.");
        }

        public void Altera(Venda venda)
        {
            dados[venda.Id] = venda;
        }

        public Venda ConsultaPorId(Guid id)
        {
            Venda venda;
            dados.TryGetValue(id, out venda);
            return venda;
        }

        public IEnumerable<Venda> ConsultaTodos()
        {
            return dados.Values;
        }

        public Venda Remove(Guid id)
        {
            Venda venda;
            dados.TryRemove(id, out venda);
            return venda;
        }
    }
}