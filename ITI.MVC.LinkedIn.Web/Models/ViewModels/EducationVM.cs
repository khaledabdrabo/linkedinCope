using ITI.MVC.LinkedIn.DbLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITI.MVC.LinkedIn.Web.Models.ViewModels
{
    public class EducationVM
    {
        public Education Education { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }
    }
}