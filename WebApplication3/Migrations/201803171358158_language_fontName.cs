namespace Travel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class language_fontName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Language", "FontName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Language", "FontName");
        }
    }
}
