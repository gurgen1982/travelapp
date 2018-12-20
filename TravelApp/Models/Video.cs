using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Travel.Models
{
    public class Video
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Url { get; set; }
        public string Title { get; set; }
        public bool ShowAsMain { get; set; }
        public short ShowInOrder { get; set; }
    }
}