﻿
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        public int MainPhotoID { get; set; }
        public virtual ICollection<NewsLocalizedDetail> NewsDetail { get; set; }
    }
}