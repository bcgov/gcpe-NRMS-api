using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gcpe.Hub.NRMS.ViewModels
{
    public class NewsReleaseViewModel
    {
        public System.DateTimeOffset Timestamp { get; set; }
        [Required]
        [MaxLength(255)]
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
        // public PublishOptions PublishOptions { get; set; }
        public bool IsActive { get; set; }
        public System.Guid CollectionId { get; set; }
        public bool IsCommitted { get; set; }
        public string AtomId { get; set; }
        public string Keywords { get; set; }
        public string AssetUrl { get; set; }
        public bool HasMediaAssets { get; set; }
        // public ReleaseType ReleaseType { get; set; }
        public string RedirectUrl { get; set; }
    }
}
