using Oglasnik.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oglasnik.Repository.Common
{
    public interface ICountyRepository
    {
        Task<bool> Add(ICounty county);
        Task<bool> Delete(ICounty county);
        Task<bool> Delete(Guid id);
        Task<IEnumerable<ICounty>> GetAllAsync();
        Task<ICounty> GetAsync(Guid id);
        Task<IEnumerable<ICounty>> GetRangeAsync(Oglasnik.Common.IFilter filter);
        Task<bool> Update(ICounty county);
    }
}
