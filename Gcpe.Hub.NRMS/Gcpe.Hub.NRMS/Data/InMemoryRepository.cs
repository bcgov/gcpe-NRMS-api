using Gcpe.Hub.NRMS.Models;
using System.Collections.Generic;
using System.Linq;

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
            return _ctx.NewsReleases.ToList();
        }

        public NewsRelease GetReleaseByKey(string key)
        {
            return _ctx.NewsReleases.FirstOrDefault(r => r.Key == key);
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
    }
}
