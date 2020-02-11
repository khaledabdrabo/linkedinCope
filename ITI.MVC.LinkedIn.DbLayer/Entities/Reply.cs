using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.MVC.LinkedIn.DbLayer.Entities
{
    [Table("Reply")]
    public class Reply
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Comment")]
        public int CommentId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Content { get; set; }

        public DateTime TimeStamp { get; set; }

        public virtual Comment Comment { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<ReplyLike> Likes { get; set; }
    }
}
