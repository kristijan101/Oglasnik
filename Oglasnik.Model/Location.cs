using Oglasnik.Model.Common;
using System;
using System.Collections.Generic;

namespace Oglasnik.Model
{
    public class Location : Common.ILocation
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CountyID { get; set; }

        public ICounty County { get; set; }
    }
}