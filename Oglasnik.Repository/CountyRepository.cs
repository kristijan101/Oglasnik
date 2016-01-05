using AutoMapper;
using Oglasnik.Common;
using Oglasnik.DAL.Entities;
using Oglasnik.Model.Common;
using Oglasnik.Repository.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Oglasnik.Repository
{
    public class CountyRepository : ICountyRepository
    {
        private IRepository<CountyEntity> repository;

        #region Constructor

        public CountyRepository(IRepository<CountyEntity> repository)
        {
            this.repository = repository;
        }

        #endregion

        #region Methods

        public Task<bool> Add(ICounty county)
        {
            if(county == null)
            {
                throw new ArgumentNullException("county");
            }
            return repository.AddAsync(Mapper.Map<CountyEntity>(county));
        }

        public Task<bool> Delete(ICounty county)
        {
            if (county == null)
            {
                throw new ArgumentNullException("county");
            }
            return repository.DeleteAsync(Mapper.Map<CountyEntity>(county));
        }

        public Task<bool> Delete(Guid id)
        {
            CountyEntity county = new CountyEntity { Id = id };
            
            return repository.DeleteAsync(county);
        }

        public async Task<IEnumerable<ICounty>> GetAllAsync()
        {
            return Mapper.Map<IEnumerable<ICounty>>(await repository.GetAll().ToListAsync());
        }

        public async Task<ICounty> GetAsync(Guid id)
        {
            return Mapper.Map<ICounty>(await repository.GetById(id));
        }

        public async Task<IEnumerable<ICounty>> GetRangeAsync(IFilter filter)
        {
            if(filter == null)
            {
                throw new ArgumentNullException("filter");
            }

            var query = repository.GetAll();

            if (!String.IsNullOrEmpty(filter.SearchString))
            {
                query = query.OrderBy(e => e.Name)
                             .Where(e => e.Name.ToLower().Contains(filter.SearchString.ToLower()))
                             .Skip((filter.PageNumber - 1) * filter.PageSize)
                             .Take(filter.PageSize);
            } else
            {
                query = query.OrderBy(e => e.Name)
                             .Skip((filter.PageNumber - 1) * filter.PageSize)
                             .Take(filter.PageSize);
            }

            return Mapper.Map<IEnumerable<ICounty>>(await query.ToListAsync());
        }

        public Task<bool> Update(ICounty county)
        {
            if (county == null)
            {
                throw new ArgumentNullException("county");
            }

            return repository.UpdateAsync(Mapper.Map<CountyEntity>(county));
        }

        #endregion
    }
}
