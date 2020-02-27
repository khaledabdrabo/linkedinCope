using ITI.MVC.LinkedIn.DbLayer.Entities;
using ITI.MVC.LinkedIn.Web.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ITI.MVC.LinkedIn.Web.Models.ViewModels
{
    public class HonorVM
    {
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        public string Issuer { get; set; }

        public string Description { get; set; }

        public int? Year { get; set; }
        public MonthEnum? Month { get; set; }

        public int? AwardsCount { get; set; }

        public DateTime? IssueDate { get; set; }
        public List<Experience> Experiences { get; set; }
        public int ExperinceId { get; set; }
        public int? id { get; set; }
    }
}