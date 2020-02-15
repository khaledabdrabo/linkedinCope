using ITI.MVC.LinkedIn.DbLayer.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.MVC.LinkedIn.DbLayer.Entities
{
    [Table("WorkExperience")]
    public class Work
    {
        [Key]
        [ForeignKey("Experience")]
        public int ExperienceId { get; set; }

        [ForeignKey("Country")]
        public string CountryName { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        [StringLength(50, ErrorMessage = "The title can only be 2 to 50 characters long.", MinimumLength = 2)]
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        public EmploymentType? EmploymentType { get; set; }

        [StringLength(50, ErrorMessage = "The name can only be 2 to 50 characters long.", MinimumLength = 2)]
        [Required(ErrorMessage = "Headline is required")]
        public string Headline { get; set; }

        public virtual Experience Experience { get; set; }
        public virtual Country Country { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
