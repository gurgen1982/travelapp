using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Travel.Models
{
    public class CategoryLocalizedDetail
    {
        [Key]
        public int ID { get; set; }
        public int CategoryID { get; set; }
        public short LangID { get; set; }
        public string CategoryName { get; set; }
    }
}