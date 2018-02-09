namespace Travel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class photo1 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.TourPhoto", "PhotoID");
            AddForeignKey("dbo.TourPhoto", "PhotoID", "dbo.Photo", "PhotoID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TourPhoto", "PhotoID", "dbo.Photo");
            DropIndex("dbo.TourPhoto", new[] { "PhotoID" });
        }
    }
}
