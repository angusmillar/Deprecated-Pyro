namespace Pyro.DataLayer.MigrationsMicrosoftSQLServer
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFHIRTaskQueueAndWorkerTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo._FhirTaskQueue",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TaskFhirId = c.String(nullable: false, maxLength: 128),
                        TaskType = c.String(nullable: false, maxLength: 128),
                        PerfomrerConnectionId = c.String(maxLength: 128),
                        Status = c.String(nullable: false, maxLength: 128),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CreatedUser = c.String(),
                        LastUpdated = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        LastUpdatedUser = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.TaskFhirId, t.TaskType }, unique: true, name: "uq_TaskFhirIdAndType")
                .Index(t => t.PerfomrerConnectionId, name: "ix_PConnectId")
                .Index(t => t.Status, name: "ix_Status");
            
            CreateTable(
                "dbo._FhirTaskWorker",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TaskType = c.String(nullable: false, maxLength: 128),
                        ClaimedBy = c.String(maxLength: 128),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CreatedUser = c.String(),
                        LastUpdated = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        LastUpdatedUser = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.TaskType, unique: true, name: "ix_TaskType")
                .Index(t => t.ClaimedBy, name: "ix_ClaimedBy");
            
        }
        
        public override void Down()
        {
            DropIndex("dbo._FhirTaskWorker", "ix_ClaimedBy");
            DropIndex("dbo._FhirTaskWorker", "ix_TaskType");
            DropIndex("dbo._FhirTaskQueue", "ix_Status");
            DropIndex("dbo._FhirTaskQueue", "ix_PConnectId");
            DropIndex("dbo._FhirTaskQueue", "uq_TaskFhirIdAndType");
            DropTable("dbo._FhirTaskWorker");
            DropTable("dbo._FhirTaskQueue");
        }
    }
}
