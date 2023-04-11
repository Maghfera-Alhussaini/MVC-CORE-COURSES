using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_CORE.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Required, MaxLength(100)]
        public string firstName { get; set; }

        [Required, MaxLength(100)]
        public string lastName { get; set; }
        public byte[] picture { get; set; }
    }
}
