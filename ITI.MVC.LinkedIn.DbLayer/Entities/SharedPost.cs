using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.MVC.LinkedIn.DbLayer.Entities
{
    [Table("SharedPost")]
    public class SharedPost
    {
        [Key]
        [ForeignKey("Post")]
        public int PostId { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        [ForeignKey("OriginalPost")]
        public int OriginalPostId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [InverseProperty("SharedPost")]
        public virtual Post Post { get; set; }

        [InverseProperty("Shares")]
        public virtual Post OriginalPost { get; set; }
    }
}
