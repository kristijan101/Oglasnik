using Oglasnik.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oglasnik.Services.Common
{
    public interface ICountyService
    {
        Task<ICounty> GetByIdAsync(Guid id);
        Task<IEnumerable<ICounty>> GetAllAsync();
        Task<int> AddAsync(ICounty county);
        Task<int> UpdateAsync(ICounty county);
        Task<int> DeleteAsync(ICounty county);
        Task<int> DeleteAsync(Guid id);
    }
}
