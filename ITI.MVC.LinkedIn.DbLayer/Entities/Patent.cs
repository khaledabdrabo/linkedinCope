using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.MVC.LinkedIn.DbLayer.Entities
{
    public class Patent
    {
        [Key]
        [Column(Order = 0)]
        public String Title { get; set; }

        [Required]
        public List<Organization> Country { get; set; }

        [Required]
        public int Number { get; set; }

        public String Inventor { get; set; }

        [Required]
        public int Status { get; set; }


        public DateTime Date { get; set; }


        public String Url { get; set; }


        public String Description { get; set; }

        [Key]
        [Column(Order =1)]
        [ForeignKey("UserID")]
        public int UserId { get; set; }


        public virtual User UserID { get; set; }

    }
}
