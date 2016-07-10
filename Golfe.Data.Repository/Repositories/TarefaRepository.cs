using Golfe.Data.Repository.Interfaces;
using Golfe.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Golfe.Web.Database;
using AutoMapper;
using Golfe.Data.Models.Mappings;

namespace Golfe.Data.Repository.Repositories
{
    public class TarefaRepository : ITarefasRepository
    {
        
        private readonly  IMapper _mapper;

        public TarefaRepository()
        {
            this._mapper = FactoryGolfMapper.Map(MappingEnum.Tarefas);

        }

        public IEnumerable<Tarefas> GetTarefas()
        {
            try
            {
                using (var db=new golfEntities())
                {

                    var tarefas = from t in db.tarefasgerais
                        orderby t.id descending
                        select t;

                    return this._mapper.Map<IEnumerable<tarefasgerais>, IEnumerable<Tarefas>>(tarefas);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            
            
        }

        public IEnumerable<Tarefas> GetTarefasByFuncionarioAndDataAndConcluida(string funcionario,DateTime start,DateTime end,bool concluida)
        {
            try
            {
                using (var db = new golfEntities())
                {
                    var tarefas = (from t in db.tarefasgerais
                        where
                            (t.funcionario == funcionario && t.data >= start && t.data <= end &&
                             t.concluida == concluida)
                        orderby t.id descending
                        select t);

                    return this._mapper.Map<IEnumerable<tarefasgerais>, IEnumerable<Tarefas>>(tarefas);
                }
            }
            catch(Exception e)
            {
                throw e;
            }
            
        }

        public Tarefas Find(int id)
        {
            try
            {
                using (var db = new golfEntities())
                {
                    var tarefaFound = db.tarefasgerais.Find(id);
                    return tarefaFound != null ? this._mapper.Map<Tarefas>(tarefaFound) : null;
                }

            }
            catch (Exception e)
            {
                throw e;
            }
            
        }

        public void Edit(int id,Tarefas tarefa)
        {
            try
            {
                using (var db = new golfEntities())
                {

                    var tarefaFound = db.tarefasgerais.Find(id);
                    if (tarefaFound == null) return;

                    tarefaFound.areajogo = tarefa.AreaJogo;
                    tarefaFound.concluida = tarefa.Concluida;
                    tarefaFound.data = tarefa.Data;
                    tarefaFound.funcionario = tarefa.Funcionario;
                    tarefaFound.maquina = tarefa.Maquina;
                    tarefaFound.operacao = tarefa.Operacao;
                    this.Save(db);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            

        }

        public void Add(Tarefas tarefa)
        {
            try
            {
                using (var db = new golfEntities())
                {
                    var tarefaToAdd = this._mapper.Map<Tarefas, tarefasgerais>(tarefa);
                    db.tarefasgerais.Add(tarefaToAdd);
                    this.Save(db);
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public void Delete(int id)
        {
            try
            {
                using (var db = new golfEntities())
                {
                    var tarefaToDelete = db.tarefasgerais.Find(id);
                    if (tarefaToDelete == null) return;
                    db.tarefasgerais.Remove(tarefaToDelete);
                    this.Save(db);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }

        public void Save(golfEntities db)
        {
             db.SaveChanges();
        }

       
        public void Dispose()
        {
           
        }
    }
}
