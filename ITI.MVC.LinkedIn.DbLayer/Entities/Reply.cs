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
    class Reply
    {
        [Key]
        [Column(Order=1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Key]
        [Column(Order = 2)]
        [ForeignKey("Comment")]
        public int CommentID { get; set; }
        [Key]
        [Column(Order = 3)]
        [ForeignKey("User")]
        public int UserID { get; set; }
        [Required]
        [MaxLength(250)]
        public string Content { get; set; }
        public DateTime TimeStamp { get; set; }

        //public virtual Comment Comment { get; set; }
        //public virtual User User { get; set; }

    }
}
