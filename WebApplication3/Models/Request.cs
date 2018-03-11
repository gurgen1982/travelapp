using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Travel.Models
{
    public class Request
    {
        [Key]
        public int RequestID { get; set; }
        public int? TourID { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string OtherContacts { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Title { get; set; }

        [Range(1, 1000)]
        [Required]
        public int CountOfTourist { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? TourDate { get; set; }

        [StringLength(1000, MinimumLength = 0)]
        public string Message { get; set; }

    }
}