using Oglasnik.Common;
using Oglasnik.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oglasnik.Repository.Common
{
    public interface ILocationRepository
    {
        Task<bool> Add(ILocation county);
        Task<bool> Delete(ILocation county);
        Task<bool> Delete(Guid id);
        Task<IEnumerable<ILocation>> GetAllAsync();
        Task<ILocation> GetAsync(Guid id);
        Task<IEnumerable<ILocation>> GetRangeAsync(IFilter filter);
        Task<bool> Update(ILocation county);
    }
}
