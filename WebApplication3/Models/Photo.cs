
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Travel.Models
{
    public class Photo
    {
        [Key]
        public int PhotoID { get; set; }
        public int GalleryID { get; set; }
        [Required]
        public string Path { get; set; }
        [StringLength(maximumLength: 100, MinimumLength = 0)]
        public string Title { get; set; }
        public virtual PhotoGalleryHeader PhotoGallery { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public ICollection<TourPhoto> TourPhoto { get; set; }
    }
}