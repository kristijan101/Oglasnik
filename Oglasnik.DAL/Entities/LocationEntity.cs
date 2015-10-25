using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oglasnik.DAL.Entities
{
    public class LocationEntity : Contracts.IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountyID { get; set; }

        public virtual CountyEntity County { get; set; }
    }
}
