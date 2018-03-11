namespace Travel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nightCount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TourHeader", "NightCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TourHeader", "NightCount");
        }
    }
}
