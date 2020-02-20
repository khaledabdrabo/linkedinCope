using ITI.MVC.LinkedIn.Store;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITI.MVC.LinkedIn.Web.Controllers
{
    [Authorize]
    public class FeedController : Controller
    {
        private DbStore store;

        public DbStore Store
        {
            get => store ?? HttpContext.GetOwinContext().Get<DbStore>();

            private set => store = value;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(User);
        }
    }
}