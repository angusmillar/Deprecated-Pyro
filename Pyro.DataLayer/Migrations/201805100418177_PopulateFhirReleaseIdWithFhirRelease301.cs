namespace Pyro.DataLayer.Migrations
{
  using System;
  using System.Data.Entity.Migrations;

  public partial class PopulateFhirReleaseIdWithFhirRelease301 : DbMigration
  {
    public override void Up()
    {
      // ADD THIS BY HAND      
      var ResourceList = Hl7.Fhir.Model.ModelInfo.SupportedResources;
      foreach (var ResourceName in ResourceList)
      {
        Sql($@"UPDATE dbo.{ResourceName}Res SET [FhirReleaseId] = (SELECT TOP 1 [Id] FROM [dbo].[_FhirRelease] where [FhirVersion] = '3.0.1') where [FhirReleaseId] IS NULL");
      }
    }

    public override void Down()
    {
      // ADD THIS BY HAND      
      var ResourceList = Hl7.Fhir.Model.ModelInfo.SupportedResources;
      foreach (var ResourceName in ResourceList)
      {
        Sql($@"UPDATE dbo.{ResourceName}Res SET [FhirReleaseId] = NULL where [FhirReleaseId] = (SELECT TOP 1 [Id] FROM [dbo].[_FhirRelease] where [FhirVersion] = '3.0.1')");
      }
    }
  }
}
