using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oglasnik.DAL.Contracts;
using Oglasnik.Model.Common;
using Oglasnik.DAL;
using AutoMapper;
using System.Linq.Expressions;
using System.Data.Entity;
using Oglasnik.DAL.Entities;
using Oglasnik.Repository.Common;
using System.Data.Entity.Infrastructure;

namespace Oglasnik.Repository
{
    public class CountyRepository : ICountyRepository
    {
        private IOglasnikContext context;

        public CountyRepository(IOglasnikContext context)
        {
            this.context = context;
        }

        public async Task<ICounty> GetAsync(Guid id)
        {
            return Mapper.Map<ICounty>(await context.Counties.FindAsync(id));
        }

        public async Task<ICounty> GetAsync(Expression<Func<CountyEntity, bool>> predicate)
        {
            return Mapper.Map<ICounty>(await context.Counties.FirstAsync(predicate));
        }

        public async Task<IEnumerable<ICounty>> GetAllAsync()
        {
            return Mapper.Map<IEnumerable<ICounty>>(await context.Counties.ToListAsync());
        }

        public async Task<int> AddAsync(ICounty county)
        {
            context.Counties.Add(Mapper.Map<CountyEntity>(county));
            return await context.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(ICounty county)
        {
            var entity = Mapper.Map<CountyEntity>(county);
            DbEntityEntry entry = context.Entry(entity);

            if(entry.State == EntityState.Detached)
            {
                context.Counties.Attach(entity);
            }
            entry.State = EntityState.Modified;

            return await context.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(ICounty county)
        {
            context.Counties.Remove(Mapper.Map<CountyEntity>(county));
            return await context.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            context.Counties.Remove(Mapper.Map<CountyEntity>(await GetAsync(id)));
            return await context.SaveChangesAsync();
        }
    }
}
