namespace Travel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class country_tagline : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CountryLocalizedDetail", "Тagline", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CountryLocalizedDetail", "Тagline");
        }
    }
}
