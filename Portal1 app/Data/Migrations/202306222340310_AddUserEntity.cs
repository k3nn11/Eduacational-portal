namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Information_Id = c.Int(),
                        PersonalInformation_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PersonalInformations", t => t.Information_Id)
                .ForeignKey("dbo.PersonalInformations", t => t.PersonalInformation_Id)
                .Index(t => t.Information_Id)
                .Index(t => t.PersonalInformation_Id);
            
            AddColumn("dbo.Courses", "User_Id", c => c.Int());
            AddColumn("dbo.Courses", "User_Id1", c => c.Int());
            AddColumn("dbo.Courses", "User_Id2", c => c.Int());
            AddColumn("dbo.PersonalInformations", "User_Id", c => c.Int());
            CreateIndex("dbo.Courses", "User_Id");
            CreateIndex("dbo.Courses", "User_Id1");
            CreateIndex("dbo.Courses", "User_Id2");
            CreateIndex("dbo.PersonalInformations", "User_Id");
            AddForeignKey("dbo.Courses", "User_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Courses", "User_Id1", "dbo.Users", "Id");
            AddForeignKey("dbo.Courses", "User_Id2", "dbo.Users", "Id");
            AddForeignKey("dbo.PersonalInformations", "User_Id", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PersonalInformations", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Users", "PersonalInformation_Id", "dbo.PersonalInformations");
            DropForeignKey("dbo.Courses", "User_Id2", "dbo.Users");
            DropForeignKey("dbo.Courses", "User_Id1", "dbo.Users");
            DropForeignKey("dbo.Users", "Information_Id", "dbo.PersonalInformations");
            DropForeignKey("dbo.Courses", "User_Id", "dbo.Users");
            DropIndex("dbo.Users", new[] { "PersonalInformation_Id" });
            DropIndex("dbo.Users", new[] { "Information_Id" });
            DropIndex("dbo.PersonalInformations", new[] { "User_Id" });
            DropIndex("dbo.Courses", new[] { "User_Id2" });
            DropIndex("dbo.Courses", new[] { "User_Id1" });
            DropIndex("dbo.Courses", new[] { "User_Id" });
            DropColumn("dbo.PersonalInformations", "User_Id");
            DropColumn("dbo.Courses", "User_Id2");
            DropColumn("dbo.Courses", "User_Id1");
            DropColumn("dbo.Courses", "User_Id");
            DropTable("dbo.Users");
        }
    }
}
