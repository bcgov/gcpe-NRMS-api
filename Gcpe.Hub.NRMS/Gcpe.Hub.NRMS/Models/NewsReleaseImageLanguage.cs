using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gcpe.Hub.NRMS.Models
{
    public class NewsReleaseImageLanguage
    {
        public NewsReleaseImageLanguage()
        {
            this.DocumentLanguages = new HashSet<NewsReleaseDocumentLanguage>();
        }

        public System.Guid ImageId { get; set; }
        public int LanguageId { get; set; }
        public string AlternateName { get; set; }

        public virtual Language Language { get; set; }
        public virtual NewsReleaseImage Image { get; set; }
        public virtual ICollection<NewsReleaseDocumentLanguage> DocumentLanguages { get; set; }
    }
}
