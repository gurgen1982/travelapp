namespace Travel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tours_forKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TourPhoto", "TourHeader_TourID", "dbo.TourHeader");
            DropIndex("dbo.TourPhoto", new[] { "TourHeader_TourID" });
            RenameColumn(table: "dbo.TourPhoto", name: "TourHeader_TourID", newName: "TourID");
            AlterColumn("dbo.TourPhoto", "TourID", c => c.Int(nullable: false));
            CreateIndex("dbo.TourPhoto", "TourID");
            AddForeignKey("dbo.TourPhoto", "TourID", "dbo.TourHeader", "TourID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TourPhoto", "TourID", "dbo.TourHeader");
            DropIndex("dbo.TourPhoto", new[] { "TourID" });
            AlterColumn("dbo.TourPhoto", "TourID", c => c.Int());
            RenameColumn(table: "dbo.TourPhoto", name: "TourID", newName: "TourHeader_TourID");
            CreateIndex("dbo.TourPhoto", "TourHeader_TourID");
            AddForeignKey("dbo.TourPhoto", "TourHeader_TourID", "dbo.TourHeader", "TourID");
        }
    }
}
