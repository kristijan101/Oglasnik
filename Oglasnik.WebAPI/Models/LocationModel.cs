using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Oglasnik.WebAPI.Models
{
    public class LocationModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CountyID { get; set; }
        public string County { get; set; }
    }
}