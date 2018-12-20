using Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Travel.Models
{
    public class ContactMail
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Body))]
        [StringLength(maximumLength: 50, MinimumLength = 3, ErrorMessageResourceName ="Min3", ErrorMessageResourceType =typeof(Body))]
        public string Name { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Body))]
        [EmailAddress(ErrorMessageResourceName = "MustBeEmail", ErrorMessageResourceType = typeof(Body))]
        public string Email { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Body))]
        [StringLength(maximumLength: 1000, MinimumLength = 10, ErrorMessageResourceName ="Min10", ErrorMessageResourceType =typeof(Body))]
        public string Message { get; set; }
    }
}