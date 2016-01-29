using Oglasnik.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oglasnik.DAL.Contracts
{
    public interface IOglasnikContext
    {
        /// <summary>
        /// Gets or sets the collection of ads.
        /// </summary>
        /// <value>
        /// The collection of ads.
        /// </value>
        DbSet<AdEntity> Ads { get; set; }

        /// <summary>
        /// Gets or sets the collection of categories.
        /// </summary>
        /// <value>
        /// The collection of categories.
        /// </value>
        DbSet<CategoryEntity> Categories { get; set; }

        /// <summary>
        /// Gets or sets the collection of counties.
        /// </summary>
        /// <value>
        /// The collection of counties.
        /// </value>
        DbSet<CountyEntity> Counties { get; set; }

        /// <summary>
        /// Gets or sets the collection of locations.
        /// </summary>
        /// <value>
        /// The collection of locations.
        /// </value>
        DbSet<LocationEntity> Locations { get; set; }

        /// <summary>
        /// Gets or sets the collection of property types.
        /// </summary>
        /// <value>
        /// The collection of property types.
        /// </value>
        DbSet<PropertyTypeEntity> PropertyTypes { get; set; }

        /// <summary>
        /// Gets or sets the collection of property values.
        /// </summary>
        /// <value>
        /// The collection of property values.
        /// </value>
        DbSet<PropertyValueEntity> PropertyValues { get; set; }

        /// <summary>
        /// Returns a <see cref="DbSet{TEntity}"/> instance for access to entities of the given type in the context and the underlying store.
        /// </summary>
        /// <typeparam name="TEntity">The type of entity for which a set should be returned.</typeparam>
        /// <returns>A set for the given entity type.</returns>
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        /// <summary>
        /// Asynchronously saves all changes made in this context to the underlying database.
        /// </summary>
        /// <returns>A task that represents the asynchronous save operation. The task result contains the number of objects written to the underlying database.</returns>
        Task<int> SaveChangesAsync();

        /// <summary>
        /// Gets a <see cref="DbEntityEntry{TEntity}"/> object for the given entity providing access to information about the entity and the ability to perform actions on the entity.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns>An entry for the entity.</returns>
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity:class;
    }
}
