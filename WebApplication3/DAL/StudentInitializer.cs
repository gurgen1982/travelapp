using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Travel.Models;

namespace Travel.DAL
{
    public class StudentInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<DbEntity>
    {
        protected override void Seed(DbEntity context)
        {
            context.MainCarousels.Add(new MainCarousel { Title = "Armenia", SubTitle = "Find Armenia", Price = 450, ImageUrl = "~/Images/1.jpg", LinkUrl = "~/Armenia", Details = "Details Info", SubDetails = "Sub Details Info" });
            context.MainCarousels.Add(new MainCarousel { Title = "Spain", SubTitle = "Find Spain", Price = 550, ImageUrl = "~/Images/2.jpg", LinkUrl = "~/Spain", Details = "Details Info", SubDetails = "Sub Details Info" });
            context.MainCarousels.Add(new MainCarousel { Title = "Cyprus", SubTitle = "Find Cyprus", Price = 650, ImageUrl = "~/Images/3.jpg", LinkUrl = "~/Cyprus", Details = "Details Info", SubDetails = "Sub Details Info" });
            context.SaveChanges();
        }
    }
}