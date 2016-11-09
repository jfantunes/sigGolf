using System;
using System.Collections.Generic;
using Golfe.Data.Models;

namespace Golfe.Data.Repository.Interfaces
{
    public interface IAreaJogoRepository 
    {
        IEnumerable<AreaJogo> GetAreasJogo();
        AreaJogo Find(int id);
    }
}