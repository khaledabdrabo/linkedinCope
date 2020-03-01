using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.MVC.LinkedIn.DbLayer.Entities
{
    [Table("Course")]
    public class Course
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Key]
        [Required(ErrorMessage = "Number is required")]
        public int Number { get; set; }

        [ForeignKey("Experience")]
        public int? ExperienceId { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual Experience Experience { get; set; }
    }
}
