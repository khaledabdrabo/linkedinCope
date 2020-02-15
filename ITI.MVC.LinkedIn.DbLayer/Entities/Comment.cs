using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.MVC.LinkedIn.DbLayer.Entities
{
    [Table("Comment")]
    public class Comment
    {
        [Key]
        [ForeignKey("Text")]
        public int TextId { get; set; }

        [ForeignKey("Post")]
        public int PostId { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
        public virtual Text Text { get; set; }
        public virtual Post Post { get; set; }
        public virtual ICollection<Reply> Replies { get; set; }
        public virtual ICollection<CommentLike> Likes { get; set; }
    }
}
