using Resources;
using System;
using System.ComponentModel.DataAnnotations;


namespace Travel.Models
{
    public class Request
    {
        [Key]
        public int RequestID { get; set; }
        public int? TourID { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Body))]
        [EmailAddress(ErrorMessageResourceName = "MustBeEmail", ErrorMessageResourceType = typeof(Body))]
        [Display(Name = "Email", ResourceType = typeof(Body))]
        public string Email { get; set; }

        [Display(Name = "OtherContacts", ResourceType = typeof(Body))]
        public string OtherContacts { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Body))]
        [StringLength(100, MinimumLength = 3, ErrorMessageResourceName = "FullNameLength", ErrorMessageResourceType = typeof(Body))]
        [Display(Name = "FullName", ResourceType = typeof(Body))]
        public string Name { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Body))]
        [StringLength(100, MinimumLength = 3, ErrorMessageResourceName = "TitleLength", ErrorMessageResourceType = typeof(Body))]
        [Display(Name = "Title", ResourceType = typeof(Body))]
        public string Title { get; set; }

        [Range(1, 1000, ErrorMessageResourceName = "CountOfTouristRange", ErrorMessageResourceType = typeof(Body))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Body))]
        [Display(Name = "CountOfTourist", ResourceType = typeof(Body))]
        public int CountOfTourist { get; set; }

        [DataType(DataType.Date, ErrorMessageResourceName = "MustBeDate", ErrorMessageResourceType = typeof(Body))]
        [Display(Name = "TourDate", ResourceType = typeof(Body))]
        public DateTime? TourDate { get; set; }

        [StringLength(1000, MinimumLength = 0, ErrorMessageResourceName = "MessageLength", ErrorMessageResourceType = typeof(Body))]
        [Display(Name = "Message", ResourceType = typeof(Body))]
        public string Message { get; set; }
    }
}