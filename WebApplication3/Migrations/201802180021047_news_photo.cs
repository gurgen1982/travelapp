namespace Travel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class news_photo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NewsHeader", "MainPhotoID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.NewsHeader", "MainPhotoID");
        }
    }
}
