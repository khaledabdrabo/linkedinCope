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
    [Table("Patent")]
    public class Patent
    {
        [Key]
        [Column(Order = 0)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Number is required")]
        [Key]
        [Column(Order = 1)]
        public int Number { get; set; }

        [Key]
        [Column(Order = 2)]
        [ForeignKey("User")]
        public string UserId { get; set; }

        [Required]
        [ForeignKey("Country")]
        public string CountryName { get; set; }

        public string Inventor { get; set; }

        [Required]
        public PatentStatus Status { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? Date { get; set; }

        public string Url { get; set; }

        public string Description { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual Country Country { get; set; }
    }
}
