
using System.Collections.Generic;
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
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public virtual ICollection<TourLocalizedDetail> TourDetail { get; set; }
        
    }
}