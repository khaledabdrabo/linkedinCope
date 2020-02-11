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
        [Key]
        [Column(Order = 0)]
        [StringLength(50, ErrorMessage = "The name can only be 2 to 50 characters long.", MinimumLength = 2)]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        
        [Key, Column(Order = 1)]
        [ForeignKey("Experience")]
        public int? ExperienceId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public DataType StartDate { get; set; }

        public DataType EndDate { get; set; }

        public string Creator { get; set; }

        public string Url { get; set; }

        public string Description { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual Experience Experience { get; set; }
    }
}
