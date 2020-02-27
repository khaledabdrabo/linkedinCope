using ITI.MVC.LinkedIn.DbLayer.Entities;
using ITI.MVC.LinkedIn.Store;
using ITI.MVC.LinkedIn.Web.Models.ViewModels;
using Microsoft.AspNet.Identity.Owin;
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

namespace ITI.MVC.LinkedIn.Web.Controllers
{
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
        public ActionResult UserProfile( string userId)
       {
            string id=userId;
            if (userId == null)
            {
                id = User.Identity.GetUserId();
            }
            var user = Store.ApplicationUserManager.FindById(User.Identity.GetUserId());
            ViewBag.getAllEperinec = Store.WorkManager.GetAll().Include(e=>e.Organization).Include(e=>e.Experience).Where(ex=>ex.UserId== id).ToList();
             ViewBag.imag=user.Images.ToList()[0].Url.Replace("C:\\Users\\khaled abdrabo\\Desktop\\LatestVersion\\newversion\\iti-mvc-linkedin\\ITI.MVC.LinkedIn.Web\\Images\\", "");
            ViewBag.name=user.FirstName + user.LastName;
            ViewBag.country=user.CountryName;
            ViewBag.connection = Store.ConnectionManager.GetAllBind().Where(c => c.SenderId == id ||  c.ReceiverId == id).Count();
            
            ViewBag.getAllEDucation = Store.EducationManager.GetAll().Include(e => e.Experience).Where(ex => ex.UserId == id).ToList();
            ViewBag.getAllCertificates = Store.UserCertificationManager.GetAll().Include(e => e.Certification).Where(c => c.UserId == id).ToList();
            ViewBag.getAllVolunteers = Store.VolunteerManager.GetAll().Include(v => v.Experience).Where(v => v.UserId == id).ToList();

            return View();
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