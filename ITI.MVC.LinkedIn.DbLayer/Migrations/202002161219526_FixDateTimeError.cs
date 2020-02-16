namespace ITI.MVC.LinkedIn.DbLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixDateTimeError : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Award", "IssueDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Experience", "StartDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Experience", "EndDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.AspNetUsers", "BirthDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Text", "Time", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Connection", "StartDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Patent", "Date", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.TestScore", "TestDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.UserCertification", "IssueDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.UserCertification", "ExpirationDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserCertification", "ExpirationDate", c => c.DateTime());
            AlterColumn("dbo.UserCertification", "IssueDate", c => c.DateTime());
            AlterColumn("dbo.TestScore", "TestDate", c => c.DateTime());
            AlterColumn("dbo.Patent", "Date", c => c.DateTime());
            AlterColumn("dbo.Connection", "StartDate", c => c.DateTime());
            AlterColumn("dbo.Text", "Time", c => c.DateTime(nullable: false));
            AlterColumn("dbo.AspNetUsers", "BirthDate", c => c.DateTime());
            AlterColumn("dbo.Experience", "EndDate", c => c.DateTime());
            AlterColumn("dbo.Experience", "StartDate", c => c.DateTime());
            AlterColumn("dbo.Award", "IssueDate", c => c.DateTime());
        }
    }
}
