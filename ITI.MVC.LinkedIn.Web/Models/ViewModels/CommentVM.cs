using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ITI.MVC.LinkedIn.Web.Models.ViewModels
{
    public class CommentVM
    {
        public int PostId { get; set; }

        [MaxLength(255, ErrorMessage = "a comment can contain a maximum of 255 characters")]
        public string CommentContent { get; set; }

        [FileExtensions(Extensions = "jpg,mp4,pdf", ErrorMessage = "An uploaded file can only be an image, video or pdf.")]
        public HttpPostedFileBase File { get; set; }
    }
}