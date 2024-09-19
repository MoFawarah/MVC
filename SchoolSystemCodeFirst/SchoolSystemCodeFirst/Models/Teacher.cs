using System.Collections.Generic;

namespace SchoolSystemCodeFirst.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }

        public string TeacherName { get; set; }

        public int TeacherAge { get; set; }

        public virtual ICollection<Course> Courses { get; set; }  // 1-to-M relationship

    }
}