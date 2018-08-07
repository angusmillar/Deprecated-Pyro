namespace Pyro.DataLayer.MigrationsMicrosoftSQLServer
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateNewLowHighUtcDateTimeColoums : DbMigration
    {
    public override void Up()
    {
      // ADD THIS BY HAND      
      var ResourceList = Hl7.Fhir.Model.ModelInfo.SupportedResources;
      foreach (var ResourceName in ResourceList)
      {
        Sql($@"UPDATE [dbo].[{ResourceName}ResIndexDateTime] SET[LowUtcDateTime] = CONVERT(datetime2(3),[DateTimeOffsetLow]) WHERE[DateTimeOffsetLow] is NOT NUll");
        Sql($@"UPDATE [dbo].[{ResourceName}ResIndexDateTime] SET[HighUtcDateTime] = CONVERT(datetime2(3),[DateTimeOffsetHigh]) WHERE[DateTimeOffsetHigh] is NOT NUll");
      }
    }

    public override void Down()
    {
      // ADD THIS BY HAND      
      var ResourceList = Hl7.Fhir.Model.ModelInfo.SupportedResources;
      foreach (var ResourceName in ResourceList)
      {
        Sql($@"UPDATE [dbo].[{ResourceName}ResIndexDateTime] SET [LowUtcDateTime] = Null WHERE [DateTimeOffsetLow] is NOT NUll");
        Sql($@"UPDATE [dbo].[{ResourceName}ResIndexDateTime] SET [HighUtcDateTime] = Null WHERE [DateTimeOffsetHigh] is NOT NUll");
      }
    }
  }
}
