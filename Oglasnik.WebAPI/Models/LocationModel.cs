using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Oglasnik.WebAPI.Models
{
    public class LocationModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the county this location belongs to.
        /// </summary>
        /// <value>
        /// The county identifier.
        /// </value>
        public Guid CountyID { get; set; }

        /// <summary>
        /// Gets or sets the county name this location belongs to.
        /// </summary>
        /// <value>
        /// The county name.
        /// </value>
        public string County { get; set; }
    }
}