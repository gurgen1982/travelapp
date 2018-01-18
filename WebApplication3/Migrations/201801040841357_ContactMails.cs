namespace Travel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContactMails : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SendContactMail",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        EMail = c.String(nullable: false),
                        Message = c.String(nullable: false, maxLength: 1000),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SendContactMail");
        }
    }
}
