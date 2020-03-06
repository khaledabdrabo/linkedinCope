using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;

namespace ITI.MVC.LinkedIn.Web.Models.ViewModels
{
    public class CreatePostVM
    {
        [MaxLength(255, ErrorMessage = "a post can contain a maximum of 255 characters")]
        public string PostContent { get; set; }

        public HttpPostedFileBase UploadedFile { get; set; }
    }
}