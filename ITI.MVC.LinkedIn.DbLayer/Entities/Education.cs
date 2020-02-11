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
        [Column(Order = 1)]
        [ForeignKey("Experience")]
        public int ExperienceId { get; set; }

        [Key]
        [Column(Order = 2)]
        [MaxLength(50)]
        public string Degree { get; set; }

        [Key]
        [Column(Order = 3)]
        [MaxLength(50)]
        public string FieldOfStudy { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public DateTime StartYear { get; set; }

        public DateTime EndYear { get; set; }

        [MaxLength(50)]
        public string Grade { get; set; }

        [MaxLength(255)]
        public string Activities { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        public virtual Experience Experience { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
