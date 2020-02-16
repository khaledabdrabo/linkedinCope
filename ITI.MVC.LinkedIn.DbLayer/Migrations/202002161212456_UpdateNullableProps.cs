namespace ITI.MVC.LinkedIn.DbLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateNullableProps : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "WorkExperienceId", "dbo.WorkExperience");
            DropIndex("dbo.AspNetUsers", new[] { "WorkExperienceId" });
            AlterColumn("dbo.Award", "IssueDate", c => c.DateTime());
            AlterColumn("dbo.Experience", "StartDate", c => c.DateTime());
            AlterColumn("dbo.Experience", "EndDate", c => c.DateTime());
            AlterColumn("dbo.AspNetUsers", "BirthDate", c => c.DateTime());
            AlterColumn("dbo.AspNetUsers", "WorkExperienceId", c => c.Int());
            AlterColumn("dbo.Connection", "StartDate", c => c.DateTime());
            AlterColumn("dbo.Patent", "Date", c => c.DateTime());
            AlterColumn("dbo.TestScore", "TestDate", c => c.DateTime());
            AlterColumn("dbo.UserCertification", "IssueDate", c => c.DateTime());
            AlterColumn("dbo.UserCertification", "ExpirationDate", c => c.DateTime());
            CreateIndex("dbo.AspNetUsers", "WorkExperienceId");
            AddForeignKey("dbo.AspNetUsers", "WorkExperienceId", "dbo.WorkExperience", "ExperienceId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "WorkExperienceId", "dbo.WorkExperience");
            DropIndex("dbo.AspNetUsers", new[] { "WorkExperienceId" });
            AlterColumn("dbo.UserCertification", "ExpirationDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.UserCertification", "IssueDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.TestScore", "TestDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Patent", "Date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Connection", "StartDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.AspNetUsers", "WorkExperienceId", c => c.Int(nullable: false));
            AlterColumn("dbo.AspNetUsers", "BirthDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Experience", "EndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Experience", "StartDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Award", "IssueDate", c => c.DateTime(nullable: false));
            CreateIndex("dbo.AspNetUsers", "WorkExperienceId");
            AddForeignKey("dbo.AspNetUsers", "WorkExperienceId", "dbo.WorkExperience", "ExperienceId", cascadeDelete: true);
        }
    }
}
