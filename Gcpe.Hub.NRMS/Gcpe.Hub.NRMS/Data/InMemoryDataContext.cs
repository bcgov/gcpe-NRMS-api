using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gcpe.Hub.NRMS.Models;

namespace Gcpe.Hub.NRMS.Data
{
    public class InMemoryDataContext : IDataContext
    {

        List<NewsRelease> _releases;
        const int releasesToCreate = 40;

        public List<NewsRelease> NewsReleases { get => _releases; set => _releases = value; }

        public InMemoryDataContext()
        {
            _releases = new List<NewsRelease>();

            for (var i = 0; i < releasesToCreate; i++)
            {
                var releaseId = Guid.NewGuid();

                var release = new NewsRelease
                {
                    Id = releaseId,
                    Key = $"2018PREM{i}-{i}00000",
                    Year = 2018,
                    Timestamp = DateTime.Now,
                    ReleaseDateTime = DateTime.Now,
                    PublishDateTime = DateTime.Now,
                    IsPublished = true,
                    IsActive = true,
                    IsCommitted = true,
                    Keywords = "lorem, ipsum, dolor",
                    Logs = new List<NewsReleaseLog>
                    {
                        new NewsReleaseLog
                        {
                            Id = 1,
                            Description = "Created by Jane Doe",
                            DateTime = DateTime.Now,
                            ReleaseId = releaseId
                        },
                        new NewsReleaseLog {
                            Id = 2,
                            Description = "Edited by John Doe",
                            DateTime = DateTime.Now,
                            ReleaseId = releaseId
                        }
                    }
                };

                _releases.Add(release);
            }
        }

        public void Add(object model)
        {
            var release = model as NewsRelease;

            release.Id = Guid.NewGuid();
            _releases.Add(release);
        }

        public void Delete(NewsRelease release)
        {
            _releases.Remove(release);
        }

        public NewsRelease Get(string id)
        {
            return _releases.FirstOrDefault(r => r.Key == id);
        }

        public IEnumerable<NewsRelease> GetAll()
        {
            return _releases.OrderBy(r => r.PublishDateTime);
        }

        public NewsRelease Update(string id, NewsRelease updatedRelease)
        {
            var release = _releases.FirstOrDefault(r => r.Key == id);
            release.Keywords = updatedRelease.Keywords;

            _releases.Remove(release);
            _releases.Add(release);

            return updatedRelease;
        }
    }
}
