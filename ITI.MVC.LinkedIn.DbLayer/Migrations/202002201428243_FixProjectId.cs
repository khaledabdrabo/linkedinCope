namespace ITI.MVC.LinkedIn.DbLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixProjectId : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Project");
            AddColumn("dbo.Project", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Project", new[] { "Name", "ExperienceId", "Id" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Project");
            DropColumn("dbo.Project", "Id");
            AddPrimaryKey("dbo.Project", new[] { "Name", "ExperienceId" });
        }
    }
}
