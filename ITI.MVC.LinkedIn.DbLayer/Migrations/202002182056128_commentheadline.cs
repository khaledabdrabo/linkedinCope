namespace ITI.MVC.LinkedIn.DbLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class commentheadline : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.WorkExperience", "Headline");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WorkExperience", "Headline", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
