namespace Travel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tours_1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TourHeader", "CommonName", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TourHeader", "CommonName");
        }
    }
}
