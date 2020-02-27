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

            List<Experience> experiences = experienceManager.GetAllBindByUserID(User.Identity.GetUserId());

            ProfileVM profileVM = new ProfileVM
            {
                Experiences = experiences
        };
            return View(profileVM);
        }

        [HttpPost]
        public ActionResult AddCourse(CoursesVM model)
        {
            if (ModelState.IsValid)
            {
                CourseManager courseManager = Store.CourseManager;
                Course course = new Course { ExperienceId = model.ExperinceId, Name = model.Name, Number = model.Number, UserId = User.Identity.GetUserId() };

                courseManager.Add(course);
                
            }
                return (null);
        }

        [HttpPost]
        public ActionResult AddProject(ProjectsVM model)
        {
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
                }
                else
                {
                    int month = Convert.ToInt32(model.StartMonth);
                    int year = Convert.ToInt32(model.StartYear.ToString());
                    int Emonth = Convert.ToInt32(model.EndMonth);
                    int Eyear = Convert.ToInt32(model.EndYear.ToString());
                    DateTime StartDate = new DateTime(year, month, day);
                    DateTime EndDate = new DateTime(Eyear, Emonth, day);
                 project = new Project { ExperienceId = model.ExperinceId, Name = model.Name, UserId = id ,
                Creator = model.Creator , Description = model.Description, StartDate = StartDate , EndDate = EndDate,
                  Url = model.Url};
                    projectManager.Add(project);
                }
               


            }
            return (null);
        }
    }
}