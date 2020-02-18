namespace ITI.MVC.LinkedIn.DbLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Award",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Issuer = c.String(),
                        ExperienceId = c.Int(),
                        IssueDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        Description = c.String(),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Experience", t => t.ExperienceId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.ExperienceId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Experience",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        OrganizationId = c.Int(nullable: false),
                        StartDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        EndDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        Description = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Organization", t => t.OrganizationId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.OrganizationId);
            
            CreateTable(
                "dbo.Education",
                c => new
                    {
                        ExperienceId = c.Int(nullable: false),
                        Degree = c.String(maxLength: 50),
                        FieldOfStudy = c.String(maxLength: 50),
                        UserId = c.String(maxLength: 128),
                        Grade = c.String(maxLength: 50),
                        Activities = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.ExperienceId)
                .ForeignKey("dbo.Experience", t => t.ExperienceId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.ExperienceId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Summary = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Headline = c.String(),
                        BirthDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        CountryName = c.String(maxLength: 50),
                        WorkExperienceId = c.Int(),
                        IndustryName = c.String(maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Country", t => t.CountryName)
                .ForeignKey("dbo.WorkExperience", t => t.WorkExperienceId)
                .ForeignKey("dbo.Industry", t => t.IndustryName)
                .Index(t => t.CountryName)
                .Index(t => t.WorkExperienceId)
                .Index(t => t.IndustryName)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.CommentLike",
                c => new
                    {
                        CommentId = c.Int(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.CommentId, t.UserId })
                .ForeignKey("dbo.Comment", t => t.CommentId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.CommentId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        TextId = c.Int(nullable: false),
                        PostId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.TextId)
                .ForeignKey("dbo.Post", t => t.PostId, cascadeDelete: true)
                .ForeignKey("dbo.Text", t => t.TextId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.TextId)
                .Index(t => t.PostId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Post",
                c => new
                    {
                        TextId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.TextId)
                .ForeignKey("dbo.Text", t => t.TextId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.TextId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.PostLike",
                c => new
                    {
                        PostId = c.Int(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.PostId, t.UserId })
                .ForeignKey("dbo.Post", t => t.PostId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.PostId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.SharedPost",
                c => new
                    {
                        PostId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                        OriginalPostId = c.Int(nullable: false),
                        Post_TextId = c.Int(),
                    })
                .PrimaryKey(t => t.PostId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.Post", t => t.PostId)
                .ForeignKey("dbo.Post", t => t.OriginalPostId, cascadeDelete: true)
                .ForeignKey("dbo.Post", t => t.Post_TextId)
                .Index(t => t.PostId)
                .Index(t => t.UserId)
                .Index(t => t.OriginalPostId)
                .Index(t => t.Post_TextId);
            
            CreateTable(
                "dbo.Text",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(nullable: false, maxLength: 255),
                        Time = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Image",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Url = c.String(),
                        TextId = c.Int(),
                        UserId = c.String(maxLength: 128),
                        ImageRole = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Text", t => t.TextId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.TextId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Reply",
                c => new
                    {
                        TextId = c.Int(nullable: false),
                        CommentId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.TextId)
                .ForeignKey("dbo.Comment", t => t.CommentId, cascadeDelete: true)
                .ForeignKey("dbo.Text", t => t.TextId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.TextId)
                .Index(t => t.CommentId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ReplyLike",
                c => new
                    {
                        ReplyId = c.Int(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.ReplyId, t.UserId })
                .ForeignKey("dbo.Reply", t => t.ReplyId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.ReplyId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ConnectionRequest",
                c => new
                    {
                        SenderId = c.String(nullable: false, maxLength: 128),
                        ReceiverId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.SenderId, t.ReceiverId })
                .ForeignKey("dbo.AspNetUsers", t => t.ReceiverId, cascadeDelete: false)
                .ForeignKey("dbo.AspNetUsers", t => t.SenderId, cascadeDelete: false)
                .Index(t => t.SenderId)
                .Index(t => t.ReceiverId);
            
            CreateTable(
                "dbo.Connection",
                c => new
                    {
                        SenderId = c.String(nullable: false, maxLength: 128),
                        ReceiverId = c.String(nullable: false, maxLength: 128),
                        StartDate = c.DateTime(precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => new { t.SenderId, t.ReceiverId })
                .ForeignKey("dbo.AspNetUsers", t => t.ReceiverId, cascadeDelete: false)
                .ForeignKey("dbo.AspNetUsers", t => t.SenderId, cascadeDelete: false)
                .Index(t => t.SenderId)
                .Index(t => t.ReceiverId);
            
            CreateTable(
                "dbo.Country",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Name);
            
            CreateTable(
                "dbo.Patent",
                c => new
                    {
                        Title = c.String(nullable: false, maxLength: 128),
                        Number = c.Int(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                        CountryName = c.String(nullable: false, maxLength: 50),
                        Inventor = c.String(),
                        Status = c.Int(nullable: false),
                        Date = c.DateTime(precision: 7, storeType: "datetime2"),
                        Url = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => new { t.Title, t.Number, t.UserId })
                .ForeignKey("dbo.Country", t => t.CountryName, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.CountryName);
            
            CreateTable(
                "dbo.WorkExperience",
                c => new
                    {
                        ExperienceId = c.Int(nullable: false),
                        CountryName = c.String(maxLength: 50),
                        UserId = c.String(maxLength: 128),
                        Title = c.String(nullable: false, maxLength: 50),
                        EmploymentType = c.Int(),
                        Headline = c.String(nullable: false, maxLength: 50),
                        Organization_Id = c.Int(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ExperienceId)
                .ForeignKey("dbo.Country", t => t.CountryName)
                .ForeignKey("dbo.Experience", t => t.ExperienceId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.Organization", t => t.Organization_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ExperienceId)
                .Index(t => t.CountryName)
                .Index(t => t.UserId)
                .Index(t => t.Organization_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        Number = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ExperienceId = c.Int(),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Number)
                .ForeignKey("dbo.Experience", t => t.ExperienceId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.ExperienceId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Industry",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Name);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Project",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 50),
                        ExperienceId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                        StartDate = c.Int(nullable: false),
                        EndDate = c.Int(nullable: false),
                        Creator = c.String(),
                        Url = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => new { t.Name, t.ExperienceId })
                .ForeignKey("dbo.Experience", t => t.ExperienceId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.ExperienceId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Publication",
                c => new
                    {
                        Title = c.String(nullable: false, maxLength: 50),
                        UserId = c.String(nullable: false, maxLength: 128),
                        Publisher = c.String(),
                        Date = c.Int(nullable: false),
                        Author = c.String(),
                        Url = c.String(),
                        Description = c.String(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.TestScore",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TestName = c.String(),
                        UserId = c.String(maxLength: 128),
                        ExperienceId = c.Int(),
                        Score = c.Int(nullable: false),
                        TestDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Experience", t => t.ExperienceId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.ExperienceId);
            
            CreateTable(
                "dbo.UserCertification",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        CertificationId = c.Int(nullable: false),
                        OrganizationId = c.Int(nullable: false),
                        IssueDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        ExpirationDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        CredentialId = c.String(maxLength: 250),
                        CredentialUrl = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => new { t.UserId, t.CertificationId })
                .ForeignKey("dbo.Certification", t => t.CertificationId, cascadeDelete: true)
                .ForeignKey("dbo.Organization", t => t.OrganizationId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.CertificationId)
                .Index(t => t.OrganizationId);
            
            CreateTable(
                "dbo.Certification",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Organization",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Logo = c.String(),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VolunteerExperience",
                c => new
                    {
                        ExperienceId = c.Int(nullable: false),
                        Role = c.String(maxLength: 50),
                        UserId = c.String(maxLength: 128),
                        VolunteeringCause = c.Int(),
                        Organization_Id = c.Int(),
                    })
                .PrimaryKey(t => t.ExperienceId)
                .ForeignKey("dbo.Experience", t => t.ExperienceId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.Organization", t => t.Organization_Id)
                .Index(t => t.ExperienceId)
                .Index(t => t.UserId)
                .Index(t => t.Organization_Id);
            
            CreateTable(
                "dbo.UserLanguage",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LanguageId = c.Int(nullable: false),
                        Proficiency = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.LanguageId })
                .ForeignKey("dbo.Language", t => t.LanguageId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.Language",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserSkill",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        SkillId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Skill", t => t.SkillId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.SkillId);
            
            CreateTable(
                "dbo.Skill",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Award", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Award", "ExperienceId", "dbo.Experience");
            DropForeignKey("dbo.Experience", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Experience", "OrganizationId", "dbo.Organization");
            DropForeignKey("dbo.Education", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.WorkExperience", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserSkill", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserSkill", "SkillId", "dbo.Skill");
            DropForeignKey("dbo.UserLanguage", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserLanguage", "LanguageId", "dbo.Language");
            DropForeignKey("dbo.UserCertification", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserCertification", "OrganizationId", "dbo.Organization");
            DropForeignKey("dbo.WorkExperience", "Organization_Id", "dbo.Organization");
            DropForeignKey("dbo.VolunteerExperience", "Organization_Id", "dbo.Organization");
            DropForeignKey("dbo.VolunteerExperience", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.VolunteerExperience", "ExperienceId", "dbo.Experience");
            DropForeignKey("dbo.UserCertification", "CertificationId", "dbo.Certification");
            DropForeignKey("dbo.TestScore", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.TestScore", "ExperienceId", "dbo.Experience");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Publication", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Project", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Project", "ExperienceId", "dbo.Experience");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "IndustryName", "dbo.Industry");
            DropForeignKey("dbo.AspNetUsers", "WorkExperienceId", "dbo.WorkExperience");
            DropForeignKey("dbo.Course", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Course", "ExperienceId", "dbo.Experience");
            DropForeignKey("dbo.AspNetUsers", "CountryName", "dbo.Country");
            DropForeignKey("dbo.WorkExperience", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.WorkExperience", "ExperienceId", "dbo.Experience");
            DropForeignKey("dbo.WorkExperience", "CountryName", "dbo.Country");
            DropForeignKey("dbo.Patent", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Patent", "CountryName", "dbo.Country");
            DropForeignKey("dbo.Connection", "SenderId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Connection", "ReceiverId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ConnectionRequest", "SenderId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ConnectionRequest", "ReceiverId", "dbo.AspNetUsers");
            DropForeignKey("dbo.CommentLike", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.CommentLike", "CommentId", "dbo.Comment");
            DropForeignKey("dbo.Comment", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comment", "TextId", "dbo.Text");
            DropForeignKey("dbo.Comment", "PostId", "dbo.Post");
            DropForeignKey("dbo.Post", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Post", "TextId", "dbo.Text");
            DropForeignKey("dbo.Text", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Reply", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Reply", "TextId", "dbo.Text");
            DropForeignKey("dbo.ReplyLike", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ReplyLike", "ReplyId", "dbo.Reply");
            DropForeignKey("dbo.Reply", "CommentId", "dbo.Comment");
            DropForeignKey("dbo.Image", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Image", "TextId", "dbo.Text");
            DropForeignKey("dbo.SharedPost", "Post_TextId", "dbo.Post");
            DropForeignKey("dbo.SharedPost", "OriginalPostId", "dbo.Post");
            DropForeignKey("dbo.SharedPost", "PostId", "dbo.Post");
            DropForeignKey("dbo.SharedPost", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.PostLike", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.PostLike", "PostId", "dbo.Post");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Education", "ExperienceId", "dbo.Experience");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.UserSkill", new[] { "SkillId" });
            DropIndex("dbo.UserSkill", new[] { "UserId" });
            DropIndex("dbo.UserLanguage", new[] { "LanguageId" });
            DropIndex("dbo.UserLanguage", new[] { "UserId" });
            DropIndex("dbo.VolunteerExperience", new[] { "Organization_Id" });
            DropIndex("dbo.VolunteerExperience", new[] { "UserId" });
            DropIndex("dbo.VolunteerExperience", new[] { "ExperienceId" });
            DropIndex("dbo.UserCertification", new[] { "OrganizationId" });
            DropIndex("dbo.UserCertification", new[] { "CertificationId" });
            DropIndex("dbo.UserCertification", new[] { "UserId" });
            DropIndex("dbo.TestScore", new[] { "ExperienceId" });
            DropIndex("dbo.TestScore", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.Publication", new[] { "User_Id" });
            DropIndex("dbo.Project", new[] { "UserId" });
            DropIndex("dbo.Project", new[] { "ExperienceId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.Course", new[] { "UserId" });
            DropIndex("dbo.Course", new[] { "ExperienceId" });
            DropIndex("dbo.WorkExperience", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.WorkExperience", new[] { "Organization_Id" });
            DropIndex("dbo.WorkExperience", new[] { "UserId" });
            DropIndex("dbo.WorkExperience", new[] { "CountryName" });
            DropIndex("dbo.WorkExperience", new[] { "ExperienceId" });
            DropIndex("dbo.Patent", new[] { "CountryName" });
            DropIndex("dbo.Patent", new[] { "UserId" });
            DropIndex("dbo.Connection", new[] { "ReceiverId" });
            DropIndex("dbo.Connection", new[] { "SenderId" });
            DropIndex("dbo.ConnectionRequest", new[] { "ReceiverId" });
            DropIndex("dbo.ConnectionRequest", new[] { "SenderId" });
            DropIndex("dbo.ReplyLike", new[] { "UserId" });
            DropIndex("dbo.ReplyLike", new[] { "ReplyId" });
            DropIndex("dbo.Reply", new[] { "UserId" });
            DropIndex("dbo.Reply", new[] { "CommentId" });
            DropIndex("dbo.Reply", new[] { "TextId" });
            DropIndex("dbo.Image", new[] { "UserId" });
            DropIndex("dbo.Image", new[] { "TextId" });
            DropIndex("dbo.Text", new[] { "UserId" });
            DropIndex("dbo.SharedPost", new[] { "Post_TextId" });
            DropIndex("dbo.SharedPost", new[] { "OriginalPostId" });
            DropIndex("dbo.SharedPost", new[] { "UserId" });
            DropIndex("dbo.SharedPost", new[] { "PostId" });
            DropIndex("dbo.PostLike", new[] { "UserId" });
            DropIndex("dbo.PostLike", new[] { "PostId" });
            DropIndex("dbo.Post", new[] { "UserId" });
            DropIndex("dbo.Post", new[] { "TextId" });
            DropIndex("dbo.Comment", new[] { "UserId" });
            DropIndex("dbo.Comment", new[] { "PostId" });
            DropIndex("dbo.Comment", new[] { "TextId" });
            DropIndex("dbo.CommentLike", new[] { "UserId" });
            DropIndex("dbo.CommentLike", new[] { "CommentId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUsers", new[] { "IndustryName" });
            DropIndex("dbo.AspNetUsers", new[] { "WorkExperienceId" });
            DropIndex("dbo.AspNetUsers", new[] { "CountryName" });
            DropIndex("dbo.Education", new[] { "UserId" });
            DropIndex("dbo.Education", new[] { "ExperienceId" });
            DropIndex("dbo.Experience", new[] { "OrganizationId" });
            DropIndex("dbo.Experience", new[] { "UserId" });
            DropIndex("dbo.Award", new[] { "UserId" });
            DropIndex("dbo.Award", new[] { "ExperienceId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Skill");
            DropTable("dbo.UserSkill");
            DropTable("dbo.Language");
            DropTable("dbo.UserLanguage");
            DropTable("dbo.VolunteerExperience");
            DropTable("dbo.Organization");
            DropTable("dbo.Certification");
            DropTable("dbo.UserCertification");
            DropTable("dbo.TestScore");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.Publication");
            DropTable("dbo.Project");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.Industry");
            DropTable("dbo.Course");
            DropTable("dbo.WorkExperience");
            DropTable("dbo.Patent");
            DropTable("dbo.Country");
            DropTable("dbo.Connection");
            DropTable("dbo.ConnectionRequest");
            DropTable("dbo.ReplyLike");
            DropTable("dbo.Reply");
            DropTable("dbo.Image");
            DropTable("dbo.Text");
            DropTable("dbo.SharedPost");
            DropTable("dbo.PostLike");
            DropTable("dbo.Post");
            DropTable("dbo.Comment");
            DropTable("dbo.CommentLike");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Education");
            DropTable("dbo.Experience");
            DropTable("dbo.Award");
        }
    }
}
