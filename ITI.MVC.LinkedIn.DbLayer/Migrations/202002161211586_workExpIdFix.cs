namespace ITI.MVC.LinkedIn.DbLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class workExpIdFix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "WorkExperienceId", "dbo.WorkExperience");
            DropIndex("dbo.AspNetUsers", new[] { "WorkExperienceId" });
            AlterColumn("dbo.AspNetUsers", "WorkExperienceId", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "WorkExperienceId");
            AddForeignKey("dbo.AspNetUsers", "WorkExperienceId", "dbo.WorkExperience", "ExperienceId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "WorkExperienceId", "dbo.WorkExperience");
            DropIndex("dbo.AspNetUsers", new[] { "WorkExperienceId" });
            AlterColumn("dbo.AspNetUsers", "WorkExperienceId", c => c.Int(nullable: false));
            CreateIndex("dbo.AspNetUsers", "WorkExperienceId");
            AddForeignKey("dbo.AspNetUsers", "WorkExperienceId", "dbo.WorkExperience", "ExperienceId", cascadeDelete: true);
        }
    }
}
