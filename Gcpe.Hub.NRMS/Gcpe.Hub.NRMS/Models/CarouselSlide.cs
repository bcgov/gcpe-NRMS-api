using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gcpe.Hub.NRMS.Models
{
    public class CarouselSlide
    {
        public System.Guid CarouselId { get; set; }
        public System.Guid SlideId { get; set; }
        public int SortIndex { get; set; }

        public virtual Carousel Carousel { get; set; }
        public virtual Slide Slide { get; set; }
    }
}
