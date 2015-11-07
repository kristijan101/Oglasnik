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

namespace Oglasnik.Repository
{
    public class CountyRepository
    {
        private IOglasnikContext context;

        public CountyRepository(IOglasnikContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Get County by id.
        /// </summary>
        /// <param name="id">County identifier</param>
        /// <returns>matching instance of County</returns>
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
    }
}
