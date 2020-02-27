using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITI.MVC.LinkedIn.DbLayer.Entities
{
    [Table("Country")]
    public class Country
    {
        [Key]
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "The name can only be 2 to 50 characters long.", MinimumLength = 2)]
        public string Name { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }
        public virtual ICollection<Work> WorkExperiences { get; set; }
        public virtual ICollection<Patent> Patents { get; set; }
    }
}