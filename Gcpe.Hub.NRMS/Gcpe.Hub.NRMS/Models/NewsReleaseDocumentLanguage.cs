using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gcpe.Hub.NRMS.Models
{
    public class NewsReleaseDocumentLanguage
    {
        public NewsReleaseDocumentLanguage()
        {
            this.Contacts = new HashSet<NewsReleaseDocumentContact>();
        }

        public System.Guid DocumentId { get; set; }
        public int LanguageId { get; set; }
        public Nullable<System.Guid> PageImageId { get; set; }
        public string PageTitle { get; set; }
        public string Organizations { get; set; }
        public string Headline { get; set; }
        public string Subheadline { get; set; }
        public string Byline { get; set; }
        public string BodyHtml { get; set; }

        public virtual Language Language { get; set; }
        public virtual NewsReleaseDocument Document { get; set; }
        public virtual ICollection<NewsReleaseDocumentContact> Contacts { get; set; }
        public virtual NewsReleaseImage PageImage { get; set; }
        public virtual NewsReleaseImageLanguage PageImageLanguage { get; internal set; }
    }
}
