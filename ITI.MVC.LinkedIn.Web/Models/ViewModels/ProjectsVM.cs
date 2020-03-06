using ITI.MVC.LinkedIn.DbLayer.Entities;
using ITI.MVC.LinkedIn.Web.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ITI.MVC.LinkedIn.Web.Models.ViewModels
{
    public class ProjectsVM
    {
        [StringLength(50, ErrorMessage = "The name can only be 2 to 50 characters long.", MinimumLength = 2)]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        public MonthEnum? StartMonth { get; set; }

        public int? StartYear { get; set; }

        public MonthEnum? EndMonth { get; set; }

        public int? EndYear { get; set; }

        public string Creator { get; set; }

        public string Url { get; set; }

        public string Description { get; set; }

        public int ExperinceId { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public int? id { get; set; }
        public int? ProjectsCount { get; set; }
        public List<Experience> Experiences { get; set; }
    }
}