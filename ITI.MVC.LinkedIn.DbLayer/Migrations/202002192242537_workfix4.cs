namespace ITI.MVC.LinkedIn.DbLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class workfix4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.WorkExperience", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.WorkExperience", new[] { "UserId" });
            DropColumn("dbo.WorkExperience", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WorkExperience", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.WorkExperience", "UserId");
            AddForeignKey("dbo.WorkExperience", "UserId", "dbo.AspNetUsers", "Id");
        }
    }
}
