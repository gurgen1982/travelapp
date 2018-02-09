namespace Travel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lang_1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Language", "CommonName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Language", "CommonName");
        }
    }
}
