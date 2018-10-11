using System.Collections.Generic;
using Gcpe.Hub.NRMS.Helpers;
using Gcpe.Hub.NRMS.Models;
using Gcpe.Hub.NRMS.Stubs;

namespace Gcpe.Hub.NRMS.Data
{
    public interface IRepository
    {
        void AddEntity(object model);
        IEnumerable<NewsRelease> GetAllReleases();
        IEnumerable<Article> GetAllArticles(SearchParams searchParams);
        IEnumerable<Article> GetSearchResults();
        NewsRelease Update(string id, NewsRelease release);
        NewsRelease GetReleaseByKey(string key);
        void Delete(NewsRelease release);
    }
}
