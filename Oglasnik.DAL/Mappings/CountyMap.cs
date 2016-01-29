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
    class CountyMap : EntityTypeConfiguration<CountyEntity>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CountyMap"/> class.
        /// </summary>
        internal CountyMap()
        {
            HasKey(p => p.Id);

            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.Name).IsRequired().HasMaxLength(25);

            ToTable("Counties");
        }
    }
}
