﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Oglasnik.DAL.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Oglasnik.DAL.Mappings
{
    class PropertyValueMap : EntityTypeConfiguration<PropertyValueEntity>
    {
        internal PropertyValueMap()
        {
            HasKey(p => p.Id);

            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.Value).IsRequired();

            ToTable("PropertyValues");
        }
    }
}
