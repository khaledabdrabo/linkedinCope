using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.MVC.LinkedIn.DbLayer.Entities
{
    [Table("Experience")]
    public class Experience
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("Organization")]
        public int OrganizationId { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual Work WorkExperience { get; set; }
        public virtual Volunteer VolunteerExperience { get; set; }
        public virtual Education EducationExperience { get; set; }
        public virtual ICollection<Award> Awards { get; set; }
    }
}
