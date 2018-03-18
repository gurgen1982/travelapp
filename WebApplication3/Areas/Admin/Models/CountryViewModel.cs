using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Travel.Models;

namespace Travel.Areas.Admin.Models
{
    public class CountryViewModel
    {
        public CountryHeader CountryHeader { get; set; }
        public bool IsEditMode { get; set; }
        public IEnumerable<Language> Languages { get; set; }
        public IEnumerable<PhotoGalleryHeader> Gallery{ get; set; }
    }
}