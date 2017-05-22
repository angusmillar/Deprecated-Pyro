namespace Pyro.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SearchParamReferance : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ServiceSearchParameter", "SearchParameterResourceId", c => c.String(maxLength: 400));
            AddColumn("dbo.ServiceSearchParameter", "SearchParameterResourceVersion", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ServiceSearchParameter", "SearchParameterResourceVersion");
            DropColumn("dbo.ServiceSearchParameter", "SearchParameterResourceId");
        }
    }
}
