
using System.ComponentModel.DataAnnotations;

namespace Travel.Models
{
    public class Settings
    {
        [Key]
        public int ID { get; set; }
        public int PageSize { get; set; }
        public string PhoneNumbers { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}