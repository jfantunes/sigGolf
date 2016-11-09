using System;
using System.Collections.Generic;
using Golfe.Data.Models;
using Golfe.Web.Database;

namespace Golfe.Data.Repository.Interfaces
{
    public interface IFuncionariosRepository
    {
        IEnumerable<Funcionarios> GetFuncionarios();
        Funcionarios Find(int id);
        void Edit(int id, Funcionarios funcionario);
        void Add(Funcionarios funcionario);
        void Delete(int id);
        void Save(golfeEntities db);
    }
}