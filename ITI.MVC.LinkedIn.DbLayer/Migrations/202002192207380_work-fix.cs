namespace ITI.MVC.LinkedIn.DbLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class workfix : DbMigration
    {
        public override void Up()
        {
            DropColumn(table: "dbo.WorkExperience", name: "UserId");
            RenameColumn(table: "dbo.WorkExperience", name: "ApplicationUserId", newName: "UserId");
        }
        
        public override void Down()
        {
        }
    }
}
