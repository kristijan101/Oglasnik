using Oglasnik.Common;
using Oglasnik.Model.Common;
using Oglasnik.Repository.Common;
using Oglasnik.Services.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Oglasnik.Services
{
    public class CountyService : ICountyService
    {
        #region Fields

        /// <summary>
        /// Store for the <see cref="ICountyRepository"/> repository.
        /// </summary>
        private readonly ICountyRepository repository;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="CountyService"/> class with an <see cref="ICountyRepository"/> instance.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public CountyService(ICountyRepository repository)
        {
            this.repository = repository;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Asynchronously adds a county to the repository.
        /// </summary>
        /// <param name="county">The county to be added.</param>
        /// <returns>Returns <see cref="Task{bool}"/> indicating whether the operation was executed successfuly.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="county"/> is null.</exception>
        public Task<bool> AddAsync(ICounty county)
        {
            if (county == null)
            {
                throw new ArgumentNullException("county");
            }

            return repository.AddAsync(county);
        }

        /// <summary>
        /// Asynchronously deletes a county with the given Id.
        /// </summary>
        /// <param name="id">Id of the county to be deleted.</param>
        /// <returns>Returns <see cref="Task{bool}"/> indicating whether the operation was executed successfuly.</returns>
        public Task<bool> DeleteAsync(Guid id)
        {
            return repository.DeleteAsync(id);
        }

        /// <summary>
        /// Asynchronously gets the county with the specified Id.
        /// </summary>
        /// <param name="id">Id (of type <see cref="Guid"/>) of the county.</param>
        /// <returns>Returns the county requested or null if not found.</returns>
        public Task<ICounty> GetAsync(Guid id)
        {
            return repository.GetAsync(id);
        }

        /// <summary>
        /// Asynchronously gets a range of counties, sorted according to the sorting options provided. An optional filter can also be applied.
        /// </summary>
        /// <param name="filter">Instance of type <see cref="IFilter"/>.</param>
        /// <param name="paging">An instance of type <see cref="IPagingParameters"/>, holds paging data.</param>
        /// <param name="sorting">Sorting options</param>
        /// <returns>Returns <see cref="Task{IEnumerable{ICounty}}"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="paging"/> is null.</exception>
        public Task<IEnumerable<ICounty>> GetAsync(IPagingParameters paging, ISortingParameters sorting, IFilter filter)
        {          
            if (paging == null)
            {
                throw new ArgumentNullException("paging");
            }

            return repository.GetAsync(paging, sorting, filter);
        }

        /// <summary>
        /// Asynchronously updates a county.
        /// </summary>
        /// <param name="county">The county to be updated.</param>
        /// <returns>Returns <see cref="Task{bool}"/> indicating whether the operation was executed successfuly.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="county"/> is null.</exception>
        public Task<bool> UpdateAsync(ICounty county)
        {
            if(county == null)
            {
                throw new ArgumentNullException("county");
            }

            return repository.UpdateAsync(county);
        }

        #endregion
    }
}
