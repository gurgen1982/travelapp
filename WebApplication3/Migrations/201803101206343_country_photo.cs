namespace Travel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class country_photo : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.CountryHeader", "PhotoID");
            AddForeignKey("dbo.CountryHeader", "PhotoID", "dbo.Photo", "PhotoID", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CountryHeader", "PhotoID", "dbo.Photo");
            DropIndex("dbo.CountryHeader", new[] { "PhotoID" });
        }
    }
}
