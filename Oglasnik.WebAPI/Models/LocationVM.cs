using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Oglasnik.WebAPI.Models
{
    public class LocationVM
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public Guid CountyID { get; set; }
    }
}