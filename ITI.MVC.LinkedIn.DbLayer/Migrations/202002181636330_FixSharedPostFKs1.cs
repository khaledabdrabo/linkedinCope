namespace ITI.MVC.LinkedIn.DbLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixSharedPostFKs1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SharedPost", "Post_TextId", "dbo.Post");
            DropIndex("dbo.SharedPost", new[] { "OriginalPostId" });
            DropIndex("dbo.SharedPost", new[] { "Post_TextId" });
            DropColumn("dbo.SharedPost", "OriginalPostId");
            RenameColumn(table: "dbo.SharedPost", name: "Post_TextId", newName: "OriginalPostId");
            AlterColumn("dbo.SharedPost", "OriginalPostId", c => c.Int(nullable: false));
            CreateIndex("dbo.SharedPost", "OriginalPostId");
            AddForeignKey("dbo.SharedPost", "OriginalPostId", "dbo.Post", "TextId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SharedPost", "OriginalPostId", "dbo.Post");
            DropIndex("dbo.SharedPost", new[] { "OriginalPostId" });
            AlterColumn("dbo.SharedPost", "OriginalPostId", c => c.Int());
            RenameColumn(table: "dbo.SharedPost", name: "OriginalPostId", newName: "Post_TextId");
            AddColumn("dbo.SharedPost", "OriginalPostId", c => c.Int(nullable: false));
            CreateIndex("dbo.SharedPost", "Post_TextId");
            CreateIndex("dbo.SharedPost", "OriginalPostId");
            AddForeignKey("dbo.SharedPost", "Post_TextId", "dbo.Post", "TextId");
        }
    }
}
