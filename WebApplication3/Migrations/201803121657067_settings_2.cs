namespace Travel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class settings_2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Settings", "PhoneNumbers", c => c.String());
            AddColumn("dbo.Settings", "Email", c => c.String());
            AddColumn("dbo.Settings", "Address", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Settings", "Address");
            DropColumn("dbo.Settings", "Email");
            DropColumn("dbo.Settings", "PhoneNumbers");
        }
    }
}
