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
    [Table("Organization")]
    public class Organization
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "The name can only be 2 to 50 characters long.", MinimumLength = 2)]
        public string Name { get; set; }
        public string Logo { get; set; }

        public OrganizationType Type { get; set; }

        public virtual ICollection<Work> WorkExperiences { get; set; }
        public virtual ICollection<Volunteer> VolunteerExperiences { get; set; }
        public virtual ICollection<UserCertification> UserCertifications { get; set; }
    }
}