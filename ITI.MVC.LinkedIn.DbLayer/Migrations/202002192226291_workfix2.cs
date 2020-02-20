namespace ITI.MVC.LinkedIn.DbLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class workfix2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.WorkExperience", "ApplicationUser_Id", "dbo.AspNetUsers");
            AddForeignKey("dbo.WorkExperience", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
        }
    }
}
