using Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Travel.Models
{
    public class Subscription
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [EmailAddress(ErrorMessageResourceName = "MustBeEmail", ErrorMessageResourceType =typeof(Body))]
        public string Email { get; set; }
    }
}