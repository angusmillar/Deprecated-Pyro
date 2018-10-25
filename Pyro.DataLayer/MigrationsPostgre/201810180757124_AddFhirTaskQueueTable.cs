namespace Pyro.DataLayer.MigrationsPostgre
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFhirTaskQueueTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "public._FhirTaskQueue",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TaskFhirId = c.String(nullable: false, maxLength: 128),
                        TaskType = c.String(nullable: false, maxLength: 128),
                        PerfomrerConnectionId = c.String(maxLength: 128),
                        Status = c.String(nullable: false, maxLength: 128),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedUser = c.String(),
                        LastUpdated = c.DateTime(nullable: false),
                        LastUpdatedUser = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.TaskFhirId, t.TaskType }, unique: true, name: "uq_TaskFhirIdAndType")
                .Index(t => t.PerfomrerConnectionId, name: "ix_PConnectId")
                .Index(t => t.Status, name: "ix_Status");
            
        }
        
        public override void Down()
        {
            DropIndex("public._FhirTaskQueue", "ix_Status");
            DropIndex("public._FhirTaskQueue", "ix_PConnectId");
            DropIndex("public._FhirTaskQueue", "uq_TaskFhirIdAndType");
            DropTable("public._FhirTaskQueue");
        }
    }
}
