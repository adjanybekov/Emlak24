namespace Wohnungstausch24.Migrations.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Step7Fixes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Listing", "PreferredAgeOfChildren", c => c.Int());
            DropColumn("dbo.Listing", "PrefferedAgeOfChildren");
        }

        public override void Down()
        {
            AddColumn("dbo.Listing", "PrefferedAgeOfChildren", c => c.Int());
            DropColumn("dbo.Listing", "PreferredAgeOfChildren");
        }
    }
}
