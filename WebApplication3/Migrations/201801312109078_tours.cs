namespace Travel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tours : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TourPhoto",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PhotoID = c.Int(nullable: false),
                        ShowAsMain = c.Boolean(nullable: false),
                        TourHeader_TourID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TourHeader", t => t.TourHeader_TourID)
                .Index(t => t.TourHeader_TourID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TourPhoto", "TourHeader_TourID", "dbo.TourHeader");
            DropIndex("dbo.TourPhoto", new[] { "TourHeader_TourID" });
            DropTable("dbo.TourPhoto");
        }
    }
}
