using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Oglasnik.DAL.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Oglasnik.DAL.Mappings
{
    class LocationMap : EntityTypeConfiguration<LocationEntity>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LocationMap"/> class.
        /// </summary>
        internal LocationMap()
        {
            HasKey(p => p.Id);

            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.Name).IsRequired().HasMaxLength(20);

            HasRequired(p => p.County).WithMany(p => p.Locations).HasForeignKey(p => p.CountyID).WillCascadeOnDelete();

            ToTable("Locations");
        }
    }
}
