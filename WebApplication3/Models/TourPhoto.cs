
using System.ComponentModel.DataAnnotations;

namespace Travel.Models
{
    public class TourPhoto
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int PhotoID { get; set; }
        public int TourID { get; set; }
        public bool ShowAsMain { get; set; }
        public virtual Photo Photo { get; set; }

        public virtual TourHeader TourHeader { get; set; }
    }
}