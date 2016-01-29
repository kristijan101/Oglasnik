using Microsoft.AspNet.Identity.EntityFramework;
using Oglasnik.DAL.Entities;
using Oglasnik.DAL.Mappings;
using System.Data.Entity;

namespace Oglasnik.DAL
{
    public class OglasnikContext : IdentityDbContext<UserEntity>, Contracts.IOglasnikContext
    {
        /// <summary>
        /// Initializes the <see cref="OglasnikContext"/> class.
        /// </summary>
        static OglasnikContext()
        {
            Database.SetInitializer(new Initializers.OglasnikDbInitializer());
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OglasnikContext"/> class.
        /// </summary>
        public OglasnikContext() : base("OglasnikDb")
        {
        }

        /// <summary>
        /// Gets or sets the collection of ads.
        /// </summary>
        /// <value>
        /// The collection of ads.
        /// </value>
        public DbSet<AdEntity> Ads { get; set; }

        /// <summary>
        /// Gets or sets the collection of categories.
        /// </summary>
        /// <value>
        /// The collection of categories.
        /// </value>
        public DbSet<CategoryEntity> Categories { get; set; }

        /// <summary>
        /// Gets or sets the collection of counties.
        /// </summary>
        /// <value>
        /// The collection of counties.
        /// </value>
        public DbSet<CountyEntity> Counties { get; set; }

        /// <summary>
        /// Gets or sets the collection of locations.
        /// </summary>
        /// <value>
        /// The collection of locations.
        /// </value>
        public DbSet<LocationEntity> Locations { get; set; }

        /// <summary>
        /// Gets or sets the collection of property types.
        /// </summary>
        /// <value>
        /// The collection of property types.
        /// </value>
        public DbSet<PropertyTypeEntity> PropertyTypes { get; set; }

        /// <summary>
        /// Gets or sets the collection of property values.
        /// </summary>
        /// <value>
        /// The collection of property values.
        /// </value>
        public DbSet<PropertyValueEntity> PropertyValues { get; set; }

        /// <summary>
        /// Maps table names, and sets up relationships between the various user entities
        /// </summary>
        /// <param name="modelBuilder"></param>
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
