using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Oglasnik.DAL.Entities;

namespace Oglasnik.DAL.Mappings
{
    internal class PropertyTypeMap : EntityTypeConfiguration<PropertyTypeEntity>
    {
        internal PropertyTypeMap()
        {
            HasKey(p => p.Id);

            Property(p => p.Name).IsRequired().HasMaxLength(25);

            HasMany(p => p.PropertyValues).WithRequired(p => p.PropertyType).HasForeignKey(p => p.PropertyTypeId);

            ToTable("PropertyTypes");
        }
    }
}
