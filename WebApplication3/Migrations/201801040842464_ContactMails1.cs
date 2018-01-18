namespace Travel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContactMails1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.SendContactMail", newName: "ContactMail");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.ContactMail", newName: "SendContactMail");
        }
    }
}
