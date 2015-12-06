using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Oglasnik.WebAPI.Models
{
    public class CountyVM
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }

        public ICollection<LocationVM> Locations { get; set; }
    }
}