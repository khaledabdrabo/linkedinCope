namespace ITI.MVC.LinkedIn.DbLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixProjectDateTime2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Project", "StartDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Project", "EndDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Project", "EndDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Project", "StartDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
    }
}
