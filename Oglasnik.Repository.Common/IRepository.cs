using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Oglasnik.Repository.Common
{
    /// <summary>
    /// Implements basic repository methods
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Asynchronously adds an entity of type <typeparamref name="TEntity"/>
        /// </summary>
        /// <typeparam name="TEntity">Type of the entity to be added.</typeparam>
        /// <param name="entity">The entity</param>
        /// <returns>Returns <see cref="Task{bool}"/> indicating whether the operation was executed successfuly.</returns>
        Task<bool> AddAsync<TEntity>(TEntity county) where TEntity : class;

        /// <summary>
        /// Asynchronously deletes an entity of type <typeparamref name="TEntity"/>.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity to be added.</typeparam>
        /// <param name="entity">The entity</param>
        /// <returns>Returns <see cref="Task{bool}"/> indicating whether the operation was executed successfuly.</returns>
        Task<bool> DeleteAsync<TEntity>(TEntity county) where TEntity : class;

        /// <summary>
        /// Gets all entities of the given type.
        /// </summary>
        /// <returns><see cref="IQueryable{TEntity}"/></returns>
        IQueryable<TEntity> GetAll<TEntity>() where TEntity : class;

        /// <summary>
        /// Asynchronously gets the entity with the given Id.
        /// </summary>
        /// <param name="id">Id of the entity to be found.</param>
        /// <returns>The requested entity or null if not found</returns>
        Task<TEntity> GetAsync<TEntity>(Guid id) where TEntity : class;

        /// <summary>
        /// Asynchronously updates an entity of type <typeparamref name="TEntity"/>.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity to be added.</typeparam>
        /// <param name="entity">The entity</param>
        /// <returns>Returns <see cref="Task{bool}"/> indicating whether the operation was executed successfuly.</returns>
        Task<bool> UpdateAsync<TEntity>(TEntity county) where TEntity : class;
    }
}