using ITI.MVC.LinkedIn.DbLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ITI.MVC.LinkedIn.Web.Models.ViewModels
{
    public class CoursesVM
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Number is required")]
        public int Number { get; set; }

        public int ExperinceId { get; set; }

        public List<Experience> Experiences { get; set; }
    }

}