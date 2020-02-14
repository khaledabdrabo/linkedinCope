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
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Content { get; set; }

        [Required]
        public DateTime Time { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<SharedPost> Shares { get; set; }
        public virtual ICollection<PostLike> Likes { get; set; }
        public virtual ICollection<Image> Images { get; set; }
    }
}
