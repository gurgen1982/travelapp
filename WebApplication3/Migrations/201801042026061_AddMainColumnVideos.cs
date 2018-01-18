namespace Travel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMainColumnVideos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Video", "ShowAsMain", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Video", "ShowAsMain");
        }
    }
}
