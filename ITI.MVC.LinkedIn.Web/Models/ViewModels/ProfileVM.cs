using ITI.MVC.LinkedIn.DbLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITI.MVC.LinkedIn.Web.Models.ViewModels
{
    public class ProfileVM
    {
        public List<Experience> Experiences { get; set; }
        public List<Skill> Skills { get; set; }
        public List<string> AllCountry { get; set; }
        public int LastSkillId { get; set; }

    }
}