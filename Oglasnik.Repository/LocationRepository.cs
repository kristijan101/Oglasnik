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
    public class LocationRepository : ILocationRepository
    {
        private IRepository<LocationEntity> repository;

        #region Constructor

        public LocationRepository(IRepository<LocationEntity> repository)
        {
            this.repository = repository;
        }

        #endregion

        #region Methods

        public Task<bool> Add(ILocation location)
        {
            if(location == null)
            {
                throw new ArgumentNullException("location");
            }

            return repository.AddAsync(Mapper.Map<LocationEntity>(location));
        }

        public Task<bool> Delete(ILocation location)
        {
            if (location == null)
            {
                throw new ArgumentNullException("location");
            }

            return repository.DeleteAsync(Mapper.Map<LocationEntity>(location));
        }

        public Task<bool> Delete(Guid id)
        {
            LocationEntity location = new LocationEntity { Id = id };

            return repository.DeleteAsync(location);
        }

        public async Task<IEnumerable<ILocation>> GetAllAsync()
        {
            return Mapper.Map<IEnumerable<ILocation>>(await repository.GetAll().ToListAsync());
        }

        public async Task<ILocation> GetAsync(Guid id)
        {
            return Mapper.Map<ILocation>(await repository.GetById(id));
        }

        public async Task<IEnumerable<ILocation>> GetRangeAsync(IFilter filter)
        {
            if (filter == null)
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
            }
            else
            {
                query = query.OrderBy(e => e.Name)
                            .Skip((filter.PageNumber - 1) * filter.PageSize)
                            .Take(filter.PageSize);
            }
                                
            return Mapper.Map<IEnumerable<ILocation>>(await query.ToListAsync());
        }

        public Task<bool> Update(ILocation location)
        {
            if (location == null)
            {
                throw new ArgumentNullException("location");
            }

            LocationEntity entity = Mapper.Map<LocationEntity>(location);

            return repository.UpdateAsync(entity);
        }

        #endregion
    }
}
