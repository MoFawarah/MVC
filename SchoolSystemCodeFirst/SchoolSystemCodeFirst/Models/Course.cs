namespace SchoolSystemCodeFirst.Models
{
    public class Course
    {
        public int CourseId { get; set; }

        public string CourseName { get; set; }

        public string CourseDescription { get; set; }

        public int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }


    }
}