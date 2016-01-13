using AutoMapper;
using Oglasnik.Common;
using Oglasnik.DAL.Entities;
using Oglasnik.Model.Common;
using Oglasnik.Repository.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using System.Threading.Tasks;

namespace Oglasnik.Repository
{
    public class CountyRepository : ICountyRepository
    {
        /// <summary>
        /// Store for the repository instance of type IRepository
        /// </summary>
        private IRepository repository;

        #region Constructor

        /// <summary>
        /// The class constructor.
        /// </summary>
        /// <param name="repository">Repository instance of type IRepository</param>
        public CountyRepository(IRepository repository)
        {
            this.repository = repository;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adds a county of type ICounty.
        /// </summary>
        /// <param name="county">Instance of type ICounty to be added.</param>
        /// <returns>Returns <see cref="Task{Boolean}"/> indicating whether the operation was executed successfuly.</returns>
        public Task<bool> Add(ICounty county)
        {
            if(county == null)
            {
                throw new ArgumentNullException("county");
            }
            return repository.AddAsync(Mapper.Map<CountyEntity>(county));
        }

        /// <summary>
        /// Deletes a county of type ICounty.
        /// </summary>
        /// <param name="county">Instance of type ICounty</param>
        /// <returns>Returns <see cref="Task{Boolean}"/> indicating whether the operation was executed successfuly.</returns>
        public Task<bool> Delete(ICounty county)
        {
            if (county == null)
            {
                throw new ArgumentNullException("county");
            }
            return repository.DeleteAsync(Mapper.Map<CountyEntity>(county));
        }

        /// <summary>
        /// Deletes the county with the given Id.
        /// </summary>
        /// <param name="id">Id of the county</param>
        /// <returns>Returns <see cref="Task{bool}"/> indicating whether the operation was executed successfuly.</returns>
        public Task<bool> Delete(Guid id)
        {
            CountyEntity county = new CountyEntity { Id = id };
            
            return repository.DeleteAsync(county);
        }

        /// <summary>
        /// Gets all counties.
        /// </summary>
        /// <returns>Returns <see cref="Task{IEnumerable{ICounty}}"/></returns>
        public async Task<IEnumerable<ICounty>> GetAllAsync()
        {
            return Mapper.Map<IEnumerable<ICounty>>(await repository.GetAll<CountyEntity>().ToListAsync());
        }

        /// <summary>
        /// Gets the county with the given Id.
        /// </summary>
        /// <param name="id">Id of the county to be fetched.</param>
        /// <returns>Returns <see cref="Task{ICounty}"/></returns>
        public async Task<ICounty> GetAsync(Guid id)
        {
            return Mapper.Map<ICounty>(await repository.GetById<CountyEntity>(id));
        }

        /// <summary>
        /// Gets a range of counties which names contain the string given by the filter object.
        /// </summary>
        /// <param name="filter">Filter instance of type IFilter</param>
        /// <param name="paging">A class instance that implements <see cref="IPagingParameters"/>, holds paging data.</param>
        /// <returns>Returns <see cref="Task{IEnumerable{ICounty}}"/></returns>
        public async Task<IEnumerable<ICounty>> GetRangeAsync(IFilter filter, IPagingParameters paging)
        {
            if(filter == null)
            {
                throw new ArgumentNullException("filter");
            }
            if(paging == null)
            {
                throw new ArgumentNullException("paging");
            }

            var query = repository.GetAll<CountyEntity>()
                            .OrderBy(e => e.Name)
                            .Where(e => e.Name.ToLower().Contains(filter.SearchString.ToLower()))
                            .Skip((paging.PageNumber - 1) * paging.PageSize)
                            .Take(paging.PageSize);

            return Mapper.Map<IEnumerable<ICounty>>(await query.ToListAsync());
        }

        /// <summary>
        /// Gets a range of counties.
        /// </summary>
        /// <param name="paging">A class instance that implements <see cref="IPagingParameters"/>, holds paging data.</param>
        /// <returns>Returns <see cref="Task{IEnumerable{ICounty}}"/></returns>
        public async Task<IEnumerable<ICounty>> GetRangeAsync(IPagingParameters paging)
        {
            if (paging == null)
            {
                throw new ArgumentNullException("paging");
            }

            var query = repository.GetAll<CountyEntity>()
                            .OrderBy(e => e.Id)
                            .Skip((paging.PageNumber - 1) * paging.PageSize)
                            .Take(paging.PageSize);

            return Mapper.Map<IEnumerable<ICounty>>(await query.ToListAsync());
        }

        /// <summary>
        /// Gets a sorted range of counties.
        /// </summary>
        /// <param name="paging">A class instance that implements <see cref="IPagingParameters"/>, holds paging data.</param>
        /// <param name="sorting">A class instance that implements <see cref="ISortingParameters"/>, holds sorting options.</param>
        /// <returns></returns>
        public async Task<IEnumerable<ICounty>> GetRangeAsync(IPagingParameters paging, ISortingParameters sorting)
        {
            if (paging == null)
            {
                throw new ArgumentNullException("paging");
            }
            if(sorting == null)
            {
                throw new ArgumentNullException("sorting");
            }

            var query = repository.GetAll<CountyEntity>()
                            .OrderBy(sorting.SortBy + " " + sorting.SortDirection)
                            .Skip((paging.PageNumber - 1) * paging.PageSize)
                            .Take(paging.PageSize);

            return Mapper.Map<IEnumerable<ICounty>>(await query.ToListAsync());
        }

        /// <summary>
        /// Updates a county of type ICounty.
        /// </summary>
        /// <param name="county">The county to be updated.</param>
        /// <returns>Returns <see cref="Task{bool}"/></returns>
        public Task<bool> Update(ICounty county)
        {
            if (county == null)
            {
                throw new ArgumentNullException("county");
            }

            return repository.UpdateAsync(Mapper.Map<CountyEntity>(county));
        }

        #endregion
    }
}
