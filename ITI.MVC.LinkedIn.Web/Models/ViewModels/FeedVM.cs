using ITI.MVC.LinkedIn.DbLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITI.MVC.LinkedIn.Web.Models.ViewModels
{
    public class FeedVM
    {
        public ApplicationUser User { get; set; }
        public List<Post> Posts { get; set; }
        public List<SharedPost> SharedPosts { get; set; }
    }
}