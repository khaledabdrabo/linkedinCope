using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.MVC.LinkedIn.DbLayer.Entities
{
    [Table("Project")]
    public class Project
    {
        [StringLength(50, ErrorMessage = "The name can only be 2 to 50 characters long.", MinimumLength = 2)]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        
        [ForeignKey("Experience")]
        public int? ExperienceId { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [ForeignKey("User")]
        public string UserId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? StartDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? EndDate { get; set; }

        public string Creator { get; set; }

        public string Url { get; set; }

        public string Description { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual Experience Experience { get; set; }
    }
}
