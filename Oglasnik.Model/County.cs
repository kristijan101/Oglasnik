using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oglasnik.Model
{
    public class County : Common.ICounty
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<Common.ILocation> Locations { get; set; }
    }
}
