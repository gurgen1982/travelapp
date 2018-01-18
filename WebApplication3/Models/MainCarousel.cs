
using System.ComponentModel.DataAnnotations;

namespace Travel.Models
{
    public class MainCarousel
    {
        [Key]
        public int ID { get; set; }
        [StringLength(maximumLength: 50)]
        public string Title { get; set; }
        [StringLength(maximumLength: 50)]
        public string SubTitle { get; set; }
        [StringLength(maximumLength: 50)]
        public string Details { get; set; }
        [StringLength(maximumLength: 50)]
        public string SubDetails { get; set; }
        public decimal Price { get; set; }
        [Required]
        public string LinkUrl { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        public bool Disabled { get; set; }
        public short LangID { get; set; }
    }
}