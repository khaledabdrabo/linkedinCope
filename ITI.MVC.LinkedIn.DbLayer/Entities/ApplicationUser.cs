using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ITI.MVC.LinkedIn.DbLayer.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<Award> Awards { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<UserCertification> UserCertifications { get; set; }
        public virtual ICollection<UserLanguage> UserLanguages { get; set; }
        public virtual ICollection<UserSkill> UserSkills { get; set; }
        public virtual ICollection<Experience> Experiences { get; set; }
        public virtual ICollection<Work> WorkExperiences { get; set; }
        public virtual ICollection<Volunteer> VolunteerExperiences { get; set; }
        public virtual ICollection<Education> EducationExperiences { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<TestScore> TestScores { get; set; }
        public virtual ICollection<Publication> Publications { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Reply> Replies { get; set; }
        public virtual ICollection<SharedPost> SharedPosts { get; set; }
        public virtual ICollection<PostLike> PostLikes { get; set; }
        public virtual ICollection<CommentLike> CommentLikes { get; set; }
        public virtual ICollection<ReplyLike> ReplyLikes { get; set; }
        public virtual ICollection<Connection> Connections { get; set; }
        public virtual ICollection<ConnectionRequest> ReceivedConnectionRequests { get; set; }
        public virtual ICollection<ConnectionRequest> SentConnectionRequests { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}