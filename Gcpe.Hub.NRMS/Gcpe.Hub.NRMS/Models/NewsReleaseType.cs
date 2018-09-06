using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gcpe.Hub.NRMS.Models
{
    public class NewsReleaseType
    {
        public string PageTitle { get; set; }
        public int LanguageId { get; set; }
        public int ReleaseType { get; set; }
        public int SortOrder { get; set; }
        public int PageLayout { get; set; }
        public Nullable<System.Guid> PageImageId { get; set; }

        public virtual Language Language { get; set; }
        public virtual NewsReleaseImage PageImage { get; set; }
    }
}
