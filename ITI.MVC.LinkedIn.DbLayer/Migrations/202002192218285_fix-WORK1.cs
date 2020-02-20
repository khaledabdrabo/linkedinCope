namespace ITI.MVC.LinkedIn.DbLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixWORK1 : DbMigration
    {
        public override void Up()
        {
            DropColumn(table: "dbo.WorkExperience", name: "UserId");
            RenameColumn(table: "dbo.WorkExperience", name: "ApplicationUser_Id", newName: "UserId");
        }
        
        public override void Down()
        {
        }
    }
}
