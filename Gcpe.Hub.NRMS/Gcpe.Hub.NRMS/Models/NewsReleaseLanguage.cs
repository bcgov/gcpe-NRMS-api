using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gcpe.Hub.NRMS.Models
{
    public class NewsReleaseLanguage
    {
        public System.Guid ReleaseId { get; set; }
        public int LanguageId { get; set; }
        public string Location { get; set; }
        public string Summary { get; set; }
        public string SocialMediaSummary { get; set; }
        public string SocialMediaHeadline { get; set; }

        public virtual Language Language { get; set; }
        public virtual NewsRelease Release { get; set; }
    }
}
