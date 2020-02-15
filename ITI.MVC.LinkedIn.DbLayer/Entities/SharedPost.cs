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
        public int PostId { get; set; }
        public string UserId { get; set; }
        public int OriginalPostId { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual Post Post { get; set; }
        public virtual Post OriginalPost { get; set; }
    }
}
