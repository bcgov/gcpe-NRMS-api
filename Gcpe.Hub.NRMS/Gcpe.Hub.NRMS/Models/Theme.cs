using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gcpe.Hub.NRMS.Models
{
    public class Theme
    {
        public Theme()
        {
            this.NewsReleases = new HashSet<NewsRelease>();
        }

        public System.Guid Id { get; set; }
        public string Key { get; set; }
        public string DisplayName { get; set; }
        public System.DateTime Timestamp { get; set; }
        public Nullable<System.Guid> TopReleaseId { get; set; }
        public Nullable<System.Guid> FeatureReleaseId { get; set; }
        public int SortOrder { get; set; }
        public bool IsActive { get; set; }

        public virtual NewsRelease FeatureRelease { get; set; }
        public virtual NewsRelease TopRelease { get; set; }
        public virtual ICollection<NewsRelease> NewsReleases { get; set; }
    }
}
