using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Travel.Models
{
    public class CountryLocalizedDetail
    {
        [Key]
        public int ID { get; set; }
        public int CountryID { get; set; }
        public short LangID { get; set; }
        public string CountryName { get; set; }
        public string Тagline { get; set; }
        [AllowHtml]
        public string Description { get; set; }
        public virtual Language Language { get; set; }
    }
}