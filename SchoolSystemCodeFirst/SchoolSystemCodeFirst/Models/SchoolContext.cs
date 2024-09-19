
using System.Data.Entity;

namespace SchoolSystemCodeFirst.Models

{

    public class SchoolContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }   // Add Course
        public DbSet<studentDetails> StudentDetails { get; set; }  // Add StudentDetails
        public DbSet<Assignment> Assignments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configure one-to-one relationship between Student and StudentDetails
            modelBuilder.Entity<Student>()
                .HasOptional(s => s.StudentDetails)  // Optional: A Student can have or not have StudentDetails
                .WithRequired(sd => sd.Student);     // Required: StudentDetails must have a Student

            // Configure one-to-many relationship between Teacher and Course (if needed)
            modelBuilder.Entity<Teacher>()
                .HasMany(t => t.Courses)
                .WithRequired(c => c.Teacher)
                .HasForeignKey(c => c.TeacherId);

            base.OnModelCreating(modelBuilder);
        }
    }
}