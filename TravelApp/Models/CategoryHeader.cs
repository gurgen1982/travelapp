using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Travel.Models
{
    public class CategoryHeader
    {
        [Key]
        public int CategoryID { get; set; }
        public int ParentCategoryID { get; set; }
        public string CommonName { get; set; }

        public virtual ICollection<CategoryLocalizedDetail> CategoryDetail { get; set; }
        public virtual ICollection<TourHeader> TourHeader { get; set; }
    }
}