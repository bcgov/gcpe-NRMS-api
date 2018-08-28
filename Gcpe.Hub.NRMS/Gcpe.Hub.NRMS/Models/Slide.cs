using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gcpe.Hub.NRMS.Models
{
    public class Slide
    {
        public Slide()
        {
            this.CarouselSlides = new HashSet<CarouselSlide>();
        }

        public System.Guid Id { get; set; }
        public string Headline { get; set; }
        public string Summary { get; set; }
        public string ActionUrl { get; set; }
        public byte[] Image { get; set; }
        public string FacebookPostUrl { get; set; }
        public Justify Justify { get; set; }
        public System.DateTimeOffset Timestamp { get; set; }

        public virtual ICollection<CarouselSlide> CarouselSlides { get; set; }
    }
}
