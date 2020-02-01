using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.MVC.LinkedIn.DbLayer.Entities
{
    public enum OrganizationType
    {
        organization,school
    }
    [Table("Organization")]
    public class Organization
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter valid name")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {1} characters long.", MinimumLength = 6)]

        public string Name { get; set; }
        public string Logo { get; set; }
        [Required(ErrorMessage = "OrganizationType required")]
        
        public OrganizationType Type { get; set; }

    }
}
