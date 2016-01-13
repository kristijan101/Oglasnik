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
        /// Adds an entity of type TEntity
        /// </summary>
        /// <typeparam name="TEntity">Reference type of the entity to be added.</typeparam>
        /// <param name="entity">Entity of type TEntity</param>
        /// <returns>Returns <see cref="Task{bool}"/> indicating whether the operation was executed successfuly.</returns>
        Task<bool> AddAsync<TEntity>(TEntity county) where TEntity : class;

        /// <summary>
        /// Deletes an entity of type TEntity.
        /// </summary>
        /// <typeparam name="TEntity">Reference type of the entity to be added.</typeparam>
        /// <param name="entity">Entity of type TEntity</param>
        /// <returns>Returns <see cref="Task{bool}"/> indicating whether the operation was executed successfuly.</returns>
        Task<bool> DeleteAsync<TEntity>(TEntity county) where TEntity : class;

        /// <summary>
        /// Gets all entities of the given type.
        /// </summary>
        /// <returns><see cref="IQueryable{TEntity}"/></returns>
        IQueryable<TEntity> GetAll<TEntity>() where TEntity : class;

        /// <summary>
        /// Gets the entity with the given Id.
        /// </summary>
        /// <param name="id">Id of type <see cref="Guid"/> of the entity to be found.</param>
        /// <returns>The requested entity or null if not found</returns>
        Task<TEntity> GetById<TEntity>(Guid id) where TEntity : class;

        /// <summary>
        /// Updates an entity of type TEntity.
        /// </summary>
        /// <typeparam name="TEntity">Reference type of the entity to be added.</typeparam>
        /// <param name="entity">Entity of type TEntity</param>
        /// <returns>Returns <see cref="Task{bool}"/> indicating whether the operation was executed successfuly.</returns>
        Task<bool> UpdateAsync<TEntity>(TEntity county) where TEntity : class;
    }
}