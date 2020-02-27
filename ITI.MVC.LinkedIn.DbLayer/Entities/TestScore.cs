using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.MVC.LinkedIn.DbLayer.Entities
{
    [Table("TestScore")]
    public class TestScore
    {
        [Key]
        public int Id { get; set; }

        public string TestName { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        [ForeignKey("Experience")]
        public int? ExperienceId { get; set; }

        [Required(ErrorMessage = "Score is required")]
        public string Score { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? TestDate { get; set; }
        
        public string Description { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual Experience Experience { get; set; }
    }
}
