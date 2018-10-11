using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gcpe.Hub.NRMS.Models;
using Gcpe.Hub.NRMS.Stubs;
using NLipsum.Core;

namespace Gcpe.Hub.NRMS.Data
{
    public class InMemoryDataContext : IDataContext
    {
        const int releasesToCreate = 40;
        const int articlesToCreate = 10;
        private LipsumGenerator lipsum;
        private string[] ministries = new string[] {
            "Public Safety and Solicitor General",
            "Finance",
            "Education",
            "Agriculture",
            "Health",
            "Labour"};

        private string[] regions = new string[] {
            "Vancouver Island / Coast",
            "Vancouver Coast & Mountains",
            "Thompson / Okanagan",
            "Kootenay Rockies",
            "Cariboo Chilcotin Coast",
            "Northern B.C."};
        private Dictionary<string, List<string>> articleImages;

        public List<NewsRelease> NewsReleases { get; set; }

        public List<Article> Articles { get; set; }

        public InMemoryDataContext()
        {
            articleImages = new Dictionary<string, List<string>> {
                { "Public Safety and Solicitor General",
                    new List<string>
                    {
                        "https://images.unsplash.com/photo-1536245344390-dbf1df63c30a?ixlib=rb-0.3.5&ixid=eyJhcHBfaWQiOjEyMDd9&s=0a5bf0efe2ef6417f062d7789d67b276&auto=format&fit=crop&w=2552&q=80",
                        "https://images.unsplash.com/photo-1528439828770-950eb52695a6?ixlib=rb-0.3.5&ixid=eyJhcHBfaWQiOjEyMDd9&s=c75ea538c2f897da10fc750caef0c863&auto=format&fit=crop&w=2545&q=80",
                        "https://images.unsplash.com/photo-1534531105712-130df666d2a1?ixlib=rb-0.3.5&ixid=eyJhcHBfaWQiOjEyMDd9&s=365264d02955eec6fab094e800e050f2&auto=format&fit=crop&w=2550&q=80"
                    }
                },
                { "Finance", new List<string>
                    {
                        "https://images.unsplash.com/photo-1531816466008-90e3a4b01450?ixlib=rb-0.3.5&s=39a4431a3ee4bc89a99bb6d9dc442a98&auto=format&fit=crop&w=2550&q=80",
                        "https://images.unsplash.com/photo-1521709986901-579827f9924a?ixlib=rb-0.3.5&ixid=eyJhcHBfaWQiOjEyMDd9&s=087ed0470bf2e3f2afb83b62d8bc510e&auto=format&fit=crop&w=2500&q=80",
                        "https://images.unsplash.com/photo-1519162584292-56dfc9eb5db4?ixlib=rb-0.3.5&ixid=eyJhcHBfaWQiOjEyMDd9&s=f6dec85ffce82ce1557a66a84ab088cd&auto=format&fit=crop&w=2168&q=80"
                    }
                },
                { "Education", new List<string>
                    {
                        "https://images.unsplash.com/photo-1496469888073-80de7e952517?ixlib=rb-0.3.5&ixid=eyJhcHBfaWQiOjEyMDd9&s=33548b2ee7e57ecb0062b82c9f19d174&auto=format&fit=crop&w=2989&q=80",
                        "https://images.unsplash.com/photo-1488521787991-ed7bbaae773c?ixlib=rb-0.3.5&ixid=eyJhcHBfaWQiOjEyMDd9&s=b73302ddf5fabf9285df2da9c462efbb&auto=format&fit=crop&w=2550&q=80",
                        "https://images.unsplash.com/photo-1477281765962-ef34e8bb0967?ixlib=rb-0.3.5&ixid=eyJhcHBfaWQiOjEyMDd9&s=31e82f46b077da92e44712da8f71bc51&auto=format&fit=crop&w=2132&q=80"
                    }
                },
                { "Agriculture", new List<string>
                    {
                        "https://images.unsplash.com/photo-1535048637252-3a8c40fa2172?ixlib=rb-0.3.5&ixid=eyJhcHBfaWQiOjEyMDd9&s=3a63c59c9a44ab1866557678994e9e36&auto=format&fit=crop&w=2990&q=80",
                        "https://images.unsplash.com/photo-1527847263472-aa5338d178b8?ixlib=rb-0.3.5&ixid=eyJhcHBfaWQiOjEyMDd9&s=09296a26ab3cea9678943c1a80d1a7c4&auto=format&fit=crop&w=2553&q=80",
                        "https://images.unsplash.com/photo-1524486361537-8ad15938e1a3?ixlib=rb-0.3.5&ixid=eyJhcHBfaWQiOjEyMDd9&s=72b0832e8eddf137d77b487bad06f280&auto=format&fit=crop&w=2549&q=80"
                    }
                },
                { "Health", new List<string>
                    {
                        "https://images.unsplash.com/photo-1526256262350-7da7584cf5eb?ixlib=rb-0.3.5&ixid=eyJhcHBfaWQiOjEyMDd9&s=ca8d963483559212f18b75c07fb6302f&auto=format&fit=crop&w=2550&q=80",
                        "https://images.unsplash.com/photo-1512615199361-5c7a110a8d11?ixlib=rb-0.3.5&s=f0ff0a6ef8be3e7fb1472276b0b08ea1&auto=format&fit=crop&w=2550&q=80",
                        "https://images.unsplash.com/photo-1536052737712-5dacded6aa90?ixlib=rb-0.3.5&ixid=eyJhcHBfaWQiOjEyMDd9&s=af4aa10e9e5bc7b32d095efddd240127&auto=format&fit=crop&w=2550&q=80"
                    }
                },
                { "Labour", new List<string>
                    {
                        "https://images.unsplash.com/photo-1532634882-df7054069092?ixlib=rb-0.3.5&ixid=eyJhcHBfaWQiOjEyMDd9&s=5994f30310a545de6fd4dd6b95a73d46&auto=format&fit=crop&w=2550&q=80",
                        "https://images.unsplash.com/photo-1527289626332-8b3abcdda02b?ixlib=rb-0.3.5&ixid=eyJhcHBfaWQiOjEyMDd9&s=1bd2deec78d4bce7123d179c6027d5a5&auto=format&fit=crop&w=2555&q=80",
                        "https://images.unsplash.com/photo-1521799022345-481a897e45ca?ixlib=rb-0.3.5&ixid=eyJhcHBfaWQiOjEyMDd9&s=30de113284aab4977434a32b803f3e5f&auto=format&fit=crop&w=2802&q=80"
                    }
                },
            };

            lipsum = new LipsumGenerator();
            Random rnd = new Random();

            Articles = new List<Article>();

            for (var i = 1; i <= articlesToCreate; i++)
            {
                var ministry = ministries[rnd.Next(ministries.Count())];
                var region = regions[rnd.Next(regions.Count())];
                var ministryImages = articleImages[ministry];
                var article = new Article
                {
                    Title = string.Join("", lipsum.GenerateSentences(1)),
                    Summary = string.Join("", lipsum.GenerateSentences(rnd.Next(1, 3))),
                    Body = string.Join("", lipsum.GenerateParagraphs(rnd.Next(3, 6))),
                    ImageURL = $"{ministryImages[rnd.Next(ministryImages.Count())]}",
                    Ministry = $"{ministry}", // pick a random ministry
                    Region = $"{region}",
                    PublicationDate = DateTime.UtcNow.AddDays(-(rnd.NextDouble() * 90 - 30)), // vary the pub date between 30 and 90 days ago 
                    TimeToRead = rnd.Next(1, 10)
                };

                Articles.Add(article);
            }


            NewsReleases = new List<NewsRelease>();

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

                NewsReleases.Add(release);
            }
        }

        public void Add(object model)
        {
            var release = model as NewsRelease;

            release.Id = Guid.NewGuid();
            NewsReleases.Add(release);
        }

        public void Delete(NewsRelease release)
        {
            NewsReleases.Remove(release);
        }

        public NewsRelease Get(string id)
        {
            return NewsReleases.FirstOrDefault(r => r.Key == id);
        }

        public IEnumerable<NewsRelease> GetAll()
        {
            return NewsReleases.OrderBy(r => r.PublishDateTime);
        }

        public IEnumerable<Article> GetArticles()
        {
            return Articles.OrderBy(a => a.PublicationDate);
        }

        public NewsRelease Update(string id, NewsRelease updatedRelease)
        {
            var release = NewsReleases.FirstOrDefault(r => r.Key == id);
            release.Keywords = updatedRelease.Keywords;

            NewsReleases.Remove(release);
            NewsReleases.Add(release);

            return updatedRelease;
        }

        public IEnumerable<Article> GetSearchResults()
        {
            return Articles.OrderBy(a => a.PublicationDate);
        }
    }
}
