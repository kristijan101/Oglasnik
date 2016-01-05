using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oglasnik.Common
{
    public class DefaultFilter : IFilter
    {
        private const int MaxPageSize = 100;
        private int _pageSize;

        #region Properties

        public int PageNumber { get; private set; }

        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            private set
            {
                _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
            }
        }

        public string SearchString { get; private set; }
        
        #endregion

        public DefaultFilter(string searchString, int pageNum = 1, int pageSize = 10)
        {
            SearchString = searchString;
            PageNumber = pageNum;
            PageSize = pageSize;
        }
    }
}
