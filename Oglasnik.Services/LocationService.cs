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
    public class LocationService : ILocationService
    {
        private ILocationRepository repository;

        public LocationService(ILocationRepository repository)
        {
            this.repository = repository;
        }

        #region Methods

        public Task<bool> Add(ILocation county)
        {
            return repository.Add(county);
        }

        public Task<bool> Delete(ILocation county)
        {
            return repository.Delete(county);
        }

        public Task<bool> Delete(Guid id)
        {
            return repository.Delete(id);
        }

        public Task<IEnumerable<ILocation>> GetAll()
        {
            return repository.GetAllAsync();
        }

        public Task<ILocation> GetById(Guid id)
        {
            return repository.GetAsync(id);
        }

        public Task<IEnumerable<ILocation>> GetRange(IFilter filter)
        {
            if (filter == null)
            {
                throw new ArgumentNullException("filter");
            }

            return repository.GetRangeAsync(filter);
        }

        public Task<bool> Update(ILocation county)
        {
            return repository.Update(county);
        }

        #endregion
    }
}
