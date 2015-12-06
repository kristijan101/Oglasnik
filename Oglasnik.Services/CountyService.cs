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

        public virtual Task<int> Add(ICounty county)
        {
            repository.Add(county);
            return repository.SaveChanges();
        }

        public virtual Task<int> Delete(ICounty county)
        {
            repository.Delete(county);
            return repository.SaveChanges();
        }

        public virtual Task<int> Delete(Guid id)
        {
            repository.Delete(id);
            return repository.SaveChanges();
        }

        public virtual Task<IEnumerable<ICounty>> GetAll()
        {
            return repository.GetAllAsync();
        }

        public virtual Task<ICounty> GetById(Guid id)
        {
            return repository.GetAsync(id);
        }

        public virtual Task<int> Update(ICounty county)
        {
            repository.Update(county);
            return repository.SaveChanges();
        }

        #endregion
    }
}
