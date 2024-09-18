
using System.Data.Entity;

namespace SchoolSystemCodeFirst.Models

{

    public class SchoolContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Assignment> Assignments { get; set; }
    }
}