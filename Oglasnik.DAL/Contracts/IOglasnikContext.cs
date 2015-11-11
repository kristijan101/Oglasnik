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
        DbSet<AdEntity> Ads { get; set; }
        DbSet<CategoryEntity> Categories { get; set; }
        DbSet<CountyEntity> Counties { get; set; }
        DbSet<LocationEntity> Locations { get; set; }
        DbSet<PropertyTypeEntity> PropertyTypes { get; set; }
        DbSet<PropertyValueEntity> PropertyValues { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        Task<int> SaveChangesAsync();
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity:class;
    }
}
