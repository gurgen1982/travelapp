namespace Travel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class show_country : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CountryHeader", "ShowInHomePage", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CountryHeader", "ShowInHomePage");
        }
    }
}
