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
    public class UserSkill
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        
        [ForeignKey("Skill")]
        public int SkillId { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual Skill Skill { get; set; }
    }
}
