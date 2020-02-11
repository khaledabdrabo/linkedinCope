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
    [Table("VolunteerExperience")]
    public class Volunteer
    {
        [Key]
        [Column(Order = 1)]
        [ForeignKey("Experience")]
        public int ExperienceId { get; set; }

        [Key]
        [Column(Order = 2)]
        [MaxLength(50)]
        public string Role { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public VolunteeringCause? VolunteeringCause { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }

        public virtual Experience Experience { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
