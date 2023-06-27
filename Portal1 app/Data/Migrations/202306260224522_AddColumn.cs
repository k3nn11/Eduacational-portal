﻿namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumn : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PersonalInformations", t => t.Id)
                .Index(t => t.Id);
            
            AddColumn("dbo.Courses", "User_Id", c => c.Int());
            AddColumn("dbo.Courses", "User_Id1", c => c.Int());
            AddColumn("dbo.Courses", "User_Id2", c => c.Int());
            CreateIndex("dbo.Courses", "User_Id");
            CreateIndex("dbo.Courses", "User_Id1");
            CreateIndex("dbo.Courses", "User_Id2");
            AddForeignKey("dbo.Courses", "User_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Courses", "User_Id1", "dbo.Users", "Id");
            AddForeignKey("dbo.Courses", "User_Id2", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Id", "dbo.PersonalInformations");
            DropForeignKey("dbo.Courses", "User_Id2", "dbo.Users");
            DropForeignKey("dbo.Courses", "User_Id1", "dbo.Users");
            DropForeignKey("dbo.Courses", "User_Id", "dbo.Users");
            DropIndex("dbo.Users", new[] { "Id" });
            DropIndex("dbo.Courses", new[] { "User_Id2" });
            DropIndex("dbo.Courses", new[] { "User_Id1" });
            DropIndex("dbo.Courses", new[] { "User_Id" });
            DropColumn("dbo.Courses", "User_Id2");
            DropColumn("dbo.Courses", "User_Id1");
            DropColumn("dbo.Courses", "User_Id");
            DropTable("dbo.Users");
        }
    }
}
