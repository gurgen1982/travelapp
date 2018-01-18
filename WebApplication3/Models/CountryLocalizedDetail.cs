using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Travel.Models
{
    public class CountryLocalizedDetail
    {
        [Key]
        public int ID { get; set; }
        public int CountryID { get; set; }
        public short LangID { get; set; }
        public string CountryName { get; set; }
    }
}