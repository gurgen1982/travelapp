using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Travel.Models;

namespace Travel.ViewModels
{
    public class NewsViewModel
    {
        public string PhotoPath { get; set; }
        public NewsHeader News { get; set; }
        public NewsLocalizedDetail NewsDetail { get; set; }
    }
}