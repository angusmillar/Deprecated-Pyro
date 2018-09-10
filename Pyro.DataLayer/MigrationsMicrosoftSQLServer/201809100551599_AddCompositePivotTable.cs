namespace Pyro.DataLayer.MigrationsMicrosoftSQLServer
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompositePivotTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo._SCompositePivot",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SequentialOrder = c.Int(nullable: false),
                        Url = c.String(maxLength: 450),
                        Expression = c.String(nullable: false),
                        ParentServiceSearchParameterId = c.Int(nullable: false),
                        ChildServiceSearchParameterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo._SearchParam", t => t.ChildServiceSearchParameterId)
                .ForeignKey("dbo._SearchParam", t => t.ParentServiceSearchParameterId, cascadeDelete: true)
                .Index(t => t.ParentServiceSearchParameterId, name: "ix_ParentParamId")
                .Index(t => t.ChildServiceSearchParameterId, name: "ix_ChildParamId");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo._SCompositePivot", "ParentServiceSearchParameterId", "dbo._SearchParam");
            DropForeignKey("dbo._SCompositePivot", "ChildServiceSearchParameterId", "dbo._SearchParam");
            DropIndex("dbo._SCompositePivot", "ix_ChildParamId");
            DropIndex("dbo._SCompositePivot", "ix_ParentParamId");
            DropTable("dbo._SCompositePivot");
        }
    }
}
