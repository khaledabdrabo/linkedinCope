using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.MVC.LinkedIn.DbLayer.Entities
{
    [Table("CommentLike")]
    public class CommentLike
    {
        [Key]
        [Column(Order = 0)]
        [ForeignKey("Comment")]
        public int CommentId { get; set; }

        [Key]
        [Column(Order = 1)]
        [ForeignKey("User")]
        public int UserId { get; set; }

        public virtual Comment Comment { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
