using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Travel.Models;

namespace Travel.ViewModels
{
    public class TourViewModel
    {
        //public string PhotoPath { get; set; }
        public Photo Photo { get; set; }
        public TourHeader Tour { get; set; }
        public TourLocalizedDetail TourDetail { get; set; }
    }
}