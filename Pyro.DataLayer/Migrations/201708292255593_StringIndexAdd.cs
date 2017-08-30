namespace Pyro.DataLayer.Migrations
{
  using System;
  using System.Data.Entity.Migrations;

  //===========================================================
  //WARNNING: This migration has been manually modified  
  //===========================================================

  public partial class StringIndexAdd : DbMigration
  {
    public override void Up()
    {
      CreateTable(
          "dbo.AccountResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.AccountRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
                "dbo.ActivityDefinitionResIndexString",
                c => new
                {
                  Id = c.Int(nullable: false, identity: true),
                  String = c.String(nullable: false, maxLength: 450),
                  ServiceSearchParameterId = c.Int(nullable: false),
                  ResourceId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ActivityDefinitionRes", t => t.ResourceId, cascadeDelete: true)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.ResourceId);

      CreateTable(
          "dbo.AdverseEventResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.AdverseEventRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.AllergyIntoleranceResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.AllergyIntoleranceRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.AppointmentResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.AppointmentRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.AppointmentResponseResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.AppointmentResponseRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.AuditEventResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.AuditEventRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.BasicResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.BasicRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.BinaryResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.BinaryRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.BodySiteResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.BodySiteRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.BundleResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.BundleRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.CapabilityStatementResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.CapabilityStatementRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.CarePlanResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.CarePlanRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.CareTeamResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.CareTeamRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.ChargeItemResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.ChargeItemRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.ClaimResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.ClaimRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.ClaimResponseResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.ClaimResponseRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.ClinicalImpressionResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.ClinicalImpressionRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.CodeSystemResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.CodeSystemRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.CommunicationResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.CommunicationRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.CommunicationRequestResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.CommunicationRequestRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.CompartmentDefinitionResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.CompartmentDefinitionRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.CompositionResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.CompositionRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.ConceptMapResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.ConceptMapRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.ConditionResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.ConditionRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.ConsentResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.ConsentRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.ContractResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.ContractRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.CoverageResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.CoverageRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.DataElementResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.DataElementRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.DetectedIssueResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.DetectedIssueRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.DeviceResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.DeviceRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.DeviceComponentResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.DeviceComponentRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.DeviceMetricResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.DeviceMetricRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.DeviceRequestResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.DeviceRequestRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.DeviceUseStatementResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.DeviceUseStatementRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.DiagnosticReportResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.DiagnosticReportRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.DocumentManifestResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.DocumentManifestRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.DocumentReferenceResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.DocumentReferenceRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.EligibilityRequestResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.EligibilityRequestRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.EligibilityResponseResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.EligibilityResponseRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.EncounterResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.EncounterRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.EndpointResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.EndpointRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.EnrollmentRequestResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.EnrollmentRequestRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.EnrollmentResponseResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.EnrollmentResponseRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.EpisodeOfCareResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.EpisodeOfCareRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.ExpansionProfileResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.ExpansionProfileRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.ExplanationOfBenefitResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.ExplanationOfBenefitRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.FamilyMemberHistoryResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.FamilyMemberHistoryRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.FlagResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.FlagRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.GoalResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.GoalRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.GraphDefinitionResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.GraphDefinitionRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.GroupResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.GroupRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.GuidanceResponseResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.GuidanceResponseRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.HealthcareServiceResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.HealthcareServiceRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.ImagingManifestResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.ImagingManifestRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.ImagingStudyResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.ImagingStudyRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.ImmunizationResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.ImmunizationRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.ImmunizationRecommendationResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.ImmunizationRecommendationRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.ImplementationGuideResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.ImplementationGuideRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.LibraryResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.LibraryRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.LinkageResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.LinkageRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.ListResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.ListRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.LocationResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.LocationRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.MeasureResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.MeasureRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.MeasureReportResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.MeasureReportRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.MediaResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.MediaRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.MedicationResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.MedicationRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.MedicationAdministrationResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.MedicationAdministrationRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.MedicationDispenseResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.MedicationDispenseRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.MedicationRequestResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.MedicationRequestRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.MedicationStatementResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.MedicationStatementRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.MessageDefinitionResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.MessageDefinitionRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.MessageHeaderResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.MessageHeaderRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.NamingSystemResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.NamingSystemRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.NutritionOrderResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.NutritionOrderRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.ObservationResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.ObservationRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.OperationDefinitionResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.OperationDefinitionRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.OperationOutcomeResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.OperationOutcomeRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.OrganizationResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.OrganizationRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.ParametersResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.ParametersRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.PatientResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.PatientRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.PaymentNoticeResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.PaymentNoticeRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.PaymentReconciliationResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.PaymentReconciliationRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.PersonResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.PersonRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.PlanDefinitionResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.PlanDefinitionRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.PractitionerResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.PractitionerRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.PractitionerRoleResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.PractitionerRoleRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.ProcedureResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.ProcedureRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.ProcedureRequestResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.ProcedureRequestRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.ProcessRequestResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.ProcessRequestRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.ProcessResponseResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.ProcessResponseRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.ProvenanceResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.ProvenanceRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.QuestionnaireResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.QuestionnaireRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.QuestionnaireResponseResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.QuestionnaireResponseRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.ReferralRequestResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.ReferralRequestRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.RelatedPersonResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.RelatedPersonRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.RequestGroupResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.RequestGroupRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.ResearchStudyResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.ResearchStudyRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.ResearchSubjectResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.ResearchSubjectRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.RiskAssessmentResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.RiskAssessmentRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.ScheduleResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.ScheduleRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.SearchParameterResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.SearchParameterRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.SequenceResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.SequenceRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.ServiceDefinitionResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.ServiceDefinitionRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.SlotResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.SlotRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.SpecimenResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.SpecimenRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.StructureDefinitionResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.StructureDefinitionRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.StructureMapResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.StructureMapRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.SubscriptionResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.SubscriptionRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.SubstanceResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.SubstanceRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.SupplyDeliveryResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.SupplyDeliveryRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.SupplyRequestResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.SupplyRequestRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.TaskResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.TaskRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.TestReportResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.TestReportRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.TestScriptResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.TestScriptRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.ValueSetResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.ValueSetRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);

      CreateTable(
          "dbo.VisionPrescriptionResIndexString",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            String = c.String(nullable: false, maxLength: 450),
            ServiceSearchParameterId = c.Int(nullable: false),
            ResourceId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.VisionPrescriptionRes", t => t.ResourceId, cascadeDelete: true)
          .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
          .Index(t => t.String, name: "ix_String")
          .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
          .Index(t => t.ResourceId);


      //Manually added insert statements
      foreach (string ResourceName in Hl7.Fhir.Model.ModelInfo.SupportedResources)
      {
        Sql($"INSERT INTO [dbo].[{ResourceName}ResIndexString] ([ServiceSearchParameterId], [String], [ResourceId]) SELECT [ServiceSearchParameterId], [String], [ResourceId] FROM [dbo].[{ResourceName}ResIndex] WHERE [String] IS NOT NULL");
      }

    }

    public override void Down()
    {
      DropForeignKey("dbo.VisionPrescriptionResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.VisionPrescriptionResIndexString", "ResourceId", "dbo.VisionPrescriptionRes");
      DropForeignKey("dbo.ValueSetResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.ValueSetResIndexString", "ResourceId", "dbo.ValueSetRes");
      DropForeignKey("dbo.TestScriptResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.TestScriptResIndexString", "ResourceId", "dbo.TestScriptRes");
      DropForeignKey("dbo.TestReportResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.TestReportResIndexString", "ResourceId", "dbo.TestReportRes");
      DropForeignKey("dbo.TaskResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.TaskResIndexString", "ResourceId", "dbo.TaskRes");
      DropForeignKey("dbo.SupplyRequestResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.SupplyRequestResIndexString", "ResourceId", "dbo.SupplyRequestRes");
      DropForeignKey("dbo.SupplyDeliveryResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.SupplyDeliveryResIndexString", "ResourceId", "dbo.SupplyDeliveryRes");
      DropForeignKey("dbo.SubstanceResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.SubstanceResIndexString", "ResourceId", "dbo.SubstanceRes");
      DropForeignKey("dbo.SubscriptionResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.SubscriptionResIndexString", "ResourceId", "dbo.SubscriptionRes");
      DropForeignKey("dbo.StructureMapResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.StructureMapResIndexString", "ResourceId", "dbo.StructureMapRes");
      DropForeignKey("dbo.StructureDefinitionResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.StructureDefinitionResIndexString", "ResourceId", "dbo.StructureDefinitionRes");
      DropForeignKey("dbo.SpecimenResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.SpecimenResIndexString", "ResourceId", "dbo.SpecimenRes");
      DropForeignKey("dbo.SlotResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.SlotResIndexString", "ResourceId", "dbo.SlotRes");
      DropForeignKey("dbo.ServiceDefinitionResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.ServiceDefinitionResIndexString", "ResourceId", "dbo.ServiceDefinitionRes");
      DropForeignKey("dbo.SequenceResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.SequenceResIndexString", "ResourceId", "dbo.SequenceRes");
      DropForeignKey("dbo.SearchParameterResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.SearchParameterResIndexString", "ResourceId", "dbo.SearchParameterRes");
      DropForeignKey("dbo.ScheduleResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.ScheduleResIndexString", "ResourceId", "dbo.ScheduleRes");
      DropForeignKey("dbo.RiskAssessmentResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.RiskAssessmentResIndexString", "ResourceId", "dbo.RiskAssessmentRes");
      DropForeignKey("dbo.ResearchSubjectResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.ResearchSubjectResIndexString", "ResourceId", "dbo.ResearchSubjectRes");
      DropForeignKey("dbo.ResearchStudyResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.ResearchStudyResIndexString", "ResourceId", "dbo.ResearchStudyRes");
      DropForeignKey("dbo.RequestGroupResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.RequestGroupResIndexString", "ResourceId", "dbo.RequestGroupRes");
      DropForeignKey("dbo.RelatedPersonResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.RelatedPersonResIndexString", "ResourceId", "dbo.RelatedPersonRes");
      DropForeignKey("dbo.ReferralRequestResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.ReferralRequestResIndexString", "ResourceId", "dbo.ReferralRequestRes");
      DropForeignKey("dbo.QuestionnaireResponseResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.QuestionnaireResponseResIndexString", "ResourceId", "dbo.QuestionnaireResponseRes");
      DropForeignKey("dbo.QuestionnaireResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.QuestionnaireResIndexString", "ResourceId", "dbo.QuestionnaireRes");
      DropForeignKey("dbo.ProvenanceResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.ProvenanceResIndexString", "ResourceId", "dbo.ProvenanceRes");
      DropForeignKey("dbo.ProcessResponseResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.ProcessResponseResIndexString", "ResourceId", "dbo.ProcessResponseRes");
      DropForeignKey("dbo.ProcessRequestResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.ProcessRequestResIndexString", "ResourceId", "dbo.ProcessRequestRes");
      DropForeignKey("dbo.ProcedureRequestResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.ProcedureRequestResIndexString", "ResourceId", "dbo.ProcedureRequestRes");
      DropForeignKey("dbo.ProcedureResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.ProcedureResIndexString", "ResourceId", "dbo.ProcedureRes");
      DropForeignKey("dbo.PractitionerRoleResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.PractitionerRoleResIndexString", "ResourceId", "dbo.PractitionerRoleRes");
      DropForeignKey("dbo.PractitionerResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.PractitionerResIndexString", "ResourceId", "dbo.PractitionerRes");
      DropForeignKey("dbo.PlanDefinitionResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.PlanDefinitionResIndexString", "ResourceId", "dbo.PlanDefinitionRes");
      DropForeignKey("dbo.PersonResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.PersonResIndexString", "ResourceId", "dbo.PersonRes");
      DropForeignKey("dbo.PaymentReconciliationResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.PaymentReconciliationResIndexString", "ResourceId", "dbo.PaymentReconciliationRes");
      DropForeignKey("dbo.PaymentNoticeResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.PaymentNoticeResIndexString", "ResourceId", "dbo.PaymentNoticeRes");
      DropForeignKey("dbo.PatientResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.PatientResIndexString", "ResourceId", "dbo.PatientRes");
      DropForeignKey("dbo.ParametersResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.ParametersResIndexString", "ResourceId", "dbo.ParametersRes");
      DropForeignKey("dbo.OrganizationResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.OrganizationResIndexString", "ResourceId", "dbo.OrganizationRes");
      DropForeignKey("dbo.OperationOutcomeResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.OperationOutcomeResIndexString", "ResourceId", "dbo.OperationOutcomeRes");
      DropForeignKey("dbo.OperationDefinitionResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.OperationDefinitionResIndexString", "ResourceId", "dbo.OperationDefinitionRes");
      DropForeignKey("dbo.ObservationResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.ObservationResIndexString", "ResourceId", "dbo.ObservationRes");
      DropForeignKey("dbo.NutritionOrderResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.NutritionOrderResIndexString", "ResourceId", "dbo.NutritionOrderRes");
      DropForeignKey("dbo.NamingSystemResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.NamingSystemResIndexString", "ResourceId", "dbo.NamingSystemRes");
      DropForeignKey("dbo.MessageHeaderResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.MessageHeaderResIndexString", "ResourceId", "dbo.MessageHeaderRes");
      DropForeignKey("dbo.MessageDefinitionResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.MessageDefinitionResIndexString", "ResourceId", "dbo.MessageDefinitionRes");
      DropForeignKey("dbo.MedicationStatementResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.MedicationStatementResIndexString", "ResourceId", "dbo.MedicationStatementRes");
      DropForeignKey("dbo.MedicationRequestResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.MedicationRequestResIndexString", "ResourceId", "dbo.MedicationRequestRes");
      DropForeignKey("dbo.MedicationDispenseResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.MedicationDispenseResIndexString", "ResourceId", "dbo.MedicationDispenseRes");
      DropForeignKey("dbo.MedicationAdministrationResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.MedicationAdministrationResIndexString", "ResourceId", "dbo.MedicationAdministrationRes");
      DropForeignKey("dbo.MedicationResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.MedicationResIndexString", "ResourceId", "dbo.MedicationRes");
      DropForeignKey("dbo.MediaResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.MediaResIndexString", "ResourceId", "dbo.MediaRes");
      DropForeignKey("dbo.MeasureReportResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.MeasureReportResIndexString", "ResourceId", "dbo.MeasureReportRes");
      DropForeignKey("dbo.MeasureResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.MeasureResIndexString", "ResourceId", "dbo.MeasureRes");
      DropForeignKey("dbo.LocationResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.LocationResIndexString", "ResourceId", "dbo.LocationRes");
      DropForeignKey("dbo.ListResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.ListResIndexString", "ResourceId", "dbo.ListRes");
      DropForeignKey("dbo.LinkageResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.LinkageResIndexString", "ResourceId", "dbo.LinkageRes");
      DropForeignKey("dbo.LibraryResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.LibraryResIndexString", "ResourceId", "dbo.LibraryRes");
      DropForeignKey("dbo.ImplementationGuideResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.ImplementationGuideResIndexString", "ResourceId", "dbo.ImplementationGuideRes");
      DropForeignKey("dbo.ImmunizationRecommendationResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.ImmunizationRecommendationResIndexString", "ResourceId", "dbo.ImmunizationRecommendationRes");
      DropForeignKey("dbo.ImmunizationResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.ImmunizationResIndexString", "ResourceId", "dbo.ImmunizationRes");
      DropForeignKey("dbo.ImagingStudyResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.ImagingStudyResIndexString", "ResourceId", "dbo.ImagingStudyRes");
      DropForeignKey("dbo.ImagingManifestResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.ImagingManifestResIndexString", "ResourceId", "dbo.ImagingManifestRes");
      DropForeignKey("dbo.HealthcareServiceResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.HealthcareServiceResIndexString", "ResourceId", "dbo.HealthcareServiceRes");
      DropForeignKey("dbo.GuidanceResponseResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.GuidanceResponseResIndexString", "ResourceId", "dbo.GuidanceResponseRes");
      DropForeignKey("dbo.GroupResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.GroupResIndexString", "ResourceId", "dbo.GroupRes");
      DropForeignKey("dbo.GraphDefinitionResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.GraphDefinitionResIndexString", "ResourceId", "dbo.GraphDefinitionRes");
      DropForeignKey("dbo.GoalResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.GoalResIndexString", "ResourceId", "dbo.GoalRes");
      DropForeignKey("dbo.FlagResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.FlagResIndexString", "ResourceId", "dbo.FlagRes");
      DropForeignKey("dbo.FamilyMemberHistoryResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.FamilyMemberHistoryResIndexString", "ResourceId", "dbo.FamilyMemberHistoryRes");
      DropForeignKey("dbo.ExplanationOfBenefitResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.ExplanationOfBenefitResIndexString", "ResourceId", "dbo.ExplanationOfBenefitRes");
      DropForeignKey("dbo.ExpansionProfileResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.ExpansionProfileResIndexString", "ResourceId", "dbo.ExpansionProfileRes");
      DropForeignKey("dbo.EpisodeOfCareResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.EpisodeOfCareResIndexString", "ResourceId", "dbo.EpisodeOfCareRes");
      DropForeignKey("dbo.EnrollmentResponseResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.EnrollmentResponseResIndexString", "ResourceId", "dbo.EnrollmentResponseRes");
      DropForeignKey("dbo.EnrollmentRequestResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.EnrollmentRequestResIndexString", "ResourceId", "dbo.EnrollmentRequestRes");
      DropForeignKey("dbo.EndpointResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.EndpointResIndexString", "ResourceId", "dbo.EndpointRes");
      DropForeignKey("dbo.EncounterResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.EncounterResIndexString", "ResourceId", "dbo.EncounterRes");
      DropForeignKey("dbo.EligibilityResponseResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.EligibilityResponseResIndexString", "ResourceId", "dbo.EligibilityResponseRes");
      DropForeignKey("dbo.EligibilityRequestResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.EligibilityRequestResIndexString", "ResourceId", "dbo.EligibilityRequestRes");
      DropForeignKey("dbo.DocumentReferenceResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.DocumentReferenceResIndexString", "ResourceId", "dbo.DocumentReferenceRes");
      DropForeignKey("dbo.DocumentManifestResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.DocumentManifestResIndexString", "ResourceId", "dbo.DocumentManifestRes");
      DropForeignKey("dbo.DiagnosticReportResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.DiagnosticReportResIndexString", "ResourceId", "dbo.DiagnosticReportRes");
      DropForeignKey("dbo.DeviceUseStatementResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.DeviceUseStatementResIndexString", "ResourceId", "dbo.DeviceUseStatementRes");
      DropForeignKey("dbo.DeviceRequestResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.DeviceRequestResIndexString", "ResourceId", "dbo.DeviceRequestRes");
      DropForeignKey("dbo.DeviceMetricResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.DeviceMetricResIndexString", "ResourceId", "dbo.DeviceMetricRes");
      DropForeignKey("dbo.DeviceComponentResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.DeviceComponentResIndexString", "ResourceId", "dbo.DeviceComponentRes");
      DropForeignKey("dbo.DeviceResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.DeviceResIndexString", "ResourceId", "dbo.DeviceRes");
      DropForeignKey("dbo.DetectedIssueResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.DetectedIssueResIndexString", "ResourceId", "dbo.DetectedIssueRes");
      DropForeignKey("dbo.DataElementResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.DataElementResIndexString", "ResourceId", "dbo.DataElementRes");
      DropForeignKey("dbo.CoverageResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.CoverageResIndexString", "ResourceId", "dbo.CoverageRes");
      DropForeignKey("dbo.ContractResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.ContractResIndexString", "ResourceId", "dbo.ContractRes");
      DropForeignKey("dbo.ConsentResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.ConsentResIndexString", "ResourceId", "dbo.ConsentRes");
      DropForeignKey("dbo.ConditionResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.ConditionResIndexString", "ResourceId", "dbo.ConditionRes");
      DropForeignKey("dbo.ConceptMapResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.ConceptMapResIndexString", "ResourceId", "dbo.ConceptMapRes");
      DropForeignKey("dbo.CompositionResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.CompositionResIndexString", "ResourceId", "dbo.CompositionRes");
      DropForeignKey("dbo.CompartmentDefinitionResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.CompartmentDefinitionResIndexString", "ResourceId", "dbo.CompartmentDefinitionRes");
      DropForeignKey("dbo.CommunicationRequestResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.CommunicationRequestResIndexString", "ResourceId", "dbo.CommunicationRequestRes");
      DropForeignKey("dbo.CommunicationResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.CommunicationResIndexString", "ResourceId", "dbo.CommunicationRes");
      DropForeignKey("dbo.CodeSystemResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.CodeSystemResIndexString", "ResourceId", "dbo.CodeSystemRes");
      DropForeignKey("dbo.ClinicalImpressionResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.ClinicalImpressionResIndexString", "ResourceId", "dbo.ClinicalImpressionRes");
      DropForeignKey("dbo.ClaimResponseResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.ClaimResponseResIndexString", "ResourceId", "dbo.ClaimResponseRes");
      DropForeignKey("dbo.ClaimResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.ClaimResIndexString", "ResourceId", "dbo.ClaimRes");
      DropForeignKey("dbo.ChargeItemResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.ChargeItemResIndexString", "ResourceId", "dbo.ChargeItemRes");
      DropForeignKey("dbo.CareTeamResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.CareTeamResIndexString", "ResourceId", "dbo.CareTeamRes");
      DropForeignKey("dbo.CarePlanResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.CarePlanResIndexString", "ResourceId", "dbo.CarePlanRes");
      DropForeignKey("dbo.CapabilityStatementResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.CapabilityStatementResIndexString", "ResourceId", "dbo.CapabilityStatementRes");
      DropForeignKey("dbo.BundleResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.BundleResIndexString", "ResourceId", "dbo.BundleRes");
      DropForeignKey("dbo.BodySiteResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.BodySiteResIndexString", "ResourceId", "dbo.BodySiteRes");
      DropForeignKey("dbo.BinaryResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.BinaryResIndexString", "ResourceId", "dbo.BinaryRes");
      DropForeignKey("dbo.BasicResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.BasicResIndexString", "ResourceId", "dbo.BasicRes");
      DropForeignKey("dbo.AuditEventResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.AuditEventResIndexString", "ResourceId", "dbo.AuditEventRes");
      DropForeignKey("dbo.AppointmentResponseResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.AppointmentResponseResIndexString", "ResourceId", "dbo.AppointmentResponseRes");
      DropForeignKey("dbo.AppointmentResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.AppointmentResIndexString", "ResourceId", "dbo.AppointmentRes");
      DropForeignKey("dbo.AllergyIntoleranceResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.AllergyIntoleranceResIndexString", "ResourceId", "dbo.AllergyIntoleranceRes");
      DropForeignKey("dbo.AdverseEventResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.AdverseEventResIndexString", "ResourceId", "dbo.AdverseEventRes");
      DropForeignKey("dbo.ActivityDefinitionResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.ActivityDefinitionResIndexString", "ResourceId", "dbo.ActivityDefinitionRes");
      DropForeignKey("dbo.AccountResIndexString", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
      DropForeignKey("dbo.AccountResIndexString", "ResourceId", "dbo.AccountRes");
      DropIndex("dbo.VisionPrescriptionResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.VisionPrescriptionResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.VisionPrescriptionResIndexString", "ix_String");
      DropIndex("dbo.ValueSetResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.ValueSetResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.ValueSetResIndexString", "ix_String");
      DropIndex("dbo.TestScriptResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.TestScriptResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.TestScriptResIndexString", "ix_String");
      DropIndex("dbo.TestReportResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.TestReportResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.TestReportResIndexString", "ix_String");
      DropIndex("dbo.TaskResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.TaskResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.TaskResIndexString", "ix_String");
      DropIndex("dbo.SupplyRequestResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.SupplyRequestResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.SupplyRequestResIndexString", "ix_String");
      DropIndex("dbo.SupplyDeliveryResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.SupplyDeliveryResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.SupplyDeliveryResIndexString", "ix_String");
      DropIndex("dbo.SubstanceResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.SubstanceResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.SubstanceResIndexString", "ix_String");
      DropIndex("dbo.SubscriptionResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.SubscriptionResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.SubscriptionResIndexString", "ix_String");
      DropIndex("dbo.StructureMapResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.StructureMapResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.StructureMapResIndexString", "ix_String");
      DropIndex("dbo.StructureDefinitionResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.StructureDefinitionResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.StructureDefinitionResIndexString", "ix_String");
      DropIndex("dbo.SpecimenResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.SpecimenResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.SpecimenResIndexString", "ix_String");
      DropIndex("dbo.SlotResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.SlotResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.SlotResIndexString", "ix_String");
      DropIndex("dbo.ServiceDefinitionResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.ServiceDefinitionResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.ServiceDefinitionResIndexString", "ix_String");
      DropIndex("dbo.SequenceResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.SequenceResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.SequenceResIndexString", "ix_String");
      DropIndex("dbo.SearchParameterResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.SearchParameterResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.SearchParameterResIndexString", "ix_String");
      DropIndex("dbo.ScheduleResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.ScheduleResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.ScheduleResIndexString", "ix_String");
      DropIndex("dbo.RiskAssessmentResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.RiskAssessmentResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.RiskAssessmentResIndexString", "ix_String");
      DropIndex("dbo.ResearchSubjectResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.ResearchSubjectResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.ResearchSubjectResIndexString", "ix_String");
      DropIndex("dbo.ResearchStudyResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.ResearchStudyResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.ResearchStudyResIndexString", "ix_String");
      DropIndex("dbo.RequestGroupResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.RequestGroupResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.RequestGroupResIndexString", "ix_String");
      DropIndex("dbo.RelatedPersonResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.RelatedPersonResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.RelatedPersonResIndexString", "ix_String");
      DropIndex("dbo.ReferralRequestResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.ReferralRequestResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.ReferralRequestResIndexString", "ix_String");
      DropIndex("dbo.QuestionnaireResponseResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.QuestionnaireResponseResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.QuestionnaireResponseResIndexString", "ix_String");
      DropIndex("dbo.QuestionnaireResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.QuestionnaireResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.QuestionnaireResIndexString", "ix_String");
      DropIndex("dbo.ProvenanceResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.ProvenanceResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.ProvenanceResIndexString", "ix_String");
      DropIndex("dbo.ProcessResponseResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.ProcessResponseResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.ProcessResponseResIndexString", "ix_String");
      DropIndex("dbo.ProcessRequestResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.ProcessRequestResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.ProcessRequestResIndexString", "ix_String");
      DropIndex("dbo.ProcedureRequestResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.ProcedureRequestResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.ProcedureRequestResIndexString", "ix_String");
      DropIndex("dbo.ProcedureResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.ProcedureResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.ProcedureResIndexString", "ix_String");
      DropIndex("dbo.PractitionerRoleResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.PractitionerRoleResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.PractitionerRoleResIndexString", "ix_String");
      DropIndex("dbo.PractitionerResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.PractitionerResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.PractitionerResIndexString", "ix_String");
      DropIndex("dbo.PlanDefinitionResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.PlanDefinitionResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.PlanDefinitionResIndexString", "ix_String");
      DropIndex("dbo.PersonResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.PersonResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.PersonResIndexString", "ix_String");
      DropIndex("dbo.PaymentReconciliationResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.PaymentReconciliationResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.PaymentReconciliationResIndexString", "ix_String");
      DropIndex("dbo.PaymentNoticeResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.PaymentNoticeResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.PaymentNoticeResIndexString", "ix_String");
      DropIndex("dbo.PatientResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.PatientResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.PatientResIndexString", "ix_String");
      DropIndex("dbo.ParametersResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.ParametersResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.ParametersResIndexString", "ix_String");
      DropIndex("dbo.OrganizationResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.OrganizationResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.OrganizationResIndexString", "ix_String");
      DropIndex("dbo.OperationOutcomeResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.OperationOutcomeResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.OperationOutcomeResIndexString", "ix_String");
      DropIndex("dbo.OperationDefinitionResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.OperationDefinitionResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.OperationDefinitionResIndexString", "ix_String");
      DropIndex("dbo.ObservationResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.ObservationResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.ObservationResIndexString", "ix_String");
      DropIndex("dbo.NutritionOrderResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.NutritionOrderResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.NutritionOrderResIndexString", "ix_String");
      DropIndex("dbo.NamingSystemResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.NamingSystemResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.NamingSystemResIndexString", "ix_String");
      DropIndex("dbo.MessageHeaderResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.MessageHeaderResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.MessageHeaderResIndexString", "ix_String");
      DropIndex("dbo.MessageDefinitionResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.MessageDefinitionResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.MessageDefinitionResIndexString", "ix_String");
      DropIndex("dbo.MedicationStatementResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.MedicationStatementResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.MedicationStatementResIndexString", "ix_String");
      DropIndex("dbo.MedicationRequestResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.MedicationRequestResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.MedicationRequestResIndexString", "ix_String");
      DropIndex("dbo.MedicationDispenseResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.MedicationDispenseResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.MedicationDispenseResIndexString", "ix_String");
      DropIndex("dbo.MedicationAdministrationResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.MedicationAdministrationResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.MedicationAdministrationResIndexString", "ix_String");
      DropIndex("dbo.MedicationResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.MedicationResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.MedicationResIndexString", "ix_String");
      DropIndex("dbo.MediaResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.MediaResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.MediaResIndexString", "ix_String");
      DropIndex("dbo.MeasureReportResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.MeasureReportResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.MeasureReportResIndexString", "ix_String");
      DropIndex("dbo.MeasureResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.MeasureResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.MeasureResIndexString", "ix_String");
      DropIndex("dbo.LocationResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.LocationResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.LocationResIndexString", "ix_String");
      DropIndex("dbo.ListResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.ListResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.ListResIndexString", "ix_String");
      DropIndex("dbo.LinkageResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.LinkageResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.LinkageResIndexString", "ix_String");
      DropIndex("dbo.LibraryResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.LibraryResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.LibraryResIndexString", "ix_String");
      DropIndex("dbo.ImplementationGuideResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.ImplementationGuideResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.ImplementationGuideResIndexString", "ix_String");
      DropIndex("dbo.ImmunizationRecommendationResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.ImmunizationRecommendationResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.ImmunizationRecommendationResIndexString", "ix_String");
      DropIndex("dbo.ImmunizationResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.ImmunizationResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.ImmunizationResIndexString", "ix_String");
      DropIndex("dbo.ImagingStudyResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.ImagingStudyResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.ImagingStudyResIndexString", "ix_String");
      DropIndex("dbo.ImagingManifestResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.ImagingManifestResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.ImagingManifestResIndexString", "ix_String");
      DropIndex("dbo.HealthcareServiceResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.HealthcareServiceResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.HealthcareServiceResIndexString", "ix_String");
      DropIndex("dbo.GuidanceResponseResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.GuidanceResponseResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.GuidanceResponseResIndexString", "ix_String");
      DropIndex("dbo.GroupResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.GroupResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.GroupResIndexString", "ix_String");
      DropIndex("dbo.GraphDefinitionResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.GraphDefinitionResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.GraphDefinitionResIndexString", "ix_String");
      DropIndex("dbo.GoalResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.GoalResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.GoalResIndexString", "ix_String");
      DropIndex("dbo.FlagResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.FlagResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.FlagResIndexString", "ix_String");
      DropIndex("dbo.FamilyMemberHistoryResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.FamilyMemberHistoryResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.FamilyMemberHistoryResIndexString", "ix_String");
      DropIndex("dbo.ExplanationOfBenefitResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.ExplanationOfBenefitResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.ExplanationOfBenefitResIndexString", "ix_String");
      DropIndex("dbo.ExpansionProfileResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.ExpansionProfileResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.ExpansionProfileResIndexString", "ix_String");
      DropIndex("dbo.EpisodeOfCareResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.EpisodeOfCareResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.EpisodeOfCareResIndexString", "ix_String");
      DropIndex("dbo.EnrollmentResponseResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.EnrollmentResponseResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.EnrollmentResponseResIndexString", "ix_String");
      DropIndex("dbo.EnrollmentRequestResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.EnrollmentRequestResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.EnrollmentRequestResIndexString", "ix_String");
      DropIndex("dbo.EndpointResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.EndpointResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.EndpointResIndexString", "ix_String");
      DropIndex("dbo.EncounterResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.EncounterResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.EncounterResIndexString", "ix_String");
      DropIndex("dbo.EligibilityResponseResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.EligibilityResponseResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.EligibilityResponseResIndexString", "ix_String");
      DropIndex("dbo.EligibilityRequestResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.EligibilityRequestResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.EligibilityRequestResIndexString", "ix_String");
      DropIndex("dbo.DocumentReferenceResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.DocumentReferenceResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.DocumentReferenceResIndexString", "ix_String");
      DropIndex("dbo.DocumentManifestResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.DocumentManifestResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.DocumentManifestResIndexString", "ix_String");
      DropIndex("dbo.DiagnosticReportResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.DiagnosticReportResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.DiagnosticReportResIndexString", "ix_String");
      DropIndex("dbo.DeviceUseStatementResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.DeviceUseStatementResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.DeviceUseStatementResIndexString", "ix_String");
      DropIndex("dbo.DeviceRequestResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.DeviceRequestResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.DeviceRequestResIndexString", "ix_String");
      DropIndex("dbo.DeviceMetricResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.DeviceMetricResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.DeviceMetricResIndexString", "ix_String");
      DropIndex("dbo.DeviceComponentResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.DeviceComponentResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.DeviceComponentResIndexString", "ix_String");
      DropIndex("dbo.DeviceResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.DeviceResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.DeviceResIndexString", "ix_String");
      DropIndex("dbo.DetectedIssueResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.DetectedIssueResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.DetectedIssueResIndexString", "ix_String");
      DropIndex("dbo.DataElementResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.DataElementResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.DataElementResIndexString", "ix_String");
      DropIndex("dbo.CoverageResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.CoverageResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.CoverageResIndexString", "ix_String");
      DropIndex("dbo.ContractResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.ContractResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.ContractResIndexString", "ix_String");
      DropIndex("dbo.ConsentResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.ConsentResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.ConsentResIndexString", "ix_String");
      DropIndex("dbo.ConditionResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.ConditionResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.ConditionResIndexString", "ix_String");
      DropIndex("dbo.ConceptMapResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.ConceptMapResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.ConceptMapResIndexString", "ix_String");
      DropIndex("dbo.CompositionResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.CompositionResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.CompositionResIndexString", "ix_String");
      DropIndex("dbo.CompartmentDefinitionResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.CompartmentDefinitionResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.CompartmentDefinitionResIndexString", "ix_String");
      DropIndex("dbo.CommunicationRequestResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.CommunicationRequestResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.CommunicationRequestResIndexString", "ix_String");
      DropIndex("dbo.CommunicationResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.CommunicationResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.CommunicationResIndexString", "ix_String");
      DropIndex("dbo.CodeSystemResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.CodeSystemResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.CodeSystemResIndexString", "ix_String");
      DropIndex("dbo.ClinicalImpressionResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.ClinicalImpressionResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.ClinicalImpressionResIndexString", "ix_String");
      DropIndex("dbo.ClaimResponseResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.ClaimResponseResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.ClaimResponseResIndexString", "ix_String");
      DropIndex("dbo.ClaimResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.ClaimResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.ClaimResIndexString", "ix_String");
      DropIndex("dbo.ChargeItemResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.ChargeItemResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.ChargeItemResIndexString", "ix_String");
      DropIndex("dbo.CareTeamResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.CareTeamResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.CareTeamResIndexString", "ix_String");
      DropIndex("dbo.CarePlanResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.CarePlanResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.CarePlanResIndexString", "ix_String");
      DropIndex("dbo.CapabilityStatementResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.CapabilityStatementResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.CapabilityStatementResIndexString", "ix_String");
      DropIndex("dbo.BundleResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.BundleResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.BundleResIndexString", "ix_String");
      DropIndex("dbo.BodySiteResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.BodySiteResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.BodySiteResIndexString", "ix_String");
      DropIndex("dbo.BinaryResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.BinaryResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.BinaryResIndexString", "ix_String");
      DropIndex("dbo.BasicResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.BasicResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.BasicResIndexString", "ix_String");
      DropIndex("dbo.AuditEventResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.AuditEventResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.AuditEventResIndexString", "ix_String");
      DropIndex("dbo.AppointmentResponseResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.AppointmentResponseResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.AppointmentResponseResIndexString", "ix_String");
      DropIndex("dbo.AppointmentResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.AppointmentResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.AppointmentResIndexString", "ix_String");
      DropIndex("dbo.AllergyIntoleranceResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.AllergyIntoleranceResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.AllergyIntoleranceResIndexString", "ix_String");
      DropIndex("dbo.AdverseEventResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.AdverseEventResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.AdverseEventResIndexString", "ix_String");
      DropIndex("dbo.ActivityDefinitionResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.ActivityDefinitionResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.ActivityDefinitionResIndexString", "ix_String");
      DropIndex("dbo.AccountResIndexString", new[] { "ResourceId" });
      DropIndex("dbo.AccountResIndexString", "ix_ServiceSearchParameterId");
      DropIndex("dbo.AccountResIndexString", "ix_String");
      DropTable("dbo.VisionPrescriptionResIndexString");
      DropTable("dbo.ValueSetResIndexString");
      DropTable("dbo.TestScriptResIndexString");
      DropTable("dbo.TestReportResIndexString");
      DropTable("dbo.TaskResIndexString");
      DropTable("dbo.SupplyRequestResIndexString");
      DropTable("dbo.SupplyDeliveryResIndexString");
      DropTable("dbo.SubstanceResIndexString");
      DropTable("dbo.SubscriptionResIndexString");
      DropTable("dbo.StructureMapResIndexString");
      DropTable("dbo.StructureDefinitionResIndexString");
      DropTable("dbo.SpecimenResIndexString");
      DropTable("dbo.SlotResIndexString");
      DropTable("dbo.ServiceDefinitionResIndexString");
      DropTable("dbo.SequenceResIndexString");
      DropTable("dbo.SearchParameterResIndexString");
      DropTable("dbo.ScheduleResIndexString");
      DropTable("dbo.RiskAssessmentResIndexString");
      DropTable("dbo.ResearchSubjectResIndexString");
      DropTable("dbo.ResearchStudyResIndexString");
      DropTable("dbo.RequestGroupResIndexString");
      DropTable("dbo.RelatedPersonResIndexString");
      DropTable("dbo.ReferralRequestResIndexString");
      DropTable("dbo.QuestionnaireResponseResIndexString");
      DropTable("dbo.QuestionnaireResIndexString");
      DropTable("dbo.ProvenanceResIndexString");
      DropTable("dbo.ProcessResponseResIndexString");
      DropTable("dbo.ProcessRequestResIndexString");
      DropTable("dbo.ProcedureRequestResIndexString");
      DropTable("dbo.ProcedureResIndexString");
      DropTable("dbo.PractitionerRoleResIndexString");
      DropTable("dbo.PractitionerResIndexString");
      DropTable("dbo.PlanDefinitionResIndexString");
      DropTable("dbo.PersonResIndexString");
      DropTable("dbo.PaymentReconciliationResIndexString");
      DropTable("dbo.PaymentNoticeResIndexString");
      DropTable("dbo.PatientResIndexString");
      DropTable("dbo.ParametersResIndexString");
      DropTable("dbo.OrganizationResIndexString");
      DropTable("dbo.OperationOutcomeResIndexString");
      DropTable("dbo.OperationDefinitionResIndexString");
      DropTable("dbo.ObservationResIndexString");
      DropTable("dbo.NutritionOrderResIndexString");
      DropTable("dbo.NamingSystemResIndexString");
      DropTable("dbo.MessageHeaderResIndexString");
      DropTable("dbo.MessageDefinitionResIndexString");
      DropTable("dbo.MedicationStatementResIndexString");
      DropTable("dbo.MedicationRequestResIndexString");
      DropTable("dbo.MedicationDispenseResIndexString");
      DropTable("dbo.MedicationAdministrationResIndexString");
      DropTable("dbo.MedicationResIndexString");
      DropTable("dbo.MediaResIndexString");
      DropTable("dbo.MeasureReportResIndexString");
      DropTable("dbo.MeasureResIndexString");
      DropTable("dbo.LocationResIndexString");
      DropTable("dbo.ListResIndexString");
      DropTable("dbo.LinkageResIndexString");
      DropTable("dbo.LibraryResIndexString");
      DropTable("dbo.ImplementationGuideResIndexString");
      DropTable("dbo.ImmunizationRecommendationResIndexString");
      DropTable("dbo.ImmunizationResIndexString");
      DropTable("dbo.ImagingStudyResIndexString");
      DropTable("dbo.ImagingManifestResIndexString");
      DropTable("dbo.HealthcareServiceResIndexString");
      DropTable("dbo.GuidanceResponseResIndexString");
      DropTable("dbo.GroupResIndexString");
      DropTable("dbo.GraphDefinitionResIndexString");
      DropTable("dbo.GoalResIndexString");
      DropTable("dbo.FlagResIndexString");
      DropTable("dbo.FamilyMemberHistoryResIndexString");
      DropTable("dbo.ExplanationOfBenefitResIndexString");
      DropTable("dbo.ExpansionProfileResIndexString");
      DropTable("dbo.EpisodeOfCareResIndexString");
      DropTable("dbo.EnrollmentResponseResIndexString");
      DropTable("dbo.EnrollmentRequestResIndexString");
      DropTable("dbo.EndpointResIndexString");
      DropTable("dbo.EncounterResIndexString");
      DropTable("dbo.EligibilityResponseResIndexString");
      DropTable("dbo.EligibilityRequestResIndexString");
      DropTable("dbo.DocumentReferenceResIndexString");
      DropTable("dbo.DocumentManifestResIndexString");
      DropTable("dbo.DiagnosticReportResIndexString");
      DropTable("dbo.DeviceUseStatementResIndexString");
      DropTable("dbo.DeviceRequestResIndexString");
      DropTable("dbo.DeviceMetricResIndexString");
      DropTable("dbo.DeviceComponentResIndexString");
      DropTable("dbo.DeviceResIndexString");
      DropTable("dbo.DetectedIssueResIndexString");
      DropTable("dbo.DataElementResIndexString");
      DropTable("dbo.CoverageResIndexString");
      DropTable("dbo.ContractResIndexString");
      DropTable("dbo.ConsentResIndexString");
      DropTable("dbo.ConditionResIndexString");
      DropTable("dbo.ConceptMapResIndexString");
      DropTable("dbo.CompositionResIndexString");
      DropTable("dbo.CompartmentDefinitionResIndexString");
      DropTable("dbo.CommunicationRequestResIndexString");
      DropTable("dbo.CommunicationResIndexString");
      DropTable("dbo.CodeSystemResIndexString");
      DropTable("dbo.ClinicalImpressionResIndexString");
      DropTable("dbo.ClaimResponseResIndexString");
      DropTable("dbo.ClaimResIndexString");
      DropTable("dbo.ChargeItemResIndexString");
      DropTable("dbo.CareTeamResIndexString");
      DropTable("dbo.CarePlanResIndexString");
      DropTable("dbo.CapabilityStatementResIndexString");
      DropTable("dbo.BundleResIndexString");
      DropTable("dbo.BodySiteResIndexString");
      DropTable("dbo.BinaryResIndexString");
      DropTable("dbo.BasicResIndexString");
      DropTable("dbo.AuditEventResIndexString");
      DropTable("dbo.AppointmentResponseResIndexString");
      DropTable("dbo.AppointmentResIndexString");
      DropTable("dbo.AllergyIntoleranceResIndexString");
      DropTable("dbo.AdverseEventResIndexString");
      DropTable("dbo.ActivityDefinitionResIndexString");
      DropTable("dbo.AccountResIndexString");
    }
  }
}
