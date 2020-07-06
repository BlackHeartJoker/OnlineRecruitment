namespace OnlineRecruitment.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changingname : DbMigration
    {
        public override void Up()
        {
            RenameTable("[dbo].[dbo.Person]", "Person");
        }
        
        public override void Down()
        {
        }
    }
}
