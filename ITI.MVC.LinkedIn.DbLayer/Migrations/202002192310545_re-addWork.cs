namespace ITI.MVC.LinkedIn.DbLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class readdWork : DbMigration
    {
        public override void Up()
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
                    })
                .PrimaryKey(t => t.ExperienceId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.Country", t => t.CountryName)
                .ForeignKey("dbo.Experience", t => t.ExperienceId)
                .ForeignKey("dbo.Organization", t => t.Organization_Id)
                .Index(t => t.ExperienceId)
                .Index(t => t.CountryName)
                .Index(t => t.UserId)
                .Index(t => t.Organization_Id);
            
            AddColumn("dbo.AspNetUsers", "CurrentWorkExperienceId", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "CurrentWorkExperienceId");
            AddForeignKey("dbo.AspNetUsers", "CurrentWorkExperienceId", "dbo.WorkExperience", "ExperienceId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkExperience", "Organization_Id", "dbo.Organization");
            DropForeignKey("dbo.AspNetUsers", "CurrentWorkExperienceId", "dbo.WorkExperience");
            DropForeignKey("dbo.WorkExperience", "ExperienceId", "dbo.Experience");
            DropForeignKey("dbo.WorkExperience", "CountryName", "dbo.Country");
            DropForeignKey("dbo.WorkExperience", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.WorkExperience", new[] { "Organization_Id" });
            DropIndex("dbo.WorkExperience", new[] { "UserId" });
            DropIndex("dbo.WorkExperience", new[] { "CountryName" });
            DropIndex("dbo.WorkExperience", new[] { "ExperienceId" });
            DropIndex("dbo.AspNetUsers", new[] { "CurrentWorkExperienceId" });
            DropColumn("dbo.AspNetUsers", "CurrentWorkExperienceId");
            DropTable("dbo.WorkExperience");
        }
    }
}
