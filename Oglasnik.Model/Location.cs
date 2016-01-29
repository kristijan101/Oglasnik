using Oglasnik.Model.Common;
using System;
using System.Collections.Generic;

namespace Oglasnik.Model
{
    public class Location : Common.ILocation
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the location.
        /// </summary>
        /// <value>
        /// The name of the location.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the county to which this location belongs to.
        /// </summary>
        /// <value>
        /// The county identifier.
        /// </value>
        public Guid CountyID { get; set; }

        /// <summary>
        /// Gets or sets the county.
        /// </summary>
        /// <value>
        /// The county.
        /// </value>
        public ICounty County { get; set; }
    }
}