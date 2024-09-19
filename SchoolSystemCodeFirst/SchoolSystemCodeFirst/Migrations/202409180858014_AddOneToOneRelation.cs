namespace SchoolSystemCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOneToOneRelation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.studentDetails",
                c => new
                    {
                        studentDetailsId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                        fatherName = c.String(),
                        fatherEmail = c.String(),
                        fatherPhone = c.String(),
                    })
                .PrimaryKey(t => t.studentDetailsId)
                .ForeignKey("dbo.Students", t => t.studentDetailsId)
                .Index(t => t.studentDetailsId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.studentDetails", "studentDetailsId", "dbo.Students");
            DropIndex("dbo.studentDetails", new[] { "studentDetailsId" });
            DropTable("dbo.studentDetails");
        }
    }
}
