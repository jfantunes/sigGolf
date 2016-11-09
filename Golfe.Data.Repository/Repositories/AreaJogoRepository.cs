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
    public class AreaJogoRepository : IAreaJogoRepository
    {

        private readonly  IMapper _mapper;

        public AreaJogoRepository()
        {
            this._mapper = FactoryGolfMapper.Map(MappingEnum.AreaJogo);

        }

        public void Dispose()
        {
            using (var db = new golfeEntities())
            {
                db.Dispose();
            }
        }

        public IEnumerable<AreaJogo> GetAreasJogo()
        {
            try
            {
                using (var db = new golfeEntities())
                {

                    var areas = from t in db.areajogo
                                  orderby t.id descending
                                  select t;

                    return this._mapper.Map<IEnumerable<areajogo>, IEnumerable<AreaJogo>>(areas);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public AreaJogo Find(int id)
        {
            try
            {
                using (var db = new golfeEntities())
                {
                    var areaFound = db.areajogo.Find(id);
                    return areaFound != null ? this._mapper.Map<AreaJogo>(areaFound) : null;
                }

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
