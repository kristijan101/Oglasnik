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
    internal class AdMap : EntityTypeConfiguration<AdEntity>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AdMap"/> class.
        /// </summary>
        internal AdMap()
        {
            HasKey(p => p.Id);

            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.Title).IsRequired().HasMaxLength(50);
            Property(p => p.Description).IsRequired();
            Property(p => p.PostDate).IsRequired();

            HasRequired(p => p.Category).WithMany(p => p.Ads).HasForeignKey(p => p.CategoryID).WillCascadeOnDelete(); // 1 - *
            HasRequired(p => p.User).WithMany(p => p.Ads).HasForeignKey(p => p.UserID).WillCascadeOnDelete();     // 1 - *
            
            ToTable("Ads");           
        }
    }
}
