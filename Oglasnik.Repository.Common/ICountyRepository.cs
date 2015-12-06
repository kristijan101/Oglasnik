using Oglasnik.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oglasnik.Repository.Common
{
    public interface ICountyRepository
    {
        void Add(ICounty county);
        void Delete(ICounty county);
        void Delete(Guid id);
        Task<IEnumerable<ICounty>> GetAllAsync();
        Task<ICounty> GetAsync(Guid id);
        Task<int> SaveChanges();
        void Update(ICounty county);
    }
}
