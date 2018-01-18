namespace Travel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPhotoData : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PhotoGalleryHeader", "GalleryCommonName", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PhotoGalleryHeader", "GalleryCommonName", c => c.String());
        }
    }
}
