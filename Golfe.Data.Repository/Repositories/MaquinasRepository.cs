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
    public class MaquinasRepository : IMaquinasRepository
    {
       private readonly  IMapper _mapper;

       public MaquinasRepository()
        {
            this._mapper = FactoryGolfMapper.Map(MappingEnum.Maquinas);

        }

        public void Dispose()
        {
            using (var db = new golfeEntities())
            {
                db.Dispose();
            }
        }

        public IEnumerable<Maquinas> GetMaquinas()
        {
            try
            {
                using (var db = new golfeEntities())
                {

                    var maquinas = from t in db.maquina
                                  orderby t.nome descending
                                  select t;

                    return this._mapper.Map<IEnumerable<maquina>, IEnumerable<Maquinas>>(maquinas);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Maquinas Find(int id)
        {
            try
            {
                using (var db = new golfeEntities())
                {
                    var maquinaFound = db.maquina.Find(id);
                    return maquinaFound != null ? this._mapper.Map<Maquinas>(maquinaFound) : null;
                }

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}