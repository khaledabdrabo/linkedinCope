using ITI.MVC.LinkedIn.DbLayer.Entities;
using ITI.MVC.LinkedIn.Web.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace ITI.MVC.LinkedIn.Web.Models.ViewModels
{
    public class WorkExperinceVM
    {
        public Work WorkExperince { get; set; }
        public MonthEnum StartMonth { get; set; }
        public int StartYear { get; set; }
        public MonthEnum? EndMonth { get; set; }
        public int? EndYear { get; set; }
        [Required(ErrorMessage ="company is required")]
        public string Organization_name { get; set; }
        
    }
}