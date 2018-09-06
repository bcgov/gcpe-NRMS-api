using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gcpe.Hub.NRMS.Models
{
    public class MinistryNewsletter
    {
        public System.Guid MinistryId { get; set; }
        public int NewsletterId { get; set; }

        public virtual Ministry Ministry { get; set; }
    }
}
