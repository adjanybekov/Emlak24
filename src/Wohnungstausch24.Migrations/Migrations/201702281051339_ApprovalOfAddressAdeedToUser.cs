namespace Wohnungstausch24.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApprovalOfAddressAdeedToUser : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "ApprovalOfAddress", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "ApprovalOfAddress", c => c.String());
        }
    }
}
