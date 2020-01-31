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
    [Table("VolunteerExperience")]
    public class VolunteerExperience
    {
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        // ana zwdt da 3shan afrd user create work experince le nfs el orgnization mrten 
        public int ID { get; set; }
        [Key]
        [Column(Order = 2)]
        [ForeignKey("User")]
        public int UserID { get; set; }
        [Key]
        [Column(Order = 3)]
        [ForeignKey("Organization")]
        public int OrganizationID { get; set; }
        [MaxLength(50)]
        public string Role{ get; set; }

        public Cause? Cause{ get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [MaxLength(250)]
        public string Description { get; set; }

        //public virtual User User { get; set; }
        //public virtual Organization Organization { get; set; }
    }
}
