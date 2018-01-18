namespace Travel.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Travel.Models.DbEntity>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DbEntity context)
        {
            context.MainCarousels.AddOrUpdate(new MainCarousel { Title = "Armenia", SubTitle = "Find Armenia", Price = 450, ImageUrl = "/Images/1.jpg", LinkUrl = "/Armenia", Details = "Details Info", SubDetails = "Sub Details Info" });
            context.MainCarousels.AddOrUpdate(new MainCarousel { Title = "Spain", SubTitle = "Find Spain", Price = 550, ImageUrl = "/Images/2.jpg", LinkUrl = "/Spain", Details = "Details Info", SubDetails = "Sub Details Info" });
            context.MainCarousels.AddOrUpdate(new MainCarousel { Title = "Cyprus", SubTitle = "Find Cyprus", Price = 650, ImageUrl = "/Images/3.jpg", LinkUrl = "/Cyprus", Details = "Details Info", SubDetails = "Sub Details Info" });

            context.Languages.AddOrUpdate(new Language { LangID = 1, Name = "Arm", Locale = "hy" });
            context.Languages.AddOrUpdate(new Language { LangID = 2, Name = "Eng", Locale = "en" });

            context.CountryHeaders.AddOrUpdate(new CountryHeader { CountryID = 1, CountryCommonName = "Armenia" });
            context.CountryHeaders.AddOrUpdate(new CountryHeader { CountryID = 2, CountryCommonName = "Spain" });
            context.CountryHeaders.AddOrUpdate(new CountryHeader { CountryID = 3, CountryCommonName = "Cyprus" });

            context.CountryDetails.AddOrUpdate(new CountryLocalizedDetail { CountryID = 1, LangID = 1, CountryName = "Հայաստան" });
            context.CountryDetails.AddOrUpdate(new CountryLocalizedDetail { CountryID = 1, LangID = 2, CountryName = "Armenia" });

            context.CountryDetails.AddOrUpdate(new CountryLocalizedDetail { CountryID = 2, LangID = 1, CountryName = "Իսպանիա" });
            context.CountryDetails.AddOrUpdate(new CountryLocalizedDetail { CountryID = 2, LangID = 2, CountryName = "Spain" });

            context.CountryDetails.AddOrUpdate(new CountryLocalizedDetail { CountryID = 3, LangID = 1, CountryName = "Կիպրոս" });
            context.CountryDetails.AddOrUpdate(new CountryLocalizedDetail { CountryID = 3, LangID = 2, CountryName = "Cyprus" });

            context.CategoryHeaders.AddOrUpdate(new CategoryHeader{ CategoryID= 1,  ParentCategoryID=0,  CategoryCommonName= "Extreme" });
            context.CategoryHeaders.AddOrUpdate(new CategoryHeader { CategoryID = 2, ParentCategoryID = 0, CategoryCommonName = "Hiking" });

            context.CategoryDetails.AddOrUpdate(new CategoryLocalizedDetail{ LangID=1, CategoryID = 1, CategoryName= "Էքստրիմ" });
            context.CategoryDetails.AddOrUpdate(new CategoryLocalizedDetail { LangID = 2, CategoryID = 1, CategoryName = "Extreme" });

            context.CategoryDetails.AddOrUpdate(new CategoryLocalizedDetail { LangID = 1, CategoryID = 1, CategoryName = "Ժայռամագլցում" });
            context.CategoryDetails.AddOrUpdate(new CategoryLocalizedDetail { LangID = 2, CategoryID = 1, CategoryName = "Hiking" });

            context.SaveChanges();
        }
    }
}