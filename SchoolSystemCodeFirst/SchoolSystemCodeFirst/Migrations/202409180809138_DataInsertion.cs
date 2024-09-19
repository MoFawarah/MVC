namespace SchoolSystemCodeFirst.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class DataInsertion : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Teachers (TeacherName, TeacherAge) VALUES ('Ahmad', 22);");
        }

        public override void Down()
        {
        }
    }
}
