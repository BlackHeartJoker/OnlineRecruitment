namespace OnlineRecruitment.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingProjectsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        ProjectName = c.String(),
                        Duration = c.Single(nullable: false),
                        Description = c.String(),
                        Role = c.String(),
                        Designation = c.String(),
                    })
                .PrimaryKey(t => t.ProjectId);
            
            AddColumn("dbo.Skills", "ProjectId", c => c.Int());
            CreateIndex("dbo.Skills", "ProjectId");
            AddForeignKey("dbo.Skills", "ProjectId", "dbo.Projects", "ProjectId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Skills", "ProjectId", "dbo.Projects");
            DropIndex("dbo.Skills", new[] { "ProjectId" });
            DropColumn("dbo.Skills", "ProjectId");
            DropTable("dbo.Projects");
        }
    }
}
