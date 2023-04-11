using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_CORE.Models
{
    public class Section
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Topic> Topic { get; set; }
    }
}
