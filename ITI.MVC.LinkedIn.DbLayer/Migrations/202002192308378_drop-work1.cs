namespace ITI.MVC.LinkedIn.DbLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dropwork1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.WorkExperience", "CountryName", "dbo.Country");
            DropForeignKey("dbo.WorkExperience", "ExperienceId", "dbo.Experience");
            DropForeignKey("dbo.WorkExperience", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "WorkExperienceId", "dbo.WorkExperience");
            DropForeignKey("dbo.WorkExperience", "Organization_Id", "dbo.Organization");
            DropForeignKey("dbo.WorkExperience", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetUsers", new[] { "WorkExperienceId" });
            DropIndex("dbo.WorkExperience", new[] { "ExperienceId" });
            DropIndex("dbo.WorkExperience", new[] { "CountryName" });
            DropIndex("dbo.WorkExperience", new[] { "UserId" });
            DropIndex("dbo.WorkExperience", new[] { "Organization_Id" });
            DropIndex("dbo.WorkExperience", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.AspNetUsers", "WorkExperienceId");
            DropTable("dbo.WorkExperience");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.WorkExperience",
                c => new
                    {
                        ExperienceId = c.Int(nullable: false),
                        CountryName = c.String(maxLength: 50),
                        UserId = c.String(maxLength: 128),
                        Title = c.String(nullable: false, maxLength: 50),
                        EmploymentType = c.Int(),
                        Headline = c.String(nullable: false, maxLength: 50),
                        Organization_Id = c.Int(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ExperienceId);
            
            AddColumn("dbo.AspNetUsers", "WorkExperienceId", c => c.Int());
            CreateIndex("dbo.WorkExperience", "ApplicationUser_Id");
            CreateIndex("dbo.WorkExperience", "Organization_Id");
            CreateIndex("dbo.WorkExperience", "UserId");
            CreateIndex("dbo.WorkExperience", "CountryName");
            CreateIndex("dbo.WorkExperience", "ExperienceId");
            CreateIndex("dbo.AspNetUsers", "WorkExperienceId");
            AddForeignKey("dbo.WorkExperience", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.WorkExperience", "Organization_Id", "dbo.Organization", "Id");
            AddForeignKey("dbo.AspNetUsers", "WorkExperienceId", "dbo.WorkExperience", "ExperienceId");
            AddForeignKey("dbo.WorkExperience", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.WorkExperience", "ExperienceId", "dbo.Experience", "Id");
            AddForeignKey("dbo.WorkExperience", "CountryName", "dbo.Country", "Name");
        }
    }
}
