using ITI.MVC.LinkedIn.Web.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITI.MVC.LinkedIn.Web.Models.ViewModels
{
    public class PublicationVM
    {
           
        public MonthEnum Month { get; set; }
        public int Year { get; set; }
        public int Day { get; set; }
    }
}