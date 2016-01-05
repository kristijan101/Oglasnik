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
        Task<bool> Add(ICounty cty);
        Task<bool> Delete(ICounty county);
        Task<bool> Delete(Guid id);
        Task<IEnumerable<ICounty>> GetAll();
        Task<ICounty> GetById(Guid id);
        Task<IEnumerable<ICounty>> GetRange(Oglasnik.Common.IFilter filter);
        Task<bool> Update(ICounty county);
    }
}
