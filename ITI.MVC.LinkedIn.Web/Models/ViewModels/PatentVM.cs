

using ITI.MVC.LinkedIn.DbLayer.Enums;
using ITI.MVC.LinkedIn.Web.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ITI.MVC.LinkedIn.Web.Models.ViewModels
{
   
    public class PatentVM
    {
        public List<string> AllCountry;
        //public PatentVM(List<string> country)
        //{
        //    AllCountry = country;
        //}
        [Required(ErrorMessage = "Name is required")]
        public string Title { get; set; }

        public string Office { get; set; }

        public int PatentNo { get; set; }
        public string Inventor { get; set; }

        public PatentStatus Status { get; set; }

        public MonthEnum Month { get; set; }
        public int Year { get; set; }
        public int Day { get; set; }
        public string URL { get; set; }
        public string Description { get; set; }

        
    }
}