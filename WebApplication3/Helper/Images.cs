using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Travel.Helper
{
    public class Images
    {
        public static string GetThumbPath(string filePath)
        {
            var lIndex = filePath.LastIndexOf("/") + 1;
            return filePath.Substring(0, lIndex) + HttpContext.Current.Application["ImageThumb"].ToString() + filePath.Substring(lIndex);
        }

        public static string GetThumbFullPath(Models.Photo photo)
        {
            return GetThumbFullPath(photo.Path, photo.GalleryID);
        }
        public static string GetThumbFullPath(string filePath, int galId)
        {
            return "/" + HttpContext.Current.Application["ImagePath"].ToString() + "/" + galId + "/" + GetThumbPath(filePath);
        }
        public static string GetPath(string filePath, int galId)
        {
            return "/" + HttpContext.Current.Application["ImagePath"].ToString() + "/" + galId + "/" + filePath;
        }

    }
}