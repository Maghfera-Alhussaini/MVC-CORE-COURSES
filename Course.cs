using System;
using System.Collections.Generic;

namespace MVC_CORE.Models
{
    public partial class Course
    {
        public int Id { get; set; }
        public int? Number { get; set; }
        public string Title { get; set; }
        public string Des { get; set; }

        public ICollection<Video> Video { get; set; }
    }
}
