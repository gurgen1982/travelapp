namespace Travel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class news : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NewsLocalizedDetail",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NewsID = c.Int(nullable: false),
                        LangID = c.Short(nullable: false),
                        Title = c.String(nullable: false, maxLength: 500),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Language", t => t.LangID, cascadeDelete: true)
                .ForeignKey("dbo.NewsHeader", t => t.NewsID, cascadeDelete: true)
                .Index(t => t.NewsID)
                .Index(t => t.LangID);
            
            CreateTable(
                "dbo.NewsHeader",
                c => new
                    {
                        NewsID = c.Int(nullable: false, identity: true),
                        CommonName = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.NewsID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NewsLocalizedDetail", "NewsID", "dbo.NewsHeader");
            DropForeignKey("dbo.NewsLocalizedDetail", "LangID", "dbo.Language");
            DropIndex("dbo.NewsLocalizedDetail", new[] { "LangID" });
            DropIndex("dbo.NewsLocalizedDetail", new[] { "NewsID" });
            DropTable("dbo.NewsHeader");
            DropTable("dbo.NewsLocalizedDetail");
        }
    }
}
