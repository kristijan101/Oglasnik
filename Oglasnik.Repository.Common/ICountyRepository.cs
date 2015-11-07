using Oglasnik.DAL.Entities;
using Oglasnik.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Oglasnik.Repository.Common
{
    public interface ICountyRepository
    {
        Task<ICounty> GetAsync(Guid id);
        Task<ICounty> GetAsync(Expression<Func<CountyEntity,bool>> predicate);
        Task<IEnumerable<ICounty>> GetAllAsync();
        Task<int> AddAsync(ICounty county);
        Task<int> UpdateAsync();  
    }
}
