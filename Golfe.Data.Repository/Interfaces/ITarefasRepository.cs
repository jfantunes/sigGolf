using Golfe.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Golfe.Web.Database;

namespace Golfe.Data.Repository.Interfaces
{
    public interface ITarefasRepository
    {
        IEnumerable<Tarefas> GetTarefas();
        Tarefas Find(int id);
        void Edit(int id, Tarefas tarefa);
        void Add(Tarefas tarefa);
        void Delete(int id);
        void Save(golfeEntities db);
    }
}
