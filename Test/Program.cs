using Golfe.Data.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Golfe.Data.Models;
using Golfe.Web.Database;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var repo = new TarefaRepository();

            DateTime today = DateTime.Today;

            var newTarefa = new Tarefas()
            {
                AreaJogo = "teste",
                Concluida = true,
                Funcionario = "Joao das Couves",
                Maquina = "ceifadeira",
                Operacao = "Corte",
                Data = new DateTime(today.Year, today.Month, today.Day, 10, 39, 30)
                
            };

            repo.Add(newTarefa);
            var tarefas = repo.GetTarefasByFuncionarioAndDataAndConcluida("Joao das Couves", today, today, true);
            var tarefases = tarefas.ToList();

            var edit = new Tarefas()
            {
                AreaJogo = "green",
                Concluida = true,
                Funcionario = "Joao das Couves2",
                Maquina = "rebarbadeira",
                Operacao = "tesourada",
                Data = new DateTime(today.Year, today.Month, today.Day, 10, 39, 30)
                
            };


            repo.Edit(6, edit);

            repo.Delete(6);

            var todastarefas = repo.GetTarefas();
            var todastarefas2=todastarefas.ToList();

            var tempotarefas = repo.GetTarefasByFuncionarioAndDataAndConcluida("Joao das Couves", today, today, true);
            var tempotarefases2 = tempotarefas.ToList();

            Console.Read();
            
        }
    }
}
