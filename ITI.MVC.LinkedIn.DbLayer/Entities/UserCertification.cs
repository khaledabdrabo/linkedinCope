using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.MVC.LinkedIn.DbLayer.Entities
{
    [Table("UserCertification")]
    class UserCertification
    {
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Key]
        [Column(Order = 2)]
        [ForeignKey("User")]
        public int UserID { get; set; }
        [Key]
        [Column(Order = 3)]
        [ForeignKey("Organization")]
        public int OrganizationID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        [MaxLength(250)]
        public string CredentialId { get; set; }
        [MaxLength(250)]
        public string CredentialUrl { get; set; }

        //public virtual User User { get; set; }
        //public virtual Organization Organization { get; set; }



    }
}
