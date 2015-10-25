using Oglasnik.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oglasnik.DAL.Mappings
{
    internal class CategoryMap : EntityTypeConfiguration<CategoryEntity>
    {
        internal CategoryMap()
        {
            HasKey(p => p.Id);

            Property(p => p.Name).IsRequired().HasMaxLength(25);

            ToTable("Categories");
        }
    }
}
