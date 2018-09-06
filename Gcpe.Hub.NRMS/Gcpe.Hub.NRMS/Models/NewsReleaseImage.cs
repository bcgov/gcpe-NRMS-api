using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gcpe.Hub.NRMS.Models
{
    public class NewsReleaseImage
    {
        public NewsReleaseImage()
        {
            this.Languages = new HashSet<NewsReleaseImageLanguage>();
            this.DocumentLanguages = new HashSet<NewsReleaseDocumentLanguage>();
            this.NewsReleaseTypes = new HashSet<NewsReleaseType>();
        }

        public System.Guid Id { get; set; }
        public string Name { get; set; }
        public string MimeType { get; set; }
        public int SortOrder { get; set; }
        public System.Guid BlobId { get; set; }

        public virtual ICollection<NewsReleaseImageLanguage> Languages { get; set; }
        public virtual Blob Blob { get; set; }
        public virtual ICollection<NewsReleaseDocumentLanguage> DocumentLanguages { get; set; }
        public virtual ICollection<NewsReleaseType> NewsReleaseTypes { get; set; }
    }
}
