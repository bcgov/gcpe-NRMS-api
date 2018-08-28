using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gcpe.Hub.NRMS.Models
{
    public class NewsReleaseCollection
    {
        public NewsReleaseCollection()
        {
            this.Releases = new HashSet<NewsRelease>();
        }

        public System.Guid Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<NewsRelease> Releases { get; set; }
    }
}
