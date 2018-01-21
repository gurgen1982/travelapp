using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Travel.Areas.Admin.Models
{
    public class LPhotoGalleryName
    {
        public short LangID { get; set; }
        public int GalleryID { get; set; }
        public string GalleryName { get; set; }
        public string LanguageName { get; set; }
    }
}