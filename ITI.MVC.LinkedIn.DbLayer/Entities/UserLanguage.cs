using ITI.MVC.LinkedIn.DbLayer.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITI.MVC.LinkedIn.DbLayer.Entities
{
    [Table("UserLanguage")]
    public class UserLanguage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [ForeignKey("User")]
        public string UserId { get; set; }


        [ForeignKey("Language")]
        public int LanguageId { get; set; }

        public LaungaugeProficiency Proficiency { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual Language Language { get; set; }
    }
}