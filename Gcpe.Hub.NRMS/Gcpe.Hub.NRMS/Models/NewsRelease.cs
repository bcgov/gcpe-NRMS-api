using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Gcpe.Hub.NRMS.Models
{
    public class NewsRelease
    {
        public NewsRelease()
        {
            //MinistryFeatureRelease = new HashSet<Ministry>();
            //MinistryTopRelease = new HashSet<Ministry>();
            //NewsReleaseDocument = new HashSet<NewsReleaseDocument>();
            //NewsReleaseHistory = new HashSet<NewsReleaseHistory>();
            //NewsReleaseLanguage = new HashSet<NewsReleaseLanguage>();
            //NewsReleaseLog = new HashSet<NewsReleaseLog>();
            //NewsReleaseMediaDistribution = new HashSet<NewsReleaseMediaDistribution>();
            //NewsReleaseMinistry = new HashSet<NewsReleaseMinistry>();
            //NewsReleaseSector = new HashSet<NewsReleaseSector>();
            //NewsReleaseService = new HashSet<NewsReleaseService>();
            //NewsReleaseTag = new HashSet<NewsReleaseTag>();
            //NewsReleaseTheme = new HashSet<NewsReleaseTheme>();
            //SectorFeatureRelease = new HashSet<Sector>();
            //SectorTopRelease = new HashSet<Sector>();
            //ThemeFeatureRelease = new HashSet<Theme>();
            //ThemeTopRelease = new HashSet<Theme>();
        }

        public System.Guid Id { get; set; }
        public System.DateTimeOffset Timestamp { get; set; }
        public string Key { get; set; }
        public Nullable<int> Year { get; set; }
        public Nullable<int> YearRelease { get; set; }
        public Nullable<System.Guid> MinistryId { get; set; }
        public Nullable<int> MinistryRelease { get; set; }
        public string Reference { get; set; }
        public Nullable<int> ActivityId { get; set; }
        public Nullable<System.DateTime> ReleaseDateTime { get; set; }
        public Nullable<System.DateTimeOffset> PublishDateTime { get; set; }
        public bool IsPublished { get; set; }
        public PublishOptions PublishOptions { get; set; }
        public bool IsActive { get; set; }
        public System.Guid CollectionId { get; set; }
        public bool IsCommitted { get; set; }
        public string AtomId { get; set; }
        public string Keywords { get; set; }
        public string AssetUrl { get; set; }
        public bool HasMediaAssets { get; set; }
        public ReleaseType ReleaseType { get; set; }
        public string RedirectUrl { get; set; }
        //public virtual ICollection<NewsReleaseLanguage> Languages { get; set; }
        //public virtual ICollection<Ministry> Ministries { get; set; }
        //public virtual ICollection<Sector> Sectors { get; set; }
        public virtual ICollection<NewsReleaseLog> Logs { get; set; }
        //public virtual Ministry Ministry { get; set; }
        //public virtual ICollection<NewsReleaseHistory> History { get; set; }
        //public virtual ICollection<NewsReleaseDocument> Documents { get; set; }
        //public virtual NewsReleaseCollection Collection { get; set; }
        // public virtual ICollection<Tag> Tags { get; set; }
        //public virtual ICollection<Ministry> TopMinistries { get; set; }
        //public virtual ICollection<Ministry> FeatureMinistries { get; set; }
        //public virtual ICollection<Sector> TopSectors { get; set; }
        //public virtual ICollection<Sector> FeatureSectors { get; set; }
        //public virtual ICollection<Theme> FeatureThemes { get; set; }
        //public virtual ICollection<Theme> TopThemes { get; set; }
        //public virtual ICollection<Theme> Themes { get; set; }
        // public virtual ICollection<Service> Services { get; set; }
        //public virtual ICollection<MediaDistributionList> MediaDistributionLists { get; set; }

    }
}
