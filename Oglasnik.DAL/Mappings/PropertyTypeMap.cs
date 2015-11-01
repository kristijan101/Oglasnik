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
    internal class PropertyTypeMap : EntityTypeConfiguration<PropertyTypeEntity>
    {
        internal PropertyTypeMap()
        {
            HasKey(p => p.Id);

            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.Name).IsRequired().HasMaxLength(25);

            HasMany(p => p.PropertyValues).WithRequired(p => p.PropertyType).HasForeignKey(p => p.PropertyTypeId);

            ToTable("PropertyTypes");
        }
    }
}
