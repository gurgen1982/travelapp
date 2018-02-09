namespace Travel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tours_forKey_1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CategoryHeader", "CommonName", c => c.String());
            AddColumn("dbo.CountryHeader", "CommonName", c => c.String());
            DropColumn("dbo.CategoryHeader", "CategoryCommonName");
            DropColumn("dbo.CountryHeader", "CountryCommonName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CountryHeader", "CountryCommonName", c => c.String());
            AddColumn("dbo.CategoryHeader", "CategoryCommonName", c => c.String());
            DropColumn("dbo.CountryHeader", "CommonName");
            DropColumn("dbo.CategoryHeader", "CommonName");
        }
    }
}
