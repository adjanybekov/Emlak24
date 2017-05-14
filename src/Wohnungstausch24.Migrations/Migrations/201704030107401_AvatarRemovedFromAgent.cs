namespace Wohnungstausch24.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AvatarRemovedFromAgent : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Agent", "LogoOrAvatarId", "dbo.Wt24File");
            DropIndex("dbo.Agent", new[] { "LogoOrAvatarId" });
            DropColumn("dbo.Agent", "LogoOrAvatarId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Agent", "LogoOrAvatarId", c => c.Int());
            CreateIndex("dbo.Agent", "LogoOrAvatarId");
            AddForeignKey("dbo.Agent", "LogoOrAvatarId", "dbo.Wt24File", "Id");
        }
    }
}
