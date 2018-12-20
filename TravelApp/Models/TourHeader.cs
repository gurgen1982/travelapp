
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Travel.Models
{
    public class TourHeader
    {
        [Key]
        public int TourID { get; set; }
        [Required]
        public int CountryID { get; set; }
        [Required]
        public int CategoryID { get; set; }
        [Required]
        [StringLength(maximumLength: 255, MinimumLength = 5)]
        public string CommonName { get; set; }
        [Required]
        [Range(1, 1000)]
        public int NightCount { get; set; }
        public bool BestOffer { get; set; }
        [Required]
        [DisplayName("Price (AMD)")]
        public decimal Price { get; set; }
        public virtual CountryHeader Country { get; set; }
        public virtual CategoryHeader Category { get; set; }

        public virtual ICollection<TourLocalizedDetail> TourDetail { get; set; }

        public virtual ICollection<TourPhoto> TourPhoto { get; set; }
    }
}