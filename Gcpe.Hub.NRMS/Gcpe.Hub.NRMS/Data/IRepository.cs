using System.Collections.Generic;
using Gcpe.Hub.NRMS.Models;

namespace Gcpe.Hub.NRMS.Data
{
    public interface IRepository
    {
        void AddEntity(object model);
        IEnumerable<NewsRelease> GetAllReleases();
        NewsRelease Update(string id, NewsRelease release);
        NewsRelease GetReleaseByKey(string key);
        void Delete(NewsRelease release);
    }
}