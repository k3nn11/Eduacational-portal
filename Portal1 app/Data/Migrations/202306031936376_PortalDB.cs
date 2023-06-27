namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PortalDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateOfPublication = c.DateTime(nullable: false),
                        Resource = c.String(),
                        Course_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.Course_Id)
                .Index(t => t.Course_Id);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NumberOfPages = c.Int(nullable: false),
                        Format = c.String(),
                        YearOfPublication = c.DateTime(nullable: false),
                        Course_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.Course_Id)
                .Index(t => t.Course_Id);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Level = c.Int(nullable: false),
                        Course_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.Course_Id)
                .Index(t => t.Course_Id);
            
            CreateTable(
                "dbo.Videos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Duration = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quality = c.String(),
                        Course_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.Course_Id)
                .Index(t => t.Course_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Videos", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.Skills", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.Books", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.Articles", "Course_Id", "dbo.Courses");
            DropIndex("dbo.Videos", new[] { "Course_Id" });
            DropIndex("dbo.Skills", new[] { "Course_Id" });
            DropIndex("dbo.Books", new[] { "Course_Id" });
            DropIndex("dbo.Articles", new[] { "Course_Id" });
            DropTable("dbo.Videos");
            DropTable("dbo.Skills");
            DropTable("dbo.Courses");
            DropTable("dbo.Books");
            DropTable("dbo.Articles");
        }
    }
}
