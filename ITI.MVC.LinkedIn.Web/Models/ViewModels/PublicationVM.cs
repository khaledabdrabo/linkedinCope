using ITI.MVC.LinkedIn.Web.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ITI.MVC.LinkedIn.Web.Models.ViewModels
{
    public class PublicationVM
    {

        [Required(ErrorMessage = "Name is required")]
        public string Title { get; set; }

        public string Publisher { get; set; }

        public MonthEnum Month { get; set; }
        public int Year { get; set; }
        public int Day { get; set; }
        public string Author { get; set; }
        public string URL { get; set; }
        public string Description { get; set; }
    }
}