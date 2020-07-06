namespace OnlineRecruitment.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedTablename : DbMigration
    {
        public override void Up()
        {
            RenameTable("person", "people");
            RenameTable(name: "dbo.People", newName: "Person");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Person", newName: "People");
        }
    }
}
