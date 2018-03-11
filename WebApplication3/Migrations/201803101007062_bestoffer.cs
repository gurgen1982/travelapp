namespace Travel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bestoffer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TourHeader", "BestOffer", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TourHeader", "BestOffer");
        }
    }
}
