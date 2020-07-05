namespace OnlineRecruitment.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingPostTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostId = c.Int(nullable: false, identity: true),
                        EmployerName = c.String(),
                        EmployerDescription = c.String(),
                        ExperienceLevel = c.Int(nullable: false),
                        EmployerDuration = c.Int(nullable: false),
                        Location = c.String(),
                        JobDescription = c.String(),
                        isEnabled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PostId);
            
            AddColumn("dbo.Skills", "PostId", c => c.Int());
            CreateIndex("dbo.Skills", "PostId");
            AddForeignKey("dbo.Skills", "PostId", "dbo.Posts", "PostId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Skills", "PostId", "dbo.Posts");
            DropIndex("dbo.Skills", new[] { "PostId" });
            DropColumn("dbo.Skills", "PostId");
            DropTable("dbo.Posts");
        }
    }
}
