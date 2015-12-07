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
        Task<int> Add(ILocation cty);
        Task<int> Delete(ILocation county);
        Task<int> Delete(Guid id);
        Task<IEnumerable<ILocation>> GetAll();
        Task<ILocation> GetById(Guid id);
        Task<int> Update(ILocation county);
    }
}
