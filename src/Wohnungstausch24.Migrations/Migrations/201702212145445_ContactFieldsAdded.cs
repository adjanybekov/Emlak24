namespace Wohnungstausch24.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContactFieldsAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Title", c => c.String());
            AddColumn("dbo.AspNetUsers", "SalutationMessage", c => c.String());
            AddColumn("dbo.AspNetUsers", "CompanyName", c => c.String());
            AddColumn("dbo.AspNetUsers", "AddressAddOn", c => c.String());
            AddColumn("dbo.AspNetUsers", "EmailPrivate", c => c.String());
            AddColumn("dbo.AspNetUsers", "EmailOther", c => c.String());
            AddColumn("dbo.AspNetUsers", "EmailFeedBack", c => c.String());
            AddColumn("dbo.AspNetUsers", "PhoneDirectAccess", c => c.String());
            AddColumn("dbo.AspNetUsers", "PhoneFax", c => c.String());
            AddColumn("dbo.AspNetUsers", "PhonePrivate", c => c.String());
            AddColumn("dbo.AspNetUsers", "OtherPhone", c => c.String());
            AddColumn("dbo.AspNetUsers", "Url", c => c.String());
            AddColumn("dbo.AspNetUsers", "FreeTextArray", c => c.String());
            AddColumn("dbo.AspNetUsers", "ApprovalOfAddress", c => c.String());
            AddColumn("dbo.AspNetUsers", "SalutationType", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "SalutationType");
            DropColumn("dbo.AspNetUsers", "ApprovalOfAddress");
            DropColumn("dbo.AspNetUsers", "FreeTextArray");
            DropColumn("dbo.AspNetUsers", "Url");
            DropColumn("dbo.AspNetUsers", "OtherPhone");
            DropColumn("dbo.AspNetUsers", "PhonePrivate");
            DropColumn("dbo.AspNetUsers", "PhoneFax");
            DropColumn("dbo.AspNetUsers", "PhoneDirectAccess");
            DropColumn("dbo.AspNetUsers", "EmailFeedBack");
            DropColumn("dbo.AspNetUsers", "EmailOther");
            DropColumn("dbo.AspNetUsers", "EmailPrivate");
            DropColumn("dbo.AspNetUsers", "AddressAddOn");
            DropColumn("dbo.AspNetUsers", "CompanyName");
            DropColumn("dbo.AspNetUsers", "SalutationMessage");
            DropColumn("dbo.AspNetUsers", "Title");
        }
    }
}
