using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Travel.Models
{
    public class Language
    {
        [Key]
        public short LangID { get; set; }
        public string Name { get; set; }
        public string CommonName { get; set; }
        public string Locale { get; set; }
        public string LangCulture { get; set; }
        public virtual ICollection<NewsLocalizedDetail> NewsDetails { get; set; }
        public virtual ICollection<TourLocalizedDetail> TourDetails { get; set; }
        public virtual ICollection<CountryLocalizedDetail> Countries { get; set; }
        public virtual ICollection<CategoryLocalizedDetail> Categories { get; set; }

        public virtual ICollection<PhotoGalleryLocalizedHeader> PhotoGallery { get; set; }
        

    }
}