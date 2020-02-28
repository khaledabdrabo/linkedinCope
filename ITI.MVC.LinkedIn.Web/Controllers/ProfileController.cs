using ITI.MVC.LinkedIn.DbLayer.Entities;
using ITI.MVC.LinkedIn.Store;
using ITI.MVC.LinkedIn.Store.DbManagers;
using Microsoft.AspNet.Identity.Owin;
using ITI.MVC.LinkedIn.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using ITI.MVC.LinkedIn.DbLayer.Enums;
using System.ComponentModel.DataAnnotations;
using ITI.MVC.LinkedIn.Web.Models.Enums;
using System.Web.Services;
using System.Threading.Tasks;
namespace ITI.MVC.LinkedIn.Web.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private DbStore store;

        public DbStore Store
        {
            get { return store ?? HttpContext.GetOwinContext().Get<DbStore>(); }

            set { store = value; }
        }
        // GET: Profile
        [WebMethod]
        public ActionResult UserProfile(string userId)
        {
            string id = userId;
            if (userId == null)
            {
                id = User.Identity.GetUserId();
            }
            var user = Store.ApplicationUserManager.FindById(User.Identity.GetUserId());
            ViewBag.getAllEperinec = Store.WorkManager.GetAll().Include(e => e.Organization).Include(e => e.Experience).Where(ex => ex.UserId == id).ToList();
            if (user.Images.ToList()[0] != null)
            {
                ViewBag.imag = user.Images.ToList()[0].Url.Replace("C:\\Users\\khaled abdrabo\\Desktop\\LatestVersion\\newversion\\iti-mvc-linkedin\\ITI.MVC.LinkedIn.Web\\Images\\", "") : null;

            }
            ViewBag.name = user.FirstName + user.LastName;
            ViewBag.country = user.CountryName;
            ViewBag.connection = Store.ConnectionManager.GetAllBind().Where(c => c.SenderId == id || c.ReceiverId == id).Count();

            ViewBag.getAllEDucation = Store.EducationManager.GetAll().Include(e => e.Experience).Where(ex => ex.UserId == id).ToList();
            ViewBag.getAllCertificates = Store.UserCertificationManager.GetAll().Include(e => e.Certification).Where(c => c.UserId == id).ToList();
            ViewBag.getAllVolunteers = Store.VolunteerManager.GetAll().Include(v => v.Experience).Where(v => v.UserId == id).ToList();

            ExperienceManager experienceManager = Store.ExperienceManager;
            CourseManager courseManager = Store.CourseManager;
            ProjectManager projectManager = Store.ProjectManager;
            UserLanguageManager userLanguageManager = Store.UserLanguageManager;
            AwardManager awardManager = Store.AwardManager;
            TestScoreManager testScoreManager = Store.TestScoreManager;

            List<Experience> experiences = experienceManager.GetAllBindByUserID(User.Identity.GetUserId());
            List<Course> courses = courseManager.GetAllBindByUserID(User.Identity.GetUserId());
            List<Project> projects = projectManager.GetAllBindByUserID(User.Identity.GetUserId());
            List<UserLanguage> userLanguages = userLanguageManager.GetAllBindByUserID(User.Identity.GetUserId());
            List<Award> awards = awardManager.GetAllBindByUserID(User.Identity.GetUserId());
            List<TestScore> testScores = testScoreManager.GetAllBindByUserID(User.Identity.GetUserId());

            ProfileVM profileVM = new ProfileVM
            {
                Experiences = experiences != null ? experiences : null,
                courses = courses != null ? courses : null,
                 UserLanguages = userLanguages != null ? userLanguages : null,
                 TestScores = testScores != null ? testScores : null,
                 Awards = awards != null ? awards : null,
                  projects = projects != null ? projects : null


            };
            return View(profileVM);
        }

        [HttpGet]
        public ActionResult AddCourse()
        {
            ViewBag.actionName = "AddCourse";
            CourseManager courseManager = Store.CourseManager;
            ExperienceManager experienceManager = Store.ExperienceManager;
            List<Experience> experiences = experienceManager.GetAllBindByUserID(User.Identity.GetUserId());
            int? count = courseManager.GetAllBindByUserID(User.Identity.GetUserId()).Count;
            CoursesVM model = new CoursesVM
            {
                Experiences = experiences,
                CoursesCount = count
            };
            return PartialView("_CoursesModal", model);
        }
        [HttpPost]
        public ActionResult AddCourse(CoursesVM model)
        {
            ViewBag.actionName = "AddCourse";
            if (ModelState.IsValid)
            {
                CourseManager courseManager = Store.CourseManager;
                Course course = new Course { ExperienceId = model.ExperinceId, Name = model.Name, Number = model.Number, UserId = User.Identity.GetUserId() };

                courseManager.Add(course);
                model.id = course.Id;
            return PartialView("ReadPV/_CourseRV",model);
            }
            return null;
        }

        [HttpGet]
        public ActionResult EditCourse(int id)
        {
            ViewBag.actionName = "EditCourse";
            ExperienceManager experienceManager = Store.ExperienceManager;
            List<Experience> experiences = experienceManager.GetAllBindByUserID(User.Identity.GetUserId());
            CourseManager courseManager = Store.CourseManager;
            var course = courseManager.GetById(id);
            int? count = courseManager.GetAllBindByUserID(User.Identity.GetUserId()).Count;
            CoursesVM coursesVM = new CoursesVM
            {
                ExperinceId = course.ExperienceId,
                Experiences = experiences,
                Name = course.Name,
                Number = course.Number,
                CoursesCount = count,
                id = course.Id,

            };
            return PartialView("_CoursesModal", coursesVM);
        }

        [HttpPost]
        public ActionResult EditCourse(CoursesVM model)
        {
            ViewBag.actionName = "EditCourse";
            if (ModelState.IsValid)
            {
                CourseManager courseManager = Store.CourseManager;
                var oldCourse = courseManager.GetById(model.id);
                Course newcourse = new Course { ExperienceId = model.ExperinceId, Name = model.Name, Number = model.Number, UserId = User.Identity.GetUserId(),Id = (int) model.id };
                model.OldName = oldCourse.Name;
                courseManager.Update(newcourse);

            }
            return PartialView("ReadPV/_CourseRV", model);
        }

        [HttpGet]
        public ActionResult EditProject(int Id)
        {
            ViewBag.actionName = "EditProject";
            ExperienceManager experienceManager = Store.ExperienceManager;
            List<Experience> experiences = experienceManager.GetAllBindByUserID(User.Identity.GetUserId());
            ProjectManager projectManager = Store.ProjectManager;
            var project = projectManager.GetById(Id);
            int? count = projectManager.GetAllBindByUserID(User.Identity.GetUserId()).Count;
            ProjectsVM projectsVM = new ProjectsVM
            {
                ExperinceId = (int)project.ExperienceId,
                Experiences = experiences,
                Name = project.Name,
                 Creator = project.Creator,
                ProjectsCount = count,
                id = project.Id,
                 Description = project.Description,
                 EndDate = project.EndDate,
                 StartDate = project.StartDate,
                 Url = project.Url

            };
            return PartialView("_Projects", projectsVM);
        }

        [HttpPost]
        public ActionResult EditProject(ProjectsVM model)
        {
            ViewBag.actionName = "EditCourse";
            if (ModelState.IsValid)
            {
                ProjectManager projectManager = Store.ProjectManager;
                Project newproject;
                string id = User.Identity.GetUserId();
                if (model.StartDate == null || model.EndDate == null)
                {
                    newproject = new Project
                    {
                        ExperienceId = model.ExperinceId,
                        Name = model.Name,
                        Id = (int)model.id,
                        UserId = id,
                        Creator = model.Creator,
                        Description = model.Description,
                        Url = model.Url
                    };
                    projectManager.UpdateProject(newproject);

                }
                else if (model.EndDate == null)
                {
                    newproject = new Project
                    {
                        ExperienceId = model.ExperinceId,
                        Name = model.Name,
                        Id = (int)model.id,
                        UserId = id,
                        Creator = model.Creator,
                        Description = model.Description,
                        Url = model.Url,
                        StartDate = model.StartDate,

                    };
                    projectManager.Update(newproject);
                }
                else
                {
                    newproject = new Project
                    {
                        ExperienceId = model.ExperinceId,
                        Name = model.Name,
                        Id = (int)model.id,
                        UserId = id,
                        Creator = model.Creator,
                        Description = model.Description,
                        Url = model.Url,
                        EndDate = model.EndDate,

                    };
                    projectManager.Update(newproject);
                }

            }
            return null;
        }


        [HttpGet]
        public ActionResult AddProject()
        {
            ViewBag.actionName = "AddProject";
            ProjectManager projectManager = Store.ProjectManager;
            ExperienceManager experienceManager = Store.ExperienceManager;
            List<Experience> experiences = experienceManager.GetAllBindByUserID(User.Identity.GetUserId());
            int? count = projectManager.GetAllBindByUserID(User.Identity.GetUserId()).Count;
            ProjectsVM model = new ProjectsVM
            {
                Experiences = experiences,
                ProjectsCount = count
            };
            return PartialView("_Projects",model);
        }
        

        [HttpPost]
        public ActionResult AddProject(ProjectsVM model)
        {
            ViewBag.actionName = "AddProject";

            if (ModelState.IsValid)
            {
                ProjectManager projectManager = Store.ProjectManager;
                Project project;
                int day = 1;
                string id = User.Identity.GetUserId();
                if (model.StartMonth == null || model.StartYear == null)
                {
                    project = new Project
                    {
                        ExperienceId = model.ExperinceId,
                        Name = model.Name,
                        UserId = id,
                        Creator = model.Creator,
                        Description = model.Description,
                        Url = model.Url
                    };
                    projectManager.Add(project);
                }
                else if (model.EndMonth == null || model.EndYear == null)
                {
                    int month = Convert.ToInt32(model.StartMonth);
                    int year = Convert.ToInt32(model.StartYear.ToString());
                    DateTime StartDate = new DateTime(year, month, day);

                    project = new Project
                    {
                        ExperienceId = model.ExperinceId,
                        Name = model.Name,
                        UserId = id,
                        Creator = model.Creator,
                        Description = model.Description,
                        StartDate = StartDate,
                        Url = model.Url
                    };
                    projectManager.Add(project);
                    model.id = project.Id;
                }
                else
                {
                    int month = Convert.ToInt32(model.StartMonth);
                    int year = Convert.ToInt32(model.StartYear.ToString());
                    int Emonth = Convert.ToInt32(model.EndMonth);
                    int Eyear = Convert.ToInt32(model.EndYear.ToString());
                    DateTime StartDate = new DateTime(year, month, day);
                    DateTime EndDate = new DateTime(Eyear, Emonth, day);
                    project = new Project
                    {
                        ExperienceId = model.ExperinceId,
                        Name = model.Name,
                        UserId = id,
                        Creator = model.Creator,
                        Description = model.Description,
                        StartDate = StartDate,
                        EndDate = EndDate,
                        Url = model.Url
                    };
                    projectManager.Add(project);
                    model.id = project.Id;
                }


            return PartialView("ReadPV/_ProjectRV",model);
            }
            return null;
        }

        [HttpGet]
        public ActionResult AddAward()
        {
            ViewBag.actionName = "AddAward";

            AwardManager awardManager = Store.AwardManager;
            ExperienceManager experienceManager = Store.ExperienceManager;
            List<Experience> experiences = experienceManager.GetAllBindByUserID(User.Identity.GetUserId());
            int? count = awardManager.GetAllBindByUserID(User.Identity.GetUserId()).Count;
            HonorVM model = new HonorVM
            {
                Experiences = experiences,
                AwardsCount = count
            };
            return PartialView("_Honor", model);
        }

        [HttpGet]
        public ActionResult EditAward(int Id)
        {
            ViewBag.actionName = "EditAward";
            ExperienceManager experienceManager = Store.ExperienceManager;
            List<Experience> experiences = experienceManager.GetAllBindByUserID(User.Identity.GetUserId());
            AwardManager awardManager = Store.AwardManager;
            var award = awardManager.GetById(Id);
            int? count = awardManager.GetAllBindByUserID(User.Identity.GetUserId()).Count;
            HonorVM HonorVM = new HonorVM
            {
                ExperinceId = (int)award.ExperienceId,
                Experiences = experiences,
                Title = award.Title,
                Issuer = award.Issuer,
                AwardsCount = count,
                id = award.Id,
                Description = award.Description,
                IssueDate = award.IssueDate,
                

            };
            return PartialView("_Honor", HonorVM);
        }

        [HttpPost]
        public ActionResult EditAward(HonorVM model)
        {
            ViewBag.actionName = "EditAward";
            if (ModelState.IsValid)
            {
                AwardManager awardManager = Store.AwardManager;
                Award award;
                int day = 1;
                string id = User.Identity.GetUserId();
                if (model.IssueDate == null )
                {
                    award = new Award
                    {
                        ExperienceId = model.ExperinceId,
                        Title = model.Title,
                        UserId = id,
                        Description = model.Description,
                        Issuer = model.Issuer,
                        Id= (int)model.id
                    };
                    awardManager.Update(award);
                }
                else
                {
                    int month = Convert.ToInt32(model.Month);
                    int year = Convert.ToInt32(model.Year.ToString());
                    DateTime date = new DateTime(year, month, day);

                    award = new Award
                    {
                        ExperienceId = model.ExperinceId,
                        Title = model.Title,
                        UserId = id,
                        Description = model.Description,
                        Issuer = model.Issuer,
                        IssueDate = date,
                        Id = (int)model.id
                    };
                    awardManager.Update(award);
                    model.IssueDate = date;
                }
            }
            return null;
        }

        public ActionResult AddAward(HonorVM model)
        {
            ViewBag.actionName = "AddAward";
            if (ModelState.IsValid)
            {
                AwardManager awardManager = Store.AwardManager;
                Award award;
                int day = 1;
                string id = User.Identity.GetUserId();
                if (model.Month == null || model.Year == null)
                {
                    award = new Award
                    {
                        ExperienceId = model.ExperinceId,
                        Title = model.Title,
                        UserId = id,
                        Description = model.Description,
                        Issuer = model.Issuer
                    };
                    awardManager.Add(award);
                    model.id = award.Id;
                }
                else
                {
                    int month = Convert.ToInt32(model.Month);
                    int year = Convert.ToInt32(model.Year.ToString());
                    DateTime date = new DateTime(year, month, day);

                    award = new Award
                    {
                        ExperienceId = model.ExperinceId,
                        Title = model.Title,
                        UserId = id,
                        Description = model.Description,
                        Issuer = model.Issuer,
                        IssueDate = date
                    };
                    awardManager.Add(award);
                    model.IssueDate = date;
                    model.id = award.Id;
                }
            return PartialView("ReadPV/_AwardsRV", model);
            }
            return null;
        }

        [HttpGet]
        public ActionResult AddTest()
        {
            ViewBag.actionName = "AddTest";
            TestScoreManager testScoreManager = Store.TestScoreManager;
            ExperienceManager experienceManager = Store.ExperienceManager;
            List<Experience> experiences = experienceManager.GetAllBindByUserID(User.Identity.GetUserId());
            int? count = testScoreManager.GetAllBindByUserID(User.Identity.GetUserId()).Count;
            TestScoresVM model = new TestScoresVM
            {
                Experiences = experiences,
                TestScoreCount = count
            };
            return PartialView("_TestScores", model);
        }

            public ActionResult AddTest(TestScoresVM model)
        {
            ViewBag.actionName = "AddTest";
            if (ModelState.IsValid)
            {
                TestScoreManager testScoreManager = Store.TestScoreManager;
                TestScore testScore;
                int day = 1;
                string id = User.Identity.GetUserId();
                if (model.Month == null || model.Year == null)
                {
                    testScore = new TestScore
                    {
                        ExperienceId = model.ExperinceId,
                        TestName = model.TestName,
                        UserId = id,
                        Description = model.Description,
                        Score = model.Score
                    };
                    testScoreManager.Add(testScore);
                    model.id = testScore.Id;

                }
                else
                {
                    int month = Convert.ToInt32(model.Month);
                    int year = Convert.ToInt32(model.Year.ToString());
                    DateTime date = new DateTime(year, month, day);

                    testScore = new TestScore
                    {
                        ExperienceId = model.ExperinceId,
                        TestName = model.TestName,
                        UserId = id,
                        Description = model.Description,
                        Score = model.Score,
                        TestDate = date
                    };
                    testScoreManager.Add(testScore);
                    model.TestDate = date;
                    model.id = testScore.Id;
                }
            return PartialView("ReadPV/_TestScoreRV",model);
            }
            return null;
        }

        [HttpGet]
        public ActionResult EditTest(int Id)
        {
            ViewBag.actionName = "EditTest";
            ExperienceManager experienceManager = Store.ExperienceManager;
            List<Experience> experiences = experienceManager.GetAllBindByUserID(User.Identity.GetUserId());
            TestScoreManager testScoreManager = Store.TestScoreManager;
            var testscore = testScoreManager.GetById(Id);
            int? count = testScoreManager.GetAllBindByUserID(User.Identity.GetUserId()).Count;
            TestScoresVM testScoresVM = new TestScoresVM
            {
                ExperinceId = (int)testscore.ExperienceId,
                Experiences = experiences,
                TestName = testscore.TestName,
                TestDate = testscore.TestDate,
                TestScoreCount = count,
                id = testscore.Id,
                Description = testscore.Description,
                Score = testscore.Score


            };
            return PartialView("_TestScores", testScoresVM);
        }

        [HttpPost]
        public ActionResult EditTest(TestScoresVM model)
        {
            if (ModelState.IsValid)
            {
                TestScoreManager testScoreManager = Store.TestScoreManager;
                TestScore testScore;
                int day = 1;
                string id = User.Identity.GetUserId();
                if (model.TestDate == null )
                {
                    testScore = new TestScore
                    {
                        ExperienceId = model.ExperinceId,
                        TestName = model.TestName,
                        UserId = id,
                        Description = model.Description,
                        Score = model.Score,
                        Id = (int)model.id
                    };
                    testScoreManager.Update(testScore);
                }
                else
                {
                    int month = Convert.ToInt32(model.Month);
                    int year = Convert.ToInt32(model.Year.ToString());
                    DateTime date = new DateTime(year, month, day);

                    testScore = new TestScore
                    {
                        ExperienceId = model.ExperinceId,
                        TestName = model.TestName,
                        UserId = id,
                        Description = model.Description,
                        Score = model.Score,
                        TestDate = date,
                        Id = (int)model.id
                    };
                    testScoreManager.Update(testScore);
                    model.TestDate = date;
                }
            }
            return null;
        }

        [HttpPost]
        public JsonResult RetriveLanguages(string Prefix)
        {
            LanguageManager languageManager = Store.LanguageManager;

            var languages = languageManager.GetAllByPrefix(Prefix).ToList();

            //Searching records from list using LINQ query  

            return Json(languages.Select(e=> new { e.Name,e.Id}), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult AddLanguage()
        {
            ViewBag.actionName = "AddLanguage";
            UserLanguageManager userLanguageManager = Store.UserLanguageManager;
            int? count = userLanguageManager.GetAllBindByUserID(User.Identity.GetUserId()).Count;
            LanguageVM model = new LanguageVM
            {
                
                userlanguageCount = count
            };
            return PartialView("_Laungauges", model);
        }
        [HttpPost]
            public ActionResult  AddLanguage(LanguageVM model)
        {
            ViewBag.actionName = "AddLanguage";

            if (ModelState.IsValid)
            {
                LanguageManager languageManager = Store.LanguageManager;
                UserLanguageManager userLanguageManager = Store.UserLanguageManager;
                Language language = languageManager.GetByName(model.LanguageName);
                UserLanguage userLanguage;
                if ( language != null)
                {
                    userLanguage = new UserLanguage { LanguageId = language.Id, Proficiency = model.Proficiency, UserId = User.Identity.GetUserId() };
                    userLanguageManager.Add(userLanguage);
                    model.id = userLanguage.Id;
                }
                else
                {
                    language = new Language { Name = model.LanguageName };
                    language = languageManager.Add(language);

                    userLanguage = new UserLanguage { LanguageId = language.Id, Proficiency = model.Proficiency, UserId = User.Identity.GetUserId() };
                    userLanguageManager.Add(userLanguage);
                    model.id = userLanguage.Id;
                }
                return PartialView("ReadPV/_UserLanguageRV", model);
            }
            return null;
        }

        [HttpGet]
        public ActionResult EditLanguage(int id)
        {
            ViewBag.actionName = "EditLanguage";
            UserLanguageManager userLanguageManager = Store.UserLanguageManager;
            var language = userLanguageManager.GetById(id);
            int? count = userLanguageManager.GetAllBindByUserID(User.Identity.GetUserId()).Count;
            LanguageVM lang = new LanguageVM
            {
                LanguageName = language.Language.Name,
                userlanguageCount = count,
                id = language.Id,
                LanguageId = language.Language.Id,
                 Proficiency = language.Proficiency

                
                

            };
            return PartialView("_Laungauges", lang);
        }


        [HttpPost]
        public ActionResult EditLanguage(LanguageVM model)
        {
            ViewBag.actionName = "EditLanguage";
            if (ModelState.IsValid)
            {
                LanguageManager languageManager = Store.LanguageManager;
                UserLanguageManager userLanguageManager = Store.UserLanguageManager;
                Language language = languageManager.GetByName(model.LanguageName);
                UserLanguage userLanguage;
                if (language != null)
                {
                    userLanguage = new UserLanguage { LanguageId = language.Id, Proficiency = model.Proficiency, UserId = User.Identity.GetUserId() , Id=(int)model.id};
                    userLanguageManager.Update(userLanguage);
                }
                else
                {
                    language = new Language { Name = model.LanguageName };
                    language = languageManager.Add(language);

                    userLanguage = new UserLanguage { LanguageId = language.Id, Proficiency = model.Proficiency, UserId = User.Identity.GetUserId() ,Id = (int)model.id };
                    userLanguageManager.Update(userLanguage);
                }
            }
            return null;
        }
        [HttpGet]
        public ActionResult AddWorkExperience()
        {
            ViewBag.actionName = "AddWorkExperience";
            return PartialView("_WorkExperince");
        }
        public ActionResult AddWorkExperience(WorkExperinceVM model)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("_WorkExperince");
                //var organization = Store.OrganizationManager.checkIfExist(model.Organization_name);
            }
            else
            {
                var organization = Store.OrganizationManager.checkIfExist(model.Organization_name);
                var country = Store.CountryManager.checkIfExist(model.WorkExperince.CountryName);

                if (country==null)
                {
                    country = new Country { Name = model.WorkExperince.CountryName };
                   country= Store.CountryManager.Add(country);
                    Store.DbContext.SaveChanges();
                }

                int day = 1;
                int month = Convert.ToInt32(model.StartMonth);
                int year = Convert.ToInt32(model.StartYear.ToString());
                string id = User.Identity.GetUserId();
                int Emonth=1, Eyear=1;
                string description;
                System.DateTime endData = DateTime.Now;
                if (model.EndMonth != null && model.EndYear!=null)
                {
                    Emonth = Convert.ToInt32(model.EndMonth);
                     Eyear = Convert.ToInt32(model.EndYear.ToString());
                    endData = new System.DateTime(Eyear, Emonth, day);
                    description = model.StartYear.ToString() + " " + model.StartMonth + " - " + model.EndYear.ToString()+" " + model.EndMonth;
                   //description = Convert.ToString(Eyear - year) + " year," + Convert.ToString(Emonth - month) + "month";
                }
                else
                {
                     description= Convert.ToString( year) + month + " - " + " Present" ;
                }
                 
                System.DateTime newdate = new System.DateTime(year, month, day);
                

                if (organization == null)
                {
                    
                    organization= Store.OrganizationManager.Add(new Organization { Name = model.Organization_name });
                    
                }
                var exp = Store.ExperienceManager.Add(new Experience { UserId = id, Organization = organization, StartDate = (newdate), EndDate = (endData), Description = description });
                Store.WorkManager.Add(new Work { Experience = exp, CountryName = model.WorkExperince.CountryName, UserId = id, Title = model.WorkExperince.Title, EmploymentType = model.WorkExperince.EmploymentType, Organization = organization, description = model.WorkExperince.description });
                Store.DbContext.SaveChanges();
                
                
                

            }


            return null;
        }
        [HttpGet]
        public ActionResult AddEducation()
        {
            ViewBag.actionName = "AddEducation";
            return PartialView("_Education");
        }
        public ActionResult AddEducation(EducationVM model)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("_Education");
                //var organization = Store.OrganizationManager.checkIfExist(model.Organization_name);
            }
            else
            {
                var organization = Store.OrganizationManager.checkIfExist(model.Education.Experience.Organization.Name);
                if (organization == null)
                {
                    organization = Store.OrganizationManager.Add(new Organization { Name = model.Education.Experience.Organization.Name, Type = OrganizationType.School });
                    
                }
                int year = Convert.ToInt32(model.StartYear.ToString());
                System.DateTime newdate = new System.DateTime(year, 1, 1);
                int Eyear = Convert.ToInt32(model.EndYear.ToString());
                System.DateTime Edate = new System.DateTime(Eyear, 1, 1);
                var exp = Store.ExperienceManager.Add(new Experience { UserId = User.Identity.GetUserId(), Organization = organization, StartDate = (newdate),  EndDate =( Edate), Description = model.Education.Experience.Description });
                Store.EducationManager.Add(new Education { Activities = model.Education.Activities, Degree = model.Education.Degree, UserId = User.Identity.GetUserId(), Grade = model.Education.Grade, Experience = exp ,FieldOfStudy=model.Education.FieldOfStudy});
                Store.DbContext.SaveChanges();
            }
            return null;
        }
        [HttpGet]
        public ActionResult editEducation(int id)
        {
            ViewBag.actionName = "editEducation";
            var edu = Store.EducationManager.getEducationData(id);
            DateTime startdate = (DateTime)edu.Experience.StartDate;
            DateTime enddate = (DateTime)edu.Experience.EndDate;
                
            return PartialView("_Education", new EducationVM { EndYear= enddate.Year, StartYear= startdate.Year,Education=edu});


        }
        [HttpPost]
        public ActionResult editEducation(EducationVM model)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("_Education", model);

            }else
            {
                var edu = Store.EducationManager.getEducationData(model.Education.ExperienceId);
                var organization = Store.OrganizationManager.checkIfExist(model.Education.Experience.Organization.Name);
                if (organization == null)
                {
                    organization = Store.OrganizationManager.Add(new Organization { Name = model.Education.Experience.Organization.Name, Type = OrganizationType.School });

                }
                int year = Convert.ToInt32(model.StartYear.ToString());
                System.DateTime newdate = new System.DateTime(year, 1, 1);
                int Eyear = Convert.ToInt32(model.EndYear.ToString());
                System.DateTime Edate = new System.DateTime(Eyear, 1, 1);
                if (edu.Experience.StartDate != newdate)
                {
                    edu.Experience.StartDate = newdate;
                    
                }
                if (edu.Experience.EndDate != Edate)
                {
                    edu.Experience.EndDate = Edate;
                }
                var exp= new Experience { UserId = User.Identity.GetUserId(), OrganizationId = organization.Id, StartDate = (newdate), EndDate = (Edate), Description = model.Education.Experience.Description, Id = model.Education.ExperienceId };
                bool result= Store.ExperienceManager.Update(exp);
                Store.EducationManager.Update(new Education { Activities = model.Education.Activities, Degree = model.Education.Degree, UserId = User.Identity.GetUserId(), Grade = model.Education.Grade, Experience = exp, FieldOfStudy = model.Education.FieldOfStudy,ExperienceId=exp.Id});
                Store.DbContext.SaveChanges();
            }
            //ViewBag.actionName = "editEducation";
            //var edu = Store.EducationManager.getEducationData(id);
            //DateTime startdate = (DateTime)edu.Experience.StartDate;
            //DateTime enddate = (DateTime)edu.Experience.EndDate;

            //return PartialView("_Education", new EducationVM { EndYear = enddate.Year, StartYear = startdate.Year, Education = edu });

            return null;
        }
        [HttpGet]
        public ActionResult AddCertification()
        {
            ViewBag.actionName = "AddCertification";
            return PartialView("_Certfications");
        }
        [HttpPost]
        public ActionResult AddCertification(CertificationsVM model)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("_Certfications");
                //var organization = Store.OrganizationManager.checkIfExist(model.Organization_name);
            }
            else
            {
                var organization = Store.OrganizationManager.checkIfExist(model.UserCertification.Organization.Name);
                if (organization == null)
                {
                    organization = Store.OrganizationManager.Add(new Organization { Name = model.UserCertification.Organization.Name, Type = OrganizationType.Company });

                }
                int day = 1;
                int month = Convert.ToInt32(model.StartMonth);
                int year = Convert.ToInt32(model.StartYear.ToString());
                string id = User.Identity.GetUserId();

                int Emonth = 1, Eyear = 1;
                string description;
                System.DateTime endData = DateTime.Now;
                if (model.EndMonth != null && model.EndYear != null)
                {
                    Emonth = Convert.ToInt32(model.EndMonth);
                    Eyear = Convert.ToInt32(model.EndYear.ToString());
                    endData = new System.DateTime(Eyear, Emonth, day);
                    description = model.StartYear.ToString() + " " + model.StartMonth + " - " + model.EndYear.ToString() + " " + model.EndMonth;
                    //description = Convert.ToString(Eyear - year) + " year," + Convert.ToString(Emonth - month) + "month";
                }
                else
                {
                    description = Convert.ToString(year) + month + " - " + " Present";
                }

                System.DateTime newdate = new System.DateTime(year, month, day);
                
                var certificate = Store.CertificationManager.checkIfExist(model.UserCertification.Certification.Name);
                if (certificate == null)
                {
                    certificate = Store.CertificationManager.Add(new Certification { Name = model.UserCertification.Certification.Name });
                }
                Store.UserCertificationManager.Add(new UserCertification { Certification = certificate, CredentialId = model.UserCertification.CredentialId, CredentialUrl = model.UserCertification.CredentialUrl, Organization = organization, ExpirationDate = endData, IssueDate = newdate, UserId = id });
                Store.DbContext.SaveChanges();

            }




            return null;
        }
        [HttpGet]
        public ActionResult AddVoulanteer()
        {
            ViewBag.actionName = "AddVoulanteer";
            return PartialView("_Voulanteer");

        }
        [HttpPost]
        public ActionResult AddVoulanteer(VoulanteerVM model)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("_Voulanteer");
                //var organization = Store.OrganizationManager.checkIfExist(model.Organization_name);
            }
            else
            {
                var organization = Store.OrganizationManager.checkIfExist(model.Volunteer.Experience.Organization.Name);
                if (organization == null)
                {
                    organization = Store.OrganizationManager.Add(new Organization { Name = model.Volunteer.Experience.Organization.Name, Type = OrganizationType.Company });

                }
                int day = 1;
                int month = Convert.ToInt32(model.StartMonth);
                int year = Convert.ToInt32(model.StartYear.ToString());
                string id = User.Identity.GetUserId();


                int Emonth = 1, Eyear = 1;
                string description;
                System.DateTime endData = DateTime.Now;
                if (model.EndMonth != null && model.EndYear != null)
                {
                    Emonth = Convert.ToInt32(model.EndMonth);
                    Eyear = Convert.ToInt32(model.EndYear.ToString());
                    endData = new System.DateTime(Eyear, Emonth, day);
                    description = model.StartYear.ToString() + " " + model.StartMonth + " - " + model.EndYear.ToString() + " " + model.EndMonth;
                    //description = Convert.ToString(Eyear - year) + " year," + Convert.ToString(Emonth - month) + "month";
                }
                else
                {
                    description = Convert.ToString(year) + month + " - " + " Present";
                }

                    System.DateTime newdate = new System.DateTime(year, month, day);
                
                var exp = Store.ExperienceManager.Add(new Experience { UserId = User.Identity.GetUserId(), Organization = organization, StartDate = (newdate), EndDate = (endData), Description = model.Volunteer.Experience.Description});
                Store.VolunteerManager.Add(new Volunteer { Role = model.Volunteer.Role, VolunteeringCause = model.Volunteer.VolunteeringCause, Experience = exp, UserId = id });
                Store.DbContext.SaveChanges();

            }


            return null;
        }
        [HttpGet]
        public ActionResult EditExperience(int id)
        {
            ViewBag.actionName = "EditExperience";
            var work = Store.WorkManager.GetById(id);
            DateTime startdate = (DateTime) work.Experience.StartDate;
            DateTime enddate = (DateTime)work.Experience.EndDate;
            return PartialView("_WorkExperince", new WorkExperinceVM { WorkExperince=work,EndMonth=(MonthEnum)enddate.Month ,EndYear= enddate.Year, StartMonth = (MonthEnum)startdate.Month, StartYear = startdate.Year,Organization_name=work.Organization.Name});
        }
        [HttpPost]
        public ActionResult EditExperience(WorkExperinceVM model)
        {
            Work mworkMpdel;
            if (!ModelState.IsValid)
            {
                return PartialView("_WorkExperince", model);
                //var organization = Store.OrganizationManager.checkIfExist(model.Organization_name);
            }
            else
            {
                var country = Store.CountryManager.checkIfExist(model.WorkExperince.CountryName);

                if (country == null)
                {
                    country = new Country { Name = model.WorkExperince.CountryName };
                    country = Store.CountryManager.Add(country);
                    Store.DbContext.SaveChanges();
                }
                var organiztion = Store.OrganizationManager.checkIfExist(model.Organization_name);
                if (organiztion == null)
                {
                    organiztion = Store.OrganizationManager.Add(new Organization { Name = model.Organization_name });
                    Store.DbContext.SaveChanges();
                }
                var experience = Store.ExperienceManager.GetById(model.WorkExperince.ExperienceId);
               
                    int day = 1;
                    int month = Convert.ToInt32(model.StartMonth);
                    int year = Convert.ToInt32(model.StartYear.ToString());
                    System.DateTime newdate = new System.DateTime(year, month, day);
                    string id = User.Identity.GetUserId();
                    int Emonth = 1, Eyear = 1;
                    string description;
                    System.DateTime endData = DateTime.Now;
                    if (model.EndMonth != null && model.EndYear != null)
                    {
                        Emonth = Convert.ToInt32(model.EndMonth);
                        Eyear = Convert.ToInt32(model.EndYear.ToString());
                        endData = new System.DateTime(Eyear, Emonth, day);
                        description = model.StartYear.ToString() + " " + model.StartMonth + " - " + model.EndYear.ToString() + " " + model.EndMonth;
                        //description = Convert.ToString(Eyear - year) + " year," + Convert.ToString(Emonth - month) + "month";
                    }
                    else
                    {
                        description = Convert.ToString(year) + month + " - " + " Present";
                    }
                    experience = new Experience { UserId = model.WorkExperince.UserId, OrganizationId = organiztion.Id, StartDate = (newdate), EndDate = (endData), Description = description, Id =(int) model.WorkExperince.ExperienceId };
                    var exp = Store.ExperienceManager.Update(experience);
                    Store.DbContext.SaveChanges();

                    mworkMpdel = new Work { ExperienceId = experience.Id, CountryName = model.WorkExperince.CountryName, UserId = id, Title = model.WorkExperince.Title, EmploymentType = model.WorkExperince.EmploymentType, Organization_Id = organiztion.Id, description = model.WorkExperince.description };
                ViewBag.mworkMpdel = mworkMpdel;
               Store.WorkManager.Update(mworkMpdel);
                    Store.DbContext.SaveChanges();
                

                 }
           
            return null;



            
        }
        public ActionResult DeleteExperience(int id)
        {
            var experience = Store.ExperienceManager.GetById(id);
            if (experience != null)
            {
              var work=  Store.WorkManager.GetById(experience.Id);
                
                Store.WorkManager.Remove(work);
                Store.ExperienceManager.Remove(experience);
                Store.DbContext.SaveChanges();
            }
            return RedirectToAction("UserProfile");
        }
        [HttpGet]
        public ActionResult EditCertification( int id)
        {
            ViewBag.actionName = "EditCertification";
            var certificate = Store.CertificationManager.GetById(id);
           
            DateTime startdate = (DateTime)certificate.UserCertifications.ToList()[0].IssueDate;
            DateTime enddate = (DateTime)certificate.UserCertifications.ToList()[0].ExpirationDate;

            return PartialView("_Certfications", new CertificationsVM { UserCertification = certificate.UserCertifications.ToList()[0], EndMonth = (MonthEnum)enddate.Month, EndYear = enddate.Year, StartMonth = (MonthEnum)startdate.Month, StartYear = startdate.Year });
        }
        [HttpPost]
        public ActionResult EditCertification(CertificationsVM model)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("_Certfications");
                //var organization = Store.OrganizationManager.checkIfExist(model.Organization_name);
            }
            else
            {
                var organization = Store.OrganizationManager.checkIfExist(model.UserCertification.Organization.Name);
                if (organization == null)
                {
                    organization = Store.OrganizationManager.Add(new Organization { Name = model.UserCertification.Organization.Name, Type = OrganizationType.Company });

                }
                int day = 1;
                int month = Convert.ToInt32(model.StartMonth);
                int year = Convert.ToInt32(model.StartYear.ToString());
                string id = User.Identity.GetUserId();

                int Emonth = 1, Eyear = 1;
                string description;
                System.DateTime endData = DateTime.Now;
                if (model.EndMonth != null && model.EndYear != null)
                {
                    Emonth = Convert.ToInt32(model.EndMonth);
                    Eyear = Convert.ToInt32(model.EndYear.ToString());
                    endData = new System.DateTime(Eyear, Emonth, day);
                    description = model.StartYear.ToString() + " " + model.StartMonth + " - " + model.EndYear.ToString() + " " + model.EndMonth;
                    //description = Convert.ToString(Eyear - year) + " year," + Convert.ToString(Emonth - month) + "month";
                }
                else
                {
                    description = Convert.ToString(year) + month + " - " + " Present";
                }

                System.DateTime newdate = new System.DateTime(year, month, day);

                var certificate = Store.CertificationManager.checkIfExist(model.UserCertification.Certification.Name);
                if (certificate == null)
                {
                    certificate = new Certification { Name = model.UserCertification.Certification.Name,Id=(int)model.UserCertification.CertificationId };
                    var result = Store.CertificationManager.Update(certificate);
                }
                Store.UserCertificationManager.Update(new UserCertification { CertificationId = certificate.Id, CredentialId = model.UserCertification.CredentialId, CredentialUrl = model.UserCertification.CredentialUrl, OrganizationId = organization.Id, ExpirationDate = endData, IssueDate = newdate, UserId = id });
                Store.DbContext.SaveChanges();
                
            }
            return null;
        }
        [HttpGet]
        public ActionResult EditVolunteer(int id)
        {
            ViewBag.actionName = "EditVolunteer";
            var Volunteer = Store.VolunteerManager.GetById(id);

            DateTime startdate = (DateTime)Volunteer.Experience.StartDate;
            DateTime enddate = (DateTime)Volunteer.Experience.EndDate;

            return PartialView("_Voulanteer", new VoulanteerVM { Volunteer = Volunteer, EndMonth = (MonthEnum)enddate.Month, EndYear = enddate.Year, StartMonth = (MonthEnum)startdate.Month, StartYear = startdate.Year });

        }
        [HttpPost]
        public ActionResult EditVolunteer(VoulanteerVM model)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("_Voulanteer");
                //var organization = Store.OrganizationManager.checkIfExist(model.Organization_name);
            }
            else
            {
                var organization = Store.OrganizationManager.checkIfExist(model.Volunteer.Experience.Organization.Name);
                if (organization == null)
                {
                    organization = Store.OrganizationManager.Add(new Organization { Name = model.Volunteer.Experience.Organization.Name, Type = OrganizationType.Company });

                }
                int day = 1;
                int month = Convert.ToInt32(model.StartMonth);
                int year = Convert.ToInt32(model.StartYear.ToString());
                string id = User.Identity.GetUserId();


                int Emonth = 1, Eyear = 1;
                string description;
                System.DateTime endData = DateTime.Now;
                if (model.EndMonth != null && model.EndYear != null)
                {
                    Emonth = Convert.ToInt32(model.EndMonth);
                    Eyear = Convert.ToInt32(model.EndYear.ToString());
                    endData = new System.DateTime(Eyear, Emonth, day);
                    description = model.StartYear.ToString() + " " + model.StartMonth + " - " + model.EndYear.ToString() + " " + model.EndMonth;
                    //description = Convert.ToString(Eyear - year) + " year," + Convert.ToString(Emonth - month) + "month";
                }
                else
                {
                    description = Convert.ToString(year) + month + " - " + " Present";
                }

                System.DateTime newdate = new System.DateTime(year, month, day);
                var exp = new Experience { UserId = User.Identity.GetUserId(), OrganizationId = organization.Id, StartDate = (newdate), EndDate = (endData), Description = model.Volunteer.Experience.Description,Id= (int)model.Volunteer.ExperienceId };
                bool result = Store.ExperienceManager.Update(exp);
                Store.VolunteerManager.Update(new Volunteer { Role = model.Volunteer.Role, VolunteeringCause = model.Volunteer.VolunteeringCause, Experience = exp, UserId = id,ExperienceId=exp.Id });
                Store.DbContext.SaveChanges();

            }


            //experience = new Experience { UserId = model.WorkExperince.UserId, OrganizationId = organiztion.Id, StartDate = (newdate), EndDate = (endData), Description = description, Id = (int)model.WorkExperince.ExperienceId };
            //var exp = Store.ExperienceManager.Update(experience);
            //Store.DbContext.SaveChanges();


            //Store.WorkManager.Update(new Work { ExperienceId = experience.Id, CountryName = model.WorkExperince.CountryName, UserId = id, Title = model.WorkExperince.Title, EmploymentType = model.WorkExperince.EmploymentType, Organization_Id = organiztion.Id, description = model.WorkExperince.description });
            //Store.DbContext.SaveChanges();



            return null;
        }

        public ActionResult DeleteEducation(int id)
        {
            var experience = Store.ExperienceManager.GetById(id);
            if (experience != null)
            {
                var education = Store.EducationManager.GetById(experience.Id);

                Store.EducationManager.Remove(education);
                Store.ExperienceManager.Remove(experience);
                Store.DbContext.SaveChanges();
            }
            return RedirectToAction("UserProfile");
        }
        public ActionResult DeleteVolunteer(int id)
        {
            var experience = Store.ExperienceManager.GetById(id);
            if (experience != null)
            {
                var Volunteer = Store.VolunteerManager.GetById(experience.Id);

                Store.VolunteerManager.Remove(Volunteer);
                Store.ExperienceManager.Remove(experience);
                Store.DbContext.SaveChanges();
            }
            return RedirectToAction("UserProfile");
        }
        public ActionResult DeleteCertification(int id)
        {
            var experience = Store.ExperienceManager.GetById(id);
            if (experience != null)
            {
                var Certification = Store.CertificationManager.GetById(experience.Id);

                Store.CertificationManager.Remove(Certification);
                Store.ExperienceManager.Remove(experience);
                Store.DbContext.SaveChanges();
            }
            return RedirectToAction("UserProfile");
        }
    }
}