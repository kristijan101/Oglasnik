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
using PagedList;

namespace Oglasnik.Repository
{
    public class CountyRepository : ICountyRepository
    {
        #region Fields

        /// <summary>
        /// Store for a generic repository instance of type <see cref="IRepository"/>
        /// </summary>
        private readonly IRepository repository;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="CountyRepository"/> class with a generic repository instance of type <see cref="IRepository"/>.
        /// </summary>
        /// <param name="repository">The repository of type <see cref="IRepository"/>.</param>
        public CountyRepository(IRepository repository)
        {
            this.repository = repository;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Asynchronously adds a county.
        /// </summary>
        /// <param name="county">The county to be added.</param>
        /// <returns>Returns <see cref="Task{Boolean}"/> indicating whether the operation was executed successfuly.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="county"/> is null.</exception>
        public Task<bool> AddAsync(ICounty county)
        {
            if(county == null)
            {
                throw new ArgumentNullException("county");
            }
            return repository.AddAsync(Mapper.Map<CountyEntity>(county));
        }

        /// <summary>
        /// Asynchronously deletes the county with the given Id.
        /// </summary>
        /// <param name="id">Id of the county</param>
        /// <returns>Returns <see cref="Task{bool}"/> indicating whether the operation was executed successfuly.</returns>
        public Task<bool> DeleteAsync(Guid id)
        {
            CountyEntity county = new CountyEntity { Id = id };
            
            return repository.DeleteAsync(county);
        }

        /// <summary>
        /// Asynchronously gets the county with the given Id.
        /// </summary>
        /// <param name="id">Id of the county.</param>
        /// <returns>Returns <see cref="Task{ICounty}"/></returns>
        public async Task<ICounty> GetAsync(Guid id)
        {
            return Mapper.Map<ICounty>(await repository.GetAsync<CountyEntity>(id));
        }

        /// <summary>
        /// Asynchronously gets a sorted collection of counties, an optional filter can also be applied.
        /// </summary>
        /// <param name="filter">An optional filter to be used</param>
        /// <param name="paging">An instance of a class that implements <see cref="IPagingParameters"/>.</param>
        /// <param name="sorting">An instance of a class that implements <see cref="ISortingParameters"/>.</param>
        /// <returns>Returns <see cref="Task{IEnumerable{ICounty}}"/></returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="paging"/> is null.</exception>
        public async Task<IEnumerable<ICounty>> GetAsync(IPagingParameters paging, ISortingParameters sorting, IFilter filter)
        {
            if(paging == null)
            {
                throw new ArgumentNullException("paging");
            }

            if(sorting == null)
            {
                IList<ISortingPair> sortPair = new List<ISortingPair>()
                {
                    new SortingPair("Name")
                };
                sorting = new SortingParameters(sortPair);
            }

            var query = repository.GetAll<CountyEntity>()
                            .OrderBy(sorting.GetJoinedSortExpressions());

            if (filter != null && !string.IsNullOrEmpty(filter.SearchString))
            {
                query = query.Where(e => e.Name.ToLower().Contains(filter.SearchString.ToLower()));
            }

            return Mapper.Map<IEnumerable<ICounty>>(await query.ToPagedListAsync(paging.PageNumber, paging.PageSize));
        }

        /// <summary>
        /// Asynchronously updates a county.
        /// </summary>
        /// <param name="county">The county to be updated.</param>
        /// <returns>Returns <see cref="Task{bool}"/></returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="county"/> is null.</exception>
        public Task<bool> UpdateAsync(ICounty county)
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
