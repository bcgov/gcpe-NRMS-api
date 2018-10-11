using System.Collections.Generic;
using System.Linq;
using Gcpe.Hub.NRMS.Helpers;
using Gcpe.Hub.NRMS.Models;
using Gcpe.Hub.NRMS.Stubs;

namespace Gcpe.Hub.NRMS.Data
{
    public class InMemoryRepository : IRepository
    {
        private readonly IDataContext _ctx;

        public InMemoryRepository(IDataContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<NewsRelease> GetAllReleases()
        {
            return _ctx.GetAll();
        }

        public NewsRelease GetReleaseByKey(string key)
        {
            return _ctx.Get(key);
        }

        public void AddEntity(object model)
        {
            _ctx.Add(model);
        }

        public NewsRelease Update(string id, NewsRelease release)
        {
            return _ctx.Update(id, release);
        }

        public void Delete(NewsRelease release)
        {
            _ctx.Delete(release);
        }

        public IEnumerable<Article> GetAllArticles(SearchParams searchParams)
        {
            if (searchParams?.RecentlyViewed == true)
            {
                return _ctx.GetArticles();
            }

            var searchTerm = searchParams?.SearchTerm;
            IEnumerable<Article> articles = _ctx.GetArticles();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                articles = articles.Where(r =>
                    r.Summary.Contains(searchTerm)
                    || r.Title.Contains(searchTerm));
            }

            return articles;
        }

        public IEnumerable<Article> GetSearchResults()
        {
            return _ctx.GetSearchResults();
        }
    }
}
