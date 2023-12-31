﻿namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingCompletion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "CompletionPercentage", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "CompletionPercentage");
        }
    }
}
