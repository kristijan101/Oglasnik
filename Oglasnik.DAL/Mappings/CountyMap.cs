using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Oglasnik.DAL.Entities;

namespace Oglasnik.DAL.Mappings
{
    class CountyMap : EntityTypeConfiguration<CountyEntity>
    {
        internal CountyMap()
        {
            HasKey(p => p.Id);

            Property(p => p.Name).IsRequired().HasMaxLength(25);

            ToTable("Counties");
        }
    }
}
