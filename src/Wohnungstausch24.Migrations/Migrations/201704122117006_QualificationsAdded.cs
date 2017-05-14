namespace Wohnungstausch24.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QualificationsAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Qualification",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AgentId = c.Int(nullable: false),
                        QualificationType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Agent", t => t.AgentId, cascadeDelete: true)
                .Index(t => t.AgentId);
            
            AlterColumn("dbo.Agent", "PositionInCompany", c => c.Int());
            AlterColumn("dbo.Agent", "FieldOfResponsibility", c => c.Int());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Qualification", "AgentId", "dbo.Agent");
            DropIndex("dbo.Qualification", new[] { "AgentId" });
            AlterColumn("dbo.Agent", "FieldOfResponsibility", c => c.Int(nullable: false));
            AlterColumn("dbo.Agent", "PositionInCompany", c => c.Int(nullable: false));
            DropTable("dbo.Qualification");
        }
    }
}
