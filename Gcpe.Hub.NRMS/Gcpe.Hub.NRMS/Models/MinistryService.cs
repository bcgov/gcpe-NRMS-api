using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gcpe.Hub.NRMS.Models
{
    public class MinistryService
    {
        public System.Guid MinistryId { get; set; }
        public int SortIndex { get; set; }
        public string LinkText { get; set; }
        public string LinkUrl { get; set; }

        public virtual Ministry Ministry { get; set; }
    }
}
