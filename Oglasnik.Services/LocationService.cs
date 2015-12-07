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

        public virtual Task<int> Add(ILocation county)
        {
            repository.Add(county);
            return repository.SaveChanges();
        }

        public virtual Task<int> Delete(ILocation county)
        {
            repository.Delete(county);
            return repository.SaveChanges();
        }

        public virtual Task<int> Delete(Guid id)
        {
            repository.Delete(id);
            return repository.SaveChanges();
        }

        public virtual Task<IEnumerable<ILocation>> GetAll()
        {
            return repository.GetAllAsync();
        }

        public virtual Task<ILocation> GetById(Guid id)
        {
            return repository.GetAsync(id);
        }

        public virtual Task<int> Update(ILocation county)
        {
            repository.Update(county);
            return repository.SaveChanges();
        }

        #endregion
    }
}
