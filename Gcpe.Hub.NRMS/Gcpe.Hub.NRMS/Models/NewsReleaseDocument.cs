using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gcpe.Hub.NRMS.Models
{
    public class NewsReleaseDocument
    {
        public NewsReleaseDocument()
        {
            this.Languages = new HashSet<NewsReleaseDocumentLanguage>();
            this.Contacts = new HashSet<NewsReleaseDocumentContact>();
        }

        public System.Guid Id { get; set; }
        public System.Guid ReleaseId { get; set; }
        public int SortIndex { get; set; }
        public PageLayout PageLayout { get; set; }

        public virtual NewsRelease Release { get; set; }
        public virtual ICollection<NewsReleaseDocumentLanguage> Languages { get; set; }
        public virtual ICollection<NewsReleaseDocumentContact> Contacts { get; set; }
    }
}
