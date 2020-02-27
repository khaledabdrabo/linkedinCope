using ITI.MVC.LinkedIn.DbLayer.Entities;
using ITI.MVC.LinkedIn.DbLayer.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace ITI.MVC.LinkedIn.Web.Models.ViewModels
{
    public class LanguageVM
    {
        public LaungaugeProficiency Proficiency { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "The name can only be 2 to 50 characters long.", MinimumLength = 2)]
        public string LanguageName { get; set; }
        public int? LanguageId { get; set; }
        public int? id { get; set; }
        public int? userlanguageCount { get; set; }
    }


}