using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Travel.Models;

namespace Travel.Areas.Admin.Models
{
    public class PhotoGalleryViewModel
    {
        public PhotoGalleryHeader GalleryHeader { get; set; }
        public LPhotoGalleryName[] GalleryNameList { get; set; }
    }
}