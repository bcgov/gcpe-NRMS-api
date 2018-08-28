using Gcpe.Hub.NRMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gcpe.Hub.NRMS
{
    public partial class SectorLanguage
    {
        public System.Guid SectorId { get; set; }
        public int LanguageId { get; set; }
        public string Name { get; set; }

        public virtual Language Language { get; set; }
        public virtual Sector Sector { get; set; }
    }
}
