
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Travel.Models
{
    public class NewsHeader
    {
        [Key]
        public int NewsID { get; set; }
        [Required]
        [StringLength(maximumLength: 255, MinimumLength = 5)]
        public string CommonName { get; set; }
        public int PhotoID { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DefaultValue("getdate()")]
        public DateTime PublishDate { get; set; }
        public Photo  Photo { get; set; }
        public virtual ICollection<NewsLocalizedDetail> NewsDetail { get; set; }
    }
}