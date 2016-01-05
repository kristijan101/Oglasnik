using Oglasnik.Common;
using Oglasnik.Model.Common;
using Oglasnik.Repository.Common;
using Oglasnik.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oglasnik.Services
{
    public class CountyService : ICountyService
    {
        private ICountyRepository repository;

        public CountyService(ICountyRepository repository)
        {
            this.repository = repository;
        }

        #region Methods

        public Task<bool> Add(ICounty county)
        {
            if (county == null)
            {
                throw new ArgumentNullException("county");
            }

            return repository.Add(county);
        }

        public Task<bool> Delete(ICounty county)
        {
            if (county == null)
            {
                throw new ArgumentNullException("county");
            }

            return repository.Delete(county);
        }

        public Task<bool> Delete(Guid id)
        {
            return repository.Delete(id);
        }

        public Task<IEnumerable<ICounty>> GetAll()
        {
            return repository.GetAllAsync();
        }

        public Task<ICounty> GetById(Guid id)
        {
            return repository.GetAsync(id);
        }

        public Task<IEnumerable<ICounty>> GetRange(IFilter filter)
        {
            if(filter == null)
            {
                throw new ArgumentNullException("filter");
            }

            return repository.GetRangeAsync(filter);
        }

        public Task<bool> Update(ICounty county)
        {
            if(county == null)
            {
                throw new ArgumentNullException("county");
            }

            return repository.Update(county);
        }

        #endregion
    }
}
