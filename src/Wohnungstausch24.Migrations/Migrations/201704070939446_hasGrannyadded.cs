namespace Wohnungstausch24.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hasGrannyadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Listing", "HasGrannyPart", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Listing", "HasGrannyPart");
        }
    }
}
