using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.MVC.LinkedIn.DbLayer.Entities
{
    [Table("Certification")]
    public class Certification
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "The name must be between 100 and 50 characters", MinimumLength = 2)]
        public string Name { get; set; }

        public virtual ICollection<UserCertification> UserCertifications { get; set; }
    }
}
