using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.MVC.LinkedIn.DbLayer.Entities
{
    [Table("Education")]
    public class Education
    {
        [Key]
        [ForeignKey("Experience")]
        public int ExperienceId { get; set; }

        [MaxLength(50)]
        public string Degree { get; set; }

        [MaxLength(50)]
        public string FieldOfStudy { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        [MaxLength(50)]
        public string Grade { get; set; }

        [MaxLength(255)]
        public string Activities { get; set; }

        public virtual Experience Experience { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
