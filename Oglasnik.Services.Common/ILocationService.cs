using Oglasnik.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oglasnik.Services.Common
{
    public interface ILocationService
    {
        Task<bool> Add(ILocation county);
        Task<bool> Delete(ILocation county);
        Task<bool> Delete(Guid id);
        Task<IEnumerable<ILocation>> GetAll();
        Task<ILocation> GetById(Guid id);
        Task<IEnumerable<ILocation>> GetRange(Oglasnik.Common.IFilter filter);
        Task<bool> Update(ILocation county);
    }
}
