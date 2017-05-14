using System.Configuration;
using System.IO;

namespace Wohnungstausch24.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LocationTablesDataAdded : DbMigration
    {
        public override void Up()
        {
            System.Data.SqlClient.SqlConnectionStringBuilder connBuilder = new System.Data.SqlClient.SqlConnectionStringBuilder();
            connBuilder.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            string database = connBuilder["Initial Catalog"] as string;

            // FROM FILE
            var sqlFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Sql/dbo.Countries.Table.sql");
            Sql(File.ReadAllText(sqlFile).Replace("DbName", database));
            // FROM FILE
            var sqlFile1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Sql/dbo.LocationLevel1.Table.sql");
            Sql(File.ReadAllText(sqlFile1).Replace("DbName", database));
            // FROM FILE
            var sqlFile2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Sql/dbo.LocationLevel2.Table.sql");
            Sql(File.ReadAllText(sqlFile2).Replace("DbName", database));
            // FROM FILE
            var sqlFile3 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Sql/dbo.LocationLevel3.Table.sql");
            Sql(File.ReadAllText(sqlFile3).Replace("DbName", database));
        }

        public override void Down()
        {
            Sql("Delete from LocationLevel3");
            Sql("Delete from LocationLevel2");
            Sql("Delete from LocationLevel1");
            Sql("Delete from Countries");
        }
    }
}
