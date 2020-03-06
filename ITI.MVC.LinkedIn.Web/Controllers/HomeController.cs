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
            get {return store ?? HttpContext.GetOwinContext().Get<DbStore>(); }

             set { store = value; }
        }

        public ActionResult Index()
        {
            return View();
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
}