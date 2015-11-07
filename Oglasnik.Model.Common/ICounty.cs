using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oglasnik.Model.Common
{
    public interface ICounty
    {
        Guid Id { get; set; }
        string Name { get; set; }

        ICollection<ILocation> Locations { get; set; }
    }
}
