namespace Pyro.DataLayer.MigrationsPostgre
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFhirTaskWorkerTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "public._FhirTaskWorker",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TaskType = c.String(nullable: false, maxLength: 128),
                        ClaimedBy = c.String(maxLength: 128),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedUser = c.String(),
                        LastUpdated = c.DateTime(nullable: false),
                        LastUpdatedUser = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.TaskType, unique: true, name: "ix_TaskType")
                .Index(t => t.ClaimedBy, name: "ix_ClaimedBy");
            
        }
        
        public override void Down()
        {
            DropIndex("public._FhirTaskWorker", "ix_ClaimedBy");
            DropIndex("public._FhirTaskWorker", "ix_TaskType");
            DropTable("public._FhirTaskWorker");
        }
    }
}
