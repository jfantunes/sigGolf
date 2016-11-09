using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Golfe.Data.Models;
using Golfe.Data.Models.Mappings;
using Golfe.Data.Repository.Interfaces;
using Golfe.Web.Database;

namespace Golfe.Data.Repository.Repositories
{
    public class OperacaoRepository : IOperacaoRepository
    {
        private readonly  IMapper _mapper;

       public OperacaoRepository()
        {
            this._mapper = FactoryGolfMapper.Map(MappingEnum.Operacao);

        }

        public void Dispose()
        {
            using (var db = new golfeEntities())
            {
                db.Dispose();
            }
        }

        public IEnumerable<Operacao> GetOperacoes()
        {
            try
            {
                using (var db = new golfeEntities())
                {

                    var operacoes = from t in db.operacao
                                  orderby t.nome descending
                                  select t;

                    return this._mapper.Map<IEnumerable<operacao>, IEnumerable<Operacao>>(operacoes);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Operacao Find(int id)
        {
            try
            {
                using (var db = new golfeEntities())
                {
                    var operacaoFound = db.operacao.Find(id);
                    return operacaoFound != null ? this._mapper.Map<Operacao>(operacaoFound) : null;
                }

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
