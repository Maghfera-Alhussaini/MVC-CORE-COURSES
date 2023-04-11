using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MVC_CORE.Models
{
    public partial class Comments
    {
        [Required]
        public int Id { get; set; }
               
        public string Contents { get; set; } 
        public int? VideoId { get; set; } 
        public string Email { get; set; }

        public Video Video { get; set; }

        [ForeignKey("commentby")]
        public string useremail { get; set; }
    }
}
