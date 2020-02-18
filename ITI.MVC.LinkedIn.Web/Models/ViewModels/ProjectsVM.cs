using ITI.MVC.LinkedIn.Web.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITI.MVC.LinkedIn.Web.Models.ViewModels
{
    public class ProjectsVM
    {
        public MonthEnum StartMonth { get; set; }
        public int StartYear { get; set; }
        public MonthEnum EndMonth { get; set; }
        public int EndYear { get; set; }
    }
}