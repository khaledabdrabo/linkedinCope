using ITI.MVC.LinkedIn.DbLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITI.MVC.LinkedIn.Web.Models.ViewModels
{
    public class PostVM
    {
        public Post Post { get; set; }
        public ApplicationUser User { get; set; }
    }
}