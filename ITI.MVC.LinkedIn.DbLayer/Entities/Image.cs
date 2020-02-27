using ITI.MVC.LinkedIn.DbLayer.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.MVC.LinkedIn.DbLayer.Entities
{
    [Table("Image")]
    public class Image
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Url { get; set; }

        [ForeignKey("Text")]
        public int? TextId { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        public ImageRole ImageRole { get; set; }

        public virtual Text Text { get; set; }
        public ApplicationUser User { get; set; }
    }
}
