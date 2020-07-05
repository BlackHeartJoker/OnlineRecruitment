namespace OnlineRecruitment.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingStackTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Stacks",
                c => new
                    {
                        StackId = c.Int(nullable: false, identity: true),
                        Competence = c.Single(nullable: false),
                        SkillId = c.Int(),
                    })
                .PrimaryKey(t => t.StackId)
                .ForeignKey("dbo.Skills", t => t.SkillId)
                .Index(t => t.SkillId);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stacks", "SkillId", "dbo.Skills");
            DropIndex("dbo.Stack", new[] { "SkillId" });
            DropTable("dbo.Stack");
        }
    }
}
