using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Travel.Models
{
    public class PhotoGalleryHeader
    {
        [Key]
        public int GalleryID { get; set; }
        public bool InternalUse { get; set; }
        [StringLength(maximumLength:50, MinimumLength = 3)]
        public string GalleryCommonName { get; set; }

        public virtual ICollection<PhotoGalleryLocalizedHeader> LocalizedHeader { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }
    }
}