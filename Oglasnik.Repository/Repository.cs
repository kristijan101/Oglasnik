using Oglasnik.Common;
using Oglasnik.DAL.Contracts;
using PagedList;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;

namespace Oglasnik.Repository
{
    public class Repository : Common.IRepository
    {
        #region Properties

        /// <summary>
        /// Stores a database context instance of type <see cref="IOglasnikContext"/>
        /// </summary>
        /// <value>Gets or sets context of type <see cref="IOglasnikContext"/></value>
        protected IOglasnikContext Context { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public Repository(IOglasnikContext context)
        {
            Context = context;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Asynchronously adds an entity
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity to be added.</typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns>Returns <see cref="Task{bool}"/> indicating whether the operation was executed successfuly.</returns>
        public async Task<bool> AddAsync<TEntity>(TEntity entity) where TEntity : class
        {
            if(entity == null)
            {
                throw new ArgumentNullException();
            }

            Context.Set<TEntity>().Add(entity);

            return (await Context.SaveChangesAsync() != 0);
        }

        /// <summary>
        /// Asynchronously deletes an entity.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity to be deleted.</typeparam>
        /// <param name="entity">The entity</param>
        /// <returns>Returns <see cref="Task{bool}"/> indicating whether the operation was executed successfuly.</returns>
        public async Task<bool> DeleteAsync<TEntity>(TEntity entity) where TEntity : class
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
        /// Gets a range of entities.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="paging">The paging parameters.</param>
        /// <returns>Returns an <see cref="IQueryable{TEntity}"/> of entities according to the paging options provided.</returns>
        public IQueryable<TEntity> Get<TEntity>(IPagingParameters paging) where TEntity : class
        {
            return Context.Set<TEntity>().ToPagedList(paging.PageNumber, paging.PageSize).AsQueryable();
        }

        /// <summary>
        /// Gets all entities of the given type.
        /// </summary>
        /// <returns><see cref="IQueryable{TEntity}"/></returns>
        public IQueryable<TEntity> GetAll<TEntity>() where TEntity : class
        {
            return Context.Set<TEntity>();
        }

        /// <summary>
        /// Asynchronously gets the entity with the given Id.
        /// </summary>
        /// <param name="id">Id of type <see cref="Guid"/> of the entity to be found.</param>
        /// <returns>The requested entity or null if not found</returns>
        public Task<TEntity> GetAsync<TEntity>(Guid id) where TEntity : class
        {
            return Context.Set<TEntity>().FindAsync(id);
        }


        /// <summary>
        /// Asynchronously updates an entity.
        /// </summary>
        /// <typeparam name="TEntity">The type of entity.</typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns>Returns <see cref="Task{bool}"/> indicating whether the operation was executed successfuly.</returns>
        public async Task<bool> UpdateAsync<TEntity>(TEntity entity) where TEntity : class
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
