namespace Pyro.DataLayer.MigrationsPostgre
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBackburnerConnectionTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "public._BackburnerConnection",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ConnectionId = c.String(nullable: false, maxLength: 128),
                        IsConnected = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedUser = c.String(),
                        LastUpdated = c.DateTime(nullable: false),
                        LastUpdatedUser = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.ConnectionId, unique: true, name: "ix_ConnectId");
            
        }
        
        public override void Down()
        {
            DropIndex("public._BackburnerConnection", "ix_ConnectId");
            DropTable("public._BackburnerConnection");
        }
    }
}
