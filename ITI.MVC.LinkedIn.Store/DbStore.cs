using ITI.MVC.LinkedIn.DbLayer;
using ITI.MVC.LinkedIn.DbManager;
using ITI.MVC.LinkedIn.Store.DbManagers;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.MVC.LinkedIn.Store
{
    public class DbStore : IDisposable
    {
        public DbContext DbContext { get; set; }
        public ApplicationUserManager ApplicationUserManager { get; set; }
        public ApplicationSignInManager ApplicationSignInManager { get; set; }
        public AwardManager AwardManager { get; set; }
        public CertificationManager CertificationManager { get; set; }
        public CommentLikeManager CommentLikeManager { get; set; }
        public CommentManager CommentManager { get; set; }
        public ConnectionManager ConnectionManager { get; set; }
        public ConnectionRequestManager ConnectionRequestManager { get; set; }
        public CountryManager CountryManager { get; set; }
        public CourseManager CourseManager { get; set; }
        public EducationManager EducationManager { get; set; }
        public ExperienceManager ExperienceManager { get; set; }
        public IndustryManager IndustryManager { get; set; }
        public LanguageManager LanguageManager { get; set; }
        public OrganizationManager OrganizationManager { get; set; }
        public PatentManager PatentManager { get; set; }
        public PostLikeManager PostLikeManager { get; set; }
        public PostManager PostManager { get; set; }
        public ProjectManager ProjectManager { get; set; }
        public PublicationManager PublicationManager { get; set; }
        public ReplyLikeManager ReplyLikeManager { get; set; }
        public ReplyManager ReplyManager { get; set; }
        public SharedPostManager SharedPostManager { get; set; }
        public SkillManager SkillManager { get; set; }
        public TestScoreManager TestScoreManager { get; set; }
        public UserCertificationManager UserCertificationManager { get; set; }
        public UserLanguageManager UserLanguageManager { get; set; }
        public UserSkillManager UserSkillManager { get; set; }
        public VolunteerManager VolunteerManager { get; set; }
        public WorkManager WorkManager { get; set; }

        public DbStore(IOwinContext owinContext)
        {
            DbContext = owinContext.Get<ApplicationDbContext>();
            ApplicationUserManager = owinContext.Get<ApplicationUserManager>();
            ApplicationSignInManager = owinContext.Get<ApplicationSignInManager>();
            AwardManager = new AwardManager(DbContext);
            CertificationManager = new CertificationManager(DbContext);
            CommentLikeManager = new CommentLikeManager(DbContext);
            CommentManager = new CommentManager(DbContext);
            ConnectionManager = new ConnectionManager(DbContext);
            ConnectionRequestManager = new ConnectionRequestManager(DbContext);
            CountryManager = new CountryManager(DbContext);
            CourseManager = new CourseManager(DbContext);
            EducationManager = new EducationManager(DbContext);
            ExperienceManager = new ExperienceManager(DbContext);
            IndustryManager = new IndustryManager(DbContext);
            LanguageManager = new LanguageManager(DbContext);
            OrganizationManager = new OrganizationManager(DbContext);
            PatentManager = new PatentManager(DbContext);
            PostLikeManager = new PostLikeManager(DbContext);
            PostManager = new PostManager(DbContext);
            ProjectManager = new ProjectManager(DbContext);
            PublicationManager = new PublicationManager(DbContext);
            ReplyLikeManager = new ReplyLikeManager(DbContext);
            ReplyManager = new ReplyManager(DbContext);
            SharedPostManager = new SharedPostManager(DbContext);
            SkillManager = new SkillManager(DbContext);
            TestScoreManager = new TestScoreManager(DbContext);
            UserCertificationManager = new UserCertificationManager(DbContext);
            UserLanguageManager = new UserLanguageManager(DbContext);
            UserSkillManager = new UserSkillManager(DbContext);
            VolunteerManager = new VolunteerManager(DbContext);
            WorkManager = new WorkManager(DbContext);
        }

        public static DbStore Create(IdentityFactoryOptions<DbStore> options, IOwinContext owinContext)
        {
            return new DbStore(owinContext);
        }

        public void Dispose()
        {
        }
    }
}
