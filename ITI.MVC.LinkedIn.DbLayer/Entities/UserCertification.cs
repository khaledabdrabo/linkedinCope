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
    public class UserCertification
    {
        [Key]
        [Column(Order = 1)]
        [ForeignKey("User")]
        public string UserId { get; set; }

        [Key]
        [Column(Order = 2)]
        [ForeignKey("Certification")]
        public int CertificationId { get; set; }

        [ForeignKey("Organization")]
        public int OrganizationId { get; set; }

        public DateTime? IssueDate { get; set; }

        public DateTime? ExpirationDate { get; set; }

        [MaxLength(250)]
        public string CredentialId { get; set; }

        [MaxLength(250)]
        public string CredentialUrl { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual Certification Certification { get; set; }
    }
}
