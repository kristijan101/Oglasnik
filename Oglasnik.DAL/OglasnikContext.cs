using Oglasnik.DAL.Entities;
using Oglasnik.DAL.Mappings;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oglasnik.DAL
{
    public class OglasnikContext : DbContext, Contracts.IOglasnikContext
    {
        public OglasnikContext() : base("OglasnikDb")
        {
        }

        public DbSet<AdEntity> Ads { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<CountyEntity> Counties { get; set; }
        public DbSet<LocationEntity> Locations { get; set; }
        public DbSet<PropertyTypeEntity> Properties { get; set; }
        public DbSet<UserEntity> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AdMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new CountyMap());
            modelBuilder.Configurations.Add(new LocationMap());
            modelBuilder.Configurations.Add(new PropertyTypeMap());
            modelBuilder.Configurations.Add(new PropertyValueMap());

            base.OnModelCreating(modelBuilder); 
        }
    }
}
