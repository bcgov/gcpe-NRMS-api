using AutoMapper;
using Gcpe.Hub.NRMS.Models;
using Gcpe.Hub.NRMS.ViewModels;

namespace Gcpe.Hub.NRMS.Data
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<NewsRelease, NewsReleaseViewModel>()
                .ReverseMap();

            CreateMap<NewsReleaseLog, NewsReleaseLogViewModel>()
                .ReverseMap();
        }
    }
}
