using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.MVC.LinkedIn.DbLayer.Entities
{
    [Table("ConnectionRequest")]
    public class ConnectionRequest
    {
        [Key]
        [Column(Order = 0)]
        [ForeignKey("Sender")]
        public string SenderId { get; set; }

        [Key]
        [Column(Order = 1)]
        [ForeignKey("Receiver")]
        public string ReceiverId { get; set; }

        public virtual ApplicationUser Sender { get; set; }
        public virtual ApplicationUser Receiver { get; set; }
    }
}
