using System;
using System.Collections.Generic;

namespace MVC_CORE.Models
{
    public partial class Video
    {
      

        public int Id { get; set; }
        public string Duration { get; set; }
        public string Source { get; set; }
        public int Rate { get; set; }
        public int? Num { get; set; }
        public int? CourseId { get; set; }

        public Course Course { get; set; }
        public ICollection<Comments> Comments { get; set; }
    }
}
