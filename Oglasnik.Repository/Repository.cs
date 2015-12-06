using AutoMapper;
using Oglasnik.DAL.Contracts;
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
    public class Repository<TEntity, TDomain> : Common.IRepository<TEntity,TDomain> where TEntity : class
                                                                            where TDomain : class                                                                                                  
    {
        #region Properties

        private IOglasnikContext context;

        protected DbSet<TEntity> Entities {
            get
            {
                return context.Set<TEntity>();
            }
        }

        #endregion

        #region Constructor

        public Repository(IOglasnikContext context)
        {
            this.context = context;
        }

        #endregion

        #region Methods

        public virtual void Add(TDomain county)
        {
            Entities.Add(Mapper.Map<TEntity>(county));
        }

        public virtual void Delete(TDomain county)
        {
            Entities.Remove(Mapper.Map<TEntity>(county));
        }

        public virtual async Task<IEnumerable<TDomain>> GetAllAsync()
        {
            return Mapper.Map<IEnumerable<TDomain>>(await Entities.ToListAsync());
        }

        public virtual async Task<TDomain> GetAsync(Guid id)
        {
            return Mapper.Map<TDomain>(await Entities.FindAsync(id));
        }

        public virtual async Task<TDomain> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Mapper.Map<TDomain>(await Entities.FirstAsync(predicate));
        }
        
        public virtual Task<int> SaveChanges()
        {
            return context.SaveChangesAsync();
        }      

        public virtual void Update(TDomain county)
        {
            TEntity entity = Mapper.Map<TEntity>(county);

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
