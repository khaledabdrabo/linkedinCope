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
using System.Web.Script.Serialization;
using ITI.MVC.LinkedIn.DbLayer;

namespace ITI.MVC.LinkedIn.Web.Controllers
{
    // [Authorize]
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
            //ExperienceManager experienceManager = Store.ExperienceManager;

            //List<Experience> experiences = experienceManager.GetAllBindByUserID(User.Identity.GetUserId());

            //ProfileVM profileVM = new ProfileVM
            //{
            //    Experiences = experiences , profileVM
            //};
            CountryManager countryManager = Store.CountryManager;
            
            SkillManager skillManager = Store.SkillManager;
            List<Skill> skills = (List<Skill>)skillManager.GetAllBind();
            List<string> country = countryManager.GetAllCountry();

            ProfileVM profileVM = new ProfileVM
            {
                AllCountry = country,
                Skills = skills,
                LastSkillId = skillManager.GetAllBind().LastOrDefault().Id
            };
            int o = 5;
            return View(profileVM);
        }
        [HttpGet]
        public ActionResult Search(List<ApplicationUser> users)
        {
            List<ApplicationUser> resultUsers = new List<ApplicationUser>();

            resultUsers =(List < ApplicationUser >)TempData["users"];

            return View(resultUsers);
        }

        [HttpPost]
        public ActionResult Search(string userName)
        {
            String firstName, lastName;
            ApplicationDbContext appUser = new ApplicationDbContext();
            List<ApplicationUser> users=new List<ApplicationUser>();

            string[] name = userName.Split(' ');
        
                
                    firstName = name[0];
            if(name.Length == 1)
            {
                users = appUser.Users.Where(e => e.FirstName == firstName).ToList();

            }

            else if (name.Length == 2)
            {
                lastName = name[1];
                users = appUser.Users.Where(e => e.FirstName == firstName && e.LastName == lastName).ToList();
            }
            TempData["users"] = users;

            return RedirectToAction("Search");
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
                }



            }
            return (null);
        }

        [HttpPost]
        public ActionResult AddPublication(PublicationVM model)
        {
            if (ModelState.IsValid)
            {
                PublicationManager publicationManager = Store.PublicationManager;
                publicationManager.Remove(publicationManager.GetAllBind().LastOrDefault());
                int userId = (int.Parse(publicationManager.GetAllBind().LastOrDefault().UserId)) + 1;
                Publication publication = new Publication { Title = model.Title, Publisher = model.Publisher, Date = new DateTime(model.Year, 4, model.Day), Author = model.Author, Url = model.URL, Description = model.Description, UserId = userId.ToString() };

                publicationManager.Add(publication);
            }
            
            return (null);
        }


        [HttpPost]
        public ActionResult AddSummary(AboutVM model)
        {
            if (ModelState.IsValid)
            {
                
            }
            return (null);
        }

        [HttpPost]
        public ActionResult AddSkills(string skillId , string skillName)
        {
            UserSkillManager userskillManager = Store.UserSkillManager;
            SkillManager skillManager = Store.SkillManager;

            JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            object[] SId = (object[])json_serializer.DeserializeObject(skillId);
            object[] SName = (object[])json_serializer.DeserializeObject(skillName);

            userSkill[] skills = new userSkill[SId.Length];
            string c = SName[0].ToString();
            for (int i = 0; i < SId.Length; i++)
            {
                skills[i] = new userSkill { skillId = int.Parse(SId[i].ToString()) , skillName = SName[i].ToString() };

                // if user add new skill that does not exist in table
                if (skillManager.GetById(skills[i].skillId) == null)
                {
                    Skill skill = new Skill { Id = skills[i].skillId, Name = skills[i].skillName };
                    skillManager.Add(skill);
                }

                UserSkill userskill = new UserSkill { UserId="1", SkillId= skills[i].skillId};
                
                userskillManager.Add(userskill);

             
               
            }

            return (null);


        }

        [HttpPost]
        public ActionResult AddPatents(PatentVM model)
        {
            if (ModelState.IsValid)
            {
                PatentManager patentnManager = Store.PatentManager;

                //patentnManager.Remove(patentnManager.GetAllBind().LastOrDefault());

                //int userId = (int.Parse(patentnManager.GetAllBind().LastOrDefault().UserId)) + 1;
                Patent patent = new Patent{ Title = model.Title, CountryName= model.Office , Number=model.PatentNo,Status=model.Status ,Date = new DateTime(model.Year, 4 , model.Day), Inventor = model.Inventor, Url = model.URL, Description = model.Description, UserId = "1" };

                patentnManager.Add(patent);
            }

            return (null);
        }
      
       
    }
    
    public class userSkill
    {
        public int skillId { get; set; }
        public string skillName { get; set;}
    }
}