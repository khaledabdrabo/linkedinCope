namespace ITI.MVC.LinkedIn.DbLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ii : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Publication", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.SharedPost", "OriginalPostId", "dbo.Post");
            DropForeignKey("dbo.SharedPost", "PostId", "dbo.Post");
            DropIndex("dbo.SharedPost", new[] { "PostId" });
            DropIndex("dbo.SharedPost", new[] { "OriginalPostId" });
            DropIndex("dbo.Publication", new[] { "UserId" });
            DropPrimaryKey("dbo.SharedPost");
            DropPrimaryKey("dbo.Publication");
            AddColumn("dbo.SharedPost", "OriginalPost_TextId", c => c.Int());
            AddColumn("dbo.SharedPost", "Post_TextId", c => c.Int());
            AddColumn("dbo.SharedPost", "Post_TextId1", c => c.Int());
            AddColumn("dbo.WorkExperience", "Organization_Id", c => c.Int());
            AddColumn("dbo.Publication", "User_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.VolunteerExperience", "Organization_Id", c => c.Int());
            AlterColumn("dbo.SharedPost", "PostId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Publication", "Date", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AddPrimaryKey("dbo.SharedPost", "PostId");
            AddPrimaryKey("dbo.Publication", "UserId");
            CreateIndex("dbo.SharedPost", "OriginalPost_TextId");
            CreateIndex("dbo.SharedPost", "Post_TextId");
            CreateIndex("dbo.SharedPost", "Post_TextId1");
            CreateIndex("dbo.WorkExperience", "Organization_Id");
            CreateIndex("dbo.Publication", "User_Id");
            CreateIndex("dbo.VolunteerExperience", "Organization_Id");
            AddForeignKey("dbo.VolunteerExperience", "Organization_Id", "dbo.Organization", "Id");
            AddForeignKey("dbo.WorkExperience", "Organization_Id", "dbo.Organization", "Id");
            AddForeignKey("dbo.Publication", "User_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.SharedPost", "Post_TextId1", "dbo.Post", "TextId");
            AddForeignKey("dbo.SharedPost", "OriginalPost_TextId", "dbo.Post", "TextId");
            AddForeignKey("dbo.SharedPost", "Post_TextId", "dbo.Post", "TextId");
            DropColumn("dbo.AspNetUsers", "Headline");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Headline", c => c.String());
            DropForeignKey("dbo.SharedPost", "Post_TextId", "dbo.Post");
            DropForeignKey("dbo.SharedPost", "OriginalPost_TextId", "dbo.Post");
            DropForeignKey("dbo.SharedPost", "Post_TextId1", "dbo.Post");
            DropForeignKey("dbo.Publication", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.WorkExperience", "Organization_Id", "dbo.Organization");
            DropForeignKey("dbo.VolunteerExperience", "Organization_Id", "dbo.Organization");
            DropIndex("dbo.VolunteerExperience", new[] { "Organization_Id" });
            DropIndex("dbo.Publication", new[] { "User_Id" });
            DropIndex("dbo.WorkExperience", new[] { "Organization_Id" });
            DropIndex("dbo.SharedPost", new[] { "Post_TextId1" });
            DropIndex("dbo.SharedPost", new[] { "Post_TextId" });
            DropIndex("dbo.SharedPost", new[] { "OriginalPost_TextId" });
            DropPrimaryKey("dbo.Publication");
            DropPrimaryKey("dbo.SharedPost");
            AlterColumn("dbo.Publication", "Date", c => c.Int(nullable: false));
            AlterColumn("dbo.SharedPost", "PostId", c => c.Int(nullable: false));
            DropColumn("dbo.VolunteerExperience", "Organization_Id");
            DropColumn("dbo.Publication", "User_Id");
            DropColumn("dbo.WorkExperience", "Organization_Id");
            DropColumn("dbo.SharedPost", "Post_TextId1");
            DropColumn("dbo.SharedPost", "Post_TextId");
            DropColumn("dbo.SharedPost", "OriginalPost_TextId");
            AddPrimaryKey("dbo.Publication", new[] { "Title", "UserId" });
            AddPrimaryKey("dbo.SharedPost", "PostId");
            CreateIndex("dbo.Publication", "UserId");
            CreateIndex("dbo.SharedPost", "OriginalPostId");
            CreateIndex("dbo.SharedPost", "PostId");
            AddForeignKey("dbo.SharedPost", "PostId", "dbo.Post", "TextId");
            AddForeignKey("dbo.SharedPost", "OriginalPostId", "dbo.Post", "TextId", cascadeDelete: true);
            AddForeignKey("dbo.Publication", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
