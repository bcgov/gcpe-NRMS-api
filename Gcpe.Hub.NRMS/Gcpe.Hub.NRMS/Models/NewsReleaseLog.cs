using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gcpe.Hub.NRMS.Models
{
    public class NewsReleaseLog
    {
        public int Id { get; set; }
        public System.Guid ReleaseId { get; set; }
        public System.DateTimeOffset DateTime { get; set; }
        public Nullable<System.Guid> UserId { get; set; }
        public string Description { get; set; }

        public virtual NewsRelease Release { get; set; }
        public virtual User User { get; set; }
    }
}
