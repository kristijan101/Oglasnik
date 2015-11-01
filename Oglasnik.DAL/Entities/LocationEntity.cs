using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oglasnik.DAL.Entities
{
    public class LocationEntity : Contracts.IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CountyID { get; set; }

        public virtual CountyEntity County { get; set; }
    }
}
