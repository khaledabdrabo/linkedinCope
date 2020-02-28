namespace ITI.MVC.LinkedIn.DbLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reset : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Education", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Education", "Description", c => c.String());
        }
    }
}
