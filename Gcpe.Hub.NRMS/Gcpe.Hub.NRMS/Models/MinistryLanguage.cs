using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gcpe.Hub.NRMS.Models
{
    public class MinistryLanguage
    {
        public System.Guid MinistryId { get; set; }
        public int LanguageId { get; set; }
        public string Name { get; set; }

        public virtual Language Language { get; set; }
        public virtual Ministry Ministry { get; set; }
    }
}
