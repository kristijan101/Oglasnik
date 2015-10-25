using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Oglasnik.DAL.Entities;

namespace Oglasnik.DAL.Mappings
{
    class LocationMap : EntityTypeConfiguration<LocationEntity>
    {
        internal LocationMap()
        {
            HasKey(p => p.Id);

            Property(p => p.Name).IsRequired().HasMaxLength(20);

            HasRequired(p => p.County).WithMany(p => p.Locations).HasForeignKey(p => p.CountyID);

            ToTable("Locations");
        }
    }
}
