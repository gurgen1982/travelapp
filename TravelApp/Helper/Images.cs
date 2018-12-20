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
            if (photo == null) return "";
            return GetThumbFullPath(photo.Path, photo.GalleryID);
        }
        public static string GetThumbFullPath(string filePath, int galId)
        {
            return "/" + HttpContext.Current.Application["ImagePath"].ToString() + "/" + galId + "/" + GetThumbPath(filePath);
        }
        public static string GetPath(Models.Photo photo)
        {
            return GetPath(photo.Path, photo.GalleryID);
        }
        public static string GetPath(string filePath, int galId)
        {
            return "/" + HttpContext.Current.Application["ImagePath"].ToString() + "/" + galId + "/" + filePath;
        }
        public static string GetStyle(Models.Photo photo, int width)
        {
            var w = photo.Width;
            var h = photo.Height;
            var leftMargin = 0;
            var topMargin = 0;
            var coef = w / width;
            if (w > h)
            {
                leftMargin = -((w - h) / 2) / coef;
                return $"margin-left: {leftMargin}px; height:{width}px; width:auto";
            }
            else
            {
                topMargin = -((h - w) / 2) / coef;
                return $"margin-top: {topMargin} px; width:{width}px; height:auto";
            }
        }
    }
}