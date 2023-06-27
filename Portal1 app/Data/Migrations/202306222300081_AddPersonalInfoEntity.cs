namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPersonalInfoEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PersonalInformations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Skills", "PersonalInformation_Id", c => c.Int());
            CreateIndex("dbo.Skills", "PersonalInformation_Id");
            AddForeignKey("dbo.Skills", "PersonalInformation_Id", "dbo.PersonalInformations", "Id");
            DropColumn("dbo.Logins", "Title");
            DropColumn("dbo.Logins", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Logins", "Description", c => c.String());
            AddColumn("dbo.Logins", "Title", c => c.String());
            DropForeignKey("dbo.Skills", "PersonalInformation_Id", "dbo.PersonalInformations");
            DropIndex("dbo.Skills", new[] { "PersonalInformation_Id" });
            DropColumn("dbo.Skills", "PersonalInformation_Id");
            DropTable("dbo.PersonalInformations");
        }
    }
}
