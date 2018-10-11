using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gcpe.Hub.NRMS.Stubs
{
    /* Stub for rapidly prototyping the search feature */
    public class Article
    {
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Body { get; set; }
        public string ImageURL { get; set; }
        public string Ministry { get; set; }
        public string Region { get; set; }
        public DateTime PublicationDate { get; set; }
        public int TimeToRead { get; set; }
    }
}
