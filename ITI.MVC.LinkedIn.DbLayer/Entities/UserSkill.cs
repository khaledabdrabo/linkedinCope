using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.MVC.LinkedIn.DbLayer.Entities
{
    [Table("UserSkill")]
    class UserSkill
    {
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Key]
        [Column(Order = 2)]
        [ForeignKey("User")]
        public int UserID { get; set; }
        [Key]
        [Column(Order = 3)]
        [ForeignKey("Skill")]
        public int SkillID { get; set; }

        //public virtual User User { get; set; }
        //public virtual Skill Skill { get; set; }

    }
}
