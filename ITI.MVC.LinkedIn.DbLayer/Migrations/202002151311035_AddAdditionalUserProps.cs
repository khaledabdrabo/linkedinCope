namespace ITI.MVC.LinkedIn.DbLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAdditionalUserProps : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.WorkExperience", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.WorkExperience", "CountryId", "dbo.Country");
            DropForeignKey("dbo.Patent", "CountryId", "dbo.Country");
            DropIndex("dbo.WorkExperience", new[] { "CountryId" });
            DropIndex("dbo.Patent", new[] { "CountryId" });
            RenameColumn(table: "dbo.WorkExperience", name: "CountryId", newName: "CountryName");
            RenameColumn(table: "dbo.Patent", name: "CountryId", newName: "CountryName");
            DropPrimaryKey("dbo.Country");
            CreateTable(
                "dbo.Industry",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Name);
            
            AddColumn("dbo.AspNetUsers", "Summary", c => c.String());
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "BirthDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "CountryName", c => c.String(maxLength: 50));
            AddColumn("dbo.AspNetUsers", "WorkExperienceId", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "IndustryName", c => c.String(maxLength: 128));
            AddColumn("dbo.WorkExperience", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.WorkExperience", "CountryName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Patent", "CountryName", c => c.String(nullable: false, maxLength: 50));
            AddPrimaryKey("dbo.Country", "Name");
            CreateIndex("dbo.AspNetUsers", "CountryName");
            CreateIndex("dbo.AspNetUsers", "WorkExperienceId");
            CreateIndex("dbo.AspNetUsers", "IndustryName");
            CreateIndex("dbo.Patent", "CountryName");
            CreateIndex("dbo.WorkExperience", "CountryName");
            CreateIndex("dbo.WorkExperience", "ApplicationUser_Id");
            AddForeignKey("dbo.AspNetUsers", "CountryName", "dbo.Country", "Name");
            AddForeignKey("dbo.AspNetUsers", "WorkExperienceId", "dbo.WorkExperience", "ExperienceId", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUsers", "IndustryName", "dbo.Industry", "Name");
            AddForeignKey("dbo.WorkExperience", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Patent", "CountryName", "dbo.Country", "Name", cascadeDelete: true);
            AddForeignKey("dbo.WorkExperience", "CountryName", "dbo.Country", "Name");
            DropColumn("dbo.Country", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Country", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.WorkExperience", "CountryName", "dbo.Country");
            DropForeignKey("dbo.Patent", "CountryName", "dbo.Country");
            DropForeignKey("dbo.WorkExperience", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "IndustryName", "dbo.Industry");
            DropForeignKey("dbo.AspNetUsers", "WorkExperienceId", "dbo.WorkExperience");
            DropForeignKey("dbo.AspNetUsers", "CountryName", "dbo.Country");
            DropIndex("dbo.WorkExperience", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.WorkExperience", new[] { "CountryName" });
            DropIndex("dbo.Patent", new[] { "CountryName" });
            DropIndex("dbo.AspNetUsers", new[] { "IndustryName" });
            DropIndex("dbo.AspNetUsers", new[] { "WorkExperienceId" });
            DropIndex("dbo.AspNetUsers", new[] { "CountryName" });
            DropPrimaryKey("dbo.Country");
            AlterColumn("dbo.Patent", "CountryName", c => c.Int(nullable: false));
            AlterColumn("dbo.WorkExperience", "CountryName", c => c.Int());
            DropColumn("dbo.WorkExperience", "ApplicationUser_Id");
            DropColumn("dbo.AspNetUsers", "IndustryName");
            DropColumn("dbo.AspNetUsers", "WorkExperienceId");
            DropColumn("dbo.AspNetUsers", "CountryName");
            DropColumn("dbo.AspNetUsers", "BirthDate");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropColumn("dbo.AspNetUsers", "Summary");
            DropTable("dbo.Industry");
            AddPrimaryKey("dbo.Country", "Id");
            RenameColumn(table: "dbo.Patent", name: "CountryName", newName: "CountryId");
            RenameColumn(table: "dbo.WorkExperience", name: "CountryName", newName: "CountryId");
            CreateIndex("dbo.Patent", "CountryId");
            CreateIndex("dbo.WorkExperience", "CountryId");
            AddForeignKey("dbo.Patent", "CountryId", "dbo.Country", "Id", cascadeDelete: true);
            AddForeignKey("dbo.WorkExperience", "CountryId", "dbo.Country", "Id");
            AddForeignKey("dbo.WorkExperience", "UserId", "dbo.AspNetUsers", "Id");
        }
    }
}
