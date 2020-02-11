namespace ITI.MVC.LinkedIn.DbLayer
{
    using ITI.MVC.LinkedIn.DbLayer.Entities;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ModelContext : DbContext
    {
        public ModelContext()
            : base("name=ModelContext")
        {
        }

        public virtual DbSet<ApplicationUser> Users { get; set; }
        public virtual DbSet<Certification> Certifications { get; set; }
        public virtual DbSet<UserCertification> UserCertifications { get; set; }
        public virtual DbSet<CommentLike> CommentLikes { get; set; }
        public virtual DbSet<Connection> Connections { get; set; }
        public virtual DbSet<ConnectionRequest> ConnectionRequests { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Experience> Experiences { get; set; }
        public virtual DbSet<Education> EducationExperiences { get; set; }
        public virtual DbSet<Volunteer> VolunteerExperiences { get; set; }
        public virtual DbSet<Work> WorkExperiences { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<UserLanguage> UserLanguages { get; set; }
        public virtual DbSet<Organization> Organizations { get; set; }
        public virtual DbSet<PostLike> PostLikes { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Publication> Publications { get; set; }
        public virtual DbSet<Reply> Replies { get; set; }
        public virtual DbSet<ReplyLike> ReplyLikes { get; set; }
        public virtual DbSet<SharedPost> SharedPosts { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<UserSkill> UserSkills { get; set; }
        public virtual DbSet<Patent> Patents { get; set; }
        public virtual DbSet<Award> Awards { get; set; }
        public virtual DbSet<TestScore> TestScores { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
    }
}