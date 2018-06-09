namespace Pyro.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ServiceConfigurationTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo._ServiceConfiguration",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Parameter = c.String(nullable: false, maxLength: 450),
                        Value = c.String(nullable: false, maxLength: 450),
                        CreatedDate = c.DateTimeOffset(nullable: false, precision: 3),
                        CreatedUser = c.String(nullable: false),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        LastUpdatedUser = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo._ServiceConfiguration");
        }
    }
}
