namespace Travel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class country_desc : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CountryHeader", "PhotoID", c => c.Int(nullable: false));
            AddColumn("dbo.CountryLocalizedDetail", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CountryLocalizedDetail", "Description");
            DropColumn("dbo.CountryHeader", "PhotoID");
        }
    }
}
