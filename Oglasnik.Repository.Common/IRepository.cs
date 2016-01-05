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
    /// <typeparam name="TEntity">Database entity</typeparam>
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<bool> AddAsync(TEntity county);
        Task<bool> DeleteAsync(TEntity county);
        IQueryable<TEntity> GetAll();
        Task<TEntity> GetById(Guid id);
        Task<bool> UpdateAsync(TEntity county);
    }
}