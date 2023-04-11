using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_CORE.Models
{
    public partial class Profile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Image { get; set; }
        public int? UserId { get; set; }
     
        public DateTime? JoinData { get; set; }
        [NotMapped]
        public IFormFile File { get; set; }

    }
}
