namespace Travel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLanguageData : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Language",
                c => new
                    {
                        LangID = c.Short(nullable: false, identity: true),
                        Name = c.String(),
                        Locale = c.String(),
                    })
                .PrimaryKey(t => t.LangID);
            
            AddColumn("dbo.MainCarousel", "Disabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.MainCarousel", "LangID", c => c.Short(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MainCarousel", "LangID");
            DropColumn("dbo.MainCarousel", "Disabled");
            DropTable("dbo.Language");
        }
    }
}
