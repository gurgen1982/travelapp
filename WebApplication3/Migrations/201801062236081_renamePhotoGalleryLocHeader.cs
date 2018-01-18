namespace Travel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class renamePhotoGalleryLocHeader : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.PhotoGalleryLocalaziedHeader", newName: "PhotoGalleryLocalizedHeader");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.PhotoGalleryLocalizedHeader", newName: "PhotoGalleryLocalaziedHeader");
        }
    }
}
