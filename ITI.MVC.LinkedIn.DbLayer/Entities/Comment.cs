using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.MVC.LinkedIn.DbLayer.Entities
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public String Content { get; set; }

        [Required]
        public DateTime Time { get; set; }

        [ForeignKey("PostID")]
        public int PostId { get; set; }

        [ForeignKey("UserID")]
        public int UserId { get; set; }


        public virtual Post PostID { get; set; }
        public virtual User UserID { get; set; }
    }
}
