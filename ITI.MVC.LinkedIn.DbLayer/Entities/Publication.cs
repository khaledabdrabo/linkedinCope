using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.MVC.LinkedIn.DbLayer.Entities
{
    [Table("Publication")]
    public class Publication
    {
        [Column(Order = 0)]
        [StringLength(50, ErrorMessage = "The title can only be 2 to 50 characters long.", MinimumLength = 2)]
        [Required(ErrorMessage = "Title is required")]
        public int Title { get; set; }

        [Key]
        [Column(Order = 1)]
        public int UserId { get; set; }

        public string Publisher { get; set; }

        public DataType Date { get; set; }

        public string Author { get; set; }

        public string Url { get; set; }

        public string Description { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
