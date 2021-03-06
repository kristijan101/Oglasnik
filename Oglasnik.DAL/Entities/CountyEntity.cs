﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oglasnik.DAL.Entities
{
    public class CountyEntity : Contracts.IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<LocationEntity> Locations { get; set; }
    }
}
