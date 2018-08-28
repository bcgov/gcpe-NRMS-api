using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gcpe.Hub.NRMS.Models
{
    public class Blob
    {
        public Blob()
        {
            this.NewsReleaseImages = new HashSet<NewsReleaseImage>();
            this.NewsReleaseHistories = new HashSet<NewsReleaseHistory>();
        }

        public System.Guid Id { get; set; }
        public byte[] Data { get; set; }

        public virtual ICollection<NewsReleaseImage> NewsReleaseImages { get; set; }
        public virtual ICollection<NewsReleaseHistory> NewsReleaseHistories { get; set; }
    }
}
