using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gcpe.Hub.NRMS.Models
{
    public class User
    {
        public User()
        {
            this.NewsReleaseLogs = new HashSet<NewsReleaseLog>();
        }

        public System.Guid Id { get; set; }
        public string DisplayName { get; set; }
        public string EmailAddress { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<NewsReleaseLog> NewsReleaseLogs { get; set; }
    }
}
