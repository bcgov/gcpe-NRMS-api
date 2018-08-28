using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gcpe.Hub.NRMS.Models
{
    public class NewsReleaseDocumentContact
    {
        public System.Guid DocumentId { get; set; }
        public int LanguageId { get; set; }
        public int SortIndex { get; set; }
        public string Information { get; set; }

        public virtual Language Language { get; set; }
        public virtual NewsReleaseDocument Document { get; set; }
        public virtual NewsReleaseDocumentLanguage DocumentLanguage { get; set; }
    }
}
