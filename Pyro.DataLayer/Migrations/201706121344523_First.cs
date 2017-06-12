namespace Pyro.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.AccountResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.AccountRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.ServiceBaseUrl",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Url = c.String(nullable: false, maxLength: 450),
                        IsServersPrimaryUrlRoot = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Url, unique: true);
            
            CreateTable(
                "dbo.ServiceSearchParameter",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Resource = c.String(nullable: false, maxLength: 50),
                        Name = c.String(nullable: false, maxLength: 50),
                        Url = c.String(maxLength: 450),
                        Description = c.String(),
                        Type = c.Int(nullable: false),
                        XPath = c.String(),
                        Expression = c.String(nullable: false),
                        IsIndexed = c.Boolean(nullable: false),
                        Status = c.Int(nullable: false),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 7),
                        SearchParameterResourceId = c.String(maxLength: 400),
                        SearchParameterResourceVersion = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.Resource, t.Name }, unique: true, name: "UQ_ResourceAndName")
                .Index(t => t.IsIndexed, name: "ix_IsIndexed")
                .Index(t => t.Status, name: "ix_Status");
            
            CreateTable(
                "dbo.ServiceSearchParameterTargetResource",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        ResourceType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId);
            
            CreateTable(
                "dbo.ActivityDefinitionRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.ActivityDefinitionResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.ActivityDefinitionRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.AdverseEventRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.AdverseEventResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.AdverseEventRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.AllergyIntoleranceRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.AllergyIntoleranceResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.AllergyIntoleranceRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.AppointmentRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.AppointmentResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.AppointmentRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.AppointmentResponseRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.AppointmentResponseResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.AppointmentResponseRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.AuditEventRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.AuditEventResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.AuditEventRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.BasicRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.BasicResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.BasicRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.BinaryRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.BinaryResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.BinaryRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.BodySiteRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.BodySiteResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.BodySiteRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.BundleRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.BundleResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.BundleRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.CapabilityStatementRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.CapabilityStatementResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.CapabilityStatementRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.CarePlanRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.CarePlanResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.CarePlanRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.CareTeamRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.CareTeamResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.CareTeamRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.ChargeItemRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.ChargeItemResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.ChargeItemRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.ClaimRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.ClaimResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.ClaimRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.ClaimResponseRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.ClaimResponseResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.ClaimResponseRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.ClinicalImpressionRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.ClinicalImpressionResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.ClinicalImpressionRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.CodeSystemRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.CodeSystemResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.CodeSystemRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.CommunicationRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.CommunicationResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.CommunicationRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.CommunicationRequestRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.CommunicationRequestResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.CommunicationRequestRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.CompartmentDefinitionRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.CompartmentDefinitionResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.CompartmentDefinitionRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.CompositionRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.CompositionResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.CompositionRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.ConceptMapRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.ConceptMapResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.ConceptMapRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.ConditionRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.ConditionResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.ConditionRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.ConsentRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.ConsentResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.ConsentRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.ContractRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.ContractResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.ContractRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.CoverageRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.CoverageResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.CoverageRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.DataElementRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.DataElementResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.DataElementRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.DetectedIssueRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.DetectedIssueResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.DetectedIssueRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.DeviceRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.DeviceResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.DeviceRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.DeviceComponentRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.DeviceComponentResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.DeviceComponentRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.DeviceMetricRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.DeviceMetricResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.DeviceMetricRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.DeviceRequestRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.DeviceRequestResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.DeviceRequestRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.DeviceUseStatementRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.DeviceUseStatementResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.DeviceUseStatementRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.DiagnosticReportRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.DiagnosticReportResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.DiagnosticReportRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.DocumentManifestRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.DocumentManifestResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.DocumentManifestRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.DocumentReferenceRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.DocumentReferenceResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.DocumentReferenceRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.EligibilityRequestRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.EligibilityRequestResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.EligibilityRequestRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.EligibilityResponseRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.EligibilityResponseResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.EligibilityResponseRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.EncounterRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.EncounterResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.EncounterRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.EndpointRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.EndpointResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.EndpointRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.EnrollmentRequestRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.EnrollmentRequestResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.EnrollmentRequestRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.EnrollmentResponseRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.EnrollmentResponseResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.EnrollmentResponseRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.EpisodeOfCareRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.EpisodeOfCareResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.EpisodeOfCareRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.ExpansionProfileRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.ExpansionProfileResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.ExpansionProfileRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.ExplanationOfBenefitRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.ExplanationOfBenefitResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.ExplanationOfBenefitRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.FamilyMemberHistoryRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.FamilyMemberHistoryResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.FamilyMemberHistoryRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.FlagRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.FlagResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.FlagRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.GoalRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.GoalResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.GoalRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.GraphDefinitionRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.GraphDefinitionResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.GraphDefinitionRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.GroupRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.GroupResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.GroupRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.GuidanceResponseRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.GuidanceResponseResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.GuidanceResponseRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.HealthcareServiceRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.HealthcareServiceResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.HealthcareServiceRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.ImagingManifestRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.ImagingManifestResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.ImagingManifestRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.ImagingStudyRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.ImagingStudyResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.ImagingStudyRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.ImmunizationRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.ImmunizationResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.ImmunizationRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.ImmunizationRecommendationRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.ImmunizationRecommendationResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.ImmunizationRecommendationRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.ImplementationGuideRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.ImplementationGuideResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.ImplementationGuideRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.LibraryRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.LibraryResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.LibraryRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.LinkageRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.LinkageResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.LinkageRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.ListRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.ListResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.ListRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.LocationRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.LocationResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.LocationRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.MeasureRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.MeasureResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.MeasureRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.MeasureReportRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.MeasureReportResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.MeasureReportRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.MediaRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.MediaResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.MediaRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.MedicationRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.MedicationResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.MedicationRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.MedicationAdministrationRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.MedicationAdministrationResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.MedicationAdministrationRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.MedicationDispenseRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.MedicationDispenseResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.MedicationDispenseRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.MedicationRequestRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.MedicationRequestResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.MedicationRequestRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.MedicationStatementRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.MedicationStatementResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.MedicationStatementRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.MessageDefinitionRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.MessageDefinitionResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.MessageDefinitionRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.MessageHeaderRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.MessageHeaderResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.MessageHeaderRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.NamingSystemRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.NamingSystemResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.NamingSystemRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.NutritionOrderRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.NutritionOrderResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.NutritionOrderRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.ObservationRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.ObservationResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.ObservationRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.OperationDefinitionRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.OperationDefinitionResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.OperationDefinitionRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.OperationOutcomeRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.OperationOutcomeResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.OperationOutcomeRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.OrganizationRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.OrganizationResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.OrganizationRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.ParametersRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.ParametersResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.ParametersRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.PatientRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.PatientResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.PatientRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.PaymentNoticeRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.PaymentNoticeResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.PaymentNoticeRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.PaymentReconciliationRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.PaymentReconciliationResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.PaymentReconciliationRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.PersonRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.PersonResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.PersonRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.PlanDefinitionRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.PlanDefinitionResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.PlanDefinitionRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.PractitionerRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.PractitionerResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.PractitionerRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.PractitionerRoleRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.PractitionerRoleResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.PractitionerRoleRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.ProcedureRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.ProcedureResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.ProcedureRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.ProcedureRequestRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.ProcedureRequestResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.ProcedureRequestRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.ProcessRequestRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.ProcessRequestResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.ProcessRequestRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.ProcessResponseRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.ProcessResponseResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.ProcessResponseRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.ProvenanceRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.ProvenanceResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.ProvenanceRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.QuestionnaireRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.QuestionnaireResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.QuestionnaireRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.QuestionnaireResponseRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.QuestionnaireResponseResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.QuestionnaireResponseRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.ReferralRequestRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.ReferralRequestResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.ReferralRequestRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.RelatedPersonRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.RelatedPersonResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.RelatedPersonRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.RequestGroupRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.RequestGroupResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.RequestGroupRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.ResearchStudyRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.ResearchStudyResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.ResearchStudyRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.ResearchSubjectRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.ResearchSubjectResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.ResearchSubjectRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.RiskAssessmentRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.RiskAssessmentResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.RiskAssessmentRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.ScheduleRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.ScheduleResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.ScheduleRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.SearchParameterRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.SearchParameterResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.SearchParameterRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.SequenceRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.SequenceResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.SequenceRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.ServiceDefinitionRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.ServiceDefinitionResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.ServiceDefinitionRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.SlotRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.SlotResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.SlotRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.SpecimenRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.SpecimenResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.SpecimenRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.StructureDefinitionRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.StructureDefinitionResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.StructureDefinitionRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.StructureMapRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.StructureMapResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.StructureMapRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.SubscriptionRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.SubscriptionResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.SubscriptionRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.SubstanceRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.SubstanceResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.SubstanceRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.SupplyDeliveryRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.SupplyDeliveryResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.SupplyDeliveryRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.SupplyRequestRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.SupplyRequestResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.SupplyRequestRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.TaskRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.TaskResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.TaskRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.TestReportRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.TestReportResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.TestReportRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.TestScriptRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.TestScriptResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.TestScriptRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.ValueSetRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.ValueSetResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.ValueSetRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.VisionPrescriptionRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 128),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsCurrent, name: "ix_IsCurrent")
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.IsDeleted, name: "ix_IsDeleted")
                .Index(t => t.LastUpdated, name: "ix_LastUpdated");
            
            CreateTable(
                "dbo.VisionPrescriptionResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 3),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 3),
                        Uri = c.String(maxLength: 450),
                        Comparator = c.Int(),
                        Quantity = c.Decimal(precision: 28, scale: 14),
                        System = c.String(maxLength: 300),
                        Code = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 50),
                        ComparatorHigh = c.Int(),
                        QuantityHigh = c.Decimal(precision: 28, scale: 14),
                        SystemHigh = c.String(maxLength: 300),
                        CodeHigh = c.String(maxLength: 50),
                        UnitHigh = c.String(maxLength: 50),
                        ReferenceFhirId = c.String(maxLength: 128),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 128),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.VisionPrescriptionRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId, name: "ix_ServiceSearchParameterId")
                .Index(t => t.String, name: "ix_String")
                .Index(t => t.DateTimeOffsetLow, name: "ix_DateTimeOffsetLow")
                .Index(t => t.DateTimeOffsetHigh, name: "ix_DateTimeOffsetHigh")
                .Index(t => t.Uri, name: "ix_Uri")
                .Index(t => t.System, name: "ix_System")
                .Index(t => t.Code, name: "ix_Code")
                .Index(t => t.ReferenceFhirId, name: "ix_ReferenceFhirId")
                .Index(t => t.ReferenceServiceBaseUrlId, name: "ix_ReferenceServiceBaseUrlId")
                .Index(t => t.ResourceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VisionPrescriptionResIndex", "ResourceId", "dbo.VisionPrescriptionRes");
            DropForeignKey("dbo.VisionPrescriptionResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.VisionPrescriptionResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.ValueSetResIndex", "ResourceId", "dbo.ValueSetRes");
            DropForeignKey("dbo.ValueSetResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.ValueSetResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.TestScriptResIndex", "ResourceId", "dbo.TestScriptRes");
            DropForeignKey("dbo.TestScriptResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.TestScriptResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.TestReportResIndex", "ResourceId", "dbo.TestReportRes");
            DropForeignKey("dbo.TestReportResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.TestReportResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.TaskResIndex", "ResourceId", "dbo.TaskRes");
            DropForeignKey("dbo.TaskResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.TaskResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.SupplyRequestResIndex", "ResourceId", "dbo.SupplyRequestRes");
            DropForeignKey("dbo.SupplyRequestResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.SupplyRequestResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.SupplyDeliveryResIndex", "ResourceId", "dbo.SupplyDeliveryRes");
            DropForeignKey("dbo.SupplyDeliveryResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.SupplyDeliveryResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.SubstanceResIndex", "ResourceId", "dbo.SubstanceRes");
            DropForeignKey("dbo.SubstanceResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.SubstanceResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.SubscriptionResIndex", "ResourceId", "dbo.SubscriptionRes");
            DropForeignKey("dbo.SubscriptionResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.SubscriptionResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.StructureMapResIndex", "ResourceId", "dbo.StructureMapRes");
            DropForeignKey("dbo.StructureMapResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.StructureMapResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.StructureDefinitionResIndex", "ResourceId", "dbo.StructureDefinitionRes");
            DropForeignKey("dbo.StructureDefinitionResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.StructureDefinitionResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.SpecimenResIndex", "ResourceId", "dbo.SpecimenRes");
            DropForeignKey("dbo.SpecimenResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.SpecimenResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.SlotResIndex", "ResourceId", "dbo.SlotRes");
            DropForeignKey("dbo.SlotResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.SlotResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.ServiceDefinitionResIndex", "ResourceId", "dbo.ServiceDefinitionRes");
            DropForeignKey("dbo.ServiceDefinitionResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.ServiceDefinitionResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.SequenceResIndex", "ResourceId", "dbo.SequenceRes");
            DropForeignKey("dbo.SequenceResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.SequenceResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.SearchParameterResIndex", "ResourceId", "dbo.SearchParameterRes");
            DropForeignKey("dbo.SearchParameterResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.SearchParameterResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.ScheduleResIndex", "ResourceId", "dbo.ScheduleRes");
            DropForeignKey("dbo.ScheduleResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.ScheduleResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.RiskAssessmentResIndex", "ResourceId", "dbo.RiskAssessmentRes");
            DropForeignKey("dbo.RiskAssessmentResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.RiskAssessmentResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.ResearchSubjectResIndex", "ResourceId", "dbo.ResearchSubjectRes");
            DropForeignKey("dbo.ResearchSubjectResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.ResearchSubjectResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.ResearchStudyResIndex", "ResourceId", "dbo.ResearchStudyRes");
            DropForeignKey("dbo.ResearchStudyResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.ResearchStudyResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.RequestGroupResIndex", "ResourceId", "dbo.RequestGroupRes");
            DropForeignKey("dbo.RequestGroupResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.RequestGroupResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.RelatedPersonResIndex", "ResourceId", "dbo.RelatedPersonRes");
            DropForeignKey("dbo.RelatedPersonResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.RelatedPersonResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.ReferralRequestResIndex", "ResourceId", "dbo.ReferralRequestRes");
            DropForeignKey("dbo.ReferralRequestResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.ReferralRequestResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.QuestionnaireResponseResIndex", "ResourceId", "dbo.QuestionnaireResponseRes");
            DropForeignKey("dbo.QuestionnaireResponseResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.QuestionnaireResponseResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.QuestionnaireResIndex", "ResourceId", "dbo.QuestionnaireRes");
            DropForeignKey("dbo.QuestionnaireResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.QuestionnaireResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.ProvenanceResIndex", "ResourceId", "dbo.ProvenanceRes");
            DropForeignKey("dbo.ProvenanceResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.ProvenanceResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.ProcessResponseResIndex", "ResourceId", "dbo.ProcessResponseRes");
            DropForeignKey("dbo.ProcessResponseResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.ProcessResponseResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.ProcessRequestResIndex", "ResourceId", "dbo.ProcessRequestRes");
            DropForeignKey("dbo.ProcessRequestResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.ProcessRequestResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.ProcedureRequestResIndex", "ResourceId", "dbo.ProcedureRequestRes");
            DropForeignKey("dbo.ProcedureRequestResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.ProcedureRequestResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.ProcedureResIndex", "ResourceId", "dbo.ProcedureRes");
            DropForeignKey("dbo.ProcedureResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.ProcedureResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.PractitionerRoleResIndex", "ResourceId", "dbo.PractitionerRoleRes");
            DropForeignKey("dbo.PractitionerRoleResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.PractitionerRoleResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.PractitionerResIndex", "ResourceId", "dbo.PractitionerRes");
            DropForeignKey("dbo.PractitionerResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.PractitionerResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.PlanDefinitionResIndex", "ResourceId", "dbo.PlanDefinitionRes");
            DropForeignKey("dbo.PlanDefinitionResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.PlanDefinitionResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.PersonResIndex", "ResourceId", "dbo.PersonRes");
            DropForeignKey("dbo.PersonResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.PersonResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.PaymentReconciliationResIndex", "ResourceId", "dbo.PaymentReconciliationRes");
            DropForeignKey("dbo.PaymentReconciliationResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.PaymentReconciliationResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.PaymentNoticeResIndex", "ResourceId", "dbo.PaymentNoticeRes");
            DropForeignKey("dbo.PaymentNoticeResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.PaymentNoticeResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.PatientResIndex", "ResourceId", "dbo.PatientRes");
            DropForeignKey("dbo.PatientResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.PatientResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.ParametersResIndex", "ResourceId", "dbo.ParametersRes");
            DropForeignKey("dbo.ParametersResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.ParametersResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.OrganizationResIndex", "ResourceId", "dbo.OrganizationRes");
            DropForeignKey("dbo.OrganizationResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.OrganizationResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.OperationOutcomeResIndex", "ResourceId", "dbo.OperationOutcomeRes");
            DropForeignKey("dbo.OperationOutcomeResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.OperationOutcomeResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.OperationDefinitionResIndex", "ResourceId", "dbo.OperationDefinitionRes");
            DropForeignKey("dbo.OperationDefinitionResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.OperationDefinitionResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.ObservationResIndex", "ResourceId", "dbo.ObservationRes");
            DropForeignKey("dbo.ObservationResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.ObservationResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.NutritionOrderResIndex", "ResourceId", "dbo.NutritionOrderRes");
            DropForeignKey("dbo.NutritionOrderResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.NutritionOrderResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.NamingSystemResIndex", "ResourceId", "dbo.NamingSystemRes");
            DropForeignKey("dbo.NamingSystemResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.NamingSystemResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.MessageHeaderResIndex", "ResourceId", "dbo.MessageHeaderRes");
            DropForeignKey("dbo.MessageHeaderResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.MessageHeaderResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.MessageDefinitionResIndex", "ResourceId", "dbo.MessageDefinitionRes");
            DropForeignKey("dbo.MessageDefinitionResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.MessageDefinitionResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.MedicationStatementResIndex", "ResourceId", "dbo.MedicationStatementRes");
            DropForeignKey("dbo.MedicationStatementResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.MedicationStatementResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.MedicationRequestResIndex", "ResourceId", "dbo.MedicationRequestRes");
            DropForeignKey("dbo.MedicationRequestResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.MedicationRequestResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.MedicationDispenseResIndex", "ResourceId", "dbo.MedicationDispenseRes");
            DropForeignKey("dbo.MedicationDispenseResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.MedicationDispenseResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.MedicationAdministrationResIndex", "ResourceId", "dbo.MedicationAdministrationRes");
            DropForeignKey("dbo.MedicationAdministrationResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.MedicationAdministrationResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.MedicationResIndex", "ResourceId", "dbo.MedicationRes");
            DropForeignKey("dbo.MedicationResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.MedicationResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.MediaResIndex", "ResourceId", "dbo.MediaRes");
            DropForeignKey("dbo.MediaResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.MediaResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.MeasureReportResIndex", "ResourceId", "dbo.MeasureReportRes");
            DropForeignKey("dbo.MeasureReportResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.MeasureReportResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.MeasureResIndex", "ResourceId", "dbo.MeasureRes");
            DropForeignKey("dbo.MeasureResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.MeasureResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.LocationResIndex", "ResourceId", "dbo.LocationRes");
            DropForeignKey("dbo.LocationResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.LocationResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.ListResIndex", "ResourceId", "dbo.ListRes");
            DropForeignKey("dbo.ListResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.ListResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.LinkageResIndex", "ResourceId", "dbo.LinkageRes");
            DropForeignKey("dbo.LinkageResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.LinkageResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.LibraryResIndex", "ResourceId", "dbo.LibraryRes");
            DropForeignKey("dbo.LibraryResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.LibraryResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.ImplementationGuideResIndex", "ResourceId", "dbo.ImplementationGuideRes");
            DropForeignKey("dbo.ImplementationGuideResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.ImplementationGuideResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.ImmunizationRecommendationResIndex", "ResourceId", "dbo.ImmunizationRecommendationRes");
            DropForeignKey("dbo.ImmunizationRecommendationResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.ImmunizationRecommendationResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.ImmunizationResIndex", "ResourceId", "dbo.ImmunizationRes");
            DropForeignKey("dbo.ImmunizationResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.ImmunizationResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.ImagingStudyResIndex", "ResourceId", "dbo.ImagingStudyRes");
            DropForeignKey("dbo.ImagingStudyResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.ImagingStudyResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.ImagingManifestResIndex", "ResourceId", "dbo.ImagingManifestRes");
            DropForeignKey("dbo.ImagingManifestResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.ImagingManifestResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.HealthcareServiceResIndex", "ResourceId", "dbo.HealthcareServiceRes");
            DropForeignKey("dbo.HealthcareServiceResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.HealthcareServiceResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.GuidanceResponseResIndex", "ResourceId", "dbo.GuidanceResponseRes");
            DropForeignKey("dbo.GuidanceResponseResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.GuidanceResponseResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.GroupResIndex", "ResourceId", "dbo.GroupRes");
            DropForeignKey("dbo.GroupResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.GroupResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.GraphDefinitionResIndex", "ResourceId", "dbo.GraphDefinitionRes");
            DropForeignKey("dbo.GraphDefinitionResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.GraphDefinitionResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.GoalResIndex", "ResourceId", "dbo.GoalRes");
            DropForeignKey("dbo.GoalResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.GoalResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.FlagResIndex", "ResourceId", "dbo.FlagRes");
            DropForeignKey("dbo.FlagResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.FlagResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.FamilyMemberHistoryResIndex", "ResourceId", "dbo.FamilyMemberHistoryRes");
            DropForeignKey("dbo.FamilyMemberHistoryResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.FamilyMemberHistoryResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.ExplanationOfBenefitResIndex", "ResourceId", "dbo.ExplanationOfBenefitRes");
            DropForeignKey("dbo.ExplanationOfBenefitResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.ExplanationOfBenefitResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.ExpansionProfileResIndex", "ResourceId", "dbo.ExpansionProfileRes");
            DropForeignKey("dbo.ExpansionProfileResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.ExpansionProfileResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.EpisodeOfCareResIndex", "ResourceId", "dbo.EpisodeOfCareRes");
            DropForeignKey("dbo.EpisodeOfCareResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.EpisodeOfCareResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.EnrollmentResponseResIndex", "ResourceId", "dbo.EnrollmentResponseRes");
            DropForeignKey("dbo.EnrollmentResponseResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.EnrollmentResponseResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.EnrollmentRequestResIndex", "ResourceId", "dbo.EnrollmentRequestRes");
            DropForeignKey("dbo.EnrollmentRequestResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.EnrollmentRequestResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.EndpointResIndex", "ResourceId", "dbo.EndpointRes");
            DropForeignKey("dbo.EndpointResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.EndpointResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.EncounterResIndex", "ResourceId", "dbo.EncounterRes");
            DropForeignKey("dbo.EncounterResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.EncounterResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.EligibilityResponseResIndex", "ResourceId", "dbo.EligibilityResponseRes");
            DropForeignKey("dbo.EligibilityResponseResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.EligibilityResponseResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.EligibilityRequestResIndex", "ResourceId", "dbo.EligibilityRequestRes");
            DropForeignKey("dbo.EligibilityRequestResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.EligibilityRequestResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.DocumentReferenceResIndex", "ResourceId", "dbo.DocumentReferenceRes");
            DropForeignKey("dbo.DocumentReferenceResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.DocumentReferenceResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.DocumentManifestResIndex", "ResourceId", "dbo.DocumentManifestRes");
            DropForeignKey("dbo.DocumentManifestResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.DocumentManifestResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.DiagnosticReportResIndex", "ResourceId", "dbo.DiagnosticReportRes");
            DropForeignKey("dbo.DiagnosticReportResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.DiagnosticReportResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.DeviceUseStatementResIndex", "ResourceId", "dbo.DeviceUseStatementRes");
            DropForeignKey("dbo.DeviceUseStatementResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.DeviceUseStatementResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.DeviceRequestResIndex", "ResourceId", "dbo.DeviceRequestRes");
            DropForeignKey("dbo.DeviceRequestResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.DeviceRequestResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.DeviceMetricResIndex", "ResourceId", "dbo.DeviceMetricRes");
            DropForeignKey("dbo.DeviceMetricResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.DeviceMetricResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.DeviceComponentResIndex", "ResourceId", "dbo.DeviceComponentRes");
            DropForeignKey("dbo.DeviceComponentResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.DeviceComponentResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.DeviceResIndex", "ResourceId", "dbo.DeviceRes");
            DropForeignKey("dbo.DeviceResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.DeviceResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.DetectedIssueResIndex", "ResourceId", "dbo.DetectedIssueRes");
            DropForeignKey("dbo.DetectedIssueResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.DetectedIssueResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.DataElementResIndex", "ResourceId", "dbo.DataElementRes");
            DropForeignKey("dbo.DataElementResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.DataElementResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.CoverageResIndex", "ResourceId", "dbo.CoverageRes");
            DropForeignKey("dbo.CoverageResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.CoverageResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.ContractResIndex", "ResourceId", "dbo.ContractRes");
            DropForeignKey("dbo.ContractResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.ContractResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.ConsentResIndex", "ResourceId", "dbo.ConsentRes");
            DropForeignKey("dbo.ConsentResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.ConsentResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.ConditionResIndex", "ResourceId", "dbo.ConditionRes");
            DropForeignKey("dbo.ConditionResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.ConditionResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.ConceptMapResIndex", "ResourceId", "dbo.ConceptMapRes");
            DropForeignKey("dbo.ConceptMapResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.ConceptMapResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.CompositionResIndex", "ResourceId", "dbo.CompositionRes");
            DropForeignKey("dbo.CompositionResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.CompositionResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.CompartmentDefinitionResIndex", "ResourceId", "dbo.CompartmentDefinitionRes");
            DropForeignKey("dbo.CompartmentDefinitionResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.CompartmentDefinitionResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.CommunicationRequestResIndex", "ResourceId", "dbo.CommunicationRequestRes");
            DropForeignKey("dbo.CommunicationRequestResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.CommunicationRequestResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.CommunicationResIndex", "ResourceId", "dbo.CommunicationRes");
            DropForeignKey("dbo.CommunicationResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.CommunicationResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.CodeSystemResIndex", "ResourceId", "dbo.CodeSystemRes");
            DropForeignKey("dbo.CodeSystemResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.CodeSystemResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.ClinicalImpressionResIndex", "ResourceId", "dbo.ClinicalImpressionRes");
            DropForeignKey("dbo.ClinicalImpressionResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.ClinicalImpressionResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.ClaimResponseResIndex", "ResourceId", "dbo.ClaimResponseRes");
            DropForeignKey("dbo.ClaimResponseResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.ClaimResponseResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.ClaimResIndex", "ResourceId", "dbo.ClaimRes");
            DropForeignKey("dbo.ClaimResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.ClaimResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.ChargeItemResIndex", "ResourceId", "dbo.ChargeItemRes");
            DropForeignKey("dbo.ChargeItemResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.ChargeItemResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.CareTeamResIndex", "ResourceId", "dbo.CareTeamRes");
            DropForeignKey("dbo.CareTeamResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.CareTeamResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.CarePlanResIndex", "ResourceId", "dbo.CarePlanRes");
            DropForeignKey("dbo.CarePlanResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.CarePlanResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.CapabilityStatementResIndex", "ResourceId", "dbo.CapabilityStatementRes");
            DropForeignKey("dbo.CapabilityStatementResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.CapabilityStatementResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.BundleResIndex", "ResourceId", "dbo.BundleRes");
            DropForeignKey("dbo.BundleResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.BundleResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.BodySiteResIndex", "ResourceId", "dbo.BodySiteRes");
            DropForeignKey("dbo.BodySiteResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.BodySiteResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.BinaryResIndex", "ResourceId", "dbo.BinaryRes");
            DropForeignKey("dbo.BinaryResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.BinaryResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.BasicResIndex", "ResourceId", "dbo.BasicRes");
            DropForeignKey("dbo.BasicResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.BasicResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.AuditEventResIndex", "ResourceId", "dbo.AuditEventRes");
            DropForeignKey("dbo.AuditEventResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.AuditEventResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.AppointmentResponseResIndex", "ResourceId", "dbo.AppointmentResponseRes");
            DropForeignKey("dbo.AppointmentResponseResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.AppointmentResponseResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.AppointmentResIndex", "ResourceId", "dbo.AppointmentRes");
            DropForeignKey("dbo.AppointmentResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.AppointmentResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.AllergyIntoleranceResIndex", "ResourceId", "dbo.AllergyIntoleranceRes");
            DropForeignKey("dbo.AllergyIntoleranceResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.AllergyIntoleranceResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.AdverseEventResIndex", "ResourceId", "dbo.AdverseEventRes");
            DropForeignKey("dbo.AdverseEventResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.AdverseEventResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.ActivityDefinitionResIndex", "ResourceId", "dbo.ActivityDefinitionRes");
            DropForeignKey("dbo.ActivityDefinitionResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.ActivityDefinitionResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropForeignKey("dbo.AccountResIndex", "ResourceId", "dbo.AccountRes");
            DropForeignKey("dbo.AccountResIndex", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.ServiceSearchParameterTargetResource", "ServiceSearchParameterId", "dbo.ServiceSearchParameter");
            DropForeignKey("dbo.AccountResIndex", "ReferenceServiceBaseUrlId", "dbo.ServiceBaseUrl");
            DropIndex("dbo.VisionPrescriptionResIndex", new[] { "ResourceId" });
            DropIndex("dbo.VisionPrescriptionResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.VisionPrescriptionResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.VisionPrescriptionResIndex", "ix_Code");
            DropIndex("dbo.VisionPrescriptionResIndex", "ix_System");
            DropIndex("dbo.VisionPrescriptionResIndex", "ix_Uri");
            DropIndex("dbo.VisionPrescriptionResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.VisionPrescriptionResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.VisionPrescriptionResIndex", "ix_String");
            DropIndex("dbo.VisionPrescriptionResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.VisionPrescriptionRes", "ix_LastUpdated");
            DropIndex("dbo.VisionPrescriptionRes", "ix_IsDeleted");
            DropIndex("dbo.VisionPrescriptionRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.VisionPrescriptionRes", "ix_IsCurrent");
            DropIndex("dbo.ValueSetResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ValueSetResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.ValueSetResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ValueSetResIndex", "ix_Code");
            DropIndex("dbo.ValueSetResIndex", "ix_System");
            DropIndex("dbo.ValueSetResIndex", "ix_Uri");
            DropIndex("dbo.ValueSetResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.ValueSetResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.ValueSetResIndex", "ix_String");
            DropIndex("dbo.ValueSetResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.ValueSetRes", "ix_LastUpdated");
            DropIndex("dbo.ValueSetRes", "ix_IsDeleted");
            DropIndex("dbo.ValueSetRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ValueSetRes", "ix_IsCurrent");
            DropIndex("dbo.TestScriptResIndex", new[] { "ResourceId" });
            DropIndex("dbo.TestScriptResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.TestScriptResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.TestScriptResIndex", "ix_Code");
            DropIndex("dbo.TestScriptResIndex", "ix_System");
            DropIndex("dbo.TestScriptResIndex", "ix_Uri");
            DropIndex("dbo.TestScriptResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.TestScriptResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.TestScriptResIndex", "ix_String");
            DropIndex("dbo.TestScriptResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.TestScriptRes", "ix_LastUpdated");
            DropIndex("dbo.TestScriptRes", "ix_IsDeleted");
            DropIndex("dbo.TestScriptRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.TestScriptRes", "ix_IsCurrent");
            DropIndex("dbo.TestReportResIndex", new[] { "ResourceId" });
            DropIndex("dbo.TestReportResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.TestReportResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.TestReportResIndex", "ix_Code");
            DropIndex("dbo.TestReportResIndex", "ix_System");
            DropIndex("dbo.TestReportResIndex", "ix_Uri");
            DropIndex("dbo.TestReportResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.TestReportResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.TestReportResIndex", "ix_String");
            DropIndex("dbo.TestReportResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.TestReportRes", "ix_LastUpdated");
            DropIndex("dbo.TestReportRes", "ix_IsDeleted");
            DropIndex("dbo.TestReportRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.TestReportRes", "ix_IsCurrent");
            DropIndex("dbo.TaskResIndex", new[] { "ResourceId" });
            DropIndex("dbo.TaskResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.TaskResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.TaskResIndex", "ix_Code");
            DropIndex("dbo.TaskResIndex", "ix_System");
            DropIndex("dbo.TaskResIndex", "ix_Uri");
            DropIndex("dbo.TaskResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.TaskResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.TaskResIndex", "ix_String");
            DropIndex("dbo.TaskResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.TaskRes", "ix_LastUpdated");
            DropIndex("dbo.TaskRes", "ix_IsDeleted");
            DropIndex("dbo.TaskRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.TaskRes", "ix_IsCurrent");
            DropIndex("dbo.SupplyRequestResIndex", new[] { "ResourceId" });
            DropIndex("dbo.SupplyRequestResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.SupplyRequestResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.SupplyRequestResIndex", "ix_Code");
            DropIndex("dbo.SupplyRequestResIndex", "ix_System");
            DropIndex("dbo.SupplyRequestResIndex", "ix_Uri");
            DropIndex("dbo.SupplyRequestResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.SupplyRequestResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.SupplyRequestResIndex", "ix_String");
            DropIndex("dbo.SupplyRequestResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.SupplyRequestRes", "ix_LastUpdated");
            DropIndex("dbo.SupplyRequestRes", "ix_IsDeleted");
            DropIndex("dbo.SupplyRequestRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.SupplyRequestRes", "ix_IsCurrent");
            DropIndex("dbo.SupplyDeliveryResIndex", new[] { "ResourceId" });
            DropIndex("dbo.SupplyDeliveryResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.SupplyDeliveryResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.SupplyDeliveryResIndex", "ix_Code");
            DropIndex("dbo.SupplyDeliveryResIndex", "ix_System");
            DropIndex("dbo.SupplyDeliveryResIndex", "ix_Uri");
            DropIndex("dbo.SupplyDeliveryResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.SupplyDeliveryResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.SupplyDeliveryResIndex", "ix_String");
            DropIndex("dbo.SupplyDeliveryResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.SupplyDeliveryRes", "ix_LastUpdated");
            DropIndex("dbo.SupplyDeliveryRes", "ix_IsDeleted");
            DropIndex("dbo.SupplyDeliveryRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.SupplyDeliveryRes", "ix_IsCurrent");
            DropIndex("dbo.SubstanceResIndex", new[] { "ResourceId" });
            DropIndex("dbo.SubstanceResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.SubstanceResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.SubstanceResIndex", "ix_Code");
            DropIndex("dbo.SubstanceResIndex", "ix_System");
            DropIndex("dbo.SubstanceResIndex", "ix_Uri");
            DropIndex("dbo.SubstanceResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.SubstanceResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.SubstanceResIndex", "ix_String");
            DropIndex("dbo.SubstanceResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.SubstanceRes", "ix_LastUpdated");
            DropIndex("dbo.SubstanceRes", "ix_IsDeleted");
            DropIndex("dbo.SubstanceRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.SubstanceRes", "ix_IsCurrent");
            DropIndex("dbo.SubscriptionResIndex", new[] { "ResourceId" });
            DropIndex("dbo.SubscriptionResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.SubscriptionResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.SubscriptionResIndex", "ix_Code");
            DropIndex("dbo.SubscriptionResIndex", "ix_System");
            DropIndex("dbo.SubscriptionResIndex", "ix_Uri");
            DropIndex("dbo.SubscriptionResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.SubscriptionResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.SubscriptionResIndex", "ix_String");
            DropIndex("dbo.SubscriptionResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.SubscriptionRes", "ix_LastUpdated");
            DropIndex("dbo.SubscriptionRes", "ix_IsDeleted");
            DropIndex("dbo.SubscriptionRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.SubscriptionRes", "ix_IsCurrent");
            DropIndex("dbo.StructureMapResIndex", new[] { "ResourceId" });
            DropIndex("dbo.StructureMapResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.StructureMapResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.StructureMapResIndex", "ix_Code");
            DropIndex("dbo.StructureMapResIndex", "ix_System");
            DropIndex("dbo.StructureMapResIndex", "ix_Uri");
            DropIndex("dbo.StructureMapResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.StructureMapResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.StructureMapResIndex", "ix_String");
            DropIndex("dbo.StructureMapResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.StructureMapRes", "ix_LastUpdated");
            DropIndex("dbo.StructureMapRes", "ix_IsDeleted");
            DropIndex("dbo.StructureMapRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.StructureMapRes", "ix_IsCurrent");
            DropIndex("dbo.StructureDefinitionResIndex", new[] { "ResourceId" });
            DropIndex("dbo.StructureDefinitionResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.StructureDefinitionResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.StructureDefinitionResIndex", "ix_Code");
            DropIndex("dbo.StructureDefinitionResIndex", "ix_System");
            DropIndex("dbo.StructureDefinitionResIndex", "ix_Uri");
            DropIndex("dbo.StructureDefinitionResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.StructureDefinitionResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.StructureDefinitionResIndex", "ix_String");
            DropIndex("dbo.StructureDefinitionResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.StructureDefinitionRes", "ix_LastUpdated");
            DropIndex("dbo.StructureDefinitionRes", "ix_IsDeleted");
            DropIndex("dbo.StructureDefinitionRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.StructureDefinitionRes", "ix_IsCurrent");
            DropIndex("dbo.SpecimenResIndex", new[] { "ResourceId" });
            DropIndex("dbo.SpecimenResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.SpecimenResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.SpecimenResIndex", "ix_Code");
            DropIndex("dbo.SpecimenResIndex", "ix_System");
            DropIndex("dbo.SpecimenResIndex", "ix_Uri");
            DropIndex("dbo.SpecimenResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.SpecimenResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.SpecimenResIndex", "ix_String");
            DropIndex("dbo.SpecimenResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.SpecimenRes", "ix_LastUpdated");
            DropIndex("dbo.SpecimenRes", "ix_IsDeleted");
            DropIndex("dbo.SpecimenRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.SpecimenRes", "ix_IsCurrent");
            DropIndex("dbo.SlotResIndex", new[] { "ResourceId" });
            DropIndex("dbo.SlotResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.SlotResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.SlotResIndex", "ix_Code");
            DropIndex("dbo.SlotResIndex", "ix_System");
            DropIndex("dbo.SlotResIndex", "ix_Uri");
            DropIndex("dbo.SlotResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.SlotResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.SlotResIndex", "ix_String");
            DropIndex("dbo.SlotResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.SlotRes", "ix_LastUpdated");
            DropIndex("dbo.SlotRes", "ix_IsDeleted");
            DropIndex("dbo.SlotRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.SlotRes", "ix_IsCurrent");
            DropIndex("dbo.ServiceDefinitionResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ServiceDefinitionResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.ServiceDefinitionResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ServiceDefinitionResIndex", "ix_Code");
            DropIndex("dbo.ServiceDefinitionResIndex", "ix_System");
            DropIndex("dbo.ServiceDefinitionResIndex", "ix_Uri");
            DropIndex("dbo.ServiceDefinitionResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.ServiceDefinitionResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.ServiceDefinitionResIndex", "ix_String");
            DropIndex("dbo.ServiceDefinitionResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.ServiceDefinitionRes", "ix_LastUpdated");
            DropIndex("dbo.ServiceDefinitionRes", "ix_IsDeleted");
            DropIndex("dbo.ServiceDefinitionRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ServiceDefinitionRes", "ix_IsCurrent");
            DropIndex("dbo.SequenceResIndex", new[] { "ResourceId" });
            DropIndex("dbo.SequenceResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.SequenceResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.SequenceResIndex", "ix_Code");
            DropIndex("dbo.SequenceResIndex", "ix_System");
            DropIndex("dbo.SequenceResIndex", "ix_Uri");
            DropIndex("dbo.SequenceResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.SequenceResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.SequenceResIndex", "ix_String");
            DropIndex("dbo.SequenceResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.SequenceRes", "ix_LastUpdated");
            DropIndex("dbo.SequenceRes", "ix_IsDeleted");
            DropIndex("dbo.SequenceRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.SequenceRes", "ix_IsCurrent");
            DropIndex("dbo.SearchParameterResIndex", new[] { "ResourceId" });
            DropIndex("dbo.SearchParameterResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.SearchParameterResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.SearchParameterResIndex", "ix_Code");
            DropIndex("dbo.SearchParameterResIndex", "ix_System");
            DropIndex("dbo.SearchParameterResIndex", "ix_Uri");
            DropIndex("dbo.SearchParameterResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.SearchParameterResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.SearchParameterResIndex", "ix_String");
            DropIndex("dbo.SearchParameterResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.SearchParameterRes", "ix_LastUpdated");
            DropIndex("dbo.SearchParameterRes", "ix_IsDeleted");
            DropIndex("dbo.SearchParameterRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.SearchParameterRes", "ix_IsCurrent");
            DropIndex("dbo.ScheduleResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ScheduleResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.ScheduleResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ScheduleResIndex", "ix_Code");
            DropIndex("dbo.ScheduleResIndex", "ix_System");
            DropIndex("dbo.ScheduleResIndex", "ix_Uri");
            DropIndex("dbo.ScheduleResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.ScheduleResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.ScheduleResIndex", "ix_String");
            DropIndex("dbo.ScheduleResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.ScheduleRes", "ix_LastUpdated");
            DropIndex("dbo.ScheduleRes", "ix_IsDeleted");
            DropIndex("dbo.ScheduleRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ScheduleRes", "ix_IsCurrent");
            DropIndex("dbo.RiskAssessmentResIndex", new[] { "ResourceId" });
            DropIndex("dbo.RiskAssessmentResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.RiskAssessmentResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.RiskAssessmentResIndex", "ix_Code");
            DropIndex("dbo.RiskAssessmentResIndex", "ix_System");
            DropIndex("dbo.RiskAssessmentResIndex", "ix_Uri");
            DropIndex("dbo.RiskAssessmentResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.RiskAssessmentResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.RiskAssessmentResIndex", "ix_String");
            DropIndex("dbo.RiskAssessmentResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.RiskAssessmentRes", "ix_LastUpdated");
            DropIndex("dbo.RiskAssessmentRes", "ix_IsDeleted");
            DropIndex("dbo.RiskAssessmentRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.RiskAssessmentRes", "ix_IsCurrent");
            DropIndex("dbo.ResearchSubjectResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ResearchSubjectResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.ResearchSubjectResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ResearchSubjectResIndex", "ix_Code");
            DropIndex("dbo.ResearchSubjectResIndex", "ix_System");
            DropIndex("dbo.ResearchSubjectResIndex", "ix_Uri");
            DropIndex("dbo.ResearchSubjectResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.ResearchSubjectResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.ResearchSubjectResIndex", "ix_String");
            DropIndex("dbo.ResearchSubjectResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.ResearchSubjectRes", "ix_LastUpdated");
            DropIndex("dbo.ResearchSubjectRes", "ix_IsDeleted");
            DropIndex("dbo.ResearchSubjectRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ResearchSubjectRes", "ix_IsCurrent");
            DropIndex("dbo.ResearchStudyResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ResearchStudyResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.ResearchStudyResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ResearchStudyResIndex", "ix_Code");
            DropIndex("dbo.ResearchStudyResIndex", "ix_System");
            DropIndex("dbo.ResearchStudyResIndex", "ix_Uri");
            DropIndex("dbo.ResearchStudyResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.ResearchStudyResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.ResearchStudyResIndex", "ix_String");
            DropIndex("dbo.ResearchStudyResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.ResearchStudyRes", "ix_LastUpdated");
            DropIndex("dbo.ResearchStudyRes", "ix_IsDeleted");
            DropIndex("dbo.ResearchStudyRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ResearchStudyRes", "ix_IsCurrent");
            DropIndex("dbo.RequestGroupResIndex", new[] { "ResourceId" });
            DropIndex("dbo.RequestGroupResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.RequestGroupResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.RequestGroupResIndex", "ix_Code");
            DropIndex("dbo.RequestGroupResIndex", "ix_System");
            DropIndex("dbo.RequestGroupResIndex", "ix_Uri");
            DropIndex("dbo.RequestGroupResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.RequestGroupResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.RequestGroupResIndex", "ix_String");
            DropIndex("dbo.RequestGroupResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.RequestGroupRes", "ix_LastUpdated");
            DropIndex("dbo.RequestGroupRes", "ix_IsDeleted");
            DropIndex("dbo.RequestGroupRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.RequestGroupRes", "ix_IsCurrent");
            DropIndex("dbo.RelatedPersonResIndex", new[] { "ResourceId" });
            DropIndex("dbo.RelatedPersonResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.RelatedPersonResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.RelatedPersonResIndex", "ix_Code");
            DropIndex("dbo.RelatedPersonResIndex", "ix_System");
            DropIndex("dbo.RelatedPersonResIndex", "ix_Uri");
            DropIndex("dbo.RelatedPersonResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.RelatedPersonResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.RelatedPersonResIndex", "ix_String");
            DropIndex("dbo.RelatedPersonResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.RelatedPersonRes", "ix_LastUpdated");
            DropIndex("dbo.RelatedPersonRes", "ix_IsDeleted");
            DropIndex("dbo.RelatedPersonRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.RelatedPersonRes", "ix_IsCurrent");
            DropIndex("dbo.ReferralRequestResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ReferralRequestResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.ReferralRequestResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ReferralRequestResIndex", "ix_Code");
            DropIndex("dbo.ReferralRequestResIndex", "ix_System");
            DropIndex("dbo.ReferralRequestResIndex", "ix_Uri");
            DropIndex("dbo.ReferralRequestResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.ReferralRequestResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.ReferralRequestResIndex", "ix_String");
            DropIndex("dbo.ReferralRequestResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.ReferralRequestRes", "ix_LastUpdated");
            DropIndex("dbo.ReferralRequestRes", "ix_IsDeleted");
            DropIndex("dbo.ReferralRequestRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ReferralRequestRes", "ix_IsCurrent");
            DropIndex("dbo.QuestionnaireResponseResIndex", new[] { "ResourceId" });
            DropIndex("dbo.QuestionnaireResponseResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.QuestionnaireResponseResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.QuestionnaireResponseResIndex", "ix_Code");
            DropIndex("dbo.QuestionnaireResponseResIndex", "ix_System");
            DropIndex("dbo.QuestionnaireResponseResIndex", "ix_Uri");
            DropIndex("dbo.QuestionnaireResponseResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.QuestionnaireResponseResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.QuestionnaireResponseResIndex", "ix_String");
            DropIndex("dbo.QuestionnaireResponseResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.QuestionnaireResponseRes", "ix_LastUpdated");
            DropIndex("dbo.QuestionnaireResponseRes", "ix_IsDeleted");
            DropIndex("dbo.QuestionnaireResponseRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.QuestionnaireResponseRes", "ix_IsCurrent");
            DropIndex("dbo.QuestionnaireResIndex", new[] { "ResourceId" });
            DropIndex("dbo.QuestionnaireResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.QuestionnaireResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.QuestionnaireResIndex", "ix_Code");
            DropIndex("dbo.QuestionnaireResIndex", "ix_System");
            DropIndex("dbo.QuestionnaireResIndex", "ix_Uri");
            DropIndex("dbo.QuestionnaireResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.QuestionnaireResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.QuestionnaireResIndex", "ix_String");
            DropIndex("dbo.QuestionnaireResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.QuestionnaireRes", "ix_LastUpdated");
            DropIndex("dbo.QuestionnaireRes", "ix_IsDeleted");
            DropIndex("dbo.QuestionnaireRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.QuestionnaireRes", "ix_IsCurrent");
            DropIndex("dbo.ProvenanceResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ProvenanceResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.ProvenanceResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ProvenanceResIndex", "ix_Code");
            DropIndex("dbo.ProvenanceResIndex", "ix_System");
            DropIndex("dbo.ProvenanceResIndex", "ix_Uri");
            DropIndex("dbo.ProvenanceResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.ProvenanceResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.ProvenanceResIndex", "ix_String");
            DropIndex("dbo.ProvenanceResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.ProvenanceRes", "ix_LastUpdated");
            DropIndex("dbo.ProvenanceRes", "ix_IsDeleted");
            DropIndex("dbo.ProvenanceRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ProvenanceRes", "ix_IsCurrent");
            DropIndex("dbo.ProcessResponseResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ProcessResponseResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.ProcessResponseResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ProcessResponseResIndex", "ix_Code");
            DropIndex("dbo.ProcessResponseResIndex", "ix_System");
            DropIndex("dbo.ProcessResponseResIndex", "ix_Uri");
            DropIndex("dbo.ProcessResponseResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.ProcessResponseResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.ProcessResponseResIndex", "ix_String");
            DropIndex("dbo.ProcessResponseResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.ProcessResponseRes", "ix_LastUpdated");
            DropIndex("dbo.ProcessResponseRes", "ix_IsDeleted");
            DropIndex("dbo.ProcessResponseRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ProcessResponseRes", "ix_IsCurrent");
            DropIndex("dbo.ProcessRequestResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ProcessRequestResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.ProcessRequestResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ProcessRequestResIndex", "ix_Code");
            DropIndex("dbo.ProcessRequestResIndex", "ix_System");
            DropIndex("dbo.ProcessRequestResIndex", "ix_Uri");
            DropIndex("dbo.ProcessRequestResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.ProcessRequestResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.ProcessRequestResIndex", "ix_String");
            DropIndex("dbo.ProcessRequestResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.ProcessRequestRes", "ix_LastUpdated");
            DropIndex("dbo.ProcessRequestRes", "ix_IsDeleted");
            DropIndex("dbo.ProcessRequestRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ProcessRequestRes", "ix_IsCurrent");
            DropIndex("dbo.ProcedureRequestResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ProcedureRequestResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.ProcedureRequestResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ProcedureRequestResIndex", "ix_Code");
            DropIndex("dbo.ProcedureRequestResIndex", "ix_System");
            DropIndex("dbo.ProcedureRequestResIndex", "ix_Uri");
            DropIndex("dbo.ProcedureRequestResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.ProcedureRequestResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.ProcedureRequestResIndex", "ix_String");
            DropIndex("dbo.ProcedureRequestResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.ProcedureRequestRes", "ix_LastUpdated");
            DropIndex("dbo.ProcedureRequestRes", "ix_IsDeleted");
            DropIndex("dbo.ProcedureRequestRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ProcedureRequestRes", "ix_IsCurrent");
            DropIndex("dbo.ProcedureResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ProcedureResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.ProcedureResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ProcedureResIndex", "ix_Code");
            DropIndex("dbo.ProcedureResIndex", "ix_System");
            DropIndex("dbo.ProcedureResIndex", "ix_Uri");
            DropIndex("dbo.ProcedureResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.ProcedureResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.ProcedureResIndex", "ix_String");
            DropIndex("dbo.ProcedureResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.ProcedureRes", "ix_LastUpdated");
            DropIndex("dbo.ProcedureRes", "ix_IsDeleted");
            DropIndex("dbo.ProcedureRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ProcedureRes", "ix_IsCurrent");
            DropIndex("dbo.PractitionerRoleResIndex", new[] { "ResourceId" });
            DropIndex("dbo.PractitionerRoleResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.PractitionerRoleResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.PractitionerRoleResIndex", "ix_Code");
            DropIndex("dbo.PractitionerRoleResIndex", "ix_System");
            DropIndex("dbo.PractitionerRoleResIndex", "ix_Uri");
            DropIndex("dbo.PractitionerRoleResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.PractitionerRoleResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.PractitionerRoleResIndex", "ix_String");
            DropIndex("dbo.PractitionerRoleResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.PractitionerRoleRes", "ix_LastUpdated");
            DropIndex("dbo.PractitionerRoleRes", "ix_IsDeleted");
            DropIndex("dbo.PractitionerRoleRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.PractitionerRoleRes", "ix_IsCurrent");
            DropIndex("dbo.PractitionerResIndex", new[] { "ResourceId" });
            DropIndex("dbo.PractitionerResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.PractitionerResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.PractitionerResIndex", "ix_Code");
            DropIndex("dbo.PractitionerResIndex", "ix_System");
            DropIndex("dbo.PractitionerResIndex", "ix_Uri");
            DropIndex("dbo.PractitionerResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.PractitionerResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.PractitionerResIndex", "ix_String");
            DropIndex("dbo.PractitionerResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.PractitionerRes", "ix_LastUpdated");
            DropIndex("dbo.PractitionerRes", "ix_IsDeleted");
            DropIndex("dbo.PractitionerRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.PractitionerRes", "ix_IsCurrent");
            DropIndex("dbo.PlanDefinitionResIndex", new[] { "ResourceId" });
            DropIndex("dbo.PlanDefinitionResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.PlanDefinitionResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.PlanDefinitionResIndex", "ix_Code");
            DropIndex("dbo.PlanDefinitionResIndex", "ix_System");
            DropIndex("dbo.PlanDefinitionResIndex", "ix_Uri");
            DropIndex("dbo.PlanDefinitionResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.PlanDefinitionResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.PlanDefinitionResIndex", "ix_String");
            DropIndex("dbo.PlanDefinitionResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.PlanDefinitionRes", "ix_LastUpdated");
            DropIndex("dbo.PlanDefinitionRes", "ix_IsDeleted");
            DropIndex("dbo.PlanDefinitionRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.PlanDefinitionRes", "ix_IsCurrent");
            DropIndex("dbo.PersonResIndex", new[] { "ResourceId" });
            DropIndex("dbo.PersonResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.PersonResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.PersonResIndex", "ix_Code");
            DropIndex("dbo.PersonResIndex", "ix_System");
            DropIndex("dbo.PersonResIndex", "ix_Uri");
            DropIndex("dbo.PersonResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.PersonResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.PersonResIndex", "ix_String");
            DropIndex("dbo.PersonResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.PersonRes", "ix_LastUpdated");
            DropIndex("dbo.PersonRes", "ix_IsDeleted");
            DropIndex("dbo.PersonRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.PersonRes", "ix_IsCurrent");
            DropIndex("dbo.PaymentReconciliationResIndex", new[] { "ResourceId" });
            DropIndex("dbo.PaymentReconciliationResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.PaymentReconciliationResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.PaymentReconciliationResIndex", "ix_Code");
            DropIndex("dbo.PaymentReconciliationResIndex", "ix_System");
            DropIndex("dbo.PaymentReconciliationResIndex", "ix_Uri");
            DropIndex("dbo.PaymentReconciliationResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.PaymentReconciliationResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.PaymentReconciliationResIndex", "ix_String");
            DropIndex("dbo.PaymentReconciliationResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.PaymentReconciliationRes", "ix_LastUpdated");
            DropIndex("dbo.PaymentReconciliationRes", "ix_IsDeleted");
            DropIndex("dbo.PaymentReconciliationRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.PaymentReconciliationRes", "ix_IsCurrent");
            DropIndex("dbo.PaymentNoticeResIndex", new[] { "ResourceId" });
            DropIndex("dbo.PaymentNoticeResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.PaymentNoticeResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.PaymentNoticeResIndex", "ix_Code");
            DropIndex("dbo.PaymentNoticeResIndex", "ix_System");
            DropIndex("dbo.PaymentNoticeResIndex", "ix_Uri");
            DropIndex("dbo.PaymentNoticeResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.PaymentNoticeResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.PaymentNoticeResIndex", "ix_String");
            DropIndex("dbo.PaymentNoticeResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.PaymentNoticeRes", "ix_LastUpdated");
            DropIndex("dbo.PaymentNoticeRes", "ix_IsDeleted");
            DropIndex("dbo.PaymentNoticeRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.PaymentNoticeRes", "ix_IsCurrent");
            DropIndex("dbo.PatientResIndex", new[] { "ResourceId" });
            DropIndex("dbo.PatientResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.PatientResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.PatientResIndex", "ix_Code");
            DropIndex("dbo.PatientResIndex", "ix_System");
            DropIndex("dbo.PatientResIndex", "ix_Uri");
            DropIndex("dbo.PatientResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.PatientResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.PatientResIndex", "ix_String");
            DropIndex("dbo.PatientResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.PatientRes", "ix_LastUpdated");
            DropIndex("dbo.PatientRes", "ix_IsDeleted");
            DropIndex("dbo.PatientRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.PatientRes", "ix_IsCurrent");
            DropIndex("dbo.ParametersResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ParametersResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.ParametersResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ParametersResIndex", "ix_Code");
            DropIndex("dbo.ParametersResIndex", "ix_System");
            DropIndex("dbo.ParametersResIndex", "ix_Uri");
            DropIndex("dbo.ParametersResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.ParametersResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.ParametersResIndex", "ix_String");
            DropIndex("dbo.ParametersResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.ParametersRes", "ix_LastUpdated");
            DropIndex("dbo.ParametersRes", "ix_IsDeleted");
            DropIndex("dbo.ParametersRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ParametersRes", "ix_IsCurrent");
            DropIndex("dbo.OrganizationResIndex", new[] { "ResourceId" });
            DropIndex("dbo.OrganizationResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.OrganizationResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.OrganizationResIndex", "ix_Code");
            DropIndex("dbo.OrganizationResIndex", "ix_System");
            DropIndex("dbo.OrganizationResIndex", "ix_Uri");
            DropIndex("dbo.OrganizationResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.OrganizationResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.OrganizationResIndex", "ix_String");
            DropIndex("dbo.OrganizationResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.OrganizationRes", "ix_LastUpdated");
            DropIndex("dbo.OrganizationRes", "ix_IsDeleted");
            DropIndex("dbo.OrganizationRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.OrganizationRes", "ix_IsCurrent");
            DropIndex("dbo.OperationOutcomeResIndex", new[] { "ResourceId" });
            DropIndex("dbo.OperationOutcomeResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.OperationOutcomeResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.OperationOutcomeResIndex", "ix_Code");
            DropIndex("dbo.OperationOutcomeResIndex", "ix_System");
            DropIndex("dbo.OperationOutcomeResIndex", "ix_Uri");
            DropIndex("dbo.OperationOutcomeResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.OperationOutcomeResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.OperationOutcomeResIndex", "ix_String");
            DropIndex("dbo.OperationOutcomeResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.OperationOutcomeRes", "ix_LastUpdated");
            DropIndex("dbo.OperationOutcomeRes", "ix_IsDeleted");
            DropIndex("dbo.OperationOutcomeRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.OperationOutcomeRes", "ix_IsCurrent");
            DropIndex("dbo.OperationDefinitionResIndex", new[] { "ResourceId" });
            DropIndex("dbo.OperationDefinitionResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.OperationDefinitionResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.OperationDefinitionResIndex", "ix_Code");
            DropIndex("dbo.OperationDefinitionResIndex", "ix_System");
            DropIndex("dbo.OperationDefinitionResIndex", "ix_Uri");
            DropIndex("dbo.OperationDefinitionResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.OperationDefinitionResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.OperationDefinitionResIndex", "ix_String");
            DropIndex("dbo.OperationDefinitionResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.OperationDefinitionRes", "ix_LastUpdated");
            DropIndex("dbo.OperationDefinitionRes", "ix_IsDeleted");
            DropIndex("dbo.OperationDefinitionRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.OperationDefinitionRes", "ix_IsCurrent");
            DropIndex("dbo.ObservationResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ObservationResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.ObservationResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ObservationResIndex", "ix_Code");
            DropIndex("dbo.ObservationResIndex", "ix_System");
            DropIndex("dbo.ObservationResIndex", "ix_Uri");
            DropIndex("dbo.ObservationResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.ObservationResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.ObservationResIndex", "ix_String");
            DropIndex("dbo.ObservationResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.ObservationRes", "ix_LastUpdated");
            DropIndex("dbo.ObservationRes", "ix_IsDeleted");
            DropIndex("dbo.ObservationRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ObservationRes", "ix_IsCurrent");
            DropIndex("dbo.NutritionOrderResIndex", new[] { "ResourceId" });
            DropIndex("dbo.NutritionOrderResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.NutritionOrderResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.NutritionOrderResIndex", "ix_Code");
            DropIndex("dbo.NutritionOrderResIndex", "ix_System");
            DropIndex("dbo.NutritionOrderResIndex", "ix_Uri");
            DropIndex("dbo.NutritionOrderResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.NutritionOrderResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.NutritionOrderResIndex", "ix_String");
            DropIndex("dbo.NutritionOrderResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.NutritionOrderRes", "ix_LastUpdated");
            DropIndex("dbo.NutritionOrderRes", "ix_IsDeleted");
            DropIndex("dbo.NutritionOrderRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.NutritionOrderRes", "ix_IsCurrent");
            DropIndex("dbo.NamingSystemResIndex", new[] { "ResourceId" });
            DropIndex("dbo.NamingSystemResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.NamingSystemResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.NamingSystemResIndex", "ix_Code");
            DropIndex("dbo.NamingSystemResIndex", "ix_System");
            DropIndex("dbo.NamingSystemResIndex", "ix_Uri");
            DropIndex("dbo.NamingSystemResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.NamingSystemResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.NamingSystemResIndex", "ix_String");
            DropIndex("dbo.NamingSystemResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.NamingSystemRes", "ix_LastUpdated");
            DropIndex("dbo.NamingSystemRes", "ix_IsDeleted");
            DropIndex("dbo.NamingSystemRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.NamingSystemRes", "ix_IsCurrent");
            DropIndex("dbo.MessageHeaderResIndex", new[] { "ResourceId" });
            DropIndex("dbo.MessageHeaderResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.MessageHeaderResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.MessageHeaderResIndex", "ix_Code");
            DropIndex("dbo.MessageHeaderResIndex", "ix_System");
            DropIndex("dbo.MessageHeaderResIndex", "ix_Uri");
            DropIndex("dbo.MessageHeaderResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.MessageHeaderResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.MessageHeaderResIndex", "ix_String");
            DropIndex("dbo.MessageHeaderResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.MessageHeaderRes", "ix_LastUpdated");
            DropIndex("dbo.MessageHeaderRes", "ix_IsDeleted");
            DropIndex("dbo.MessageHeaderRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.MessageHeaderRes", "ix_IsCurrent");
            DropIndex("dbo.MessageDefinitionResIndex", new[] { "ResourceId" });
            DropIndex("dbo.MessageDefinitionResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.MessageDefinitionResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.MessageDefinitionResIndex", "ix_Code");
            DropIndex("dbo.MessageDefinitionResIndex", "ix_System");
            DropIndex("dbo.MessageDefinitionResIndex", "ix_Uri");
            DropIndex("dbo.MessageDefinitionResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.MessageDefinitionResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.MessageDefinitionResIndex", "ix_String");
            DropIndex("dbo.MessageDefinitionResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.MessageDefinitionRes", "ix_LastUpdated");
            DropIndex("dbo.MessageDefinitionRes", "ix_IsDeleted");
            DropIndex("dbo.MessageDefinitionRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.MessageDefinitionRes", "ix_IsCurrent");
            DropIndex("dbo.MedicationStatementResIndex", new[] { "ResourceId" });
            DropIndex("dbo.MedicationStatementResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.MedicationStatementResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.MedicationStatementResIndex", "ix_Code");
            DropIndex("dbo.MedicationStatementResIndex", "ix_System");
            DropIndex("dbo.MedicationStatementResIndex", "ix_Uri");
            DropIndex("dbo.MedicationStatementResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.MedicationStatementResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.MedicationStatementResIndex", "ix_String");
            DropIndex("dbo.MedicationStatementResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.MedicationStatementRes", "ix_LastUpdated");
            DropIndex("dbo.MedicationStatementRes", "ix_IsDeleted");
            DropIndex("dbo.MedicationStatementRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.MedicationStatementRes", "ix_IsCurrent");
            DropIndex("dbo.MedicationRequestResIndex", new[] { "ResourceId" });
            DropIndex("dbo.MedicationRequestResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.MedicationRequestResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.MedicationRequestResIndex", "ix_Code");
            DropIndex("dbo.MedicationRequestResIndex", "ix_System");
            DropIndex("dbo.MedicationRequestResIndex", "ix_Uri");
            DropIndex("dbo.MedicationRequestResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.MedicationRequestResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.MedicationRequestResIndex", "ix_String");
            DropIndex("dbo.MedicationRequestResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.MedicationRequestRes", "ix_LastUpdated");
            DropIndex("dbo.MedicationRequestRes", "ix_IsDeleted");
            DropIndex("dbo.MedicationRequestRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.MedicationRequestRes", "ix_IsCurrent");
            DropIndex("dbo.MedicationDispenseResIndex", new[] { "ResourceId" });
            DropIndex("dbo.MedicationDispenseResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.MedicationDispenseResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.MedicationDispenseResIndex", "ix_Code");
            DropIndex("dbo.MedicationDispenseResIndex", "ix_System");
            DropIndex("dbo.MedicationDispenseResIndex", "ix_Uri");
            DropIndex("dbo.MedicationDispenseResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.MedicationDispenseResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.MedicationDispenseResIndex", "ix_String");
            DropIndex("dbo.MedicationDispenseResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.MedicationDispenseRes", "ix_LastUpdated");
            DropIndex("dbo.MedicationDispenseRes", "ix_IsDeleted");
            DropIndex("dbo.MedicationDispenseRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.MedicationDispenseRes", "ix_IsCurrent");
            DropIndex("dbo.MedicationAdministrationResIndex", new[] { "ResourceId" });
            DropIndex("dbo.MedicationAdministrationResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.MedicationAdministrationResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.MedicationAdministrationResIndex", "ix_Code");
            DropIndex("dbo.MedicationAdministrationResIndex", "ix_System");
            DropIndex("dbo.MedicationAdministrationResIndex", "ix_Uri");
            DropIndex("dbo.MedicationAdministrationResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.MedicationAdministrationResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.MedicationAdministrationResIndex", "ix_String");
            DropIndex("dbo.MedicationAdministrationResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.MedicationAdministrationRes", "ix_LastUpdated");
            DropIndex("dbo.MedicationAdministrationRes", "ix_IsDeleted");
            DropIndex("dbo.MedicationAdministrationRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.MedicationAdministrationRes", "ix_IsCurrent");
            DropIndex("dbo.MedicationResIndex", new[] { "ResourceId" });
            DropIndex("dbo.MedicationResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.MedicationResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.MedicationResIndex", "ix_Code");
            DropIndex("dbo.MedicationResIndex", "ix_System");
            DropIndex("dbo.MedicationResIndex", "ix_Uri");
            DropIndex("dbo.MedicationResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.MedicationResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.MedicationResIndex", "ix_String");
            DropIndex("dbo.MedicationResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.MedicationRes", "ix_LastUpdated");
            DropIndex("dbo.MedicationRes", "ix_IsDeleted");
            DropIndex("dbo.MedicationRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.MedicationRes", "ix_IsCurrent");
            DropIndex("dbo.MediaResIndex", new[] { "ResourceId" });
            DropIndex("dbo.MediaResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.MediaResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.MediaResIndex", "ix_Code");
            DropIndex("dbo.MediaResIndex", "ix_System");
            DropIndex("dbo.MediaResIndex", "ix_Uri");
            DropIndex("dbo.MediaResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.MediaResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.MediaResIndex", "ix_String");
            DropIndex("dbo.MediaResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.MediaRes", "ix_LastUpdated");
            DropIndex("dbo.MediaRes", "ix_IsDeleted");
            DropIndex("dbo.MediaRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.MediaRes", "ix_IsCurrent");
            DropIndex("dbo.MeasureReportResIndex", new[] { "ResourceId" });
            DropIndex("dbo.MeasureReportResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.MeasureReportResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.MeasureReportResIndex", "ix_Code");
            DropIndex("dbo.MeasureReportResIndex", "ix_System");
            DropIndex("dbo.MeasureReportResIndex", "ix_Uri");
            DropIndex("dbo.MeasureReportResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.MeasureReportResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.MeasureReportResIndex", "ix_String");
            DropIndex("dbo.MeasureReportResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.MeasureReportRes", "ix_LastUpdated");
            DropIndex("dbo.MeasureReportRes", "ix_IsDeleted");
            DropIndex("dbo.MeasureReportRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.MeasureReportRes", "ix_IsCurrent");
            DropIndex("dbo.MeasureResIndex", new[] { "ResourceId" });
            DropIndex("dbo.MeasureResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.MeasureResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.MeasureResIndex", "ix_Code");
            DropIndex("dbo.MeasureResIndex", "ix_System");
            DropIndex("dbo.MeasureResIndex", "ix_Uri");
            DropIndex("dbo.MeasureResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.MeasureResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.MeasureResIndex", "ix_String");
            DropIndex("dbo.MeasureResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.MeasureRes", "ix_LastUpdated");
            DropIndex("dbo.MeasureRes", "ix_IsDeleted");
            DropIndex("dbo.MeasureRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.MeasureRes", "ix_IsCurrent");
            DropIndex("dbo.LocationResIndex", new[] { "ResourceId" });
            DropIndex("dbo.LocationResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.LocationResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.LocationResIndex", "ix_Code");
            DropIndex("dbo.LocationResIndex", "ix_System");
            DropIndex("dbo.LocationResIndex", "ix_Uri");
            DropIndex("dbo.LocationResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.LocationResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.LocationResIndex", "ix_String");
            DropIndex("dbo.LocationResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.LocationRes", "ix_LastUpdated");
            DropIndex("dbo.LocationRes", "ix_IsDeleted");
            DropIndex("dbo.LocationRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.LocationRes", "ix_IsCurrent");
            DropIndex("dbo.ListResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ListResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.ListResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ListResIndex", "ix_Code");
            DropIndex("dbo.ListResIndex", "ix_System");
            DropIndex("dbo.ListResIndex", "ix_Uri");
            DropIndex("dbo.ListResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.ListResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.ListResIndex", "ix_String");
            DropIndex("dbo.ListResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.ListRes", "ix_LastUpdated");
            DropIndex("dbo.ListRes", "ix_IsDeleted");
            DropIndex("dbo.ListRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ListRes", "ix_IsCurrent");
            DropIndex("dbo.LinkageResIndex", new[] { "ResourceId" });
            DropIndex("dbo.LinkageResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.LinkageResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.LinkageResIndex", "ix_Code");
            DropIndex("dbo.LinkageResIndex", "ix_System");
            DropIndex("dbo.LinkageResIndex", "ix_Uri");
            DropIndex("dbo.LinkageResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.LinkageResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.LinkageResIndex", "ix_String");
            DropIndex("dbo.LinkageResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.LinkageRes", "ix_LastUpdated");
            DropIndex("dbo.LinkageRes", "ix_IsDeleted");
            DropIndex("dbo.LinkageRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.LinkageRes", "ix_IsCurrent");
            DropIndex("dbo.LibraryResIndex", new[] { "ResourceId" });
            DropIndex("dbo.LibraryResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.LibraryResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.LibraryResIndex", "ix_Code");
            DropIndex("dbo.LibraryResIndex", "ix_System");
            DropIndex("dbo.LibraryResIndex", "ix_Uri");
            DropIndex("dbo.LibraryResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.LibraryResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.LibraryResIndex", "ix_String");
            DropIndex("dbo.LibraryResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.LibraryRes", "ix_LastUpdated");
            DropIndex("dbo.LibraryRes", "ix_IsDeleted");
            DropIndex("dbo.LibraryRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.LibraryRes", "ix_IsCurrent");
            DropIndex("dbo.ImplementationGuideResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ImplementationGuideResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.ImplementationGuideResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ImplementationGuideResIndex", "ix_Code");
            DropIndex("dbo.ImplementationGuideResIndex", "ix_System");
            DropIndex("dbo.ImplementationGuideResIndex", "ix_Uri");
            DropIndex("dbo.ImplementationGuideResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.ImplementationGuideResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.ImplementationGuideResIndex", "ix_String");
            DropIndex("dbo.ImplementationGuideResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.ImplementationGuideRes", "ix_LastUpdated");
            DropIndex("dbo.ImplementationGuideRes", "ix_IsDeleted");
            DropIndex("dbo.ImplementationGuideRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ImplementationGuideRes", "ix_IsCurrent");
            DropIndex("dbo.ImmunizationRecommendationResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ImmunizationRecommendationResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.ImmunizationRecommendationResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ImmunizationRecommendationResIndex", "ix_Code");
            DropIndex("dbo.ImmunizationRecommendationResIndex", "ix_System");
            DropIndex("dbo.ImmunizationRecommendationResIndex", "ix_Uri");
            DropIndex("dbo.ImmunizationRecommendationResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.ImmunizationRecommendationResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.ImmunizationRecommendationResIndex", "ix_String");
            DropIndex("dbo.ImmunizationRecommendationResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.ImmunizationRecommendationRes", "ix_LastUpdated");
            DropIndex("dbo.ImmunizationRecommendationRes", "ix_IsDeleted");
            DropIndex("dbo.ImmunizationRecommendationRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ImmunizationRecommendationRes", "ix_IsCurrent");
            DropIndex("dbo.ImmunizationResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ImmunizationResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.ImmunizationResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ImmunizationResIndex", "ix_Code");
            DropIndex("dbo.ImmunizationResIndex", "ix_System");
            DropIndex("dbo.ImmunizationResIndex", "ix_Uri");
            DropIndex("dbo.ImmunizationResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.ImmunizationResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.ImmunizationResIndex", "ix_String");
            DropIndex("dbo.ImmunizationResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.ImmunizationRes", "ix_LastUpdated");
            DropIndex("dbo.ImmunizationRes", "ix_IsDeleted");
            DropIndex("dbo.ImmunizationRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ImmunizationRes", "ix_IsCurrent");
            DropIndex("dbo.ImagingStudyResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ImagingStudyResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.ImagingStudyResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ImagingStudyResIndex", "ix_Code");
            DropIndex("dbo.ImagingStudyResIndex", "ix_System");
            DropIndex("dbo.ImagingStudyResIndex", "ix_Uri");
            DropIndex("dbo.ImagingStudyResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.ImagingStudyResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.ImagingStudyResIndex", "ix_String");
            DropIndex("dbo.ImagingStudyResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.ImagingStudyRes", "ix_LastUpdated");
            DropIndex("dbo.ImagingStudyRes", "ix_IsDeleted");
            DropIndex("dbo.ImagingStudyRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ImagingStudyRes", "ix_IsCurrent");
            DropIndex("dbo.ImagingManifestResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ImagingManifestResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.ImagingManifestResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ImagingManifestResIndex", "ix_Code");
            DropIndex("dbo.ImagingManifestResIndex", "ix_System");
            DropIndex("dbo.ImagingManifestResIndex", "ix_Uri");
            DropIndex("dbo.ImagingManifestResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.ImagingManifestResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.ImagingManifestResIndex", "ix_String");
            DropIndex("dbo.ImagingManifestResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.ImagingManifestRes", "ix_LastUpdated");
            DropIndex("dbo.ImagingManifestRes", "ix_IsDeleted");
            DropIndex("dbo.ImagingManifestRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ImagingManifestRes", "ix_IsCurrent");
            DropIndex("dbo.HealthcareServiceResIndex", new[] { "ResourceId" });
            DropIndex("dbo.HealthcareServiceResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.HealthcareServiceResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.HealthcareServiceResIndex", "ix_Code");
            DropIndex("dbo.HealthcareServiceResIndex", "ix_System");
            DropIndex("dbo.HealthcareServiceResIndex", "ix_Uri");
            DropIndex("dbo.HealthcareServiceResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.HealthcareServiceResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.HealthcareServiceResIndex", "ix_String");
            DropIndex("dbo.HealthcareServiceResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.HealthcareServiceRes", "ix_LastUpdated");
            DropIndex("dbo.HealthcareServiceRes", "ix_IsDeleted");
            DropIndex("dbo.HealthcareServiceRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.HealthcareServiceRes", "ix_IsCurrent");
            DropIndex("dbo.GuidanceResponseResIndex", new[] { "ResourceId" });
            DropIndex("dbo.GuidanceResponseResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.GuidanceResponseResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.GuidanceResponseResIndex", "ix_Code");
            DropIndex("dbo.GuidanceResponseResIndex", "ix_System");
            DropIndex("dbo.GuidanceResponseResIndex", "ix_Uri");
            DropIndex("dbo.GuidanceResponseResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.GuidanceResponseResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.GuidanceResponseResIndex", "ix_String");
            DropIndex("dbo.GuidanceResponseResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.GuidanceResponseRes", "ix_LastUpdated");
            DropIndex("dbo.GuidanceResponseRes", "ix_IsDeleted");
            DropIndex("dbo.GuidanceResponseRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.GuidanceResponseRes", "ix_IsCurrent");
            DropIndex("dbo.GroupResIndex", new[] { "ResourceId" });
            DropIndex("dbo.GroupResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.GroupResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.GroupResIndex", "ix_Code");
            DropIndex("dbo.GroupResIndex", "ix_System");
            DropIndex("dbo.GroupResIndex", "ix_Uri");
            DropIndex("dbo.GroupResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.GroupResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.GroupResIndex", "ix_String");
            DropIndex("dbo.GroupResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.GroupRes", "ix_LastUpdated");
            DropIndex("dbo.GroupRes", "ix_IsDeleted");
            DropIndex("dbo.GroupRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.GroupRes", "ix_IsCurrent");
            DropIndex("dbo.GraphDefinitionResIndex", new[] { "ResourceId" });
            DropIndex("dbo.GraphDefinitionResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.GraphDefinitionResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.GraphDefinitionResIndex", "ix_Code");
            DropIndex("dbo.GraphDefinitionResIndex", "ix_System");
            DropIndex("dbo.GraphDefinitionResIndex", "ix_Uri");
            DropIndex("dbo.GraphDefinitionResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.GraphDefinitionResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.GraphDefinitionResIndex", "ix_String");
            DropIndex("dbo.GraphDefinitionResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.GraphDefinitionRes", "ix_LastUpdated");
            DropIndex("dbo.GraphDefinitionRes", "ix_IsDeleted");
            DropIndex("dbo.GraphDefinitionRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.GraphDefinitionRes", "ix_IsCurrent");
            DropIndex("dbo.GoalResIndex", new[] { "ResourceId" });
            DropIndex("dbo.GoalResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.GoalResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.GoalResIndex", "ix_Code");
            DropIndex("dbo.GoalResIndex", "ix_System");
            DropIndex("dbo.GoalResIndex", "ix_Uri");
            DropIndex("dbo.GoalResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.GoalResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.GoalResIndex", "ix_String");
            DropIndex("dbo.GoalResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.GoalRes", "ix_LastUpdated");
            DropIndex("dbo.GoalRes", "ix_IsDeleted");
            DropIndex("dbo.GoalRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.GoalRes", "ix_IsCurrent");
            DropIndex("dbo.FlagResIndex", new[] { "ResourceId" });
            DropIndex("dbo.FlagResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.FlagResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.FlagResIndex", "ix_Code");
            DropIndex("dbo.FlagResIndex", "ix_System");
            DropIndex("dbo.FlagResIndex", "ix_Uri");
            DropIndex("dbo.FlagResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.FlagResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.FlagResIndex", "ix_String");
            DropIndex("dbo.FlagResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.FlagRes", "ix_LastUpdated");
            DropIndex("dbo.FlagRes", "ix_IsDeleted");
            DropIndex("dbo.FlagRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.FlagRes", "ix_IsCurrent");
            DropIndex("dbo.FamilyMemberHistoryResIndex", new[] { "ResourceId" });
            DropIndex("dbo.FamilyMemberHistoryResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.FamilyMemberHistoryResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.FamilyMemberHistoryResIndex", "ix_Code");
            DropIndex("dbo.FamilyMemberHistoryResIndex", "ix_System");
            DropIndex("dbo.FamilyMemberHistoryResIndex", "ix_Uri");
            DropIndex("dbo.FamilyMemberHistoryResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.FamilyMemberHistoryResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.FamilyMemberHistoryResIndex", "ix_String");
            DropIndex("dbo.FamilyMemberHistoryResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.FamilyMemberHistoryRes", "ix_LastUpdated");
            DropIndex("dbo.FamilyMemberHistoryRes", "ix_IsDeleted");
            DropIndex("dbo.FamilyMemberHistoryRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.FamilyMemberHistoryRes", "ix_IsCurrent");
            DropIndex("dbo.ExplanationOfBenefitResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ExplanationOfBenefitResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.ExplanationOfBenefitResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ExplanationOfBenefitResIndex", "ix_Code");
            DropIndex("dbo.ExplanationOfBenefitResIndex", "ix_System");
            DropIndex("dbo.ExplanationOfBenefitResIndex", "ix_Uri");
            DropIndex("dbo.ExplanationOfBenefitResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.ExplanationOfBenefitResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.ExplanationOfBenefitResIndex", "ix_String");
            DropIndex("dbo.ExplanationOfBenefitResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.ExplanationOfBenefitRes", "ix_LastUpdated");
            DropIndex("dbo.ExplanationOfBenefitRes", "ix_IsDeleted");
            DropIndex("dbo.ExplanationOfBenefitRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ExplanationOfBenefitRes", "ix_IsCurrent");
            DropIndex("dbo.ExpansionProfileResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ExpansionProfileResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.ExpansionProfileResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ExpansionProfileResIndex", "ix_Code");
            DropIndex("dbo.ExpansionProfileResIndex", "ix_System");
            DropIndex("dbo.ExpansionProfileResIndex", "ix_Uri");
            DropIndex("dbo.ExpansionProfileResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.ExpansionProfileResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.ExpansionProfileResIndex", "ix_String");
            DropIndex("dbo.ExpansionProfileResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.ExpansionProfileRes", "ix_LastUpdated");
            DropIndex("dbo.ExpansionProfileRes", "ix_IsDeleted");
            DropIndex("dbo.ExpansionProfileRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ExpansionProfileRes", "ix_IsCurrent");
            DropIndex("dbo.EpisodeOfCareResIndex", new[] { "ResourceId" });
            DropIndex("dbo.EpisodeOfCareResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.EpisodeOfCareResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.EpisodeOfCareResIndex", "ix_Code");
            DropIndex("dbo.EpisodeOfCareResIndex", "ix_System");
            DropIndex("dbo.EpisodeOfCareResIndex", "ix_Uri");
            DropIndex("dbo.EpisodeOfCareResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.EpisodeOfCareResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.EpisodeOfCareResIndex", "ix_String");
            DropIndex("dbo.EpisodeOfCareResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.EpisodeOfCareRes", "ix_LastUpdated");
            DropIndex("dbo.EpisodeOfCareRes", "ix_IsDeleted");
            DropIndex("dbo.EpisodeOfCareRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.EpisodeOfCareRes", "ix_IsCurrent");
            DropIndex("dbo.EnrollmentResponseResIndex", new[] { "ResourceId" });
            DropIndex("dbo.EnrollmentResponseResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.EnrollmentResponseResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.EnrollmentResponseResIndex", "ix_Code");
            DropIndex("dbo.EnrollmentResponseResIndex", "ix_System");
            DropIndex("dbo.EnrollmentResponseResIndex", "ix_Uri");
            DropIndex("dbo.EnrollmentResponseResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.EnrollmentResponseResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.EnrollmentResponseResIndex", "ix_String");
            DropIndex("dbo.EnrollmentResponseResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.EnrollmentResponseRes", "ix_LastUpdated");
            DropIndex("dbo.EnrollmentResponseRes", "ix_IsDeleted");
            DropIndex("dbo.EnrollmentResponseRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.EnrollmentResponseRes", "ix_IsCurrent");
            DropIndex("dbo.EnrollmentRequestResIndex", new[] { "ResourceId" });
            DropIndex("dbo.EnrollmentRequestResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.EnrollmentRequestResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.EnrollmentRequestResIndex", "ix_Code");
            DropIndex("dbo.EnrollmentRequestResIndex", "ix_System");
            DropIndex("dbo.EnrollmentRequestResIndex", "ix_Uri");
            DropIndex("dbo.EnrollmentRequestResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.EnrollmentRequestResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.EnrollmentRequestResIndex", "ix_String");
            DropIndex("dbo.EnrollmentRequestResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.EnrollmentRequestRes", "ix_LastUpdated");
            DropIndex("dbo.EnrollmentRequestRes", "ix_IsDeleted");
            DropIndex("dbo.EnrollmentRequestRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.EnrollmentRequestRes", "ix_IsCurrent");
            DropIndex("dbo.EndpointResIndex", new[] { "ResourceId" });
            DropIndex("dbo.EndpointResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.EndpointResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.EndpointResIndex", "ix_Code");
            DropIndex("dbo.EndpointResIndex", "ix_System");
            DropIndex("dbo.EndpointResIndex", "ix_Uri");
            DropIndex("dbo.EndpointResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.EndpointResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.EndpointResIndex", "ix_String");
            DropIndex("dbo.EndpointResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.EndpointRes", "ix_LastUpdated");
            DropIndex("dbo.EndpointRes", "ix_IsDeleted");
            DropIndex("dbo.EndpointRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.EndpointRes", "ix_IsCurrent");
            DropIndex("dbo.EncounterResIndex", new[] { "ResourceId" });
            DropIndex("dbo.EncounterResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.EncounterResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.EncounterResIndex", "ix_Code");
            DropIndex("dbo.EncounterResIndex", "ix_System");
            DropIndex("dbo.EncounterResIndex", "ix_Uri");
            DropIndex("dbo.EncounterResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.EncounterResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.EncounterResIndex", "ix_String");
            DropIndex("dbo.EncounterResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.EncounterRes", "ix_LastUpdated");
            DropIndex("dbo.EncounterRes", "ix_IsDeleted");
            DropIndex("dbo.EncounterRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.EncounterRes", "ix_IsCurrent");
            DropIndex("dbo.EligibilityResponseResIndex", new[] { "ResourceId" });
            DropIndex("dbo.EligibilityResponseResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.EligibilityResponseResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.EligibilityResponseResIndex", "ix_Code");
            DropIndex("dbo.EligibilityResponseResIndex", "ix_System");
            DropIndex("dbo.EligibilityResponseResIndex", "ix_Uri");
            DropIndex("dbo.EligibilityResponseResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.EligibilityResponseResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.EligibilityResponseResIndex", "ix_String");
            DropIndex("dbo.EligibilityResponseResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.EligibilityResponseRes", "ix_LastUpdated");
            DropIndex("dbo.EligibilityResponseRes", "ix_IsDeleted");
            DropIndex("dbo.EligibilityResponseRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.EligibilityResponseRes", "ix_IsCurrent");
            DropIndex("dbo.EligibilityRequestResIndex", new[] { "ResourceId" });
            DropIndex("dbo.EligibilityRequestResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.EligibilityRequestResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.EligibilityRequestResIndex", "ix_Code");
            DropIndex("dbo.EligibilityRequestResIndex", "ix_System");
            DropIndex("dbo.EligibilityRequestResIndex", "ix_Uri");
            DropIndex("dbo.EligibilityRequestResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.EligibilityRequestResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.EligibilityRequestResIndex", "ix_String");
            DropIndex("dbo.EligibilityRequestResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.EligibilityRequestRes", "ix_LastUpdated");
            DropIndex("dbo.EligibilityRequestRes", "ix_IsDeleted");
            DropIndex("dbo.EligibilityRequestRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.EligibilityRequestRes", "ix_IsCurrent");
            DropIndex("dbo.DocumentReferenceResIndex", new[] { "ResourceId" });
            DropIndex("dbo.DocumentReferenceResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.DocumentReferenceResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.DocumentReferenceResIndex", "ix_Code");
            DropIndex("dbo.DocumentReferenceResIndex", "ix_System");
            DropIndex("dbo.DocumentReferenceResIndex", "ix_Uri");
            DropIndex("dbo.DocumentReferenceResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.DocumentReferenceResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.DocumentReferenceResIndex", "ix_String");
            DropIndex("dbo.DocumentReferenceResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.DocumentReferenceRes", "ix_LastUpdated");
            DropIndex("dbo.DocumentReferenceRes", "ix_IsDeleted");
            DropIndex("dbo.DocumentReferenceRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.DocumentReferenceRes", "ix_IsCurrent");
            DropIndex("dbo.DocumentManifestResIndex", new[] { "ResourceId" });
            DropIndex("dbo.DocumentManifestResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.DocumentManifestResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.DocumentManifestResIndex", "ix_Code");
            DropIndex("dbo.DocumentManifestResIndex", "ix_System");
            DropIndex("dbo.DocumentManifestResIndex", "ix_Uri");
            DropIndex("dbo.DocumentManifestResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.DocumentManifestResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.DocumentManifestResIndex", "ix_String");
            DropIndex("dbo.DocumentManifestResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.DocumentManifestRes", "ix_LastUpdated");
            DropIndex("dbo.DocumentManifestRes", "ix_IsDeleted");
            DropIndex("dbo.DocumentManifestRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.DocumentManifestRes", "ix_IsCurrent");
            DropIndex("dbo.DiagnosticReportResIndex", new[] { "ResourceId" });
            DropIndex("dbo.DiagnosticReportResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.DiagnosticReportResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.DiagnosticReportResIndex", "ix_Code");
            DropIndex("dbo.DiagnosticReportResIndex", "ix_System");
            DropIndex("dbo.DiagnosticReportResIndex", "ix_Uri");
            DropIndex("dbo.DiagnosticReportResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.DiagnosticReportResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.DiagnosticReportResIndex", "ix_String");
            DropIndex("dbo.DiagnosticReportResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.DiagnosticReportRes", "ix_LastUpdated");
            DropIndex("dbo.DiagnosticReportRes", "ix_IsDeleted");
            DropIndex("dbo.DiagnosticReportRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.DiagnosticReportRes", "ix_IsCurrent");
            DropIndex("dbo.DeviceUseStatementResIndex", new[] { "ResourceId" });
            DropIndex("dbo.DeviceUseStatementResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.DeviceUseStatementResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.DeviceUseStatementResIndex", "ix_Code");
            DropIndex("dbo.DeviceUseStatementResIndex", "ix_System");
            DropIndex("dbo.DeviceUseStatementResIndex", "ix_Uri");
            DropIndex("dbo.DeviceUseStatementResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.DeviceUseStatementResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.DeviceUseStatementResIndex", "ix_String");
            DropIndex("dbo.DeviceUseStatementResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.DeviceUseStatementRes", "ix_LastUpdated");
            DropIndex("dbo.DeviceUseStatementRes", "ix_IsDeleted");
            DropIndex("dbo.DeviceUseStatementRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.DeviceUseStatementRes", "ix_IsCurrent");
            DropIndex("dbo.DeviceRequestResIndex", new[] { "ResourceId" });
            DropIndex("dbo.DeviceRequestResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.DeviceRequestResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.DeviceRequestResIndex", "ix_Code");
            DropIndex("dbo.DeviceRequestResIndex", "ix_System");
            DropIndex("dbo.DeviceRequestResIndex", "ix_Uri");
            DropIndex("dbo.DeviceRequestResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.DeviceRequestResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.DeviceRequestResIndex", "ix_String");
            DropIndex("dbo.DeviceRequestResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.DeviceRequestRes", "ix_LastUpdated");
            DropIndex("dbo.DeviceRequestRes", "ix_IsDeleted");
            DropIndex("dbo.DeviceRequestRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.DeviceRequestRes", "ix_IsCurrent");
            DropIndex("dbo.DeviceMetricResIndex", new[] { "ResourceId" });
            DropIndex("dbo.DeviceMetricResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.DeviceMetricResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.DeviceMetricResIndex", "ix_Code");
            DropIndex("dbo.DeviceMetricResIndex", "ix_System");
            DropIndex("dbo.DeviceMetricResIndex", "ix_Uri");
            DropIndex("dbo.DeviceMetricResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.DeviceMetricResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.DeviceMetricResIndex", "ix_String");
            DropIndex("dbo.DeviceMetricResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.DeviceMetricRes", "ix_LastUpdated");
            DropIndex("dbo.DeviceMetricRes", "ix_IsDeleted");
            DropIndex("dbo.DeviceMetricRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.DeviceMetricRes", "ix_IsCurrent");
            DropIndex("dbo.DeviceComponentResIndex", new[] { "ResourceId" });
            DropIndex("dbo.DeviceComponentResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.DeviceComponentResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.DeviceComponentResIndex", "ix_Code");
            DropIndex("dbo.DeviceComponentResIndex", "ix_System");
            DropIndex("dbo.DeviceComponentResIndex", "ix_Uri");
            DropIndex("dbo.DeviceComponentResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.DeviceComponentResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.DeviceComponentResIndex", "ix_String");
            DropIndex("dbo.DeviceComponentResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.DeviceComponentRes", "ix_LastUpdated");
            DropIndex("dbo.DeviceComponentRes", "ix_IsDeleted");
            DropIndex("dbo.DeviceComponentRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.DeviceComponentRes", "ix_IsCurrent");
            DropIndex("dbo.DeviceResIndex", new[] { "ResourceId" });
            DropIndex("dbo.DeviceResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.DeviceResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.DeviceResIndex", "ix_Code");
            DropIndex("dbo.DeviceResIndex", "ix_System");
            DropIndex("dbo.DeviceResIndex", "ix_Uri");
            DropIndex("dbo.DeviceResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.DeviceResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.DeviceResIndex", "ix_String");
            DropIndex("dbo.DeviceResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.DeviceRes", "ix_LastUpdated");
            DropIndex("dbo.DeviceRes", "ix_IsDeleted");
            DropIndex("dbo.DeviceRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.DeviceRes", "ix_IsCurrent");
            DropIndex("dbo.DetectedIssueResIndex", new[] { "ResourceId" });
            DropIndex("dbo.DetectedIssueResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.DetectedIssueResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.DetectedIssueResIndex", "ix_Code");
            DropIndex("dbo.DetectedIssueResIndex", "ix_System");
            DropIndex("dbo.DetectedIssueResIndex", "ix_Uri");
            DropIndex("dbo.DetectedIssueResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.DetectedIssueResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.DetectedIssueResIndex", "ix_String");
            DropIndex("dbo.DetectedIssueResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.DetectedIssueRes", "ix_LastUpdated");
            DropIndex("dbo.DetectedIssueRes", "ix_IsDeleted");
            DropIndex("dbo.DetectedIssueRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.DetectedIssueRes", "ix_IsCurrent");
            DropIndex("dbo.DataElementResIndex", new[] { "ResourceId" });
            DropIndex("dbo.DataElementResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.DataElementResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.DataElementResIndex", "ix_Code");
            DropIndex("dbo.DataElementResIndex", "ix_System");
            DropIndex("dbo.DataElementResIndex", "ix_Uri");
            DropIndex("dbo.DataElementResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.DataElementResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.DataElementResIndex", "ix_String");
            DropIndex("dbo.DataElementResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.DataElementRes", "ix_LastUpdated");
            DropIndex("dbo.DataElementRes", "ix_IsDeleted");
            DropIndex("dbo.DataElementRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.DataElementRes", "ix_IsCurrent");
            DropIndex("dbo.CoverageResIndex", new[] { "ResourceId" });
            DropIndex("dbo.CoverageResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.CoverageResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.CoverageResIndex", "ix_Code");
            DropIndex("dbo.CoverageResIndex", "ix_System");
            DropIndex("dbo.CoverageResIndex", "ix_Uri");
            DropIndex("dbo.CoverageResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.CoverageResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.CoverageResIndex", "ix_String");
            DropIndex("dbo.CoverageResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.CoverageRes", "ix_LastUpdated");
            DropIndex("dbo.CoverageRes", "ix_IsDeleted");
            DropIndex("dbo.CoverageRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.CoverageRes", "ix_IsCurrent");
            DropIndex("dbo.ContractResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ContractResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.ContractResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ContractResIndex", "ix_Code");
            DropIndex("dbo.ContractResIndex", "ix_System");
            DropIndex("dbo.ContractResIndex", "ix_Uri");
            DropIndex("dbo.ContractResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.ContractResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.ContractResIndex", "ix_String");
            DropIndex("dbo.ContractResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.ContractRes", "ix_LastUpdated");
            DropIndex("dbo.ContractRes", "ix_IsDeleted");
            DropIndex("dbo.ContractRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ContractRes", "ix_IsCurrent");
            DropIndex("dbo.ConsentResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ConsentResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.ConsentResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ConsentResIndex", "ix_Code");
            DropIndex("dbo.ConsentResIndex", "ix_System");
            DropIndex("dbo.ConsentResIndex", "ix_Uri");
            DropIndex("dbo.ConsentResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.ConsentResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.ConsentResIndex", "ix_String");
            DropIndex("dbo.ConsentResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.ConsentRes", "ix_LastUpdated");
            DropIndex("dbo.ConsentRes", "ix_IsDeleted");
            DropIndex("dbo.ConsentRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ConsentRes", "ix_IsCurrent");
            DropIndex("dbo.ConditionResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ConditionResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.ConditionResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ConditionResIndex", "ix_Code");
            DropIndex("dbo.ConditionResIndex", "ix_System");
            DropIndex("dbo.ConditionResIndex", "ix_Uri");
            DropIndex("dbo.ConditionResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.ConditionResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.ConditionResIndex", "ix_String");
            DropIndex("dbo.ConditionResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.ConditionRes", "ix_LastUpdated");
            DropIndex("dbo.ConditionRes", "ix_IsDeleted");
            DropIndex("dbo.ConditionRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ConditionRes", "ix_IsCurrent");
            DropIndex("dbo.ConceptMapResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ConceptMapResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.ConceptMapResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ConceptMapResIndex", "ix_Code");
            DropIndex("dbo.ConceptMapResIndex", "ix_System");
            DropIndex("dbo.ConceptMapResIndex", "ix_Uri");
            DropIndex("dbo.ConceptMapResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.ConceptMapResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.ConceptMapResIndex", "ix_String");
            DropIndex("dbo.ConceptMapResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.ConceptMapRes", "ix_LastUpdated");
            DropIndex("dbo.ConceptMapRes", "ix_IsDeleted");
            DropIndex("dbo.ConceptMapRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ConceptMapRes", "ix_IsCurrent");
            DropIndex("dbo.CompositionResIndex", new[] { "ResourceId" });
            DropIndex("dbo.CompositionResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.CompositionResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.CompositionResIndex", "ix_Code");
            DropIndex("dbo.CompositionResIndex", "ix_System");
            DropIndex("dbo.CompositionResIndex", "ix_Uri");
            DropIndex("dbo.CompositionResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.CompositionResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.CompositionResIndex", "ix_String");
            DropIndex("dbo.CompositionResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.CompositionRes", "ix_LastUpdated");
            DropIndex("dbo.CompositionRes", "ix_IsDeleted");
            DropIndex("dbo.CompositionRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.CompositionRes", "ix_IsCurrent");
            DropIndex("dbo.CompartmentDefinitionResIndex", new[] { "ResourceId" });
            DropIndex("dbo.CompartmentDefinitionResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.CompartmentDefinitionResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.CompartmentDefinitionResIndex", "ix_Code");
            DropIndex("dbo.CompartmentDefinitionResIndex", "ix_System");
            DropIndex("dbo.CompartmentDefinitionResIndex", "ix_Uri");
            DropIndex("dbo.CompartmentDefinitionResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.CompartmentDefinitionResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.CompartmentDefinitionResIndex", "ix_String");
            DropIndex("dbo.CompartmentDefinitionResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.CompartmentDefinitionRes", "ix_LastUpdated");
            DropIndex("dbo.CompartmentDefinitionRes", "ix_IsDeleted");
            DropIndex("dbo.CompartmentDefinitionRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.CompartmentDefinitionRes", "ix_IsCurrent");
            DropIndex("dbo.CommunicationRequestResIndex", new[] { "ResourceId" });
            DropIndex("dbo.CommunicationRequestResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.CommunicationRequestResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.CommunicationRequestResIndex", "ix_Code");
            DropIndex("dbo.CommunicationRequestResIndex", "ix_System");
            DropIndex("dbo.CommunicationRequestResIndex", "ix_Uri");
            DropIndex("dbo.CommunicationRequestResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.CommunicationRequestResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.CommunicationRequestResIndex", "ix_String");
            DropIndex("dbo.CommunicationRequestResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.CommunicationRequestRes", "ix_LastUpdated");
            DropIndex("dbo.CommunicationRequestRes", "ix_IsDeleted");
            DropIndex("dbo.CommunicationRequestRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.CommunicationRequestRes", "ix_IsCurrent");
            DropIndex("dbo.CommunicationResIndex", new[] { "ResourceId" });
            DropIndex("dbo.CommunicationResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.CommunicationResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.CommunicationResIndex", "ix_Code");
            DropIndex("dbo.CommunicationResIndex", "ix_System");
            DropIndex("dbo.CommunicationResIndex", "ix_Uri");
            DropIndex("dbo.CommunicationResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.CommunicationResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.CommunicationResIndex", "ix_String");
            DropIndex("dbo.CommunicationResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.CommunicationRes", "ix_LastUpdated");
            DropIndex("dbo.CommunicationRes", "ix_IsDeleted");
            DropIndex("dbo.CommunicationRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.CommunicationRes", "ix_IsCurrent");
            DropIndex("dbo.CodeSystemResIndex", new[] { "ResourceId" });
            DropIndex("dbo.CodeSystemResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.CodeSystemResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.CodeSystemResIndex", "ix_Code");
            DropIndex("dbo.CodeSystemResIndex", "ix_System");
            DropIndex("dbo.CodeSystemResIndex", "ix_Uri");
            DropIndex("dbo.CodeSystemResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.CodeSystemResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.CodeSystemResIndex", "ix_String");
            DropIndex("dbo.CodeSystemResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.CodeSystemRes", "ix_LastUpdated");
            DropIndex("dbo.CodeSystemRes", "ix_IsDeleted");
            DropIndex("dbo.CodeSystemRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.CodeSystemRes", "ix_IsCurrent");
            DropIndex("dbo.ClinicalImpressionResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ClinicalImpressionResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.ClinicalImpressionResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ClinicalImpressionResIndex", "ix_Code");
            DropIndex("dbo.ClinicalImpressionResIndex", "ix_System");
            DropIndex("dbo.ClinicalImpressionResIndex", "ix_Uri");
            DropIndex("dbo.ClinicalImpressionResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.ClinicalImpressionResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.ClinicalImpressionResIndex", "ix_String");
            DropIndex("dbo.ClinicalImpressionResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.ClinicalImpressionRes", "ix_LastUpdated");
            DropIndex("dbo.ClinicalImpressionRes", "ix_IsDeleted");
            DropIndex("dbo.ClinicalImpressionRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ClinicalImpressionRes", "ix_IsCurrent");
            DropIndex("dbo.ClaimResponseResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ClaimResponseResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.ClaimResponseResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ClaimResponseResIndex", "ix_Code");
            DropIndex("dbo.ClaimResponseResIndex", "ix_System");
            DropIndex("dbo.ClaimResponseResIndex", "ix_Uri");
            DropIndex("dbo.ClaimResponseResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.ClaimResponseResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.ClaimResponseResIndex", "ix_String");
            DropIndex("dbo.ClaimResponseResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.ClaimResponseRes", "ix_LastUpdated");
            DropIndex("dbo.ClaimResponseRes", "ix_IsDeleted");
            DropIndex("dbo.ClaimResponseRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ClaimResponseRes", "ix_IsCurrent");
            DropIndex("dbo.ClaimResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ClaimResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.ClaimResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ClaimResIndex", "ix_Code");
            DropIndex("dbo.ClaimResIndex", "ix_System");
            DropIndex("dbo.ClaimResIndex", "ix_Uri");
            DropIndex("dbo.ClaimResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.ClaimResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.ClaimResIndex", "ix_String");
            DropIndex("dbo.ClaimResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.ClaimRes", "ix_LastUpdated");
            DropIndex("dbo.ClaimRes", "ix_IsDeleted");
            DropIndex("dbo.ClaimRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ClaimRes", "ix_IsCurrent");
            DropIndex("dbo.ChargeItemResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ChargeItemResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.ChargeItemResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ChargeItemResIndex", "ix_Code");
            DropIndex("dbo.ChargeItemResIndex", "ix_System");
            DropIndex("dbo.ChargeItemResIndex", "ix_Uri");
            DropIndex("dbo.ChargeItemResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.ChargeItemResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.ChargeItemResIndex", "ix_String");
            DropIndex("dbo.ChargeItemResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.ChargeItemRes", "ix_LastUpdated");
            DropIndex("dbo.ChargeItemRes", "ix_IsDeleted");
            DropIndex("dbo.ChargeItemRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ChargeItemRes", "ix_IsCurrent");
            DropIndex("dbo.CareTeamResIndex", new[] { "ResourceId" });
            DropIndex("dbo.CareTeamResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.CareTeamResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.CareTeamResIndex", "ix_Code");
            DropIndex("dbo.CareTeamResIndex", "ix_System");
            DropIndex("dbo.CareTeamResIndex", "ix_Uri");
            DropIndex("dbo.CareTeamResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.CareTeamResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.CareTeamResIndex", "ix_String");
            DropIndex("dbo.CareTeamResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.CareTeamRes", "ix_LastUpdated");
            DropIndex("dbo.CareTeamRes", "ix_IsDeleted");
            DropIndex("dbo.CareTeamRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.CareTeamRes", "ix_IsCurrent");
            DropIndex("dbo.CarePlanResIndex", new[] { "ResourceId" });
            DropIndex("dbo.CarePlanResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.CarePlanResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.CarePlanResIndex", "ix_Code");
            DropIndex("dbo.CarePlanResIndex", "ix_System");
            DropIndex("dbo.CarePlanResIndex", "ix_Uri");
            DropIndex("dbo.CarePlanResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.CarePlanResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.CarePlanResIndex", "ix_String");
            DropIndex("dbo.CarePlanResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.CarePlanRes", "ix_LastUpdated");
            DropIndex("dbo.CarePlanRes", "ix_IsDeleted");
            DropIndex("dbo.CarePlanRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.CarePlanRes", "ix_IsCurrent");
            DropIndex("dbo.CapabilityStatementResIndex", new[] { "ResourceId" });
            DropIndex("dbo.CapabilityStatementResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.CapabilityStatementResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.CapabilityStatementResIndex", "ix_Code");
            DropIndex("dbo.CapabilityStatementResIndex", "ix_System");
            DropIndex("dbo.CapabilityStatementResIndex", "ix_Uri");
            DropIndex("dbo.CapabilityStatementResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.CapabilityStatementResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.CapabilityStatementResIndex", "ix_String");
            DropIndex("dbo.CapabilityStatementResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.CapabilityStatementRes", "ix_LastUpdated");
            DropIndex("dbo.CapabilityStatementRes", "ix_IsDeleted");
            DropIndex("dbo.CapabilityStatementRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.CapabilityStatementRes", "ix_IsCurrent");
            DropIndex("dbo.BundleResIndex", new[] { "ResourceId" });
            DropIndex("dbo.BundleResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.BundleResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.BundleResIndex", "ix_Code");
            DropIndex("dbo.BundleResIndex", "ix_System");
            DropIndex("dbo.BundleResIndex", "ix_Uri");
            DropIndex("dbo.BundleResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.BundleResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.BundleResIndex", "ix_String");
            DropIndex("dbo.BundleResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.BundleRes", "ix_LastUpdated");
            DropIndex("dbo.BundleRes", "ix_IsDeleted");
            DropIndex("dbo.BundleRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.BundleRes", "ix_IsCurrent");
            DropIndex("dbo.BodySiteResIndex", new[] { "ResourceId" });
            DropIndex("dbo.BodySiteResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.BodySiteResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.BodySiteResIndex", "ix_Code");
            DropIndex("dbo.BodySiteResIndex", "ix_System");
            DropIndex("dbo.BodySiteResIndex", "ix_Uri");
            DropIndex("dbo.BodySiteResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.BodySiteResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.BodySiteResIndex", "ix_String");
            DropIndex("dbo.BodySiteResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.BodySiteRes", "ix_LastUpdated");
            DropIndex("dbo.BodySiteRes", "ix_IsDeleted");
            DropIndex("dbo.BodySiteRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.BodySiteRes", "ix_IsCurrent");
            DropIndex("dbo.BinaryResIndex", new[] { "ResourceId" });
            DropIndex("dbo.BinaryResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.BinaryResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.BinaryResIndex", "ix_Code");
            DropIndex("dbo.BinaryResIndex", "ix_System");
            DropIndex("dbo.BinaryResIndex", "ix_Uri");
            DropIndex("dbo.BinaryResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.BinaryResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.BinaryResIndex", "ix_String");
            DropIndex("dbo.BinaryResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.BinaryRes", "ix_LastUpdated");
            DropIndex("dbo.BinaryRes", "ix_IsDeleted");
            DropIndex("dbo.BinaryRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.BinaryRes", "ix_IsCurrent");
            DropIndex("dbo.BasicResIndex", new[] { "ResourceId" });
            DropIndex("dbo.BasicResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.BasicResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.BasicResIndex", "ix_Code");
            DropIndex("dbo.BasicResIndex", "ix_System");
            DropIndex("dbo.BasicResIndex", "ix_Uri");
            DropIndex("dbo.BasicResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.BasicResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.BasicResIndex", "ix_String");
            DropIndex("dbo.BasicResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.BasicRes", "ix_LastUpdated");
            DropIndex("dbo.BasicRes", "ix_IsDeleted");
            DropIndex("dbo.BasicRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.BasicRes", "ix_IsCurrent");
            DropIndex("dbo.AuditEventResIndex", new[] { "ResourceId" });
            DropIndex("dbo.AuditEventResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.AuditEventResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.AuditEventResIndex", "ix_Code");
            DropIndex("dbo.AuditEventResIndex", "ix_System");
            DropIndex("dbo.AuditEventResIndex", "ix_Uri");
            DropIndex("dbo.AuditEventResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.AuditEventResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.AuditEventResIndex", "ix_String");
            DropIndex("dbo.AuditEventResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.AuditEventRes", "ix_LastUpdated");
            DropIndex("dbo.AuditEventRes", "ix_IsDeleted");
            DropIndex("dbo.AuditEventRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.AuditEventRes", "ix_IsCurrent");
            DropIndex("dbo.AppointmentResponseResIndex", new[] { "ResourceId" });
            DropIndex("dbo.AppointmentResponseResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.AppointmentResponseResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.AppointmentResponseResIndex", "ix_Code");
            DropIndex("dbo.AppointmentResponseResIndex", "ix_System");
            DropIndex("dbo.AppointmentResponseResIndex", "ix_Uri");
            DropIndex("dbo.AppointmentResponseResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.AppointmentResponseResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.AppointmentResponseResIndex", "ix_String");
            DropIndex("dbo.AppointmentResponseResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.AppointmentResponseRes", "ix_LastUpdated");
            DropIndex("dbo.AppointmentResponseRes", "ix_IsDeleted");
            DropIndex("dbo.AppointmentResponseRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.AppointmentResponseRes", "ix_IsCurrent");
            DropIndex("dbo.AppointmentResIndex", new[] { "ResourceId" });
            DropIndex("dbo.AppointmentResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.AppointmentResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.AppointmentResIndex", "ix_Code");
            DropIndex("dbo.AppointmentResIndex", "ix_System");
            DropIndex("dbo.AppointmentResIndex", "ix_Uri");
            DropIndex("dbo.AppointmentResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.AppointmentResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.AppointmentResIndex", "ix_String");
            DropIndex("dbo.AppointmentResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.AppointmentRes", "ix_LastUpdated");
            DropIndex("dbo.AppointmentRes", "ix_IsDeleted");
            DropIndex("dbo.AppointmentRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.AppointmentRes", "ix_IsCurrent");
            DropIndex("dbo.AllergyIntoleranceResIndex", new[] { "ResourceId" });
            DropIndex("dbo.AllergyIntoleranceResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.AllergyIntoleranceResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.AllergyIntoleranceResIndex", "ix_Code");
            DropIndex("dbo.AllergyIntoleranceResIndex", "ix_System");
            DropIndex("dbo.AllergyIntoleranceResIndex", "ix_Uri");
            DropIndex("dbo.AllergyIntoleranceResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.AllergyIntoleranceResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.AllergyIntoleranceResIndex", "ix_String");
            DropIndex("dbo.AllergyIntoleranceResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.AllergyIntoleranceRes", "ix_LastUpdated");
            DropIndex("dbo.AllergyIntoleranceRes", "ix_IsDeleted");
            DropIndex("dbo.AllergyIntoleranceRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.AllergyIntoleranceRes", "ix_IsCurrent");
            DropIndex("dbo.AdverseEventResIndex", new[] { "ResourceId" });
            DropIndex("dbo.AdverseEventResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.AdverseEventResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.AdverseEventResIndex", "ix_Code");
            DropIndex("dbo.AdverseEventResIndex", "ix_System");
            DropIndex("dbo.AdverseEventResIndex", "ix_Uri");
            DropIndex("dbo.AdverseEventResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.AdverseEventResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.AdverseEventResIndex", "ix_String");
            DropIndex("dbo.AdverseEventResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.AdverseEventRes", "ix_LastUpdated");
            DropIndex("dbo.AdverseEventRes", "ix_IsDeleted");
            DropIndex("dbo.AdverseEventRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.AdverseEventRes", "ix_IsCurrent");
            DropIndex("dbo.ActivityDefinitionResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ActivityDefinitionResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.ActivityDefinitionResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.ActivityDefinitionResIndex", "ix_Code");
            DropIndex("dbo.ActivityDefinitionResIndex", "ix_System");
            DropIndex("dbo.ActivityDefinitionResIndex", "ix_Uri");
            DropIndex("dbo.ActivityDefinitionResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.ActivityDefinitionResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.ActivityDefinitionResIndex", "ix_String");
            DropIndex("dbo.ActivityDefinitionResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.ActivityDefinitionRes", "ix_LastUpdated");
            DropIndex("dbo.ActivityDefinitionRes", "ix_IsDeleted");
            DropIndex("dbo.ActivityDefinitionRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ActivityDefinitionRes", "ix_IsCurrent");
            DropIndex("dbo.ServiceSearchParameterTargetResource", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.ServiceSearchParameter", "ix_Status");
            DropIndex("dbo.ServiceSearchParameter", "ix_IsIndexed");
            DropIndex("dbo.ServiceSearchParameter", "UQ_ResourceAndName");
            DropIndex("dbo.ServiceBaseUrl", new[] { "Url" });
            DropIndex("dbo.AccountResIndex", new[] { "ResourceId" });
            DropIndex("dbo.AccountResIndex", "ix_ReferenceServiceBaseUrlId");
            DropIndex("dbo.AccountResIndex", "ix_ReferenceFhirId");
            DropIndex("dbo.AccountResIndex", "ix_Code");
            DropIndex("dbo.AccountResIndex", "ix_System");
            DropIndex("dbo.AccountResIndex", "ix_Uri");
            DropIndex("dbo.AccountResIndex", "ix_DateTimeOffsetHigh");
            DropIndex("dbo.AccountResIndex", "ix_DateTimeOffsetLow");
            DropIndex("dbo.AccountResIndex", "ix_String");
            DropIndex("dbo.AccountResIndex", "ix_ServiceSearchParameterId");
            DropIndex("dbo.AccountRes", "ix_LastUpdated");
            DropIndex("dbo.AccountRes", "ix_IsDeleted");
            DropIndex("dbo.AccountRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.AccountRes", "ix_IsCurrent");
            DropTable("dbo.VisionPrescriptionResIndex");
            DropTable("dbo.VisionPrescriptionRes");
            DropTable("dbo.ValueSetResIndex");
            DropTable("dbo.ValueSetRes");
            DropTable("dbo.TestScriptResIndex");
            DropTable("dbo.TestScriptRes");
            DropTable("dbo.TestReportResIndex");
            DropTable("dbo.TestReportRes");
            DropTable("dbo.TaskResIndex");
            DropTable("dbo.TaskRes");
            DropTable("dbo.SupplyRequestResIndex");
            DropTable("dbo.SupplyRequestRes");
            DropTable("dbo.SupplyDeliveryResIndex");
            DropTable("dbo.SupplyDeliveryRes");
            DropTable("dbo.SubstanceResIndex");
            DropTable("dbo.SubstanceRes");
            DropTable("dbo.SubscriptionResIndex");
            DropTable("dbo.SubscriptionRes");
            DropTable("dbo.StructureMapResIndex");
            DropTable("dbo.StructureMapRes");
            DropTable("dbo.StructureDefinitionResIndex");
            DropTable("dbo.StructureDefinitionRes");
            DropTable("dbo.SpecimenResIndex");
            DropTable("dbo.SpecimenRes");
            DropTable("dbo.SlotResIndex");
            DropTable("dbo.SlotRes");
            DropTable("dbo.ServiceDefinitionResIndex");
            DropTable("dbo.ServiceDefinitionRes");
            DropTable("dbo.SequenceResIndex");
            DropTable("dbo.SequenceRes");
            DropTable("dbo.SearchParameterResIndex");
            DropTable("dbo.SearchParameterRes");
            DropTable("dbo.ScheduleResIndex");
            DropTable("dbo.ScheduleRes");
            DropTable("dbo.RiskAssessmentResIndex");
            DropTable("dbo.RiskAssessmentRes");
            DropTable("dbo.ResearchSubjectResIndex");
            DropTable("dbo.ResearchSubjectRes");
            DropTable("dbo.ResearchStudyResIndex");
            DropTable("dbo.ResearchStudyRes");
            DropTable("dbo.RequestGroupResIndex");
            DropTable("dbo.RequestGroupRes");
            DropTable("dbo.RelatedPersonResIndex");
            DropTable("dbo.RelatedPersonRes");
            DropTable("dbo.ReferralRequestResIndex");
            DropTable("dbo.ReferralRequestRes");
            DropTable("dbo.QuestionnaireResponseResIndex");
            DropTable("dbo.QuestionnaireResponseRes");
            DropTable("dbo.QuestionnaireResIndex");
            DropTable("dbo.QuestionnaireRes");
            DropTable("dbo.ProvenanceResIndex");
            DropTable("dbo.ProvenanceRes");
            DropTable("dbo.ProcessResponseResIndex");
            DropTable("dbo.ProcessResponseRes");
            DropTable("dbo.ProcessRequestResIndex");
            DropTable("dbo.ProcessRequestRes");
            DropTable("dbo.ProcedureRequestResIndex");
            DropTable("dbo.ProcedureRequestRes");
            DropTable("dbo.ProcedureResIndex");
            DropTable("dbo.ProcedureRes");
            DropTable("dbo.PractitionerRoleResIndex");
            DropTable("dbo.PractitionerRoleRes");
            DropTable("dbo.PractitionerResIndex");
            DropTable("dbo.PractitionerRes");
            DropTable("dbo.PlanDefinitionResIndex");
            DropTable("dbo.PlanDefinitionRes");
            DropTable("dbo.PersonResIndex");
            DropTable("dbo.PersonRes");
            DropTable("dbo.PaymentReconciliationResIndex");
            DropTable("dbo.PaymentReconciliationRes");
            DropTable("dbo.PaymentNoticeResIndex");
            DropTable("dbo.PaymentNoticeRes");
            DropTable("dbo.PatientResIndex");
            DropTable("dbo.PatientRes");
            DropTable("dbo.ParametersResIndex");
            DropTable("dbo.ParametersRes");
            DropTable("dbo.OrganizationResIndex");
            DropTable("dbo.OrganizationRes");
            DropTable("dbo.OperationOutcomeResIndex");
            DropTable("dbo.OperationOutcomeRes");
            DropTable("dbo.OperationDefinitionResIndex");
            DropTable("dbo.OperationDefinitionRes");
            DropTable("dbo.ObservationResIndex");
            DropTable("dbo.ObservationRes");
            DropTable("dbo.NutritionOrderResIndex");
            DropTable("dbo.NutritionOrderRes");
            DropTable("dbo.NamingSystemResIndex");
            DropTable("dbo.NamingSystemRes");
            DropTable("dbo.MessageHeaderResIndex");
            DropTable("dbo.MessageHeaderRes");
            DropTable("dbo.MessageDefinitionResIndex");
            DropTable("dbo.MessageDefinitionRes");
            DropTable("dbo.MedicationStatementResIndex");
            DropTable("dbo.MedicationStatementRes");
            DropTable("dbo.MedicationRequestResIndex");
            DropTable("dbo.MedicationRequestRes");
            DropTable("dbo.MedicationDispenseResIndex");
            DropTable("dbo.MedicationDispenseRes");
            DropTable("dbo.MedicationAdministrationResIndex");
            DropTable("dbo.MedicationAdministrationRes");
            DropTable("dbo.MedicationResIndex");
            DropTable("dbo.MedicationRes");
            DropTable("dbo.MediaResIndex");
            DropTable("dbo.MediaRes");
            DropTable("dbo.MeasureReportResIndex");
            DropTable("dbo.MeasureReportRes");
            DropTable("dbo.MeasureResIndex");
            DropTable("dbo.MeasureRes");
            DropTable("dbo.LocationResIndex");
            DropTable("dbo.LocationRes");
            DropTable("dbo.ListResIndex");
            DropTable("dbo.ListRes");
            DropTable("dbo.LinkageResIndex");
            DropTable("dbo.LinkageRes");
            DropTable("dbo.LibraryResIndex");
            DropTable("dbo.LibraryRes");
            DropTable("dbo.ImplementationGuideResIndex");
            DropTable("dbo.ImplementationGuideRes");
            DropTable("dbo.ImmunizationRecommendationResIndex");
            DropTable("dbo.ImmunizationRecommendationRes");
            DropTable("dbo.ImmunizationResIndex");
            DropTable("dbo.ImmunizationRes");
            DropTable("dbo.ImagingStudyResIndex");
            DropTable("dbo.ImagingStudyRes");
            DropTable("dbo.ImagingManifestResIndex");
            DropTable("dbo.ImagingManifestRes");
            DropTable("dbo.HealthcareServiceResIndex");
            DropTable("dbo.HealthcareServiceRes");
            DropTable("dbo.GuidanceResponseResIndex");
            DropTable("dbo.GuidanceResponseRes");
            DropTable("dbo.GroupResIndex");
            DropTable("dbo.GroupRes");
            DropTable("dbo.GraphDefinitionResIndex");
            DropTable("dbo.GraphDefinitionRes");
            DropTable("dbo.GoalResIndex");
            DropTable("dbo.GoalRes");
            DropTable("dbo.FlagResIndex");
            DropTable("dbo.FlagRes");
            DropTable("dbo.FamilyMemberHistoryResIndex");
            DropTable("dbo.FamilyMemberHistoryRes");
            DropTable("dbo.ExplanationOfBenefitResIndex");
            DropTable("dbo.ExplanationOfBenefitRes");
            DropTable("dbo.ExpansionProfileResIndex");
            DropTable("dbo.ExpansionProfileRes");
            DropTable("dbo.EpisodeOfCareResIndex");
            DropTable("dbo.EpisodeOfCareRes");
            DropTable("dbo.EnrollmentResponseResIndex");
            DropTable("dbo.EnrollmentResponseRes");
            DropTable("dbo.EnrollmentRequestResIndex");
            DropTable("dbo.EnrollmentRequestRes");
            DropTable("dbo.EndpointResIndex");
            DropTable("dbo.EndpointRes");
            DropTable("dbo.EncounterResIndex");
            DropTable("dbo.EncounterRes");
            DropTable("dbo.EligibilityResponseResIndex");
            DropTable("dbo.EligibilityResponseRes");
            DropTable("dbo.EligibilityRequestResIndex");
            DropTable("dbo.EligibilityRequestRes");
            DropTable("dbo.DocumentReferenceResIndex");
            DropTable("dbo.DocumentReferenceRes");
            DropTable("dbo.DocumentManifestResIndex");
            DropTable("dbo.DocumentManifestRes");
            DropTable("dbo.DiagnosticReportResIndex");
            DropTable("dbo.DiagnosticReportRes");
            DropTable("dbo.DeviceUseStatementResIndex");
            DropTable("dbo.DeviceUseStatementRes");
            DropTable("dbo.DeviceRequestResIndex");
            DropTable("dbo.DeviceRequestRes");
            DropTable("dbo.DeviceMetricResIndex");
            DropTable("dbo.DeviceMetricRes");
            DropTable("dbo.DeviceComponentResIndex");
            DropTable("dbo.DeviceComponentRes");
            DropTable("dbo.DeviceResIndex");
            DropTable("dbo.DeviceRes");
            DropTable("dbo.DetectedIssueResIndex");
            DropTable("dbo.DetectedIssueRes");
            DropTable("dbo.DataElementResIndex");
            DropTable("dbo.DataElementRes");
            DropTable("dbo.CoverageResIndex");
            DropTable("dbo.CoverageRes");
            DropTable("dbo.ContractResIndex");
            DropTable("dbo.ContractRes");
            DropTable("dbo.ConsentResIndex");
            DropTable("dbo.ConsentRes");
            DropTable("dbo.ConditionResIndex");
            DropTable("dbo.ConditionRes");
            DropTable("dbo.ConceptMapResIndex");
            DropTable("dbo.ConceptMapRes");
            DropTable("dbo.CompositionResIndex");
            DropTable("dbo.CompositionRes");
            DropTable("dbo.CompartmentDefinitionResIndex");
            DropTable("dbo.CompartmentDefinitionRes");
            DropTable("dbo.CommunicationRequestResIndex");
            DropTable("dbo.CommunicationRequestRes");
            DropTable("dbo.CommunicationResIndex");
            DropTable("dbo.CommunicationRes");
            DropTable("dbo.CodeSystemResIndex");
            DropTable("dbo.CodeSystemRes");
            DropTable("dbo.ClinicalImpressionResIndex");
            DropTable("dbo.ClinicalImpressionRes");
            DropTable("dbo.ClaimResponseResIndex");
            DropTable("dbo.ClaimResponseRes");
            DropTable("dbo.ClaimResIndex");
            DropTable("dbo.ClaimRes");
            DropTable("dbo.ChargeItemResIndex");
            DropTable("dbo.ChargeItemRes");
            DropTable("dbo.CareTeamResIndex");
            DropTable("dbo.CareTeamRes");
            DropTable("dbo.CarePlanResIndex");
            DropTable("dbo.CarePlanRes");
            DropTable("dbo.CapabilityStatementResIndex");
            DropTable("dbo.CapabilityStatementRes");
            DropTable("dbo.BundleResIndex");
            DropTable("dbo.BundleRes");
            DropTable("dbo.BodySiteResIndex");
            DropTable("dbo.BodySiteRes");
            DropTable("dbo.BinaryResIndex");
            DropTable("dbo.BinaryRes");
            DropTable("dbo.BasicResIndex");
            DropTable("dbo.BasicRes");
            DropTable("dbo.AuditEventResIndex");
            DropTable("dbo.AuditEventRes");
            DropTable("dbo.AppointmentResponseResIndex");
            DropTable("dbo.AppointmentResponseRes");
            DropTable("dbo.AppointmentResIndex");
            DropTable("dbo.AppointmentRes");
            DropTable("dbo.AllergyIntoleranceResIndex");
            DropTable("dbo.AllergyIntoleranceRes");
            DropTable("dbo.AdverseEventResIndex");
            DropTable("dbo.AdverseEventRes");
            DropTable("dbo.ActivityDefinitionResIndex");
            DropTable("dbo.ActivityDefinitionRes");
            DropTable("dbo.ServiceSearchParameterTargetResource");
            DropTable("dbo.ServiceSearchParameter");
            DropTable("dbo.ServiceBaseUrl");
            DropTable("dbo.AccountResIndex");
            DropTable("dbo.AccountRes");
        }
    }
}
