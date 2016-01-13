using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oglasnik.Common
{
    public class CountySortingParameters : ISortingParameters
    {
        public string SortBy { get; private set; }

        public string SortDirection { get; private set; }

        public CountySortingParameters(string sortProperty = "id", string sortOrder = "asc")
        {
            SortBy = GetRealPropertyName(sortProperty);
            SortDirection = GetSortDirection(sortOrder);
        }

        private string GetRealPropertyName(string sortProperty)
        {
            switch (sortProperty.ToLower())
            {
                case "":
                case "id":
                    return "Id";
                case "name":
                    return "Name";
                default:
                    throw new ArgumentException("Invalid property.", "sortProperty");
            }
        }

        private string GetSortDirection(string sortOrder)
        {
            switch (sortOrder.ToLower())
            {
                case "desc":
                case "descending":
                    return "desc";
                default:
                    return "asc";
            }
        }
    }
}
