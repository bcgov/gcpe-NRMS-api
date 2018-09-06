using Gcpe.Hub.NRMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gcpe.Hub.NRMS.Data
{
    public interface IDataContext
    {
        List<NewsRelease> NewsReleases { get; set; }
        IEnumerable<NewsRelease> GetAll();
        NewsRelease Get(string id);
        void Add(object model);
        NewsRelease Update(string id, NewsRelease release);
        void Delete(NewsRelease release);
    }
}
