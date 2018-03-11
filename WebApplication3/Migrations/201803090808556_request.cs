namespace Travel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class request : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Request",
                c => new
                    {
                        RequestID = c.Int(nullable: false, identity: true),
                        TourID = c.Int(),
                        Email = c.String(nullable: false),
                        OtherContacts = c.String(),
                        Name = c.String(nullable: false, maxLength: 100),
                        Title = c.String(nullable: false, maxLength: 100),
                        CountOfTourist = c.Int(nullable: false),
                        TourDate = c.DateTime(),
                        Message = c.String(maxLength: 1000),
                    })
                .PrimaryKey(t => t.RequestID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Request");
        }
    }
}
