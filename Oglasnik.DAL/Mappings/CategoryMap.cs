using Oglasnik.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.Name).IsRequired().HasMaxLength(25);

            HasMany(p => p.PropertyTypes).WithRequired(p => p.Category).HasForeignKey(p => p.CategoryID);

            ToTable("Categories");
        }
    }
}
