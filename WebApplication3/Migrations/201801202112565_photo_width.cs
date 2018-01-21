namespace Travel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class photo_width : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Photo", "Width", c => c.Int(nullable: false));
            AddColumn("dbo.Photo", "Height", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Photo", "Height");
            DropColumn("dbo.Photo", "Width");
        }
    }
}
