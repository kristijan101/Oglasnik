using Oglasnik.DAL.Contracts;
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
        /// Stores a database context instance of type IOglasnikContext
        /// </summary>
        /// <value>Gets/sets context of type IOglasnikContext</value>
        protected IOglasnikContext Context { get; private set; }       

        #endregion

        #region Constructor

        /// <summary>
        /// The class constructor.
        /// </summary>
        /// <param name="context">Instance of a type that implements IOglasnikContext.</param>
        public Repository(IOglasnikContext context)
        {
            Context = context;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adds an entity of type TEntity
        /// </summary>
        /// <typeparam name="TEntity">Reference type of the entity to be added.</typeparam>
        /// <param name="entity">Entity of type TEntity</param>
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
        /// Deletes an entity of type TEntity.
        /// </summary>
        /// <typeparam name="TEntity">Reference type of the entity to be added.</typeparam>
        /// <param name="entity">Entity of type TEntity</param>
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
        /// Gets all entities of the given type.
        /// </summary>
        /// <returns><see cref="IQueryable{TEntity}"/></returns>
        public IQueryable<TEntity> GetAll<TEntity>() where TEntity : class
        {
            return Context.Set<TEntity>();
        }
        
        /// <summary>
        /// Gets the entity with the given Id.
        /// </summary>
        /// <param name="id">Id of type <see cref="Guid"/> of the entity to be found.</param>
        /// <returns>The requested entity or null if not found</returns>
        public Task<TEntity> GetById<TEntity>(Guid id) where TEntity : class
        {
            return Context.Set<TEntity>().FindAsync(id);
        }


        /// <summary>
        /// Updates an entity of type TEntity.
        /// </summary>
        /// <typeparam name="TEntity">Reference type of the entity to be added.</typeparam>
        /// <param name="entity">Entity of type TEntity</param>
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
