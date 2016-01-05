﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Oglasnik.WebAPI.Models
{
    public class CountyModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<LocationModel> Locations { get; set; }
    }
}