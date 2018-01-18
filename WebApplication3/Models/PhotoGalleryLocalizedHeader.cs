using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Travel.Models
{
    public class PhotoGalleryLocalizedHeader
    {
        [Key]
        public int ID { get; set; }
        public short LangID { get; set; }
        public int GalleryID { get; set; }
        [StringLength(maximumLength:50, MinimumLength = 3)]
        public string GalleryName { get; set; }
        public virtual Language Language { get; set; }
    }
}