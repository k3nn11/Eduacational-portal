namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingColumns : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Articles", "Title", c => c.String(nullable: false));
            AddColumn("dbo.Articles", "Description", c => c.String());
            AddColumn("dbo.Books", "Title", c => c.String(nullable: false));
            AddColumn("dbo.Books", "Description", c => c.String());
            AddColumn("dbo.Skills", "Title", c => c.String(nullable: false));
            AddColumn("dbo.Skills", "Description", c => c.String());
            AddColumn("dbo.Videos", "Title", c => c.String(nullable: false));
            AddColumn("dbo.Videos", "Description", c => c.String());
            AddColumn("dbo.Logins", "Title", c => c.String(nullable: false));
            AddColumn("dbo.Logins", "Description", c => c.String());
            AlterColumn("dbo.Courses", "Title", c => c.String(nullable: false));
            DropColumn("dbo.Skills", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Skills", "Name", c => c.String());
            AlterColumn("dbo.Courses", "Title", c => c.String());
            DropColumn("dbo.Logins", "Description");
            DropColumn("dbo.Logins", "Title");
            DropColumn("dbo.Videos", "Description");
            DropColumn("dbo.Videos", "Title");
            DropColumn("dbo.Skills", "Description");
            DropColumn("dbo.Skills", "Title");
            DropColumn("dbo.Books", "Description");
            DropColumn("dbo.Books", "Title");
            DropColumn("dbo.Articles", "Description");
            DropColumn("dbo.Articles", "Title");
        }
    }
}
