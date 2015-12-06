using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Oglasnik.Repository.Common
{
    /// <summary>
    /// Implements basic repository methods
    /// </summary>
    /// <typeparam name="TDomain">Domain entity type</typeparam>
    public interface IRepository<TEntity, TDomain> where TDomain:class where TEntity:class
    {
        void Add(TDomain county);
        void Delete(TDomain county);
        Task<IEnumerable<TDomain>> GetAllAsync();
        Task<TDomain> GetAsync(Guid id);
        Task<int> SaveChanges();
        void Update(TDomain county);
    }
}