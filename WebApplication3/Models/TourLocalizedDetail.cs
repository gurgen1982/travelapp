
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Travel.Models
{
    public class TourLocalizedDetail
    {
        [Key]
        public int ID { get; set; }
        public int TourID { get; set; }

        [Required]
        public short LangID { get; set; }
        [Required]
        [StringLength(maximumLength:500, MinimumLength = 5)]
        public string Title { get; set; }
        [StringLength(maximumLength: 500, MinimumLength = 0)]
        public string SubTitle { get; set; }
        [AllowHtml]
        public string Description { get; set; }
        
    }
}