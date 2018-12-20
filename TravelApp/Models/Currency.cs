using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Travel.Models
{
    public class Currency
    {
        [Key]
        public int CurrencyID { get; set; }
        public string Name { get; set; }
    }
}