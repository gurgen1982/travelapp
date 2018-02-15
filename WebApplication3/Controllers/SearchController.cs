using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Travel.Models;

namespace Travel.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index(string q)
        {
            q = q.ToLower().Trim();
            ViewBag.Search = q;
            ViewBag.Empty = false;
            if (string.IsNullOrEmpty(q) || q.Length<3)
            {
                ViewBag.Empty = true;
                return View();
                //return RedirectToAction("index", "home");
            }
            var origin = "";
            do
            {
                origin = q;
                q = q.Replace("  ", " ");
            }
            while (origin != q);

            var words = q.Split(' ');
            for (var i = 0; i < words.Count(); i++)
            {
                words[i] = words[i].Trim();
            }

            var db = new DbEntity();
            var tours = db.TourDetails.ToList();
            var titles = tours.Where(x => x.Title.ContainsAnyOf(words));
            var descriptions = tours.Where(x => x.Description.ContainsAnyOf(words));

            var result = titles.Concat(descriptions);
            result = result.Distinct();

            foreach (var item in result)
            {
                    item.Title = item.Title.ReplaceAllSubStrings(words, "<span class='highlight'>{0}</span>");
                    item.Description = item.Description.ReplaceAllSubStrings(words, "<span class='highlight'>{0}</span>");
            }

            return View(result);
        }
    }

    public static class Ext
    {
        public static bool ContainsAnyOf(this string source, params string[] needles)
        {
            foreach (var needle in needles)
            {
                if (source.ToLower().Contains(needle)) return true;
            }
            return false;
        }

        public static string ReplaceAllSubStrings(this string str, string[] values, string replaceWithPatern)
        {
            if (values == null || values.Length == 0)
                throw new ArgumentException("the string to find may not be empty", "value");
            foreach (var val in values)
            {
                var diff = replaceWithPatern.Length - 3;
                var s = str.ToLower();
                var value = val.ToLower();
                var index = 0;
                //for (int index = 0; ; index += value.Length)
                while (true)
                {
                    index = s.IndexOf(value, index);
                    if (index != -1)
                    {
                        var foundString = str.Substring(index, value.Length);
                        var toReplaceWith = string.Format(replaceWithPatern, foundString);
                        str = str.Substring(0, index) + toReplaceWith + str.Substring(index + value.Length);
                        s = str.ToLower();
                        index += toReplaceWith.Length;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return str;
        }
    }
}