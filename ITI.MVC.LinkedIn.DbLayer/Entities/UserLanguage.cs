using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITI.MVC.LinkedIn.DbLayer.Entities
{
    [Table("UserLanguage")]
    public class UserLanguage
    {
        [Key]
        [Column(Order = 1)]
        [ForeignKey("User")]
        public string UserId { get; set; }

        [Key]
        [Column(Order = 2)]
        [ForeignKey("Language")]
        public int LanguageId { get; set; }

        public int Proficiency { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual Language Language { get; set; }
    }
}