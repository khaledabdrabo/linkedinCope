using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.MVC.LinkedIn.DbLayer.Entities
{
    [Table("Language")]
   public class Language
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter valid name")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {1} characters long.", MinimumLength = 6)]

        public string Name { get; set; }

    }
}
