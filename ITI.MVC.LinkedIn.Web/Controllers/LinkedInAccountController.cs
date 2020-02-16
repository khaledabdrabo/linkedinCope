using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITI.MVC.LinkedIn.Web.Controllers
{
    public class LinkedInAccountController : Controller
    {
        // GET: LinkedInAccount
        public ActionResult SignUp()
        {
            return View();
        }
    }
}