using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Travel.Models
{
    public class CountryHeader
    {
        [Key]
        public int CountryID { get; set; }
        public string CommonName { get; set; }
        public int PhotoID { get; set; }
        public bool ShowInHomePage { get; set; }
        public virtual Photo Photo { get; set; }
        public virtual ICollection<CountryLocalizedDetail> Countries { get; set; }
        public virtual ICollection<TourHeader> TourHeader { get; set; }
    }
}