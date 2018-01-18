namespace Travel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnOrder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Video", "ShowInOrder", c => c.Short(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Video", "ShowInOrder");
        }
    }
}
