namespace Travel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lang_cult : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Language", "LangCulture", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Language", "LangCulture");
        }
    }
}
