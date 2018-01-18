namespace Travel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateVideos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Video",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Url = c.String(nullable: false),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Video");
        }
    }
}
