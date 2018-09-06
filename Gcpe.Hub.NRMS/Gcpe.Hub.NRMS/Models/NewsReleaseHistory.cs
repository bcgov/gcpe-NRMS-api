using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gcpe.Hub.NRMS.Models
{
    public class NewsReleaseHistory
    {
        public System.Guid ReleaseId { get; set; }
        public System.DateTimeOffset PublishDateTime { get; set; }
        public string MimeType { get; set; }
        public System.Guid BlobId { get; set; }

        public virtual NewsRelease Release { get; set; }
        public virtual Blob Blob { get; set; }
    }
}
