using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Travel.Models;

namespace Travel.ViewModels
{
    public class HomeIndexViewModel
    {
        public IEnumerable<MainCarousel> MainCarouselList { get; set; }
        public IEnumerable<Video> VideoBox { get; set; }
        public IEnumerable<Photo> PhotoGallery { get; set; }
        public IEnumerable<TourViewModel> Tours { get; set; }
    }
}