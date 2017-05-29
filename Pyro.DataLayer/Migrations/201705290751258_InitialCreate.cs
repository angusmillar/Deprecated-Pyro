namespace Pyro.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.AccountResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.AccountRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
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
                .PrimaryKey(t => t.Id);
            
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
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.ActivityDefinitionResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.ActivityDefinitionRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.AdverseEventRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.AdverseEventResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.AdverseEventRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.AllergyIntoleranceRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.AllergyIntoleranceResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.AllergyIntoleranceRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.AppointmentRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.AppointmentResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.AppointmentRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.AppointmentResponseRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.AppointmentResponseResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.AppointmentResponseRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.AuditEventRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.AuditEventResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.AuditEventRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.BasicRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.BasicResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.BasicRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.BinaryRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.BinaryResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.BinaryRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.BodySiteRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.BodySiteResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.BodySiteRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.BundleRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.BundleResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.BundleRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.CapabilityStatementRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.CapabilityStatementResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.CapabilityStatementRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.CarePlanRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.CarePlanResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.CarePlanRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.CareTeamRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.CareTeamResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.CareTeamRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.ChargeItemRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.ChargeItemResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.ChargeItemRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.ClaimRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.ClaimResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.ClaimRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.ClaimResponseRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.ClaimResponseResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.ClaimResponseRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.ClinicalImpressionRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.ClinicalImpressionResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.ClinicalImpressionRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.CodeSystemRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.CodeSystemResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.CodeSystemRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.CommunicationRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.CommunicationResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.CommunicationRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.CommunicationRequestRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.CommunicationRequestResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.CommunicationRequestRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.CompartmentDefinitionRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.CompartmentDefinitionResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.CompartmentDefinitionRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.CompositionRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.CompositionResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.CompositionRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.ConceptMapRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.ConceptMapResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.ConceptMapRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.ConditionRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.ConditionResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.ConditionRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.ConsentRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.ConsentResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.ConsentRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.ContractRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.ContractResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.ContractRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.CoverageRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.CoverageResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.CoverageRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.DataElementRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.DataElementResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.DataElementRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.DetectedIssueRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.DetectedIssueResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.DetectedIssueRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.DeviceRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.DeviceResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.DeviceRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.DeviceComponentRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.DeviceComponentResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.DeviceComponentRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.DeviceMetricRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.DeviceMetricResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.DeviceMetricRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.DeviceRequestRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.DeviceRequestResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.DeviceRequestRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.DeviceUseStatementRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.DeviceUseStatementResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.DeviceUseStatementRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.DiagnosticReportRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.DiagnosticReportResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.DiagnosticReportRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.DocumentManifestRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.DocumentManifestResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.DocumentManifestRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.DocumentReferenceRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.DocumentReferenceResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.DocumentReferenceRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.EligibilityRequestRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.EligibilityRequestResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.EligibilityRequestRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.EligibilityResponseRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.EligibilityResponseResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.EligibilityResponseRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.EncounterRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.EncounterResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.EncounterRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.EndpointRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.EndpointResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.EndpointRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.EnrollmentRequestRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.EnrollmentRequestResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.EnrollmentRequestRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.EnrollmentResponseRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.EnrollmentResponseResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.EnrollmentResponseRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.EpisodeOfCareRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.EpisodeOfCareResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.EpisodeOfCareRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.ExpansionProfileRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.ExpansionProfileResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.ExpansionProfileRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.ExplanationOfBenefitRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.ExplanationOfBenefitResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.ExplanationOfBenefitRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.FamilyMemberHistoryRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.FamilyMemberHistoryResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.FamilyMemberHistoryRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.FlagRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.FlagResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.FlagRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.GoalRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.GoalResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.GoalRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.GraphDefinitionRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.GraphDefinitionResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.GraphDefinitionRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.GroupRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.GroupResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.GroupRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.GuidanceResponseRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.GuidanceResponseResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.GuidanceResponseRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.HealthcareServiceRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.HealthcareServiceResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.HealthcareServiceRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.ImagingManifestRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.ImagingManifestResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.ImagingManifestRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.ImagingStudyRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.ImagingStudyResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.ImagingStudyRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.ImmunizationRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.ImmunizationResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.ImmunizationRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.ImmunizationRecommendationRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.ImmunizationRecommendationResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.ImmunizationRecommendationRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.ImplementationGuideRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.ImplementationGuideResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.ImplementationGuideRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.LibraryRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.LibraryResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.LibraryRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.LinkageRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.LinkageResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.LinkageRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.ListRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.ListResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.ListRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.LocationRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.LocationResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.LocationRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.MeasureRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.MeasureResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.MeasureRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.MeasureReportRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.MeasureReportResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.MeasureReportRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.MediaRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.MediaResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.MediaRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.MedicationRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.MedicationResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.MedicationRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.MedicationAdministrationRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.MedicationAdministrationResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.MedicationAdministrationRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.MedicationDispenseRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.MedicationDispenseResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.MedicationDispenseRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.MedicationRequestRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.MedicationRequestResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.MedicationRequestRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.MedicationStatementRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.MedicationStatementResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.MedicationStatementRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.MessageDefinitionRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.MessageDefinitionResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.MessageDefinitionRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.MessageHeaderRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.MessageHeaderResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.MessageHeaderRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.NamingSystemRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.NamingSystemResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.NamingSystemRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.NutritionOrderRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.NutritionOrderResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.NutritionOrderRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.ObservationRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.ObservationResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.ObservationRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.OperationDefinitionRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.OperationDefinitionResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.OperationDefinitionRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.OperationOutcomeRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.OperationOutcomeResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.OperationOutcomeRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.OrganizationRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.OrganizationResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.OrganizationRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.ParametersRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.ParametersResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.ParametersRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.PatientRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.PatientResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.PatientRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.PaymentNoticeRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.PaymentNoticeResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.PaymentNoticeRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.PaymentReconciliationRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.PaymentReconciliationResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.PaymentReconciliationRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.PersonRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.PersonResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.PersonRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.PlanDefinitionRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.PlanDefinitionResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.PlanDefinitionRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.PractitionerRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.PractitionerResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.PractitionerRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.PractitionerRoleRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.PractitionerRoleResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.PractitionerRoleRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.ProcedureRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.ProcedureResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.ProcedureRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.ProcedureRequestRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.ProcedureRequestResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.ProcedureRequestRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.ProcessRequestRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.ProcessRequestResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.ProcessRequestRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.ProcessResponseRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.ProcessResponseResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.ProcessResponseRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.ProvenanceRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.ProvenanceResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.ProvenanceRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.QuestionnaireRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.QuestionnaireResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.QuestionnaireRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.QuestionnaireResponseRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.QuestionnaireResponseResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.QuestionnaireResponseRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.ReferralRequestRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.ReferralRequestResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.ReferralRequestRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.RelatedPersonRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.RelatedPersonResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.RelatedPersonRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.RequestGroupRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.RequestGroupResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.RequestGroupRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.ResearchStudyRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.ResearchStudyResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.ResearchStudyRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.ResearchSubjectRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.ResearchSubjectResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.ResearchSubjectRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.RiskAssessmentRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.RiskAssessmentResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.RiskAssessmentRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.ScheduleRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.ScheduleResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.ScheduleRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.SearchParameterRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.SearchParameterResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.SearchParameterRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.SequenceRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.SequenceResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.SequenceRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.ServiceDefinitionRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.ServiceDefinitionResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.ServiceDefinitionRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.SlotRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.SlotResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.SlotRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.SpecimenRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.SpecimenResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.SpecimenRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.StructureDefinitionRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.StructureDefinitionResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.StructureDefinitionRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.StructureMapRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.StructureMapResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.StructureMapRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.SubscriptionRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.SubscriptionResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.SubscriptionRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.SubstanceRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.SubstanceResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.SubstanceRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.SupplyDeliveryRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.SupplyDeliveryResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.SupplyDeliveryRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.SupplyRequestRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.SupplyRequestResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.SupplyRequestRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.TaskRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.TaskResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.TaskRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.TestReportRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.TestReportResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.TestReportRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.TestScriptRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.TestScriptResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.TestScriptRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.ValueSetRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.ValueSetResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.ValueSetRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.VisionPrescriptionRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCurrent = c.Boolean(nullable: false),
                        FhirId = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        VersionId = c.String(nullable: false, maxLength: 50),
                        LastUpdated = c.DateTimeOffset(nullable: false, precision: 3),
                        XmlBlob = c.String(nullable: false),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FhirId, t.VersionId }, unique: true, name: "UQ_FhirIdAndVersionId")
                .Index(t => t.LastUpdated, name: "dsf");
            
            CreateTable(
                "dbo.VisionPrescriptionResIndex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceSearchParameterId = c.Int(nullable: false),
                        String = c.String(maxLength: 450),
                        DateTimeOffsetLow = c.DateTimeOffset(precision: 7),
                        DateTimeOffsetHigh = c.DateTimeOffset(precision: 7),
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
                        ReferenceFhirId = c.String(maxLength: 400),
                        ReferenceResourceType = c.String(maxLength: 50),
                        ReferenceVersionId = c.String(maxLength: 50),
                        ReferenceServiceBaseUrlId = c.Int(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceBaseUrl", t => t.ReferenceServiceBaseUrlId)
                .ForeignKey("dbo.ServiceSearchParameter", t => t.ServiceSearchParameterId, cascadeDelete: true)
                .ForeignKey("dbo.VisionPrescriptionRes", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ServiceSearchParameterId)
                .Index(t => t.ReferenceServiceBaseUrlId)
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
            DropIndex("dbo.VisionPrescriptionResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.VisionPrescriptionResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.VisionPrescriptionRes", "dsf");
            DropIndex("dbo.VisionPrescriptionRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ValueSetResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ValueSetResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.ValueSetResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.ValueSetRes", "dsf");
            DropIndex("dbo.ValueSetRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.TestScriptResIndex", new[] { "ResourceId" });
            DropIndex("dbo.TestScriptResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.TestScriptResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.TestScriptRes", "dsf");
            DropIndex("dbo.TestScriptRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.TestReportResIndex", new[] { "ResourceId" });
            DropIndex("dbo.TestReportResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.TestReportResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.TestReportRes", "dsf");
            DropIndex("dbo.TestReportRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.TaskResIndex", new[] { "ResourceId" });
            DropIndex("dbo.TaskResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.TaskResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.TaskRes", "dsf");
            DropIndex("dbo.TaskRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.SupplyRequestResIndex", new[] { "ResourceId" });
            DropIndex("dbo.SupplyRequestResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.SupplyRequestResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.SupplyRequestRes", "dsf");
            DropIndex("dbo.SupplyRequestRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.SupplyDeliveryResIndex", new[] { "ResourceId" });
            DropIndex("dbo.SupplyDeliveryResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.SupplyDeliveryResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.SupplyDeliveryRes", "dsf");
            DropIndex("dbo.SupplyDeliveryRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.SubstanceResIndex", new[] { "ResourceId" });
            DropIndex("dbo.SubstanceResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.SubstanceResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.SubstanceRes", "dsf");
            DropIndex("dbo.SubstanceRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.SubscriptionResIndex", new[] { "ResourceId" });
            DropIndex("dbo.SubscriptionResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.SubscriptionResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.SubscriptionRes", "dsf");
            DropIndex("dbo.SubscriptionRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.StructureMapResIndex", new[] { "ResourceId" });
            DropIndex("dbo.StructureMapResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.StructureMapResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.StructureMapRes", "dsf");
            DropIndex("dbo.StructureMapRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.StructureDefinitionResIndex", new[] { "ResourceId" });
            DropIndex("dbo.StructureDefinitionResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.StructureDefinitionResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.StructureDefinitionRes", "dsf");
            DropIndex("dbo.StructureDefinitionRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.SpecimenResIndex", new[] { "ResourceId" });
            DropIndex("dbo.SpecimenResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.SpecimenResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.SpecimenRes", "dsf");
            DropIndex("dbo.SpecimenRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.SlotResIndex", new[] { "ResourceId" });
            DropIndex("dbo.SlotResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.SlotResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.SlotRes", "dsf");
            DropIndex("dbo.SlotRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ServiceDefinitionResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ServiceDefinitionResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.ServiceDefinitionResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.ServiceDefinitionRes", "dsf");
            DropIndex("dbo.ServiceDefinitionRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.SequenceResIndex", new[] { "ResourceId" });
            DropIndex("dbo.SequenceResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.SequenceResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.SequenceRes", "dsf");
            DropIndex("dbo.SequenceRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.SearchParameterResIndex", new[] { "ResourceId" });
            DropIndex("dbo.SearchParameterResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.SearchParameterResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.SearchParameterRes", "dsf");
            DropIndex("dbo.SearchParameterRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ScheduleResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ScheduleResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.ScheduleResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.ScheduleRes", "dsf");
            DropIndex("dbo.ScheduleRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.RiskAssessmentResIndex", new[] { "ResourceId" });
            DropIndex("dbo.RiskAssessmentResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.RiskAssessmentResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.RiskAssessmentRes", "dsf");
            DropIndex("dbo.RiskAssessmentRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ResearchSubjectResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ResearchSubjectResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.ResearchSubjectResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.ResearchSubjectRes", "dsf");
            DropIndex("dbo.ResearchSubjectRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ResearchStudyResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ResearchStudyResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.ResearchStudyResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.ResearchStudyRes", "dsf");
            DropIndex("dbo.ResearchStudyRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.RequestGroupResIndex", new[] { "ResourceId" });
            DropIndex("dbo.RequestGroupResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.RequestGroupResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.RequestGroupRes", "dsf");
            DropIndex("dbo.RequestGroupRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.RelatedPersonResIndex", new[] { "ResourceId" });
            DropIndex("dbo.RelatedPersonResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.RelatedPersonResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.RelatedPersonRes", "dsf");
            DropIndex("dbo.RelatedPersonRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ReferralRequestResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ReferralRequestResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.ReferralRequestResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.ReferralRequestRes", "dsf");
            DropIndex("dbo.ReferralRequestRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.QuestionnaireResponseResIndex", new[] { "ResourceId" });
            DropIndex("dbo.QuestionnaireResponseResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.QuestionnaireResponseResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.QuestionnaireResponseRes", "dsf");
            DropIndex("dbo.QuestionnaireResponseRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.QuestionnaireResIndex", new[] { "ResourceId" });
            DropIndex("dbo.QuestionnaireResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.QuestionnaireResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.QuestionnaireRes", "dsf");
            DropIndex("dbo.QuestionnaireRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ProvenanceResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ProvenanceResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.ProvenanceResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.ProvenanceRes", "dsf");
            DropIndex("dbo.ProvenanceRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ProcessResponseResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ProcessResponseResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.ProcessResponseResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.ProcessResponseRes", "dsf");
            DropIndex("dbo.ProcessResponseRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ProcessRequestResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ProcessRequestResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.ProcessRequestResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.ProcessRequestRes", "dsf");
            DropIndex("dbo.ProcessRequestRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ProcedureRequestResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ProcedureRequestResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.ProcedureRequestResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.ProcedureRequestRes", "dsf");
            DropIndex("dbo.ProcedureRequestRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ProcedureResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ProcedureResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.ProcedureResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.ProcedureRes", "dsf");
            DropIndex("dbo.ProcedureRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.PractitionerRoleResIndex", new[] { "ResourceId" });
            DropIndex("dbo.PractitionerRoleResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.PractitionerRoleResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.PractitionerRoleRes", "dsf");
            DropIndex("dbo.PractitionerRoleRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.PractitionerResIndex", new[] { "ResourceId" });
            DropIndex("dbo.PractitionerResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.PractitionerResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.PractitionerRes", "dsf");
            DropIndex("dbo.PractitionerRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.PlanDefinitionResIndex", new[] { "ResourceId" });
            DropIndex("dbo.PlanDefinitionResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.PlanDefinitionResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.PlanDefinitionRes", "dsf");
            DropIndex("dbo.PlanDefinitionRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.PersonResIndex", new[] { "ResourceId" });
            DropIndex("dbo.PersonResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.PersonResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.PersonRes", "dsf");
            DropIndex("dbo.PersonRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.PaymentReconciliationResIndex", new[] { "ResourceId" });
            DropIndex("dbo.PaymentReconciliationResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.PaymentReconciliationResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.PaymentReconciliationRes", "dsf");
            DropIndex("dbo.PaymentReconciliationRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.PaymentNoticeResIndex", new[] { "ResourceId" });
            DropIndex("dbo.PaymentNoticeResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.PaymentNoticeResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.PaymentNoticeRes", "dsf");
            DropIndex("dbo.PaymentNoticeRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.PatientResIndex", new[] { "ResourceId" });
            DropIndex("dbo.PatientResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.PatientResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.PatientRes", "dsf");
            DropIndex("dbo.PatientRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ParametersResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ParametersResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.ParametersResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.ParametersRes", "dsf");
            DropIndex("dbo.ParametersRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.OrganizationResIndex", new[] { "ResourceId" });
            DropIndex("dbo.OrganizationResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.OrganizationResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.OrganizationRes", "dsf");
            DropIndex("dbo.OrganizationRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.OperationOutcomeResIndex", new[] { "ResourceId" });
            DropIndex("dbo.OperationOutcomeResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.OperationOutcomeResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.OperationOutcomeRes", "dsf");
            DropIndex("dbo.OperationOutcomeRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.OperationDefinitionResIndex", new[] { "ResourceId" });
            DropIndex("dbo.OperationDefinitionResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.OperationDefinitionResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.OperationDefinitionRes", "dsf");
            DropIndex("dbo.OperationDefinitionRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ObservationResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ObservationResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.ObservationResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.ObservationRes", "dsf");
            DropIndex("dbo.ObservationRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.NutritionOrderResIndex", new[] { "ResourceId" });
            DropIndex("dbo.NutritionOrderResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.NutritionOrderResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.NutritionOrderRes", "dsf");
            DropIndex("dbo.NutritionOrderRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.NamingSystemResIndex", new[] { "ResourceId" });
            DropIndex("dbo.NamingSystemResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.NamingSystemResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.NamingSystemRes", "dsf");
            DropIndex("dbo.NamingSystemRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.MessageHeaderResIndex", new[] { "ResourceId" });
            DropIndex("dbo.MessageHeaderResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.MessageHeaderResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.MessageHeaderRes", "dsf");
            DropIndex("dbo.MessageHeaderRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.MessageDefinitionResIndex", new[] { "ResourceId" });
            DropIndex("dbo.MessageDefinitionResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.MessageDefinitionResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.MessageDefinitionRes", "dsf");
            DropIndex("dbo.MessageDefinitionRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.MedicationStatementResIndex", new[] { "ResourceId" });
            DropIndex("dbo.MedicationStatementResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.MedicationStatementResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.MedicationStatementRes", "dsf");
            DropIndex("dbo.MedicationStatementRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.MedicationRequestResIndex", new[] { "ResourceId" });
            DropIndex("dbo.MedicationRequestResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.MedicationRequestResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.MedicationRequestRes", "dsf");
            DropIndex("dbo.MedicationRequestRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.MedicationDispenseResIndex", new[] { "ResourceId" });
            DropIndex("dbo.MedicationDispenseResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.MedicationDispenseResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.MedicationDispenseRes", "dsf");
            DropIndex("dbo.MedicationDispenseRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.MedicationAdministrationResIndex", new[] { "ResourceId" });
            DropIndex("dbo.MedicationAdministrationResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.MedicationAdministrationResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.MedicationAdministrationRes", "dsf");
            DropIndex("dbo.MedicationAdministrationRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.MedicationResIndex", new[] { "ResourceId" });
            DropIndex("dbo.MedicationResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.MedicationResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.MedicationRes", "dsf");
            DropIndex("dbo.MedicationRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.MediaResIndex", new[] { "ResourceId" });
            DropIndex("dbo.MediaResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.MediaResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.MediaRes", "dsf");
            DropIndex("dbo.MediaRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.MeasureReportResIndex", new[] { "ResourceId" });
            DropIndex("dbo.MeasureReportResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.MeasureReportResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.MeasureReportRes", "dsf");
            DropIndex("dbo.MeasureReportRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.MeasureResIndex", new[] { "ResourceId" });
            DropIndex("dbo.MeasureResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.MeasureResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.MeasureRes", "dsf");
            DropIndex("dbo.MeasureRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.LocationResIndex", new[] { "ResourceId" });
            DropIndex("dbo.LocationResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.LocationResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.LocationRes", "dsf");
            DropIndex("dbo.LocationRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ListResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ListResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.ListResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.ListRes", "dsf");
            DropIndex("dbo.ListRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.LinkageResIndex", new[] { "ResourceId" });
            DropIndex("dbo.LinkageResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.LinkageResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.LinkageRes", "dsf");
            DropIndex("dbo.LinkageRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.LibraryResIndex", new[] { "ResourceId" });
            DropIndex("dbo.LibraryResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.LibraryResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.LibraryRes", "dsf");
            DropIndex("dbo.LibraryRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ImplementationGuideResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ImplementationGuideResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.ImplementationGuideResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.ImplementationGuideRes", "dsf");
            DropIndex("dbo.ImplementationGuideRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ImmunizationRecommendationResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ImmunizationRecommendationResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.ImmunizationRecommendationResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.ImmunizationRecommendationRes", "dsf");
            DropIndex("dbo.ImmunizationRecommendationRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ImmunizationResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ImmunizationResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.ImmunizationResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.ImmunizationRes", "dsf");
            DropIndex("dbo.ImmunizationRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ImagingStudyResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ImagingStudyResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.ImagingStudyResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.ImagingStudyRes", "dsf");
            DropIndex("dbo.ImagingStudyRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ImagingManifestResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ImagingManifestResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.ImagingManifestResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.ImagingManifestRes", "dsf");
            DropIndex("dbo.ImagingManifestRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.HealthcareServiceResIndex", new[] { "ResourceId" });
            DropIndex("dbo.HealthcareServiceResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.HealthcareServiceResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.HealthcareServiceRes", "dsf");
            DropIndex("dbo.HealthcareServiceRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.GuidanceResponseResIndex", new[] { "ResourceId" });
            DropIndex("dbo.GuidanceResponseResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.GuidanceResponseResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.GuidanceResponseRes", "dsf");
            DropIndex("dbo.GuidanceResponseRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.GroupResIndex", new[] { "ResourceId" });
            DropIndex("dbo.GroupResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.GroupResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.GroupRes", "dsf");
            DropIndex("dbo.GroupRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.GraphDefinitionResIndex", new[] { "ResourceId" });
            DropIndex("dbo.GraphDefinitionResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.GraphDefinitionResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.GraphDefinitionRes", "dsf");
            DropIndex("dbo.GraphDefinitionRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.GoalResIndex", new[] { "ResourceId" });
            DropIndex("dbo.GoalResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.GoalResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.GoalRes", "dsf");
            DropIndex("dbo.GoalRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.FlagResIndex", new[] { "ResourceId" });
            DropIndex("dbo.FlagResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.FlagResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.FlagRes", "dsf");
            DropIndex("dbo.FlagRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.FamilyMemberHistoryResIndex", new[] { "ResourceId" });
            DropIndex("dbo.FamilyMemberHistoryResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.FamilyMemberHistoryResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.FamilyMemberHistoryRes", "dsf");
            DropIndex("dbo.FamilyMemberHistoryRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ExplanationOfBenefitResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ExplanationOfBenefitResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.ExplanationOfBenefitResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.ExplanationOfBenefitRes", "dsf");
            DropIndex("dbo.ExplanationOfBenefitRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ExpansionProfileResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ExpansionProfileResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.ExpansionProfileResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.ExpansionProfileRes", "dsf");
            DropIndex("dbo.ExpansionProfileRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.EpisodeOfCareResIndex", new[] { "ResourceId" });
            DropIndex("dbo.EpisodeOfCareResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.EpisodeOfCareResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.EpisodeOfCareRes", "dsf");
            DropIndex("dbo.EpisodeOfCareRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.EnrollmentResponseResIndex", new[] { "ResourceId" });
            DropIndex("dbo.EnrollmentResponseResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.EnrollmentResponseResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.EnrollmentResponseRes", "dsf");
            DropIndex("dbo.EnrollmentResponseRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.EnrollmentRequestResIndex", new[] { "ResourceId" });
            DropIndex("dbo.EnrollmentRequestResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.EnrollmentRequestResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.EnrollmentRequestRes", "dsf");
            DropIndex("dbo.EnrollmentRequestRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.EndpointResIndex", new[] { "ResourceId" });
            DropIndex("dbo.EndpointResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.EndpointResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.EndpointRes", "dsf");
            DropIndex("dbo.EndpointRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.EncounterResIndex", new[] { "ResourceId" });
            DropIndex("dbo.EncounterResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.EncounterResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.EncounterRes", "dsf");
            DropIndex("dbo.EncounterRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.EligibilityResponseResIndex", new[] { "ResourceId" });
            DropIndex("dbo.EligibilityResponseResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.EligibilityResponseResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.EligibilityResponseRes", "dsf");
            DropIndex("dbo.EligibilityResponseRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.EligibilityRequestResIndex", new[] { "ResourceId" });
            DropIndex("dbo.EligibilityRequestResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.EligibilityRequestResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.EligibilityRequestRes", "dsf");
            DropIndex("dbo.EligibilityRequestRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.DocumentReferenceResIndex", new[] { "ResourceId" });
            DropIndex("dbo.DocumentReferenceResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.DocumentReferenceResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.DocumentReferenceRes", "dsf");
            DropIndex("dbo.DocumentReferenceRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.DocumentManifestResIndex", new[] { "ResourceId" });
            DropIndex("dbo.DocumentManifestResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.DocumentManifestResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.DocumentManifestRes", "dsf");
            DropIndex("dbo.DocumentManifestRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.DiagnosticReportResIndex", new[] { "ResourceId" });
            DropIndex("dbo.DiagnosticReportResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.DiagnosticReportResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.DiagnosticReportRes", "dsf");
            DropIndex("dbo.DiagnosticReportRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.DeviceUseStatementResIndex", new[] { "ResourceId" });
            DropIndex("dbo.DeviceUseStatementResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.DeviceUseStatementResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.DeviceUseStatementRes", "dsf");
            DropIndex("dbo.DeviceUseStatementRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.DeviceRequestResIndex", new[] { "ResourceId" });
            DropIndex("dbo.DeviceRequestResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.DeviceRequestResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.DeviceRequestRes", "dsf");
            DropIndex("dbo.DeviceRequestRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.DeviceMetricResIndex", new[] { "ResourceId" });
            DropIndex("dbo.DeviceMetricResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.DeviceMetricResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.DeviceMetricRes", "dsf");
            DropIndex("dbo.DeviceMetricRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.DeviceComponentResIndex", new[] { "ResourceId" });
            DropIndex("dbo.DeviceComponentResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.DeviceComponentResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.DeviceComponentRes", "dsf");
            DropIndex("dbo.DeviceComponentRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.DeviceResIndex", new[] { "ResourceId" });
            DropIndex("dbo.DeviceResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.DeviceResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.DeviceRes", "dsf");
            DropIndex("dbo.DeviceRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.DetectedIssueResIndex", new[] { "ResourceId" });
            DropIndex("dbo.DetectedIssueResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.DetectedIssueResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.DetectedIssueRes", "dsf");
            DropIndex("dbo.DetectedIssueRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.DataElementResIndex", new[] { "ResourceId" });
            DropIndex("dbo.DataElementResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.DataElementResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.DataElementRes", "dsf");
            DropIndex("dbo.DataElementRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.CoverageResIndex", new[] { "ResourceId" });
            DropIndex("dbo.CoverageResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.CoverageResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.CoverageRes", "dsf");
            DropIndex("dbo.CoverageRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ContractResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ContractResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.ContractResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.ContractRes", "dsf");
            DropIndex("dbo.ContractRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ConsentResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ConsentResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.ConsentResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.ConsentRes", "dsf");
            DropIndex("dbo.ConsentRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ConditionResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ConditionResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.ConditionResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.ConditionRes", "dsf");
            DropIndex("dbo.ConditionRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ConceptMapResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ConceptMapResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.ConceptMapResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.ConceptMapRes", "dsf");
            DropIndex("dbo.ConceptMapRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.CompositionResIndex", new[] { "ResourceId" });
            DropIndex("dbo.CompositionResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.CompositionResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.CompositionRes", "dsf");
            DropIndex("dbo.CompositionRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.CompartmentDefinitionResIndex", new[] { "ResourceId" });
            DropIndex("dbo.CompartmentDefinitionResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.CompartmentDefinitionResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.CompartmentDefinitionRes", "dsf");
            DropIndex("dbo.CompartmentDefinitionRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.CommunicationRequestResIndex", new[] { "ResourceId" });
            DropIndex("dbo.CommunicationRequestResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.CommunicationRequestResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.CommunicationRequestRes", "dsf");
            DropIndex("dbo.CommunicationRequestRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.CommunicationResIndex", new[] { "ResourceId" });
            DropIndex("dbo.CommunicationResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.CommunicationResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.CommunicationRes", "dsf");
            DropIndex("dbo.CommunicationRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.CodeSystemResIndex", new[] { "ResourceId" });
            DropIndex("dbo.CodeSystemResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.CodeSystemResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.CodeSystemRes", "dsf");
            DropIndex("dbo.CodeSystemRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ClinicalImpressionResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ClinicalImpressionResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.ClinicalImpressionResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.ClinicalImpressionRes", "dsf");
            DropIndex("dbo.ClinicalImpressionRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ClaimResponseResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ClaimResponseResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.ClaimResponseResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.ClaimResponseRes", "dsf");
            DropIndex("dbo.ClaimResponseRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ClaimResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ClaimResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.ClaimResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.ClaimRes", "dsf");
            DropIndex("dbo.ClaimRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ChargeItemResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ChargeItemResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.ChargeItemResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.ChargeItemRes", "dsf");
            DropIndex("dbo.ChargeItemRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.CareTeamResIndex", new[] { "ResourceId" });
            DropIndex("dbo.CareTeamResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.CareTeamResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.CareTeamRes", "dsf");
            DropIndex("dbo.CareTeamRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.CarePlanResIndex", new[] { "ResourceId" });
            DropIndex("dbo.CarePlanResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.CarePlanResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.CarePlanRes", "dsf");
            DropIndex("dbo.CarePlanRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.CapabilityStatementResIndex", new[] { "ResourceId" });
            DropIndex("dbo.CapabilityStatementResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.CapabilityStatementResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.CapabilityStatementRes", "dsf");
            DropIndex("dbo.CapabilityStatementRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.BundleResIndex", new[] { "ResourceId" });
            DropIndex("dbo.BundleResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.BundleResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.BundleRes", "dsf");
            DropIndex("dbo.BundleRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.BodySiteResIndex", new[] { "ResourceId" });
            DropIndex("dbo.BodySiteResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.BodySiteResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.BodySiteRes", "dsf");
            DropIndex("dbo.BodySiteRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.BinaryResIndex", new[] { "ResourceId" });
            DropIndex("dbo.BinaryResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.BinaryResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.BinaryRes", "dsf");
            DropIndex("dbo.BinaryRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.BasicResIndex", new[] { "ResourceId" });
            DropIndex("dbo.BasicResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.BasicResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.BasicRes", "dsf");
            DropIndex("dbo.BasicRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.AuditEventResIndex", new[] { "ResourceId" });
            DropIndex("dbo.AuditEventResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.AuditEventResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.AuditEventRes", "dsf");
            DropIndex("dbo.AuditEventRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.AppointmentResponseResIndex", new[] { "ResourceId" });
            DropIndex("dbo.AppointmentResponseResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.AppointmentResponseResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.AppointmentResponseRes", "dsf");
            DropIndex("dbo.AppointmentResponseRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.AppointmentResIndex", new[] { "ResourceId" });
            DropIndex("dbo.AppointmentResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.AppointmentResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.AppointmentRes", "dsf");
            DropIndex("dbo.AppointmentRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.AllergyIntoleranceResIndex", new[] { "ResourceId" });
            DropIndex("dbo.AllergyIntoleranceResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.AllergyIntoleranceResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.AllergyIntoleranceRes", "dsf");
            DropIndex("dbo.AllergyIntoleranceRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.AdverseEventResIndex", new[] { "ResourceId" });
            DropIndex("dbo.AdverseEventResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.AdverseEventResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.AdverseEventRes", "dsf");
            DropIndex("dbo.AdverseEventRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ActivityDefinitionResIndex", new[] { "ResourceId" });
            DropIndex("dbo.ActivityDefinitionResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.ActivityDefinitionResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.ActivityDefinitionRes", "dsf");
            DropIndex("dbo.ActivityDefinitionRes", "UQ_FhirIdAndVersionId");
            DropIndex("dbo.ServiceSearchParameterTargetResource", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.ServiceBaseUrl", new[] { "Url" });
            DropIndex("dbo.AccountResIndex", new[] { "ResourceId" });
            DropIndex("dbo.AccountResIndex", new[] { "ReferenceServiceBaseUrlId" });
            DropIndex("dbo.AccountResIndex", new[] { "ServiceSearchParameterId" });
            DropIndex("dbo.AccountRes", "dsf");
            DropIndex("dbo.AccountRes", "UQ_FhirIdAndVersionId");
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
