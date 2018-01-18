using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Travel.Models
{
    public class Photo
    {
        [Key]
        public int PhotoID { get; set; }
        public int GalleryID { get; set; }
        [Required]
        public string Path { get; set; }
        [StringLength(maximumLength:100, MinimumLength = 0)]
        public string Title { get; set; }
    }
}