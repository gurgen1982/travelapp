namespace Travel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TourTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CategoryLocalizedDetail",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CategoryID = c.Int(nullable: false),
                        LangID = c.Short(nullable: false),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CategoryHeader", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.Language", t => t.LangID, cascadeDelete: true)
                .Index(t => t.CategoryID)
                .Index(t => t.LangID);
            
            CreateTable(
                "dbo.CategoryHeader",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        ParentCategoryID = c.Int(nullable: false),
                        CategoryCommonName = c.String(),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.TourHeader",
                c => new
                    {
                        TourID = c.Int(nullable: false, identity: true),
                        CountryID = c.Int(nullable: false),
                        CategoryID = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.TourID)
                .ForeignKey("dbo.CategoryHeader", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.CountryHeader", t => t.CountryID, cascadeDelete: true)
                .Index(t => t.CountryID)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.TourLocalizedDetail",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TourID = c.Int(nullable: false),
                        LangID = c.Short(nullable: false),
                        Title = c.String(nullable: false, maxLength: 500),
                        SubTitle = c.String(maxLength: 500),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TourHeader", t => t.TourID, cascadeDelete: true)
                .ForeignKey("dbo.Language", t => t.LangID, cascadeDelete: true)
                .Index(t => t.TourID)
                .Index(t => t.LangID);
            
            CreateTable(
                "dbo.CountryLocalizedDetail",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CountryID = c.Int(nullable: false),
                        LangID = c.Short(nullable: false),
                        CountryName = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CountryHeader", t => t.CountryID, cascadeDelete: true)
                .ForeignKey("dbo.Language", t => t.LangID, cascadeDelete: true)
                .Index(t => t.CountryID)
                .Index(t => t.LangID);
            
            CreateTable(
                "dbo.CountryHeader",
                c => new
                    {
                        CountryID = c.Int(nullable: false, identity: true),
                        CountryCommonName = c.String(),
                    })
                .PrimaryKey(t => t.CountryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TourLocalizedDetail", "LangID", "dbo.Language");
            DropForeignKey("dbo.CountryLocalizedDetail", "LangID", "dbo.Language");
            DropForeignKey("dbo.CategoryLocalizedDetail", "LangID", "dbo.Language");
            DropForeignKey("dbo.TourHeader", "CountryID", "dbo.CountryHeader");
            DropForeignKey("dbo.CountryLocalizedDetail", "CountryID", "dbo.CountryHeader");
            DropForeignKey("dbo.TourHeader", "CategoryID", "dbo.CategoryHeader");
            DropForeignKey("dbo.TourLocalizedDetail", "TourID", "dbo.TourHeader");
            DropForeignKey("dbo.CategoryLocalizedDetail", "CategoryID", "dbo.CategoryHeader");
            DropIndex("dbo.CountryLocalizedDetail", new[] { "LangID" });
            DropIndex("dbo.CountryLocalizedDetail", new[] { "CountryID" });
            DropIndex("dbo.TourLocalizedDetail", new[] { "LangID" });
            DropIndex("dbo.TourLocalizedDetail", new[] { "TourID" });
            DropIndex("dbo.TourHeader", new[] { "CategoryID" });
            DropIndex("dbo.TourHeader", new[] { "CountryID" });
            DropIndex("dbo.CategoryLocalizedDetail", new[] { "LangID" });
            DropIndex("dbo.CategoryLocalizedDetail", new[] { "CategoryID" });
            DropTable("dbo.CountryHeader");
            DropTable("dbo.CountryLocalizedDetail");
            DropTable("dbo.TourLocalizedDetail");
            DropTable("dbo.TourHeader");
            DropTable("dbo.CategoryHeader");
            DropTable("dbo.CategoryLocalizedDetail");
        }
    }
}
