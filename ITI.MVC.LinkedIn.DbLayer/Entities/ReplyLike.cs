using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.MVC.LinkedIn.DbLayer.Entities
{
    [Table("ReplyLike")]
    public class ReplyLike
    {
        [Key]
        [Column(Order = 0)]
        [ForeignKey("Reply")]
        public int ReplyId { get; set; }

        [Key]
        [Column(Order = 1)]
        [ForeignKey("User")]
        public string UserId { get; set; }

        public virtual Reply Reply { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
