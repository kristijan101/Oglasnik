using Oglasnik.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oglasnik.Services.Common
{
    public interface ILocationService
    {
        void Add(ILocation cty);
        void Delete(ILocation county);
        Task<IEnumerable<ILocation>> GetAll();
        Task<ILocation> GetById(Guid id);
        void Update(ILocation county);
    }
}
