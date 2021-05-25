using System;
using System.Collections.Generic;
using DemoRest1.Models;

namespace DemoRest1.Services
{
    public interface IVendasService
    {
        IEnumerable<Venda> ConsultaTodos();
        Venda ConsultaPorId(Guid id);
        Venda Adiciona(Venda venda);
        Venda Remove(Guid id);
        void Altera(Venda venda);
    }
}