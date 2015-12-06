using Oglasnik.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oglasnik.Repository.Common
{
    public interface ILocationRepository
    {
        void Add(ILocation county);
        void Delete(ILocation county);
        Task<IEnumerable<ILocation>> GetAllAsync();
        Task<ILocation> GetAsync(Guid id);
        Task<int> SaveChanges();
        void Update(ILocation county);
    }
}
