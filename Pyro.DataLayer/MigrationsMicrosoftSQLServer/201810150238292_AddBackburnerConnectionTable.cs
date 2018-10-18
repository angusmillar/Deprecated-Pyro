namespace Pyro.DataLayer.MigrationsMicrosoftSQLServer
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBackburnerConnectionTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo._BackburnerConnection",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ConnectionId = c.String(nullable: false, maxLength: 128),
                        IsConnected = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CreatedUser = c.String(),
                        LastUpdated = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        LastUpdatedUser = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.ConnectionId, unique: true, name: "ix_ConnectId");
            
        }
        
        public override void Down()
        {
            DropIndex("dbo._BackburnerConnection", "ix_ConnectId");
            DropTable("dbo._BackburnerConnection");
        }
    }
}
