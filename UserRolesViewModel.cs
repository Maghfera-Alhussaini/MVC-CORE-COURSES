using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_CORE.Models.View_Models
{
    public class UserRolesViewModel
    {
        public string UserId { set; get; }
        public string UserName { get; set; }
        public List<RoleViewModel> Roles { set; get; }
    }
}
