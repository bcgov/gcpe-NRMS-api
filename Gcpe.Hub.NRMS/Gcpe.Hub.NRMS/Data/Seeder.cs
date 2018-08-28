using Gcpe.Hub.NRMS.Models;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Gcpe.Hub.NRMS.Data
{
    public class Seeder // use this class for seeding a relational database
    {
        //private readonly RelationalDataContext _ctx;
        //private readonly IHostingEnvironment _hosting;

        //public Seeder(RelationalDataContext ctx, IHostingEnvironment hosting)
        //{
        //    _ctx = ctx;
        //    _hosting = hosting;
        //}

        //public void Seed()
        //{
        //    _ctx.Database.EnsureCreated();

        //    if (!_ctx.NewsReleases.Any())
        //    {
        //        // create sample data
        //        var filepath = Path.Combine(_hosting.ContentRootPath, "Data/releases.json");
        //        var json = File.ReadAllText(filepath);
        //        var releases = JsonConvert.DeserializeObject<IEnumerable<NewsRelease>>(json);
        //        _ctx.NewsReleases.AddRange(releases);

        //        _ctx.SaveChanges();
        //    }
        //}
    }
}