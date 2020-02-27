namespace ITI.MVC.LinkedIn.DbLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateWorkRelations : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.WorkExperience", "Organization_Id", "dbo.Organization");
            DropIndex("dbo.WorkExperience", new[] { "Organization_Id" });
            AlterColumn("dbo.WorkExperience", "Organization_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.WorkExperience", "Organization_Id");
            AddForeignKey("dbo.WorkExperience", "Organization_Id", "dbo.Organization", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkExperience", "Organization_Id", "dbo.Organization");
            DropIndex("dbo.WorkExperience", new[] { "Organization_Id" });
            AlterColumn("dbo.WorkExperience", "Organization_Id", c => c.Int());
            CreateIndex("dbo.WorkExperience", "Organization_Id");
            AddForeignKey("dbo.WorkExperience", "Organization_Id", "dbo.Organization", "Id");
        }
    }
}
