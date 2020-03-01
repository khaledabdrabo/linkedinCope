using ITI.MVC.LinkedIn.Store;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITI.MVC.LinkedIn.Web.Controllers
{
    public class HomeController : Controller
    {
        private DbStore store;

        public DbStore Store 
        {
            get => store ?? HttpContext.GetOwinContext().Get<DbStore>();

            private set => store = value;
        }

        public ActionResult Index()
        {
            //List<string> list1 = new List<string> { "Engineering", "Business Development", "Finance", "Administrative Assistant", "Retail Associate", "Customer Service", "Operations", "Information Technology", "Marketing", "Human Resources" };

            data data = new data();
            data.list1 = new List<string> { "Development", "Engineering", "Finance", "Finance", "Human Resources", "Marketing", "Information Technology" };
            data.topic = new List<string> { "Training and Education", "IT Help Desk", "Business Analysis and Strategy", "Finance and Accounting", "Career Development" };
            data.general = new List<string> { "Sign Up", "Help Center", "About", "Press", "Blog", "Careers", "Developers" };
            data.Browse = new List<string> { "Learning", "Jobs", "Salary", "Mobile", "ProFinder" };
            data.business = new List<string> { "Talent", "Marketing", "Sales", "Learning" };
            data.directories = new List<string> { "Members", "Jobs", "Companies", "Salaries", "Universities", "Featured", "Learning", "Posts" };
            data.contact = new List<string> { "About", "User Agreement", "Privacy policy", "Cookie Policy", "Copyright Policy", "Brand Policy", "Guest Controls", "Community Guidelines" };
            data.lang = new List<string> { "English", "Greek", "French", "Japanese", "Russian" };


            return View(data);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


    }

    public class data
    {

        public List<string> list1;
        public List<string> topic;
        public List<string> general;
        public List<string> Browse;
        public List<string> business;
        public List<string> directories;
        public List<string> contact;
        public List<string> lang;
    }
}