using Oglasnik.Common;
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
    public class Repository<TEntity> : Common.IRepository<TEntity> where TEntity:class
    {
        #region Properties

        protected IOglasnikContext Context { get; private set; }       

        protected DbSet<TEntity> Entities
        {
            get
            {
                return Context.Set<TEntity>();
            }
        }

        #endregion

        #region Constructor

        public Repository(IOglasnikContext context)
        {
            Context = context;
        }

        #endregion

        #region Methods
        
        public async Task<bool> AddAsync(TEntity entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException();
            }

            Entities.Add(entity);

            return (await Context.SaveChangesAsync() != 0);
        }

        public async Task<bool> DeleteAsync(TEntity entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException();
            }

            DbEntityEntry<TEntity> entry = Context.Entry(entity);

            if(entry.State == EntityState.Detached)
            {
                Context.Set<TEntity>().Attach(entity);
            }
            entry.State = EntityState.Deleted;

            return (await Context.SaveChangesAsync() != 0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Entities as IQueryable</returns>
        public IQueryable<TEntity> GetAll()
        {
            return Entities;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Primary key value for the entity to be found</param>
        /// <returns>The requested entity or null if not found</returns>
        public Task<TEntity> GetById(Guid id)
        {
            return Entities.FindAsync(id);
        }
    
        public async Task<bool> UpdateAsync(TEntity entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException();
            }

            Context.Entry(entity).State = EntityState.Modified;

            return (await Context.SaveChangesAsync() != 0);
        }

        #endregion
    }
}
