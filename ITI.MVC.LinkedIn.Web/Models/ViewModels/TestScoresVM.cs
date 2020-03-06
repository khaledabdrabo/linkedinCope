using ITI.MVC.LinkedIn.DbLayer.Entities;
using ITI.MVC.LinkedIn.Web.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ITI.MVC.LinkedIn.Web.Models.ViewModels
{
    public class TestScoresVM
    {
        public int? Year { get; set; }
        public MonthEnum? Month { get; set; }

        public string TestName { get; set; }


        [Required(ErrorMessage = "Score is required")]
        public string Score { get; set; }

        public int? TestScoreCount { get; set; }

        public DateTime? TestDate { get; set; }

        public string Description { get; set; }
        public List<Experience> Experiences { get; set; }
        public int ExperinceId { get; set; }
        public int id { get; set; }
    }
}