using Microsoft.AspNet.Identity.EntityFramework;
using Oglasnik.DAL.Entities;
using Oglasnik.DAL.Mappings;
using System.Data.Entity;

namespace Oglasnik.DAL
{
    public class OglasnikContext : IdentityDbContext<UserEntity>, Contracts.IOglasnikContext
    {
        static OglasnikContext()
        {
            Database.SetInitializer(new Initializers.OglasnikDbInitializer());
        }

        public OglasnikContext() : base("OglasnikDb")
        {
        }

        public DbSet<AdEntity> Ads { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<CountyEntity> Counties { get; set; }
        public DbSet<LocationEntity> Locations { get; set; }
        public DbSet<PropertyTypeEntity> PropertyTypes { get; set; }
        public DbSet<PropertyValueEntity> PropertyValues { get; set; }

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
