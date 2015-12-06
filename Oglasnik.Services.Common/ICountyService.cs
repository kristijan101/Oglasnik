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
        Task<int> Add(ICounty cty);
        Task<int> Delete(ICounty county);
        Task<int> Delete(Guid id);
        Task<IEnumerable<ICounty>> GetAll();
        Task<ICounty> GetById(Guid id);
        Task<int> Update(ICounty county);
    }
}
