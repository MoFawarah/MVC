namespace SchoolSystemCodeFirst.Migrations
{
    using SchoolSystemCodeFirst.Models;
    using System.Data.Entity.Migrations;


    internal sealed class Configuration : DbMigrationsConfiguration<SchoolSystemCodeFirst.Models.SchoolContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SchoolContext context)
        {



            // Adding new Student records
            context.Students.AddOrUpdate(
            s => s.StudentName, // Assuming StudentName should be unique for demo purposes
            new Student { StudentName = "John Doe", StudentAge = 20 },
            new Student { StudentName = "Jane Smith", StudentAge = 22 }
        );


            context.SaveChanges();
        }
    }
}
