namespace OnlineRecruitment.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingEmployerTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        EmployerId = c.Int(nullable: false),
                        EmployerName = c.String(),
                        PersonId = c.Int(nullable: false),
                        PersonName = c.String(),
                        Designation = c.String(),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Employers", t => t.EmployerId, cascadeDelete: true)
                //.ForeignKey("dbo.Person",t=>t.PersonId)
                .Index(t => t.EmployerId);

            AddForeignKey("dbo.Employees", "PersonId", "dbo.Person", "PersonId");

            CreateTable(
                "dbo.Employers",
                c => new
                    {
                        EmployerId = c.Int(nullable: false, identity: true),
                        EmployerName = c.String(),
                        Description = c.String(),
                        EstablishmentDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EmployerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "EmployerId", "dbo.Employers");
            DropIndex("dbo.Employees", new[] { "EmployerId" });
            DropTable("dbo.Employers");
            DropTable("dbo.Employees");
        }
    }
}
