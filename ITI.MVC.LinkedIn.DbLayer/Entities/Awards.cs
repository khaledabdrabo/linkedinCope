using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.MVC.LinkedIn.DbLayer.Entities
{
    public class Awards
    {
        [Key]
        [Column(Order = 0)]
        public String Title { get; set; }

        public List<Organization> WorkExperienceId { get; set; }

        public String Issuer { get; set; }

        public DateTime IssueDate { get; set; }

        [Required]
        public String Description { get; set; }
        
        [Key]
        [Column(Order = 1)]
        [ForeignKey("UserID")]
        public int UserId { get; set; }


        public virtual User UserID { get; set; }
    }
}
