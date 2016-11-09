using System;
using System.Collections.Generic;
using Golfe.Data.Models;

namespace Golfe.Data.Repository.Interfaces
{
    public interface IOperacaoRepository
    {
        IEnumerable<Operacao> GetOperacoes();
        Operacao Find(int id);
    }
}