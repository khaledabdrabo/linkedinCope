using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.MVC.LinkedIn.DbLayer.Entities
{
    [Table("Post")]
    public class Post
    {
        [Key]
        [ForeignKey("Text")]
        public int TextId { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
        public virtual Text Text { get; set; }

        [InverseProperty("Post")]
        public virtual SharedPost SharedPost { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }

        [InverseProperty("OriginalPost")]
        public virtual ICollection<SharedPost> Shares { get; set; }
        public virtual ICollection<PostLike> Likes { get; set; }
    }
}
