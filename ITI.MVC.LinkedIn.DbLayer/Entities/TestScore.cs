using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.MVC.LinkedIn.DbLayer.Entities
{
    public class TestScore
    {

        [Key]
        [Column(Order = 0)]
        public String TestName { get; set; }
        
        public List<Organization> WorkExperienceId { get; set; }

        [Required]
        public int Score { get; set; }

        public DateTime TestDate { get; set; }
        
        public String Description { get; set; }

        [Key]
        [Column(Order = 1)]
        [ForeignKey("UserID")]
        public int UserId { get; set; }


        public virtual User UserID { get; set; }
    }
}
