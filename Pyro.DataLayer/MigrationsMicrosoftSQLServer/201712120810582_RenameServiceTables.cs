namespace Pyro.DataLayer.MigrationsMicrosoftSQLServer
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameServiceTables : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ServiceSearchParameter", newName: "_ServiceSearchParameter");
            RenameTable(name: "dbo.ServiceSearchParameterTargetResource", newName: "_ServiceSearchParameterTargetResource");
            RenameTable(name: "dbo.ServiceBaseUrl", newName: "_ServiceBaseUrl");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo._ServiceBaseUrl", newName: "ServiceBaseUrl");
            RenameTable(name: "dbo._ServiceSearchParameterTargetResource", newName: "ServiceSearchParameterTargetResource");
            RenameTable(name: "dbo._ServiceSearchParameter", newName: "ServiceSearchParameter");
        }
    }
}
