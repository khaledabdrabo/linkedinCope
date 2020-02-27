using ITI.MVC.LinkedIn.DbLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace ITI.MVC.LinkedIn.Web.Models.ViewModels
{
    public class SignUpVM
    {
        [Required(ErrorMessage ="Email is required")]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required")]
        [StringLength(50, ErrorMessage = "The Password Must Be 8 chars long.", MinimumLength = 8)]
        public string Password{ get; set; }

        [Required(ErrorMessage = "FirstName is required")]
        [StringLength(10, ErrorMessage = "The title can only be 2 to 10 characters long.", MinimumLength = 2)]
        public string FirstName{ get; set; }

        [StringLength(10, ErrorMessage = "The title can only be 2 to 10 characters long.", MinimumLength = 2)]
        [Required(ErrorMessage = "LastName is required")]
        public string LastName{ get; set; }

        [Required(ErrorMessage = "Country is required")]
        public string Country{ get; set; }

        public int? PostalCode{ get; set; }

        [Required(ErrorMessage = "Enter the Birth date.")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public List<Country> Countries { get; set; }

        public string ImagePath { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
    }
}