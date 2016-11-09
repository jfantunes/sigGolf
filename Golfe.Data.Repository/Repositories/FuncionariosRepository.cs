using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Golfe.Data.Models;
using Golfe.Data.Models.Mappings;
using Golfe.Data.Repository.Interfaces;
using Golfe.Web.Database;

namespace Golfe.Data.Repository.Repositories
{
    public class FuncionariosRepository:IFuncionariosRepository
    {
        private readonly  IMapper _mapper;

         public FuncionariosRepository()
        {
            this._mapper = FactoryGolfMapper.Map(MappingEnum.Funcionarios);

        }

        public IEnumerable<Funcionarios> GetFuncionarios()
        {
           try{  
                using (var db=new golfeEntities())
                {

                    var funcionarios = from t in db.funcionarios
                        orderby t.nome descending
                        select t;

                    return this._mapper.Map<IEnumerable<funcionarios>, IEnumerable<Funcionarios>>(funcionarios);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Funcionarios Find(int id)
        {
            try
            {
                using (var db = new golfeEntities())
                {
                    var funcionarioFound = db.funcionarios.Find(id);
                    return funcionarioFound != null ? this._mapper.Map<Funcionarios>(funcionarioFound) : null;
                }

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Edit(int id, Funcionarios funcionario)
        {
            try
            {
                using (var db = new golfeEntities())
                {

                    var funcionariofound = db.funcionarios.Find(id);
                    if (funcionariofound == null) return;

                    funcionariofound.nome = funcionario.Nome;
                    funcionariofound.email = funcionario.Email;
                    this.Save(db);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Add(Funcionarios funcionario)
        {
            try
            {
                using (var db = new golfeEntities())
                {
                    var funcionarioToAdd = this._mapper.Map<Funcionarios, funcionarios>(funcionario);
                    db.funcionarios.Add(funcionarioToAdd);
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
                using (var db = new golfeEntities())
                {
                    var funcionarioToDelete = db.funcionarios.Find(id);
                    if (funcionarioToDelete == null) return;
                    db.funcionarios.Remove(funcionarioToDelete);
                    this.Save(db);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Save(golfeEntities db)
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            using (var db = new golfeEntities())
            {
                db.Dispose();
            }
        }
    }
}
