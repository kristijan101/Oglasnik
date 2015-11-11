using Oglasnik.Repository.Common;
using Oglasnik.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oglasnik.Model.Common;

namespace Oglasnik.Services
{
    public class CountyService : ICountyService
    {
        private ICountyRepository rep;

        public CountyService(ICountyRepository rep)
        {
            this.rep = rep;
        }

        public async Task<ICounty> GetByIdAsync(Guid id)
        {
            return await rep.GetAsync(id);
        }

        public async Task<IEnumerable<ICounty>> GetAllAsync()
        {
            return await rep.GetAllAsync();
        }

        public async Task<int> AddAsync(ICounty cty)
        {
            return await rep.AddAsync(cty);
        }

        public async Task<int> UpdateAsync(ICounty county)
        {
            return await rep.UpdateAsync(county);
        }

        public async Task<int> DeleteAsync(ICounty county)
        {
            return await rep.DeleteAsync(county);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await rep.DeleteAsync(id);
        }
    }
}
