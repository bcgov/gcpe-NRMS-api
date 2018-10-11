using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gcpe.Hub.NRMS.Helpers
{
    public class SearchParams
    {
        public bool RecentlyViewed { get; set; } = false;
        public string SearchTerm { get; set; }
    }
}
