using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Travel.Models
{
    public class DbEntity : DbContext
    {
        public DbEntity() : base("dbConnectionString")
        {
        }

        public DbSet<MainCarousel> MainCarousels { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<ContactMail> ContactMails { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Video> VideoGallery { get; set; }
        public DbSet<CategoryHeader> CategoryHeaders { get; set; }
        public DbSet<CategoryLocalizedDetail> CategoryDetails { get; set; }
        public DbSet<CountryHeader> CountryHeaders { get; set; }
        public DbSet<CountryLocalizedDetail> CountryDetails { get; set; }
        public DbSet<TourHeader> TourHeaders { get; set; }
        public DbSet<TourLocalizedDetail> TourDetails { get; set; }
        public DbSet<TourPhoto> TourPhotos { get; set; }
        public DbSet<PhotoGalleryHeader> PhotoGalleryHeaders { get; set; }
        public DbSet<PhotoGalleryLocalizedHeader> PhotoGalleryLocalizedHeaders { get; set; }
        public DbSet<Photo> Photos { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //base.OnModelCreating(modelBuilder);
        }
    }
}