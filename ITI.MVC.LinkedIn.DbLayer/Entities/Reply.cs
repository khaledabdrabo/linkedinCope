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
        [ForeignKey("Text")]
        public int TextId { get; set; }

        [ForeignKey("Comment")]
        public int CommentId { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
        public virtual Text Text { get; set; }
        public virtual Comment Comment { get; set; }
        public virtual ICollection<ReplyLike> Likes { get; set; }
    }
}
