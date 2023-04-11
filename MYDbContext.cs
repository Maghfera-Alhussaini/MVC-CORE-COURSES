using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_CORE.Models
{
    public class MYDbContext : DbContext
    {
        internal object Comments;

       

        public MYDbContext(DbContextOptions<MYDbContext> options)
            : base(options)
        {

        }

        public DbSet<Profile> profiles { get; set; }
        public DbSet<Video> videos { get; set; }
        public DbSet<Comments> comments { get; set; }
        public DbSet<Course> courses { get; set; }
        public DbSet<TaskQuestion> taskQustions { get; set; }
        public DbSet<Book> books { get; set; }
        public DbSet<Section> sections { get; set; }
        public DbSet<Topic> topics { get; set; }

        



    }
}
