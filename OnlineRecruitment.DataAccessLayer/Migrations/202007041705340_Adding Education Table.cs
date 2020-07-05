namespace OnlineRecruitment.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingEducationTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Educations",
                c => new
                    {
                        EducationId = c.Int(nullable: false, identity: true),
                        InstituteName = c.String(),
                        StudyDuration = c.Single(nullable: false),
                        StartYear = c.DateTime(nullable: false),
                        EndYear = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EducationId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Educations");
        }
    }
}
