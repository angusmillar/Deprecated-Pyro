namespace Pyro.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ServiceCompartment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo._ServiceCompartment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Url = c.String(nullable: false, maxLength: 450),
                        CompartmentDefinitionResourceId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 128),
                        Title = c.String(maxLength: 256),
                        Code = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Code, unique: true, name: "ix_ServiceCompartmentCode");
            
            CreateTable(
                "dbo._ServiceCompartmentResource",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 50),
                        Param = c.String(),
                        _ServiceCompartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo._ServiceCompartment", t => t._ServiceCompartmentId, cascadeDelete: true)
                .Index(t => t._ServiceCompartmentId, name: "ix_ServiceCompartmentId");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo._ServiceCompartmentResource", "_ServiceCompartmentId", "dbo._ServiceCompartment");
            DropIndex("dbo._ServiceCompartmentResource", "ix_ServiceCompartmentId");
            DropIndex("dbo._ServiceCompartment", "ix_ServiceCompartmentCode");
            DropTable("dbo._ServiceCompartmentResource");
            DropTable("dbo._ServiceCompartment");
        }
    }
}
