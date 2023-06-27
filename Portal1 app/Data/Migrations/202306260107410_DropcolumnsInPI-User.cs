namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropcolumnsInPIUser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Users", "Information_Id", "dbo.PersonalInformations");
            DropForeignKey("dbo.Courses", "User_Id1", "dbo.Users");
            DropForeignKey("dbo.Courses", "User_Id2", "dbo.Users");
            DropForeignKey("dbo.Users", "PersonalInformation_Id", "dbo.PersonalInformations");
            DropForeignKey("dbo.PersonalInformations", "User_Id", "dbo.Users");
            DropIndex("dbo.Courses", new[] { "User_Id" });
            DropIndex("dbo.Courses", new[] { "User_Id1" });
            DropIndex("dbo.Courses", new[] { "User_Id2" });
            DropIndex("dbo.PersonalInformations", new[] { "User_Id" });
            DropIndex("dbo.Users", new[] { "Information_Id" });
            DropIndex("dbo.Users", new[] { "PersonalInformation_Id" });
            DropColumn("dbo.Courses", "User_Id");
            DropColumn("dbo.Courses", "User_Id1");
            DropColumn("dbo.Courses", "User_Id2");
            DropColumn("dbo.PersonalInformations", "User_Id");
            DropTable("dbo.Users");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Information_Id = c.Int(),
                        PersonalInformation_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.PersonalInformations", "User_Id", c => c.Int());
            AddColumn("dbo.Courses", "User_Id2", c => c.Int());
            AddColumn("dbo.Courses", "User_Id1", c => c.Int());
            AddColumn("dbo.Courses", "User_Id", c => c.Int());
            CreateIndex("dbo.Users", "PersonalInformation_Id");
            CreateIndex("dbo.Users", "Information_Id");
            CreateIndex("dbo.PersonalInformations", "User_Id");
            CreateIndex("dbo.Courses", "User_Id2");
            CreateIndex("dbo.Courses", "User_Id1");
            CreateIndex("dbo.Courses", "User_Id");
            AddForeignKey("dbo.PersonalInformations", "User_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Users", "PersonalInformation_Id", "dbo.PersonalInformations", "Id");
            AddForeignKey("dbo.Courses", "User_Id2", "dbo.Users", "Id");
            AddForeignKey("dbo.Courses", "User_Id1", "dbo.Users", "Id");
            AddForeignKey("dbo.Users", "Information_Id", "dbo.PersonalInformations", "Id");
            AddForeignKey("dbo.Courses", "User_Id", "dbo.Users", "Id");
        }
    }
}
