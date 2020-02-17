using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITI.MVC.LinkedIn.Web.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        public ActionResult UserProfile()
        {
            return View();
        }
    }
}