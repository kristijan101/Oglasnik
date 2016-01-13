using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oglasnik.Common
{
    public interface IPagingParameters
    {
        int PageNumber { get; }
        int PageSize { get; }
    }
}
