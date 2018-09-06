using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gcpe.Hub.NRMS.Models
{
    public class Carousel
    {
        public Carousel()
        {
            this.CarouselSlides = new HashSet<CarouselSlide>();
        }

        public System.Guid Id { get; set; }
        public Nullable<System.DateTimeOffset> PublishDateTime { get; set; }
        public System.DateTimeOffset Timestamp { get; set; }

        public virtual ICollection<CarouselSlide> CarouselSlides { get; set; }
    }
}
