namespace Travel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateSubscription : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Subscription",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Subscription");
        }
    }
}
