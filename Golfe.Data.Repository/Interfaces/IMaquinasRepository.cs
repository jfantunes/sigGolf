using System;
using System.Collections.Generic;
using Golfe.Data.Models;

namespace Golfe.Data.Repository.Interfaces
{
    public interface IMaquinasRepository
    {
        IEnumerable<Maquinas> GetMaquinas();
        Maquinas Find(int id);
    }
}