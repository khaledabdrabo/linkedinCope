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
        [Column(Order = 0)]
        [ForeignKey("Experience")]
        public int ExperienceId { get; set; }

        [ForeignKey("Country")]
        public int? CountryId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50, ErrorMessage = "The title can only be 2 to 50 characters long.", MinimumLength = 2)]
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        public EmploymentType? EmploymentType { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        [StringLength(50, ErrorMessage = "The name can only be 2 to 50 characters long.", MinimumLength = 2)]
        [Required(ErrorMessage = "Headline is required")]
        public string Headline { get; set; }

        public virtual Experience Experience { get; set; }
        public virtual Country Location { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
