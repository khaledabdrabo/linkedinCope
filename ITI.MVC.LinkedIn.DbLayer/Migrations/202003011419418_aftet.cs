namespace ITI.MVC.LinkedIn.DbLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aftet : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Publication", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Publication", "Date", c => c.Int(nullable: false));
        }
    }
}
