
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Travel.Models
{
    public class NewsLocalizedDetail
    {
        [Key]
        public int ID { get; set; }
        public int NewsID { get; set; }

        [Required]
        public short LangID { get; set; }
        [Required]
        [StringLength(maximumLength:500, MinimumLength = 5)]
        public string Title { get; set; }
        [AllowHtml]
        public string Description { get; set; }

        public virtual Language Language { get; set; }
        public virtual NewsHeader NewsHeader { get; set; }

    }
}