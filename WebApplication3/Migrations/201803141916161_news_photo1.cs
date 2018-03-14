namespace Travel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class news_photo1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NewsHeader", "PhotoID", c => c.Int(nullable: false));
            CreateIndex("dbo.NewsHeader", "PhotoID");
            AddForeignKey("dbo.NewsHeader", "PhotoID", "dbo.Photo", "PhotoID", cascadeDelete: true);
            DropColumn("dbo.NewsHeader", "MainPhotoID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NewsHeader", "MainPhotoID", c => c.Int(nullable: false));
            DropForeignKey("dbo.NewsHeader", "PhotoID", "dbo.Photo");
            DropIndex("dbo.NewsHeader", new[] { "PhotoID" });
            DropColumn("dbo.NewsHeader", "PhotoID");
        }
    }
}
