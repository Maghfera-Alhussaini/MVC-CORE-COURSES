using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_CORE.Models
{
    public class Topic
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("Section")]
        public int? SectionId { get; set; }
        public Section Section { get; set; }
    }
}
