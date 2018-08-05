namespace Pyro.DataLayer.MigrationsMicrosoftSQLServer
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTable_FhirRelease : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo._FhirRelease",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FhirVersion = c.String(),
                        Date = c.DateTime(nullable: false),
                        Description = c.String(),
                        CreatedDate = c.DateTimeOffset(nullable: false, precision: 7),
                        CreatedUser = c.String(),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 7),
                        LastUpdatedUser = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo._FhirRelease");
        }
    }
}
