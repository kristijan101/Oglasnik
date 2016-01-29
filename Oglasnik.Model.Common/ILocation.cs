using System;

namespace Oglasnik.Model.Common
{
    public interface ILocation
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        Guid Id { get; set; }


        /// <summary>
        /// Gets or sets the name of the location.
        /// </summary>
        /// <value>
        /// The name of the location.
        /// </value>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the county to which this location belongs to.
        /// </summary>
        /// <value>
        /// The county identifier.
        /// </value>
        Guid CountyID { get; set; }

        /// <summary>
        /// Gets or sets the county.
        /// </summary>
        /// <value>
        /// The county.
        /// </value>
        ICounty County { get; set; }
    }
}