using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Oglasnik.Services.Common
{
    public interface IService<TDomain> where TDomain : class
    {
        void Add(TDomain cty);
        void Delete(TDomain county);
        Task<IEnumerable<TDomain>> GetAll();
        Task<TDomain> GetById(Guid id);
        void Update(TDomain county);
    }
}