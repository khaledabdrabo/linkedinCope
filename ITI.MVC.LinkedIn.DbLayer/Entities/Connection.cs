using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.MVC.LinkedIn.DbLayer.Entities
{
    [Table("Connection")]
    public class Connection
    {
        [Key]
        [Column(Order = 0)]
        [ForeignKey("Sender")]
        public string SenderId { get; set; }

        [Key]
        [Column(Order = 1)]
        [ForeignKey("Receiver")]
        public string ReceiverId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? StartDate { get; set; }

        public virtual ApplicationUser Sender { get; set; }
        public virtual ApplicationUser Receiver { get; set; }
    }
}
