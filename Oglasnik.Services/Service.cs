using Oglasnik.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oglasnik.Services
{
    public class Service<TDomain> : Common.IService<TDomain> where TDomain : class
    {
        private IRepository<TDomain> repository;

        public Service(IRepository<TDomain> repository)
        {
            this.repository = repository;
        }

        #region Methods

        public virtual void Add(TDomain county)
        {
            repository.Add(county);
            repository.SaveChanges();
        }

        public virtual void Delete(TDomain county)
        {
            repository.Delete(county);
            repository.SaveChanges();
        }

        public virtual Task<IEnumerable<TDomain>> GetAll()
        {
            return repository.GetAllAsync();
        }

        public virtual Task<TDomain> GetById(Guid id)
        {
            return repository.GetAsync(id);
        }

        public virtual void Update(TDomain county)
        {
            repository.Update(county);
            repository.SaveChanges();
        }

        #endregion
    }
}
