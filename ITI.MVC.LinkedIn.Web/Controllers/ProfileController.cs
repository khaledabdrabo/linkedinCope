using ITI.MVC.LinkedIn.DbLayer.Entities;
using ITI.MVC.LinkedIn.Store;
using ITI.MVC.LinkedIn.Store.DbManagers;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using ITI.MVC.LinkedIn.Web.Models.ViewModels;
using System.Threading.Tasks;

namespace ITI.MVC.LinkedIn.Web.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private DbStore store;
        public DbStore Store
        {

            get => store ?? HttpContext.GetOwinContext().Get<DbStore>();

            private set => store = value;
        }
        // GET: Profile
        public ActionResult UserProfile()
        {
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
    }
}