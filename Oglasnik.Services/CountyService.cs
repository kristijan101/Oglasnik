using Oglasnik.Common;
using Oglasnik.Model.Common;
using Oglasnik.Repository.Common;
using Oglasnik.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oglasnik.Services
{
    public class CountyService : ICountyService
    {
        private ICountyRepository repository;

        /// <summary>
        /// The class constructor method.
        /// </summary>
        /// <param name="repository">Instance of ICountyRepository type.</param>
        public CountyService(ICountyRepository repository)
        {
            this.repository = repository;
        }

        #region Methods

        /// <summary>
        /// Adds a county to the repository.
        /// </summary>
        /// <param name="county">The county instance to be added.</param>
        /// <returns>Returns <see cref="Task{bool}"/> indicating whether the operation was executed successfuly.</returns>
        public Task<bool> Add(ICounty county)
        {
            if (county == null)
            {
                throw new ArgumentNullException("county");
            }

            return repository.Add(county);
        }

        /// <summary>
        /// Deletes a county from the repository.
        /// </summary>
        /// <param name="county">The county instance to be deleted.</param>
        /// <returns>Returns <see cref="Task{bool}"/> indicating whether the operation was executed successfuly.</returns>
        public Task<bool> Delete(ICounty county)
        {
            if (county == null)
            {
                throw new ArgumentNullException("county");
            }

            return repository.Delete(county);
        }

        /// <summary>
        /// Deletes a county with the given Id.
        /// </summary>
        /// <param name="id">Id of the county to be deleted.</param>
        /// <returns>Returns <see cref="Task{bool}"/> indicating whether the operation was executed successfuly.</returns>
        public Task<bool> Delete(Guid id)
        {
            return repository.Delete(id);
        }

        /// <summary>
        /// Gets all counties from the repository.
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<ICounty>> GetAll()
        {
            return repository.GetAllAsync();
        }

        /// <summary>
        /// Gets the county with the specified Id.
        /// </summary>
        /// <param name="id">Id (of type <see cref="Guid"/>) of the county.</param>
        /// <returns>Returns the county requested or null if not found.</returns>
        public Task<ICounty> GetById(Guid id)
        {
            return repository.GetAsync(id);
        }

        /// <summary>
        /// Gets a range of counties according to the applied filter.
        /// </summary>
        /// <param name="filter">Filter instance of type IFilter.</param>
        /// <param name="paging">A class instance that implements <see cref="IPagingParameters"/>, holds paging data.</param>
        /// <returns>Returns <see cref="Task{IEnumerable{ICounty}}"/>.</returns>
        public Task<IEnumerable<ICounty>> GetRange(IFilter filter, IPagingParameters paging)
        {
            if(filter == null)
            {
                throw new ArgumentNullException("filter");
            }
            if(paging == null)
            {
                throw new ArgumentNullException("paging");
            }
            
            return repository.GetRangeAsync(filter, paging);
        }

        /// <summary>
        /// Gets a range of counties.
        /// </summary>
        /// <param name="paging">A class instance that implements <see cref="IPagingParameters"/>, holds paging data.</param>
        /// <returns>Returns <see cref="Task{IEnumerable{ICounty}}"/></returns>
        public Task<IEnumerable<ICounty>> GetRange(IPagingParameters paging)
        {
            if (paging == null)
            {
                throw new ArgumentNullException("paging");
            }

            return repository.GetRangeAsync(paging);
        }

        /// <summary>
        /// Gets a sorted range of counties.
        /// </summary>
        /// <param name="paging">A class instance that implements <see cref="IPagingParameters"/>, holds paging data.</param>
        /// <param name="sorting">A class instance that implements <see cref="ISortingParameters"/>, holds sorting options.</param>
        /// <returns></returns>
        public Task<IEnumerable<ICounty>> GetRange(IPagingParameters paging, ISortingParameters sorting)
        {
            if (paging == null)
            {
                throw new ArgumentNullException("paging");
            }
            if (sorting == null)
            {
                throw new ArgumentNullException("sorting");
            }

            return repository.GetRangeAsync(paging, sorting);
        }

        /// <summary>
        /// Updates a county.
        /// </summary>
        /// <param name="county">The county to be updated.</param>
        /// <returns>Returns <see cref="Task{bool}"/> indicating whether the operation was executed successfuly.</returns>
        public Task<bool> Update(ICounty county)
        {
            if(county == null)
            {
                throw new ArgumentNullException("county");
            }

            return repository.Update(county);
        }

        #endregion
    }
}
