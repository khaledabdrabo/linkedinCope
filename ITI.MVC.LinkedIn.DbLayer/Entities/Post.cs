using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.MVC.LinkedIn.DbLayer.Entities
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public String Content { get; set; }

        [Required]
        public DateTime Time { get; set; }
    }
}
