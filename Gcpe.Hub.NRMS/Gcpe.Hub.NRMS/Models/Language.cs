using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gcpe.Hub.NRMS.Models
{
    public class Language
    {
        public Language()
        {
            this.Ministries = new HashSet<MinistryLanguage>();
            this.NewsReleases = new HashSet<NewsReleaseLanguage>();
            this.Sectors = new HashSet<SectorLanguage>();
            this.NewsReleaseImageLanguages = new HashSet<NewsReleaseImageLanguage>();
            this.NewsReleaseDocumentLanguages = new HashSet<NewsReleaseDocumentLanguage>();
            this.NewsReleaseDocumentContacts = new HashSet<NewsReleaseDocumentContact>();
            this.NewsReleaseTypes = new HashSet<NewsReleaseType>();
        }

        public int Id { get; set; }
        public int SortOrder { get; set; }
        public string Name { get; set; }

        public virtual ICollection<MinistryLanguage> Ministries { get; set; }
        public virtual ICollection<NewsReleaseLanguage> NewsReleases { get; set; }
        public virtual ICollection<SectorLanguage> Sectors { get; set; }
        public virtual ICollection<NewsReleaseImageLanguage> NewsReleaseImageLanguages { get; set; }
        public virtual ICollection<NewsReleaseDocumentLanguage> NewsReleaseDocumentLanguages { get; set; }
        public virtual ICollection<NewsReleaseDocumentContact> NewsReleaseDocumentContacts { get; set; }
        public virtual ICollection<NewsReleaseType> NewsReleaseTypes { get; set; }
    }
}
