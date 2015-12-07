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
    public class CountyRepository : ICountyRepository
    {
        #region Properties

        private IOglasnikContext context;

        protected DbSet<CountyEntity> Entities
        {
            get
            {
                return context.Set<CountyEntity>();
            }
        }

        #endregion

        #region Constructor

        public CountyRepository(IOglasnikContext context)
        {
            this.context = context;
        }

        #endregion

        #region Methods

        public virtual void Add(ICounty county)
        {
            Entities.Add(Mapper.Map<CountyEntity>(county));
        }

        public virtual void Delete(ICounty county)
        {
            Entities.Remove(Mapper.Map<CountyEntity>(county));
        }

        public virtual void Delete(Guid id)
        {
            CountyEntity county = new CountyEntity { Id = id };

            DbEntityEntry entry = context.Entry(county);

            if(entry.State == EntityState.Detached)
            {
                Entities.Attach(county);
            }
  
            entry.State = EntityState.Deleted;
        }

        public virtual async Task<IEnumerable<ICounty>> GetAllAsync()
        {
            return Mapper.Map<IEnumerable<ICounty>>(await Entities.ToListAsync());
        }

        public virtual async Task<ICounty> GetAsync(Guid id)
        {
            return Mapper.Map<ICounty>(await Entities.FindAsync(id));
        }

        public virtual async Task<ICounty> GetAsync(Expression<Func<CountyEntity, bool>> predicate)
        {
            return Mapper.Map<ICounty>(await Entities.FirstAsync(predicate));
        }

        public virtual Task<int> SaveChanges()
        {
            return context.SaveChangesAsync();
        }

        public virtual void Update(ICounty county)
        {
            CountyEntity entity = Mapper.Map<CountyEntity>(county);

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
