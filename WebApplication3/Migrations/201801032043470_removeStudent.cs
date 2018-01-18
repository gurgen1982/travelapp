namespace Travel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeStudent : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Student");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        BirthDay = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.StudentId);
            
        }
    }
}
