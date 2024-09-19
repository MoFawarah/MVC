namespace SchoolSystemCodeFirst.Models
{
    public class studentDetails
    {
        public int studentDetailsId { get; set; }

        public int StudentId { get; set; }

        // Navigation property
        public virtual Student Student { get; set; }
        public string fatherName { get; set; }

        public string fatherEmail { get; set; }

        public string fatherPhone { get; set; }
    }
}