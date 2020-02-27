namespace ITI.MVC.LinkedIn.DbLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addworkDescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WorkExperience", "description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.WorkExperience", "description");
        }
    }
}
