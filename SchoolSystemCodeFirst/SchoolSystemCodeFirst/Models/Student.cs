namespace SchoolSystemCodeFirst.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        public string StudentName { get; set; }

        public int StudentAge { get; set; }


        // Navigation property for one-to-one relationship
        public virtual studentDetails StudentDetails { get; set; }
    }


}