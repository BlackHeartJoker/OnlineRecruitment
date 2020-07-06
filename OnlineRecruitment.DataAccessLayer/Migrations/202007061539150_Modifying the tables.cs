namespace OnlineRecruitment.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modifyingthetables : DbMigration
    {
        public override void Up()
        {
            RenameTable("dbo.dbo.People", "Person");
            AddColumn("dbo.Employers", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employers", "Email");
        }
    }
}
