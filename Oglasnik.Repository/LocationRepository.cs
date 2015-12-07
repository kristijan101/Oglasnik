using AutoMapper;
using Oglasnik.DAL.Contracts;
using Oglasnik.DAL.Entities;
using Oglasnik.Model.Common;
using Oglasnik.Repository.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Oglasnik.Repository
{
    public class LocationRepository:ILocationRepository
    {
        #region Properties

        private IOglasnikContext context;

        protected DbSet<LocationEntity> Entities
        {
            get
            {
                return context.Set<LocationEntity>();
            }
        }

        #endregion

        #region Constructor

        public LocationRepository(IOglasnikContext context)
        {
            this.context = context;
        }

        #endregion

        #region Methods

        public virtual void Add(ILocation county)
        {
            Entities.Add(Mapper.Map<LocationEntity>(county));
        }

        public virtual void Delete(ILocation county)
        {
            Entities.Remove(Mapper.Map<LocationEntity>(county));
        }

        public virtual void Delete(Guid id)
        {
            LocationEntity county = new LocationEntity { Id = id };

            DbEntityEntry entry = context.Entry(county);

            if (entry.State == EntityState.Detached)
            {
                Entities.Attach(county);
            }

            entry.State = EntityState.Deleted;
        }

        public virtual async Task<IEnumerable<ILocation>> GetAllAsync()
        {
            return Mapper.Map<IEnumerable<ILocation>>(await Entities.ToListAsync());
        }

        public virtual async Task<ILocation> GetAsync(Guid id)
        {
            return Mapper.Map<ILocation>(await Entities.FindAsync(id));
        }

        public virtual async Task<ILocation> GetAsync(Expression<Func<LocationEntity, bool>> predicate)
        {
            return Mapper.Map<ILocation>(await Entities.FirstAsync(predicate));
        }

        public virtual Task<int> SaveChanges()
        {
            return context.SaveChangesAsync();
        }

        public virtual void Update(ILocation county)
        {
            LocationEntity entity = Mapper.Map<LocationEntity>(county);

            DbEntityEntry entry = context.Entry(entity);

            if (entry.State == EntityState.Detached)
            {
                Entities.Attach(entity);
            }
            entry.State = EntityState.Modified;
        }

        #endregion
    }
}
