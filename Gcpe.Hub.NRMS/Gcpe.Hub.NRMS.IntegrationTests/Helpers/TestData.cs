using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Gcpe.Hub.NRMS.Models;
using Bogus;

namespace Gcpe.Hub.NRMS.IntegrationTests
{
    public static class TestData
    {
        private static Faker f = new Faker();
        private static int globalId = 0;
        private static int NextId()
        {
            return globalId++;
        }

        public static NewsRelease CreateNewsRelease()
        {
            var release = new NewsRelease
            {
                Id = Guid.NewGuid(),
                Key = NextId().ToString(),
                Keywords = string.Join(", ", f.Lorem.Words(3)),
                Year = f.PickRandom(new[] { 2018, 2010, 2001, 1995 }),
                Timestamp = f.Date.Past(),
                ReleaseDateTime = f.Date.Past(),
                PublishDateTime = f.Date.Past(),
                IsPublished = f.PickRandom(new bool[] { true, true, false }),
                IsActive = f.PickRandom(new bool[] { true, true, false }),
                IsCommitted = f.PickRandom(new bool[] { true, true, false }),
                Logs = CreateNewsReleaseLogCollection(f.Random.Number(1, 5))
            };

            // Link children to parent object
            foreach (var x in release.Logs)
            {
                x.ReleaseId = release.Id;
            }

            return release;
        }

        public static ICollection<NewsRelease> CreateNewsReleaseCollection(int count = 5)
        {
            var collection = new List<NewsRelease>();
            for (int i = 0; i < count; i++)
            {
                var item = CreateNewsRelease();
                collection.Add(item);
            }
            return collection;
        }

        public static NewsReleaseLog CreateNewsReleaseLog()
        {
            return new NewsReleaseLog
            {
                Id = NextId(),
                Description = f.Lorem.Sentences(3),
                DateTime = f.Date.Past()
            };
        }

        public static ICollection<NewsReleaseLog> CreateNewsReleaseLogCollection(int count = 5)
        {
            var collection = new List<NewsReleaseLog>();
            for (int i = 0; i < count; i++)
            {
                var item = CreateNewsReleaseLog();
                collection.Add(item);
            }
            return collection;
        }
    }
}
