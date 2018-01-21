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
        [Display(Name = "Internal Use")]
        public bool InternalUse { get; set; }
        [StringLength(maximumLength:50, MinimumLength = 3)]
        [Display(Name ="Common Name")]
        public string GalleryCommonName { get; set; }

        public virtual ICollection<PhotoGalleryLocalizedHeader> LocalizedHeader { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }
    }
}