namespace Pyro.DataLayer.MigrationsPostgre
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompositePivotTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "public._SCompositePivot",
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
                .ForeignKey("public._SearchParam", t => t.ChildServiceSearchParameterId)
                .ForeignKey("public._SearchParam", t => t.ParentServiceSearchParameterId, cascadeDelete: true)
                .Index(t => t.ParentServiceSearchParameterId, name: "ix_ParentParamId")
                .Index(t => t.ChildServiceSearchParameterId, name: "ix_ChildParamId");
            
        }
        
        public override void Down()
        {
            DropForeignKey("public._SCompositePivot", "ParentServiceSearchParameterId", "public._SearchParam");
            DropForeignKey("public._SCompositePivot", "ChildServiceSearchParameterId", "public._SearchParam");
            DropIndex("public._SCompositePivot", "ix_ChildParamId");
            DropIndex("public._SCompositePivot", "ix_ParentParamId");
            DropTable("public._SCompositePivot");
        }
    }
}
