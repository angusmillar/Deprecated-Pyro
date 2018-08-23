CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

CREATE TABLE [dbo].[AccountRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.AccountRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[AccountRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[AccountRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[AccountRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[AccountRes]([LastUpdated])
CREATE TABLE [dbo].[AccountResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.AccountResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[AccountResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[AccountResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[AccountResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[AccountResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[AccountResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[AccountResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[AccountResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[AccountResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[AccountResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[AccountResIndex]([ResourceId])
CREATE TABLE [dbo].[ServiceBaseUrl] (
    [Id] [int] NOT NULL IDENTITY,
    [Url] [nvarchar](450) NOT NULL,
    [IsServersPrimaryUrlRoot] [bit] NOT NULL,
    CONSTRAINT [PK_dbo.ServiceBaseUrl] PRIMARY KEY ([Id])
)
CREATE UNIQUE INDEX [ix_Url] ON [dbo].[ServiceBaseUrl]([Url])
CREATE TABLE [dbo].[ServiceSearchParameter] (
    [Id] [int] NOT NULL IDENTITY,
    [Resource] [nvarchar](50) NOT NULL,
    [Name] [nvarchar](50) NOT NULL,
    [Url] [nvarchar](450),
    [Description] [nvarchar](max),
    [Type] [int] NOT NULL,
    [XPath] [nvarchar](max),
    [Expression] [nvarchar](max) NOT NULL,
    [IsIndexed] [bit] NOT NULL,
    [Status] [int] NOT NULL,
    [LastUpdated] [datetimeoffset](7) NOT NULL,
    [SearchParameterResourceId] [nvarchar](128),
    [SearchParameterResourceVersion] [nvarchar](128),
    CONSTRAINT [PK_dbo.ServiceSearchParameter] PRIMARY KEY ([Id])
)
CREATE UNIQUE INDEX [uq_ResourceAndName] ON [dbo].[ServiceSearchParameter]([Resource], [Name])
CREATE INDEX [ix_IsIndexed] ON [dbo].[ServiceSearchParameter]([IsIndexed])
CREATE INDEX [ix_Status] ON [dbo].[ServiceSearchParameter]([Status])
CREATE TABLE [dbo].[ServiceSearchParameterTargetResource] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [ResourceType] [int] NOT NULL,
    CONSTRAINT [PK_dbo.ServiceSearchParameterTargetResource] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_ServiceSearchParameterId] ON [dbo].[ServiceSearchParameterTargetResource]([ServiceSearchParameterId])
CREATE TABLE [dbo].[ActivityDefinitionRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.ActivityDefinitionRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[ActivityDefinitionRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[ActivityDefinitionRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[ActivityDefinitionRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[ActivityDefinitionRes]([LastUpdated])
CREATE TABLE [dbo].[ActivityDefinitionResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.ActivityDefinitionResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[ActivityDefinitionResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[ActivityDefinitionResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[ActivityDefinitionResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[ActivityDefinitionResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[ActivityDefinitionResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[ActivityDefinitionResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[ActivityDefinitionResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[ActivityDefinitionResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[ActivityDefinitionResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[ActivityDefinitionResIndex]([ResourceId])
CREATE TABLE [dbo].[AdverseEventRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.AdverseEventRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[AdverseEventRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[AdverseEventRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[AdverseEventRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[AdverseEventRes]([LastUpdated])
CREATE TABLE [dbo].[AdverseEventResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.AdverseEventResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[AdverseEventResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[AdverseEventResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[AdverseEventResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[AdverseEventResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[AdverseEventResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[AdverseEventResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[AdverseEventResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[AdverseEventResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[AdverseEventResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[AdverseEventResIndex]([ResourceId])
CREATE TABLE [dbo].[AllergyIntoleranceRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.AllergyIntoleranceRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[AllergyIntoleranceRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[AllergyIntoleranceRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[AllergyIntoleranceRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[AllergyIntoleranceRes]([LastUpdated])
CREATE TABLE [dbo].[AllergyIntoleranceResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.AllergyIntoleranceResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[AllergyIntoleranceResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[AllergyIntoleranceResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[AllergyIntoleranceResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[AllergyIntoleranceResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[AllergyIntoleranceResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[AllergyIntoleranceResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[AllergyIntoleranceResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[AllergyIntoleranceResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[AllergyIntoleranceResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[AllergyIntoleranceResIndex]([ResourceId])
CREATE TABLE [dbo].[AppointmentRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.AppointmentRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[AppointmentRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[AppointmentRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[AppointmentRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[AppointmentRes]([LastUpdated])
CREATE TABLE [dbo].[AppointmentResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.AppointmentResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[AppointmentResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[AppointmentResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[AppointmentResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[AppointmentResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[AppointmentResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[AppointmentResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[AppointmentResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[AppointmentResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[AppointmentResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[AppointmentResIndex]([ResourceId])
CREATE TABLE [dbo].[AppointmentResponseRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.AppointmentResponseRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[AppointmentResponseRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[AppointmentResponseRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[AppointmentResponseRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[AppointmentResponseRes]([LastUpdated])
CREATE TABLE [dbo].[AppointmentResponseResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.AppointmentResponseResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[AppointmentResponseResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[AppointmentResponseResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[AppointmentResponseResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[AppointmentResponseResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[AppointmentResponseResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[AppointmentResponseResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[AppointmentResponseResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[AppointmentResponseResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[AppointmentResponseResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[AppointmentResponseResIndex]([ResourceId])
CREATE TABLE [dbo].[AuditEventRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.AuditEventRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[AuditEventRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[AuditEventRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[AuditEventRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[AuditEventRes]([LastUpdated])
CREATE TABLE [dbo].[AuditEventResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.AuditEventResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[AuditEventResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[AuditEventResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[AuditEventResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[AuditEventResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[AuditEventResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[AuditEventResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[AuditEventResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[AuditEventResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[AuditEventResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[AuditEventResIndex]([ResourceId])
CREATE TABLE [dbo].[BasicRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.BasicRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[BasicRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[BasicRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[BasicRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[BasicRes]([LastUpdated])
CREATE TABLE [dbo].[BasicResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.BasicResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[BasicResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[BasicResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[BasicResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[BasicResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[BasicResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[BasicResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[BasicResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[BasicResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[BasicResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[BasicResIndex]([ResourceId])
CREATE TABLE [dbo].[BinaryRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.BinaryRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[BinaryRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[BinaryRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[BinaryRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[BinaryRes]([LastUpdated])
CREATE TABLE [dbo].[BinaryResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.BinaryResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[BinaryResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[BinaryResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[BinaryResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[BinaryResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[BinaryResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[BinaryResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[BinaryResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[BinaryResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[BinaryResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[BinaryResIndex]([ResourceId])
CREATE TABLE [dbo].[BodySiteRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.BodySiteRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[BodySiteRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[BodySiteRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[BodySiteRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[BodySiteRes]([LastUpdated])
CREATE TABLE [dbo].[BodySiteResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.BodySiteResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[BodySiteResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[BodySiteResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[BodySiteResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[BodySiteResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[BodySiteResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[BodySiteResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[BodySiteResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[BodySiteResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[BodySiteResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[BodySiteResIndex]([ResourceId])
CREATE TABLE [dbo].[BundleRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.BundleRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[BundleRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[BundleRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[BundleRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[BundleRes]([LastUpdated])
CREATE TABLE [dbo].[BundleResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.BundleResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[BundleResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[BundleResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[BundleResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[BundleResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[BundleResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[BundleResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[BundleResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[BundleResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[BundleResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[BundleResIndex]([ResourceId])
CREATE TABLE [dbo].[CapabilityStatementRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.CapabilityStatementRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[CapabilityStatementRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[CapabilityStatementRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[CapabilityStatementRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[CapabilityStatementRes]([LastUpdated])
CREATE TABLE [dbo].[CapabilityStatementResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.CapabilityStatementResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[CapabilityStatementResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[CapabilityStatementResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[CapabilityStatementResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[CapabilityStatementResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[CapabilityStatementResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[CapabilityStatementResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[CapabilityStatementResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[CapabilityStatementResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[CapabilityStatementResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[CapabilityStatementResIndex]([ResourceId])
CREATE TABLE [dbo].[CarePlanRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.CarePlanRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[CarePlanRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[CarePlanRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[CarePlanRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[CarePlanRes]([LastUpdated])
CREATE TABLE [dbo].[CarePlanResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.CarePlanResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[CarePlanResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[CarePlanResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[CarePlanResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[CarePlanResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[CarePlanResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[CarePlanResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[CarePlanResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[CarePlanResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[CarePlanResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[CarePlanResIndex]([ResourceId])
CREATE TABLE [dbo].[CareTeamRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.CareTeamRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[CareTeamRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[CareTeamRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[CareTeamRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[CareTeamRes]([LastUpdated])
CREATE TABLE [dbo].[CareTeamResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.CareTeamResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[CareTeamResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[CareTeamResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[CareTeamResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[CareTeamResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[CareTeamResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[CareTeamResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[CareTeamResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[CareTeamResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[CareTeamResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[CareTeamResIndex]([ResourceId])
CREATE TABLE [dbo].[ChargeItemRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.ChargeItemRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[ChargeItemRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[ChargeItemRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[ChargeItemRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[ChargeItemRes]([LastUpdated])
CREATE TABLE [dbo].[ChargeItemResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.ChargeItemResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[ChargeItemResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[ChargeItemResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[ChargeItemResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[ChargeItemResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[ChargeItemResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[ChargeItemResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[ChargeItemResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[ChargeItemResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[ChargeItemResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[ChargeItemResIndex]([ResourceId])
CREATE TABLE [dbo].[ClaimRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.ClaimRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[ClaimRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[ClaimRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[ClaimRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[ClaimRes]([LastUpdated])
CREATE TABLE [dbo].[ClaimResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.ClaimResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[ClaimResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[ClaimResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[ClaimResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[ClaimResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[ClaimResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[ClaimResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[ClaimResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[ClaimResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[ClaimResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[ClaimResIndex]([ResourceId])
CREATE TABLE [dbo].[ClaimResponseRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.ClaimResponseRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[ClaimResponseRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[ClaimResponseRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[ClaimResponseRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[ClaimResponseRes]([LastUpdated])
CREATE TABLE [dbo].[ClaimResponseResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.ClaimResponseResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[ClaimResponseResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[ClaimResponseResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[ClaimResponseResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[ClaimResponseResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[ClaimResponseResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[ClaimResponseResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[ClaimResponseResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[ClaimResponseResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[ClaimResponseResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[ClaimResponseResIndex]([ResourceId])
CREATE TABLE [dbo].[ClinicalImpressionRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.ClinicalImpressionRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[ClinicalImpressionRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[ClinicalImpressionRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[ClinicalImpressionRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[ClinicalImpressionRes]([LastUpdated])
CREATE TABLE [dbo].[ClinicalImpressionResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.ClinicalImpressionResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[ClinicalImpressionResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[ClinicalImpressionResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[ClinicalImpressionResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[ClinicalImpressionResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[ClinicalImpressionResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[ClinicalImpressionResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[ClinicalImpressionResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[ClinicalImpressionResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[ClinicalImpressionResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[ClinicalImpressionResIndex]([ResourceId])
CREATE TABLE [dbo].[CodeSystemRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.CodeSystemRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[CodeSystemRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[CodeSystemRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[CodeSystemRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[CodeSystemRes]([LastUpdated])
CREATE TABLE [dbo].[CodeSystemResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.CodeSystemResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[CodeSystemResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[CodeSystemResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[CodeSystemResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[CodeSystemResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[CodeSystemResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[CodeSystemResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[CodeSystemResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[CodeSystemResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[CodeSystemResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[CodeSystemResIndex]([ResourceId])
CREATE TABLE [dbo].[CommunicationRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.CommunicationRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[CommunicationRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[CommunicationRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[CommunicationRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[CommunicationRes]([LastUpdated])
CREATE TABLE [dbo].[CommunicationResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.CommunicationResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[CommunicationResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[CommunicationResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[CommunicationResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[CommunicationResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[CommunicationResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[CommunicationResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[CommunicationResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[CommunicationResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[CommunicationResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[CommunicationResIndex]([ResourceId])
CREATE TABLE [dbo].[CommunicationRequestRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.CommunicationRequestRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[CommunicationRequestRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[CommunicationRequestRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[CommunicationRequestRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[CommunicationRequestRes]([LastUpdated])
CREATE TABLE [dbo].[CommunicationRequestResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.CommunicationRequestResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[CommunicationRequestResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[CommunicationRequestResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[CommunicationRequestResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[CommunicationRequestResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[CommunicationRequestResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[CommunicationRequestResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[CommunicationRequestResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[CommunicationRequestResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[CommunicationRequestResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[CommunicationRequestResIndex]([ResourceId])
CREATE TABLE [dbo].[CompartmentDefinitionRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.CompartmentDefinitionRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[CompartmentDefinitionRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[CompartmentDefinitionRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[CompartmentDefinitionRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[CompartmentDefinitionRes]([LastUpdated])
CREATE TABLE [dbo].[CompartmentDefinitionResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.CompartmentDefinitionResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[CompartmentDefinitionResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[CompartmentDefinitionResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[CompartmentDefinitionResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[CompartmentDefinitionResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[CompartmentDefinitionResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[CompartmentDefinitionResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[CompartmentDefinitionResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[CompartmentDefinitionResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[CompartmentDefinitionResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[CompartmentDefinitionResIndex]([ResourceId])
CREATE TABLE [dbo].[CompositionRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.CompositionRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[CompositionRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[CompositionRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[CompositionRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[CompositionRes]([LastUpdated])
CREATE TABLE [dbo].[CompositionResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.CompositionResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[CompositionResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[CompositionResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[CompositionResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[CompositionResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[CompositionResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[CompositionResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[CompositionResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[CompositionResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[CompositionResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[CompositionResIndex]([ResourceId])
CREATE TABLE [dbo].[ConceptMapRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.ConceptMapRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[ConceptMapRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[ConceptMapRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[ConceptMapRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[ConceptMapRes]([LastUpdated])
CREATE TABLE [dbo].[ConceptMapResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.ConceptMapResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[ConceptMapResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[ConceptMapResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[ConceptMapResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[ConceptMapResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[ConceptMapResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[ConceptMapResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[ConceptMapResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[ConceptMapResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[ConceptMapResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[ConceptMapResIndex]([ResourceId])
CREATE TABLE [dbo].[ConditionRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.ConditionRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[ConditionRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[ConditionRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[ConditionRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[ConditionRes]([LastUpdated])
CREATE TABLE [dbo].[ConditionResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.ConditionResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[ConditionResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[ConditionResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[ConditionResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[ConditionResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[ConditionResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[ConditionResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[ConditionResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[ConditionResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[ConditionResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[ConditionResIndex]([ResourceId])
CREATE TABLE [dbo].[ConsentRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.ConsentRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[ConsentRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[ConsentRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[ConsentRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[ConsentRes]([LastUpdated])
CREATE TABLE [dbo].[ConsentResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.ConsentResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[ConsentResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[ConsentResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[ConsentResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[ConsentResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[ConsentResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[ConsentResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[ConsentResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[ConsentResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[ConsentResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[ConsentResIndex]([ResourceId])
CREATE TABLE [dbo].[ContractRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.ContractRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[ContractRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[ContractRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[ContractRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[ContractRes]([LastUpdated])
CREATE TABLE [dbo].[ContractResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.ContractResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[ContractResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[ContractResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[ContractResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[ContractResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[ContractResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[ContractResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[ContractResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[ContractResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[ContractResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[ContractResIndex]([ResourceId])
CREATE TABLE [dbo].[CoverageRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.CoverageRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[CoverageRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[CoverageRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[CoverageRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[CoverageRes]([LastUpdated])
CREATE TABLE [dbo].[CoverageResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.CoverageResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[CoverageResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[CoverageResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[CoverageResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[CoverageResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[CoverageResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[CoverageResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[CoverageResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[CoverageResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[CoverageResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[CoverageResIndex]([ResourceId])
CREATE TABLE [dbo].[DataElementRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.DataElementRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[DataElementRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[DataElementRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[DataElementRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[DataElementRes]([LastUpdated])
CREATE TABLE [dbo].[DataElementResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.DataElementResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[DataElementResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[DataElementResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[DataElementResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[DataElementResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[DataElementResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[DataElementResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[DataElementResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[DataElementResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[DataElementResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[DataElementResIndex]([ResourceId])
CREATE TABLE [dbo].[DetectedIssueRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.DetectedIssueRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[DetectedIssueRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[DetectedIssueRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[DetectedIssueRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[DetectedIssueRes]([LastUpdated])
CREATE TABLE [dbo].[DetectedIssueResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.DetectedIssueResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[DetectedIssueResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[DetectedIssueResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[DetectedIssueResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[DetectedIssueResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[DetectedIssueResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[DetectedIssueResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[DetectedIssueResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[DetectedIssueResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[DetectedIssueResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[DetectedIssueResIndex]([ResourceId])
CREATE TABLE [dbo].[DeviceRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.DeviceRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[DeviceRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[DeviceRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[DeviceRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[DeviceRes]([LastUpdated])
CREATE TABLE [dbo].[DeviceResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.DeviceResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[DeviceResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[DeviceResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[DeviceResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[DeviceResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[DeviceResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[DeviceResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[DeviceResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[DeviceResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[DeviceResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[DeviceResIndex]([ResourceId])
CREATE TABLE [dbo].[DeviceComponentRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.DeviceComponentRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[DeviceComponentRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[DeviceComponentRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[DeviceComponentRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[DeviceComponentRes]([LastUpdated])
CREATE TABLE [dbo].[DeviceComponentResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.DeviceComponentResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[DeviceComponentResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[DeviceComponentResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[DeviceComponentResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[DeviceComponentResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[DeviceComponentResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[DeviceComponentResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[DeviceComponentResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[DeviceComponentResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[DeviceComponentResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[DeviceComponentResIndex]([ResourceId])
CREATE TABLE [dbo].[DeviceMetricRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.DeviceMetricRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[DeviceMetricRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[DeviceMetricRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[DeviceMetricRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[DeviceMetricRes]([LastUpdated])
CREATE TABLE [dbo].[DeviceMetricResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.DeviceMetricResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[DeviceMetricResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[DeviceMetricResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[DeviceMetricResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[DeviceMetricResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[DeviceMetricResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[DeviceMetricResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[DeviceMetricResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[DeviceMetricResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[DeviceMetricResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[DeviceMetricResIndex]([ResourceId])
CREATE TABLE [dbo].[DeviceRequestRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.DeviceRequestRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[DeviceRequestRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[DeviceRequestRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[DeviceRequestRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[DeviceRequestRes]([LastUpdated])
CREATE TABLE [dbo].[DeviceRequestResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.DeviceRequestResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[DeviceRequestResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[DeviceRequestResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[DeviceRequestResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[DeviceRequestResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[DeviceRequestResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[DeviceRequestResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[DeviceRequestResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[DeviceRequestResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[DeviceRequestResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[DeviceRequestResIndex]([ResourceId])
CREATE TABLE [dbo].[DeviceUseStatementRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.DeviceUseStatementRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[DeviceUseStatementRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[DeviceUseStatementRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[DeviceUseStatementRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[DeviceUseStatementRes]([LastUpdated])
CREATE TABLE [dbo].[DeviceUseStatementResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.DeviceUseStatementResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[DeviceUseStatementResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[DeviceUseStatementResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[DeviceUseStatementResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[DeviceUseStatementResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[DeviceUseStatementResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[DeviceUseStatementResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[DeviceUseStatementResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[DeviceUseStatementResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[DeviceUseStatementResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[DeviceUseStatementResIndex]([ResourceId])
CREATE TABLE [dbo].[DiagnosticReportRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.DiagnosticReportRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[DiagnosticReportRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[DiagnosticReportRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[DiagnosticReportRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[DiagnosticReportRes]([LastUpdated])
CREATE TABLE [dbo].[DiagnosticReportResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.DiagnosticReportResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[DiagnosticReportResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[DiagnosticReportResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[DiagnosticReportResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[DiagnosticReportResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[DiagnosticReportResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[DiagnosticReportResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[DiagnosticReportResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[DiagnosticReportResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[DiagnosticReportResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[DiagnosticReportResIndex]([ResourceId])
CREATE TABLE [dbo].[DocumentManifestRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.DocumentManifestRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[DocumentManifestRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[DocumentManifestRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[DocumentManifestRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[DocumentManifestRes]([LastUpdated])
CREATE TABLE [dbo].[DocumentManifestResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.DocumentManifestResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[DocumentManifestResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[DocumentManifestResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[DocumentManifestResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[DocumentManifestResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[DocumentManifestResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[DocumentManifestResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[DocumentManifestResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[DocumentManifestResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[DocumentManifestResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[DocumentManifestResIndex]([ResourceId])
CREATE TABLE [dbo].[DocumentReferenceRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.DocumentReferenceRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[DocumentReferenceRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[DocumentReferenceRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[DocumentReferenceRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[DocumentReferenceRes]([LastUpdated])
CREATE TABLE [dbo].[DocumentReferenceResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.DocumentReferenceResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[DocumentReferenceResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[DocumentReferenceResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[DocumentReferenceResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[DocumentReferenceResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[DocumentReferenceResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[DocumentReferenceResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[DocumentReferenceResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[DocumentReferenceResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[DocumentReferenceResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[DocumentReferenceResIndex]([ResourceId])
CREATE TABLE [dbo].[EligibilityRequestRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.EligibilityRequestRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[EligibilityRequestRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[EligibilityRequestRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[EligibilityRequestRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[EligibilityRequestRes]([LastUpdated])
CREATE TABLE [dbo].[EligibilityRequestResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.EligibilityRequestResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[EligibilityRequestResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[EligibilityRequestResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[EligibilityRequestResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[EligibilityRequestResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[EligibilityRequestResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[EligibilityRequestResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[EligibilityRequestResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[EligibilityRequestResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[EligibilityRequestResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[EligibilityRequestResIndex]([ResourceId])
CREATE TABLE [dbo].[EligibilityResponseRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.EligibilityResponseRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[EligibilityResponseRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[EligibilityResponseRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[EligibilityResponseRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[EligibilityResponseRes]([LastUpdated])
CREATE TABLE [dbo].[EligibilityResponseResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.EligibilityResponseResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[EligibilityResponseResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[EligibilityResponseResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[EligibilityResponseResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[EligibilityResponseResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[EligibilityResponseResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[EligibilityResponseResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[EligibilityResponseResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[EligibilityResponseResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[EligibilityResponseResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[EligibilityResponseResIndex]([ResourceId])
CREATE TABLE [dbo].[EncounterRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.EncounterRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[EncounterRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[EncounterRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[EncounterRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[EncounterRes]([LastUpdated])
CREATE TABLE [dbo].[EncounterResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.EncounterResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[EncounterResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[EncounterResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[EncounterResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[EncounterResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[EncounterResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[EncounterResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[EncounterResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[EncounterResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[EncounterResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[EncounterResIndex]([ResourceId])
CREATE TABLE [dbo].[EndpointRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.EndpointRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[EndpointRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[EndpointRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[EndpointRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[EndpointRes]([LastUpdated])
CREATE TABLE [dbo].[EndpointResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.EndpointResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[EndpointResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[EndpointResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[EndpointResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[EndpointResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[EndpointResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[EndpointResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[EndpointResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[EndpointResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[EndpointResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[EndpointResIndex]([ResourceId])
CREATE TABLE [dbo].[EnrollmentRequestRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.EnrollmentRequestRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[EnrollmentRequestRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[EnrollmentRequestRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[EnrollmentRequestRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[EnrollmentRequestRes]([LastUpdated])
CREATE TABLE [dbo].[EnrollmentRequestResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.EnrollmentRequestResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[EnrollmentRequestResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[EnrollmentRequestResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[EnrollmentRequestResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[EnrollmentRequestResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[EnrollmentRequestResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[EnrollmentRequestResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[EnrollmentRequestResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[EnrollmentRequestResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[EnrollmentRequestResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[EnrollmentRequestResIndex]([ResourceId])
CREATE TABLE [dbo].[EnrollmentResponseRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.EnrollmentResponseRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[EnrollmentResponseRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[EnrollmentResponseRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[EnrollmentResponseRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[EnrollmentResponseRes]([LastUpdated])
CREATE TABLE [dbo].[EnrollmentResponseResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.EnrollmentResponseResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[EnrollmentResponseResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[EnrollmentResponseResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[EnrollmentResponseResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[EnrollmentResponseResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[EnrollmentResponseResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[EnrollmentResponseResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[EnrollmentResponseResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[EnrollmentResponseResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[EnrollmentResponseResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[EnrollmentResponseResIndex]([ResourceId])
CREATE TABLE [dbo].[EpisodeOfCareRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.EpisodeOfCareRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[EpisodeOfCareRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[EpisodeOfCareRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[EpisodeOfCareRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[EpisodeOfCareRes]([LastUpdated])
CREATE TABLE [dbo].[EpisodeOfCareResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.EpisodeOfCareResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[EpisodeOfCareResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[EpisodeOfCareResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[EpisodeOfCareResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[EpisodeOfCareResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[EpisodeOfCareResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[EpisodeOfCareResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[EpisodeOfCareResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[EpisodeOfCareResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[EpisodeOfCareResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[EpisodeOfCareResIndex]([ResourceId])
CREATE TABLE [dbo].[ExpansionProfileRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.ExpansionProfileRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[ExpansionProfileRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[ExpansionProfileRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[ExpansionProfileRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[ExpansionProfileRes]([LastUpdated])
CREATE TABLE [dbo].[ExpansionProfileResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.ExpansionProfileResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[ExpansionProfileResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[ExpansionProfileResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[ExpansionProfileResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[ExpansionProfileResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[ExpansionProfileResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[ExpansionProfileResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[ExpansionProfileResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[ExpansionProfileResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[ExpansionProfileResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[ExpansionProfileResIndex]([ResourceId])
CREATE TABLE [dbo].[ExplanationOfBenefitRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.ExplanationOfBenefitRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[ExplanationOfBenefitRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[ExplanationOfBenefitRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[ExplanationOfBenefitRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[ExplanationOfBenefitRes]([LastUpdated])
CREATE TABLE [dbo].[ExplanationOfBenefitResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.ExplanationOfBenefitResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[ExplanationOfBenefitResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[ExplanationOfBenefitResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[ExplanationOfBenefitResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[ExplanationOfBenefitResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[ExplanationOfBenefitResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[ExplanationOfBenefitResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[ExplanationOfBenefitResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[ExplanationOfBenefitResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[ExplanationOfBenefitResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[ExplanationOfBenefitResIndex]([ResourceId])
CREATE TABLE [dbo].[FamilyMemberHistoryRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.FamilyMemberHistoryRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[FamilyMemberHistoryRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[FamilyMemberHistoryRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[FamilyMemberHistoryRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[FamilyMemberHistoryRes]([LastUpdated])
CREATE TABLE [dbo].[FamilyMemberHistoryResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.FamilyMemberHistoryResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[FamilyMemberHistoryResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[FamilyMemberHistoryResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[FamilyMemberHistoryResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[FamilyMemberHistoryResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[FamilyMemberHistoryResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[FamilyMemberHistoryResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[FamilyMemberHistoryResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[FamilyMemberHistoryResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[FamilyMemberHistoryResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[FamilyMemberHistoryResIndex]([ResourceId])
CREATE TABLE [dbo].[FlagRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.FlagRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[FlagRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[FlagRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[FlagRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[FlagRes]([LastUpdated])
CREATE TABLE [dbo].[FlagResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.FlagResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[FlagResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[FlagResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[FlagResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[FlagResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[FlagResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[FlagResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[FlagResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[FlagResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[FlagResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[FlagResIndex]([ResourceId])
CREATE TABLE [dbo].[GoalRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.GoalRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[GoalRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[GoalRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[GoalRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[GoalRes]([LastUpdated])
CREATE TABLE [dbo].[GoalResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.GoalResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[GoalResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[GoalResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[GoalResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[GoalResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[GoalResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[GoalResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[GoalResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[GoalResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[GoalResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[GoalResIndex]([ResourceId])
CREATE TABLE [dbo].[GraphDefinitionRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.GraphDefinitionRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[GraphDefinitionRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[GraphDefinitionRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[GraphDefinitionRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[GraphDefinitionRes]([LastUpdated])
CREATE TABLE [dbo].[GraphDefinitionResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.GraphDefinitionResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[GraphDefinitionResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[GraphDefinitionResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[GraphDefinitionResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[GraphDefinitionResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[GraphDefinitionResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[GraphDefinitionResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[GraphDefinitionResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[GraphDefinitionResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[GraphDefinitionResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[GraphDefinitionResIndex]([ResourceId])
CREATE TABLE [dbo].[GroupRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.GroupRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[GroupRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[GroupRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[GroupRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[GroupRes]([LastUpdated])
CREATE TABLE [dbo].[GroupResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.GroupResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[GroupResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[GroupResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[GroupResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[GroupResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[GroupResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[GroupResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[GroupResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[GroupResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[GroupResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[GroupResIndex]([ResourceId])
CREATE TABLE [dbo].[GuidanceResponseRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.GuidanceResponseRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[GuidanceResponseRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[GuidanceResponseRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[GuidanceResponseRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[GuidanceResponseRes]([LastUpdated])
CREATE TABLE [dbo].[GuidanceResponseResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.GuidanceResponseResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[GuidanceResponseResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[GuidanceResponseResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[GuidanceResponseResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[GuidanceResponseResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[GuidanceResponseResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[GuidanceResponseResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[GuidanceResponseResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[GuidanceResponseResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[GuidanceResponseResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[GuidanceResponseResIndex]([ResourceId])
CREATE TABLE [dbo].[HealthcareServiceRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.HealthcareServiceRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[HealthcareServiceRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[HealthcareServiceRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[HealthcareServiceRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[HealthcareServiceRes]([LastUpdated])
CREATE TABLE [dbo].[HealthcareServiceResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.HealthcareServiceResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[HealthcareServiceResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[HealthcareServiceResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[HealthcareServiceResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[HealthcareServiceResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[HealthcareServiceResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[HealthcareServiceResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[HealthcareServiceResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[HealthcareServiceResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[HealthcareServiceResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[HealthcareServiceResIndex]([ResourceId])
CREATE TABLE [dbo].[ImagingManifestRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.ImagingManifestRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[ImagingManifestRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[ImagingManifestRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[ImagingManifestRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[ImagingManifestRes]([LastUpdated])
CREATE TABLE [dbo].[ImagingManifestResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.ImagingManifestResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[ImagingManifestResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[ImagingManifestResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[ImagingManifestResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[ImagingManifestResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[ImagingManifestResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[ImagingManifestResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[ImagingManifestResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[ImagingManifestResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[ImagingManifestResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[ImagingManifestResIndex]([ResourceId])
CREATE TABLE [dbo].[ImagingStudyRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.ImagingStudyRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[ImagingStudyRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[ImagingStudyRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[ImagingStudyRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[ImagingStudyRes]([LastUpdated])
CREATE TABLE [dbo].[ImagingStudyResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.ImagingStudyResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[ImagingStudyResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[ImagingStudyResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[ImagingStudyResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[ImagingStudyResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[ImagingStudyResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[ImagingStudyResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[ImagingStudyResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[ImagingStudyResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[ImagingStudyResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[ImagingStudyResIndex]([ResourceId])
CREATE TABLE [dbo].[ImmunizationRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.ImmunizationRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[ImmunizationRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[ImmunizationRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[ImmunizationRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[ImmunizationRes]([LastUpdated])
CREATE TABLE [dbo].[ImmunizationResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.ImmunizationResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[ImmunizationResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[ImmunizationResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[ImmunizationResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[ImmunizationResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[ImmunizationResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[ImmunizationResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[ImmunizationResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[ImmunizationResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[ImmunizationResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[ImmunizationResIndex]([ResourceId])
CREATE TABLE [dbo].[ImmunizationRecommendationRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.ImmunizationRecommendationRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[ImmunizationRecommendationRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[ImmunizationRecommendationRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[ImmunizationRecommendationRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[ImmunizationRecommendationRes]([LastUpdated])
CREATE TABLE [dbo].[ImmunizationRecommendationResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.ImmunizationRecommendationResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[ImmunizationRecommendationResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[ImmunizationRecommendationResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[ImmunizationRecommendationResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[ImmunizationRecommendationResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[ImmunizationRecommendationResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[ImmunizationRecommendationResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[ImmunizationRecommendationResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[ImmunizationRecommendationResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[ImmunizationRecommendationResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[ImmunizationRecommendationResIndex]([ResourceId])
CREATE TABLE [dbo].[ImplementationGuideRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.ImplementationGuideRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[ImplementationGuideRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[ImplementationGuideRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[ImplementationGuideRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[ImplementationGuideRes]([LastUpdated])
CREATE TABLE [dbo].[ImplementationGuideResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.ImplementationGuideResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[ImplementationGuideResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[ImplementationGuideResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[ImplementationGuideResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[ImplementationGuideResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[ImplementationGuideResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[ImplementationGuideResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[ImplementationGuideResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[ImplementationGuideResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[ImplementationGuideResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[ImplementationGuideResIndex]([ResourceId])
CREATE TABLE [dbo].[LibraryRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.LibraryRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[LibraryRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[LibraryRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[LibraryRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[LibraryRes]([LastUpdated])
CREATE TABLE [dbo].[LibraryResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.LibraryResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[LibraryResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[LibraryResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[LibraryResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[LibraryResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[LibraryResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[LibraryResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[LibraryResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[LibraryResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[LibraryResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[LibraryResIndex]([ResourceId])
CREATE TABLE [dbo].[LinkageRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.LinkageRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[LinkageRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[LinkageRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[LinkageRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[LinkageRes]([LastUpdated])
CREATE TABLE [dbo].[LinkageResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.LinkageResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[LinkageResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[LinkageResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[LinkageResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[LinkageResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[LinkageResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[LinkageResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[LinkageResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[LinkageResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[LinkageResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[LinkageResIndex]([ResourceId])
CREATE TABLE [dbo].[ListRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.ListRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[ListRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[ListRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[ListRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[ListRes]([LastUpdated])
CREATE TABLE [dbo].[ListResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.ListResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[ListResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[ListResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[ListResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[ListResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[ListResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[ListResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[ListResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[ListResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[ListResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[ListResIndex]([ResourceId])
CREATE TABLE [dbo].[LocationRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.LocationRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[LocationRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[LocationRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[LocationRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[LocationRes]([LastUpdated])
CREATE TABLE [dbo].[LocationResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.LocationResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[LocationResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[LocationResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[LocationResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[LocationResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[LocationResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[LocationResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[LocationResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[LocationResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[LocationResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[LocationResIndex]([ResourceId])
CREATE TABLE [dbo].[MeasureRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.MeasureRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[MeasureRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[MeasureRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[MeasureRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[MeasureRes]([LastUpdated])
CREATE TABLE [dbo].[MeasureResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.MeasureResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[MeasureResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[MeasureResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[MeasureResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[MeasureResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[MeasureResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[MeasureResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[MeasureResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[MeasureResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[MeasureResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[MeasureResIndex]([ResourceId])
CREATE TABLE [dbo].[MeasureReportRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.MeasureReportRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[MeasureReportRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[MeasureReportRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[MeasureReportRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[MeasureReportRes]([LastUpdated])
CREATE TABLE [dbo].[MeasureReportResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.MeasureReportResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[MeasureReportResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[MeasureReportResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[MeasureReportResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[MeasureReportResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[MeasureReportResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[MeasureReportResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[MeasureReportResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[MeasureReportResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[MeasureReportResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[MeasureReportResIndex]([ResourceId])
CREATE TABLE [dbo].[MediaRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.MediaRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[MediaRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[MediaRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[MediaRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[MediaRes]([LastUpdated])
CREATE TABLE [dbo].[MediaResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.MediaResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[MediaResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[MediaResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[MediaResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[MediaResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[MediaResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[MediaResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[MediaResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[MediaResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[MediaResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[MediaResIndex]([ResourceId])
CREATE TABLE [dbo].[MedicationRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.MedicationRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[MedicationRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[MedicationRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[MedicationRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[MedicationRes]([LastUpdated])
CREATE TABLE [dbo].[MedicationResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.MedicationResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[MedicationResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[MedicationResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[MedicationResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[MedicationResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[MedicationResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[MedicationResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[MedicationResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[MedicationResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[MedicationResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[MedicationResIndex]([ResourceId])
CREATE TABLE [dbo].[MedicationAdministrationRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.MedicationAdministrationRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[MedicationAdministrationRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[MedicationAdministrationRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[MedicationAdministrationRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[MedicationAdministrationRes]([LastUpdated])
CREATE TABLE [dbo].[MedicationAdministrationResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.MedicationAdministrationResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[MedicationAdministrationResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[MedicationAdministrationResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[MedicationAdministrationResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[MedicationAdministrationResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[MedicationAdministrationResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[MedicationAdministrationResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[MedicationAdministrationResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[MedicationAdministrationResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[MedicationAdministrationResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[MedicationAdministrationResIndex]([ResourceId])
CREATE TABLE [dbo].[MedicationDispenseRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.MedicationDispenseRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[MedicationDispenseRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[MedicationDispenseRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[MedicationDispenseRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[MedicationDispenseRes]([LastUpdated])
CREATE TABLE [dbo].[MedicationDispenseResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.MedicationDispenseResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[MedicationDispenseResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[MedicationDispenseResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[MedicationDispenseResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[MedicationDispenseResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[MedicationDispenseResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[MedicationDispenseResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[MedicationDispenseResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[MedicationDispenseResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[MedicationDispenseResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[MedicationDispenseResIndex]([ResourceId])
CREATE TABLE [dbo].[MedicationRequestRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.MedicationRequestRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[MedicationRequestRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[MedicationRequestRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[MedicationRequestRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[MedicationRequestRes]([LastUpdated])
CREATE TABLE [dbo].[MedicationRequestResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.MedicationRequestResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[MedicationRequestResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[MedicationRequestResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[MedicationRequestResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[MedicationRequestResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[MedicationRequestResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[MedicationRequestResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[MedicationRequestResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[MedicationRequestResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[MedicationRequestResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[MedicationRequestResIndex]([ResourceId])
CREATE TABLE [dbo].[MedicationStatementRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.MedicationStatementRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[MedicationStatementRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[MedicationStatementRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[MedicationStatementRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[MedicationStatementRes]([LastUpdated])
CREATE TABLE [dbo].[MedicationStatementResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.MedicationStatementResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[MedicationStatementResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[MedicationStatementResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[MedicationStatementResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[MedicationStatementResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[MedicationStatementResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[MedicationStatementResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[MedicationStatementResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[MedicationStatementResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[MedicationStatementResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[MedicationStatementResIndex]([ResourceId])
CREATE TABLE [dbo].[MessageDefinitionRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.MessageDefinitionRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[MessageDefinitionRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[MessageDefinitionRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[MessageDefinitionRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[MessageDefinitionRes]([LastUpdated])
CREATE TABLE [dbo].[MessageDefinitionResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.MessageDefinitionResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[MessageDefinitionResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[MessageDefinitionResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[MessageDefinitionResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[MessageDefinitionResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[MessageDefinitionResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[MessageDefinitionResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[MessageDefinitionResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[MessageDefinitionResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[MessageDefinitionResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[MessageDefinitionResIndex]([ResourceId])
CREATE TABLE [dbo].[MessageHeaderRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.MessageHeaderRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[MessageHeaderRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[MessageHeaderRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[MessageHeaderRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[MessageHeaderRes]([LastUpdated])
CREATE TABLE [dbo].[MessageHeaderResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.MessageHeaderResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[MessageHeaderResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[MessageHeaderResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[MessageHeaderResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[MessageHeaderResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[MessageHeaderResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[MessageHeaderResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[MessageHeaderResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[MessageHeaderResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[MessageHeaderResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[MessageHeaderResIndex]([ResourceId])
CREATE TABLE [dbo].[NamingSystemRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.NamingSystemRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[NamingSystemRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[NamingSystemRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[NamingSystemRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[NamingSystemRes]([LastUpdated])
CREATE TABLE [dbo].[NamingSystemResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.NamingSystemResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[NamingSystemResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[NamingSystemResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[NamingSystemResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[NamingSystemResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[NamingSystemResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[NamingSystemResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[NamingSystemResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[NamingSystemResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[NamingSystemResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[NamingSystemResIndex]([ResourceId])
CREATE TABLE [dbo].[NutritionOrderRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.NutritionOrderRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[NutritionOrderRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[NutritionOrderRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[NutritionOrderRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[NutritionOrderRes]([LastUpdated])
CREATE TABLE [dbo].[NutritionOrderResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.NutritionOrderResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[NutritionOrderResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[NutritionOrderResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[NutritionOrderResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[NutritionOrderResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[NutritionOrderResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[NutritionOrderResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[NutritionOrderResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[NutritionOrderResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[NutritionOrderResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[NutritionOrderResIndex]([ResourceId])
CREATE TABLE [dbo].[ObservationRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.ObservationRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[ObservationRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[ObservationRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[ObservationRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[ObservationRes]([LastUpdated])
CREATE TABLE [dbo].[ObservationResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.ObservationResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[ObservationResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[ObservationResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[ObservationResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[ObservationResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[ObservationResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[ObservationResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[ObservationResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[ObservationResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[ObservationResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[ObservationResIndex]([ResourceId])
CREATE TABLE [dbo].[OperationDefinitionRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.OperationDefinitionRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[OperationDefinitionRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[OperationDefinitionRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[OperationDefinitionRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[OperationDefinitionRes]([LastUpdated])
CREATE TABLE [dbo].[OperationDefinitionResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.OperationDefinitionResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[OperationDefinitionResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[OperationDefinitionResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[OperationDefinitionResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[OperationDefinitionResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[OperationDefinitionResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[OperationDefinitionResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[OperationDefinitionResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[OperationDefinitionResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[OperationDefinitionResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[OperationDefinitionResIndex]([ResourceId])
CREATE TABLE [dbo].[OperationOutcomeRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.OperationOutcomeRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[OperationOutcomeRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[OperationOutcomeRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[OperationOutcomeRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[OperationOutcomeRes]([LastUpdated])
CREATE TABLE [dbo].[OperationOutcomeResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.OperationOutcomeResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[OperationOutcomeResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[OperationOutcomeResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[OperationOutcomeResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[OperationOutcomeResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[OperationOutcomeResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[OperationOutcomeResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[OperationOutcomeResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[OperationOutcomeResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[OperationOutcomeResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[OperationOutcomeResIndex]([ResourceId])
CREATE TABLE [dbo].[OrganizationRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.OrganizationRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[OrganizationRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[OrganizationRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[OrganizationRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[OrganizationRes]([LastUpdated])
CREATE TABLE [dbo].[OrganizationResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.OrganizationResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[OrganizationResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[OrganizationResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[OrganizationResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[OrganizationResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[OrganizationResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[OrganizationResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[OrganizationResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[OrganizationResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[OrganizationResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[OrganizationResIndex]([ResourceId])
CREATE TABLE [dbo].[ParametersRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.ParametersRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[ParametersRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[ParametersRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[ParametersRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[ParametersRes]([LastUpdated])
CREATE TABLE [dbo].[ParametersResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.ParametersResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[ParametersResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[ParametersResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[ParametersResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[ParametersResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[ParametersResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[ParametersResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[ParametersResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[ParametersResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[ParametersResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[ParametersResIndex]([ResourceId])
CREATE TABLE [dbo].[PatientRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.PatientRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[PatientRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[PatientRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[PatientRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[PatientRes]([LastUpdated])
CREATE TABLE [dbo].[PatientResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.PatientResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[PatientResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[PatientResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[PatientResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[PatientResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[PatientResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[PatientResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[PatientResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[PatientResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[PatientResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[PatientResIndex]([ResourceId])
CREATE TABLE [dbo].[PaymentNoticeRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.PaymentNoticeRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[PaymentNoticeRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[PaymentNoticeRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[PaymentNoticeRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[PaymentNoticeRes]([LastUpdated])
CREATE TABLE [dbo].[PaymentNoticeResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.PaymentNoticeResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[PaymentNoticeResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[PaymentNoticeResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[PaymentNoticeResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[PaymentNoticeResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[PaymentNoticeResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[PaymentNoticeResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[PaymentNoticeResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[PaymentNoticeResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[PaymentNoticeResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[PaymentNoticeResIndex]([ResourceId])
CREATE TABLE [dbo].[PaymentReconciliationRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.PaymentReconciliationRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[PaymentReconciliationRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[PaymentReconciliationRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[PaymentReconciliationRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[PaymentReconciliationRes]([LastUpdated])
CREATE TABLE [dbo].[PaymentReconciliationResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.PaymentReconciliationResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[PaymentReconciliationResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[PaymentReconciliationResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[PaymentReconciliationResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[PaymentReconciliationResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[PaymentReconciliationResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[PaymentReconciliationResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[PaymentReconciliationResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[PaymentReconciliationResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[PaymentReconciliationResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[PaymentReconciliationResIndex]([ResourceId])
CREATE TABLE [dbo].[PersonRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.PersonRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[PersonRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[PersonRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[PersonRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[PersonRes]([LastUpdated])
CREATE TABLE [dbo].[PersonResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.PersonResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[PersonResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[PersonResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[PersonResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[PersonResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[PersonResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[PersonResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[PersonResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[PersonResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[PersonResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[PersonResIndex]([ResourceId])
CREATE TABLE [dbo].[PlanDefinitionRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.PlanDefinitionRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[PlanDefinitionRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[PlanDefinitionRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[PlanDefinitionRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[PlanDefinitionRes]([LastUpdated])
CREATE TABLE [dbo].[PlanDefinitionResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.PlanDefinitionResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[PlanDefinitionResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[PlanDefinitionResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[PlanDefinitionResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[PlanDefinitionResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[PlanDefinitionResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[PlanDefinitionResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[PlanDefinitionResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[PlanDefinitionResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[PlanDefinitionResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[PlanDefinitionResIndex]([ResourceId])
CREATE TABLE [dbo].[PractitionerRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.PractitionerRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[PractitionerRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[PractitionerRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[PractitionerRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[PractitionerRes]([LastUpdated])
CREATE TABLE [dbo].[PractitionerResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.PractitionerResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[PractitionerResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[PractitionerResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[PractitionerResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[PractitionerResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[PractitionerResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[PractitionerResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[PractitionerResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[PractitionerResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[PractitionerResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[PractitionerResIndex]([ResourceId])
CREATE TABLE [dbo].[PractitionerRoleRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.PractitionerRoleRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[PractitionerRoleRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[PractitionerRoleRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[PractitionerRoleRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[PractitionerRoleRes]([LastUpdated])
CREATE TABLE [dbo].[PractitionerRoleResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.PractitionerRoleResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[PractitionerRoleResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[PractitionerRoleResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[PractitionerRoleResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[PractitionerRoleResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[PractitionerRoleResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[PractitionerRoleResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[PractitionerRoleResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[PractitionerRoleResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[PractitionerRoleResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[PractitionerRoleResIndex]([ResourceId])
CREATE TABLE [dbo].[ProcedureRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.ProcedureRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[ProcedureRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[ProcedureRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[ProcedureRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[ProcedureRes]([LastUpdated])
CREATE TABLE [dbo].[ProcedureResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.ProcedureResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[ProcedureResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[ProcedureResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[ProcedureResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[ProcedureResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[ProcedureResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[ProcedureResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[ProcedureResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[ProcedureResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[ProcedureResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[ProcedureResIndex]([ResourceId])
CREATE TABLE [dbo].[ProcedureRequestRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.ProcedureRequestRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[ProcedureRequestRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[ProcedureRequestRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[ProcedureRequestRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[ProcedureRequestRes]([LastUpdated])
CREATE TABLE [dbo].[ProcedureRequestResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.ProcedureRequestResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[ProcedureRequestResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[ProcedureRequestResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[ProcedureRequestResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[ProcedureRequestResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[ProcedureRequestResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[ProcedureRequestResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[ProcedureRequestResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[ProcedureRequestResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[ProcedureRequestResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[ProcedureRequestResIndex]([ResourceId])
CREATE TABLE [dbo].[ProcessRequestRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.ProcessRequestRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[ProcessRequestRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[ProcessRequestRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[ProcessRequestRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[ProcessRequestRes]([LastUpdated])
CREATE TABLE [dbo].[ProcessRequestResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.ProcessRequestResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[ProcessRequestResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[ProcessRequestResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[ProcessRequestResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[ProcessRequestResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[ProcessRequestResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[ProcessRequestResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[ProcessRequestResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[ProcessRequestResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[ProcessRequestResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[ProcessRequestResIndex]([ResourceId])
CREATE TABLE [dbo].[ProcessResponseRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.ProcessResponseRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[ProcessResponseRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[ProcessResponseRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[ProcessResponseRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[ProcessResponseRes]([LastUpdated])
CREATE TABLE [dbo].[ProcessResponseResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.ProcessResponseResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[ProcessResponseResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[ProcessResponseResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[ProcessResponseResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[ProcessResponseResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[ProcessResponseResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[ProcessResponseResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[ProcessResponseResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[ProcessResponseResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[ProcessResponseResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[ProcessResponseResIndex]([ResourceId])
CREATE TABLE [dbo].[ProvenanceRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.ProvenanceRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[ProvenanceRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[ProvenanceRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[ProvenanceRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[ProvenanceRes]([LastUpdated])
CREATE TABLE [dbo].[ProvenanceResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.ProvenanceResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[ProvenanceResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[ProvenanceResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[ProvenanceResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[ProvenanceResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[ProvenanceResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[ProvenanceResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[ProvenanceResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[ProvenanceResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[ProvenanceResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[ProvenanceResIndex]([ResourceId])
CREATE TABLE [dbo].[QuestionnaireRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.QuestionnaireRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[QuestionnaireRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[QuestionnaireRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[QuestionnaireRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[QuestionnaireRes]([LastUpdated])
CREATE TABLE [dbo].[QuestionnaireResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.QuestionnaireResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[QuestionnaireResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[QuestionnaireResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[QuestionnaireResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[QuestionnaireResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[QuestionnaireResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[QuestionnaireResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[QuestionnaireResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[QuestionnaireResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[QuestionnaireResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[QuestionnaireResIndex]([ResourceId])
CREATE TABLE [dbo].[QuestionnaireResponseRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.QuestionnaireResponseRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[QuestionnaireResponseRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[QuestionnaireResponseRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[QuestionnaireResponseRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[QuestionnaireResponseRes]([LastUpdated])
CREATE TABLE [dbo].[QuestionnaireResponseResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.QuestionnaireResponseResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[QuestionnaireResponseResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[QuestionnaireResponseResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[QuestionnaireResponseResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[QuestionnaireResponseResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[QuestionnaireResponseResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[QuestionnaireResponseResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[QuestionnaireResponseResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[QuestionnaireResponseResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[QuestionnaireResponseResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[QuestionnaireResponseResIndex]([ResourceId])
CREATE TABLE [dbo].[ReferralRequestRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.ReferralRequestRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[ReferralRequestRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[ReferralRequestRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[ReferralRequestRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[ReferralRequestRes]([LastUpdated])
CREATE TABLE [dbo].[ReferralRequestResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.ReferralRequestResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[ReferralRequestResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[ReferralRequestResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[ReferralRequestResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[ReferralRequestResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[ReferralRequestResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[ReferralRequestResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[ReferralRequestResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[ReferralRequestResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[ReferralRequestResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[ReferralRequestResIndex]([ResourceId])
CREATE TABLE [dbo].[RelatedPersonRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.RelatedPersonRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[RelatedPersonRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[RelatedPersonRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[RelatedPersonRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[RelatedPersonRes]([LastUpdated])
CREATE TABLE [dbo].[RelatedPersonResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.RelatedPersonResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[RelatedPersonResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[RelatedPersonResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[RelatedPersonResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[RelatedPersonResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[RelatedPersonResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[RelatedPersonResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[RelatedPersonResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[RelatedPersonResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[RelatedPersonResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[RelatedPersonResIndex]([ResourceId])
CREATE TABLE [dbo].[RequestGroupRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.RequestGroupRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[RequestGroupRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[RequestGroupRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[RequestGroupRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[RequestGroupRes]([LastUpdated])
CREATE TABLE [dbo].[RequestGroupResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.RequestGroupResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[RequestGroupResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[RequestGroupResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[RequestGroupResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[RequestGroupResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[RequestGroupResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[RequestGroupResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[RequestGroupResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[RequestGroupResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[RequestGroupResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[RequestGroupResIndex]([ResourceId])
CREATE TABLE [dbo].[ResearchStudyRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.ResearchStudyRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[ResearchStudyRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[ResearchStudyRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[ResearchStudyRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[ResearchStudyRes]([LastUpdated])
CREATE TABLE [dbo].[ResearchStudyResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.ResearchStudyResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[ResearchStudyResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[ResearchStudyResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[ResearchStudyResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[ResearchStudyResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[ResearchStudyResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[ResearchStudyResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[ResearchStudyResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[ResearchStudyResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[ResearchStudyResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[ResearchStudyResIndex]([ResourceId])
CREATE TABLE [dbo].[ResearchSubjectRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.ResearchSubjectRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[ResearchSubjectRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[ResearchSubjectRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[ResearchSubjectRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[ResearchSubjectRes]([LastUpdated])
CREATE TABLE [dbo].[ResearchSubjectResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.ResearchSubjectResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[ResearchSubjectResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[ResearchSubjectResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[ResearchSubjectResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[ResearchSubjectResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[ResearchSubjectResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[ResearchSubjectResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[ResearchSubjectResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[ResearchSubjectResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[ResearchSubjectResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[ResearchSubjectResIndex]([ResourceId])
CREATE TABLE [dbo].[RiskAssessmentRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.RiskAssessmentRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[RiskAssessmentRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[RiskAssessmentRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[RiskAssessmentRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[RiskAssessmentRes]([LastUpdated])
CREATE TABLE [dbo].[RiskAssessmentResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.RiskAssessmentResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[RiskAssessmentResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[RiskAssessmentResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[RiskAssessmentResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[RiskAssessmentResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[RiskAssessmentResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[RiskAssessmentResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[RiskAssessmentResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[RiskAssessmentResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[RiskAssessmentResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[RiskAssessmentResIndex]([ResourceId])
CREATE TABLE [dbo].[ScheduleRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.ScheduleRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[ScheduleRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[ScheduleRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[ScheduleRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[ScheduleRes]([LastUpdated])
CREATE TABLE [dbo].[ScheduleResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.ScheduleResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[ScheduleResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[ScheduleResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[ScheduleResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[ScheduleResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[ScheduleResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[ScheduleResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[ScheduleResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[ScheduleResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[ScheduleResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[ScheduleResIndex]([ResourceId])
CREATE TABLE [dbo].[SearchParameterRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.SearchParameterRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[SearchParameterRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[SearchParameterRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[SearchParameterRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[SearchParameterRes]([LastUpdated])
CREATE TABLE [dbo].[SearchParameterResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.SearchParameterResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[SearchParameterResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[SearchParameterResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[SearchParameterResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[SearchParameterResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[SearchParameterResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[SearchParameterResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[SearchParameterResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[SearchParameterResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[SearchParameterResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[SearchParameterResIndex]([ResourceId])
CREATE TABLE [dbo].[SequenceRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.SequenceRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[SequenceRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[SequenceRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[SequenceRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[SequenceRes]([LastUpdated])
CREATE TABLE [dbo].[SequenceResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.SequenceResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[SequenceResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[SequenceResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[SequenceResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[SequenceResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[SequenceResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[SequenceResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[SequenceResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[SequenceResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[SequenceResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[SequenceResIndex]([ResourceId])
CREATE TABLE [dbo].[ServiceDefinitionRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.ServiceDefinitionRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[ServiceDefinitionRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[ServiceDefinitionRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[ServiceDefinitionRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[ServiceDefinitionRes]([LastUpdated])
CREATE TABLE [dbo].[ServiceDefinitionResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.ServiceDefinitionResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[ServiceDefinitionResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[ServiceDefinitionResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[ServiceDefinitionResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[ServiceDefinitionResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[ServiceDefinitionResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[ServiceDefinitionResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[ServiceDefinitionResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[ServiceDefinitionResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[ServiceDefinitionResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[ServiceDefinitionResIndex]([ResourceId])
CREATE TABLE [dbo].[SlotRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.SlotRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[SlotRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[SlotRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[SlotRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[SlotRes]([LastUpdated])
CREATE TABLE [dbo].[SlotResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.SlotResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[SlotResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[SlotResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[SlotResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[SlotResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[SlotResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[SlotResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[SlotResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[SlotResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[SlotResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[SlotResIndex]([ResourceId])
CREATE TABLE [dbo].[SpecimenRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.SpecimenRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[SpecimenRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[SpecimenRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[SpecimenRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[SpecimenRes]([LastUpdated])
CREATE TABLE [dbo].[SpecimenResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.SpecimenResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[SpecimenResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[SpecimenResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[SpecimenResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[SpecimenResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[SpecimenResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[SpecimenResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[SpecimenResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[SpecimenResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[SpecimenResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[SpecimenResIndex]([ResourceId])
CREATE TABLE [dbo].[StructureDefinitionRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.StructureDefinitionRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[StructureDefinitionRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[StructureDefinitionRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[StructureDefinitionRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[StructureDefinitionRes]([LastUpdated])
CREATE TABLE [dbo].[StructureDefinitionResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.StructureDefinitionResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[StructureDefinitionResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[StructureDefinitionResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[StructureDefinitionResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[StructureDefinitionResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[StructureDefinitionResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[StructureDefinitionResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[StructureDefinitionResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[StructureDefinitionResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[StructureDefinitionResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[StructureDefinitionResIndex]([ResourceId])
CREATE TABLE [dbo].[StructureMapRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.StructureMapRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[StructureMapRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[StructureMapRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[StructureMapRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[StructureMapRes]([LastUpdated])
CREATE TABLE [dbo].[StructureMapResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.StructureMapResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[StructureMapResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[StructureMapResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[StructureMapResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[StructureMapResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[StructureMapResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[StructureMapResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[StructureMapResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[StructureMapResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[StructureMapResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[StructureMapResIndex]([ResourceId])
CREATE TABLE [dbo].[SubscriptionRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.SubscriptionRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[SubscriptionRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[SubscriptionRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[SubscriptionRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[SubscriptionRes]([LastUpdated])
CREATE TABLE [dbo].[SubscriptionResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.SubscriptionResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[SubscriptionResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[SubscriptionResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[SubscriptionResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[SubscriptionResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[SubscriptionResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[SubscriptionResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[SubscriptionResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[SubscriptionResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[SubscriptionResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[SubscriptionResIndex]([ResourceId])
CREATE TABLE [dbo].[SubstanceRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.SubstanceRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[SubstanceRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[SubstanceRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[SubstanceRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[SubstanceRes]([LastUpdated])
CREATE TABLE [dbo].[SubstanceResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.SubstanceResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[SubstanceResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[SubstanceResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[SubstanceResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[SubstanceResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[SubstanceResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[SubstanceResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[SubstanceResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[SubstanceResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[SubstanceResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[SubstanceResIndex]([ResourceId])
CREATE TABLE [dbo].[SupplyDeliveryRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.SupplyDeliveryRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[SupplyDeliveryRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[SupplyDeliveryRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[SupplyDeliveryRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[SupplyDeliveryRes]([LastUpdated])
CREATE TABLE [dbo].[SupplyDeliveryResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.SupplyDeliveryResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[SupplyDeliveryResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[SupplyDeliveryResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[SupplyDeliveryResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[SupplyDeliveryResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[SupplyDeliveryResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[SupplyDeliveryResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[SupplyDeliveryResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[SupplyDeliveryResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[SupplyDeliveryResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[SupplyDeliveryResIndex]([ResourceId])
CREATE TABLE [dbo].[SupplyRequestRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.SupplyRequestRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[SupplyRequestRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[SupplyRequestRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[SupplyRequestRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[SupplyRequestRes]([LastUpdated])
CREATE TABLE [dbo].[SupplyRequestResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.SupplyRequestResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[SupplyRequestResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[SupplyRequestResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[SupplyRequestResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[SupplyRequestResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[SupplyRequestResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[SupplyRequestResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[SupplyRequestResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[SupplyRequestResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[SupplyRequestResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[SupplyRequestResIndex]([ResourceId])
CREATE TABLE [dbo].[TaskRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.TaskRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[TaskRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[TaskRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[TaskRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[TaskRes]([LastUpdated])
CREATE TABLE [dbo].[TaskResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.TaskResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[TaskResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[TaskResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[TaskResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[TaskResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[TaskResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[TaskResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[TaskResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[TaskResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[TaskResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[TaskResIndex]([ResourceId])
CREATE TABLE [dbo].[TestReportRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.TestReportRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[TestReportRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[TestReportRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[TestReportRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[TestReportRes]([LastUpdated])
CREATE TABLE [dbo].[TestReportResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.TestReportResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[TestReportResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[TestReportResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[TestReportResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[TestReportResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[TestReportResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[TestReportResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[TestReportResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[TestReportResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[TestReportResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[TestReportResIndex]([ResourceId])
CREATE TABLE [dbo].[TestScriptRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.TestScriptRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[TestScriptRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[TestScriptRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[TestScriptRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[TestScriptRes]([LastUpdated])
CREATE TABLE [dbo].[TestScriptResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.TestScriptResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[TestScriptResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[TestScriptResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[TestScriptResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[TestScriptResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[TestScriptResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[TestScriptResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[TestScriptResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[TestScriptResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[TestScriptResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[TestScriptResIndex]([ResourceId])
CREATE TABLE [dbo].[ValueSetRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.ValueSetRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[ValueSetRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[ValueSetRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[ValueSetRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[ValueSetRes]([LastUpdated])
CREATE TABLE [dbo].[ValueSetResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.ValueSetResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[ValueSetResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[ValueSetResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[ValueSetResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[ValueSetResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[ValueSetResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[ValueSetResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[ValueSetResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[ValueSetResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[ValueSetResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[ValueSetResIndex]([ResourceId])
CREATE TABLE [dbo].[VisionPrescriptionRes] (
    [Id] [int] NOT NULL IDENTITY,
    [IsCurrent] [bit] NOT NULL,
    [FhirId] [nvarchar](128) NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [VersionId] [nvarchar](128) NOT NULL,
    [LastUpdated] [datetimeoffset](3) NOT NULL,
    [XmlBlob] [nvarchar](max) NOT NULL,
    [Method] [int] NOT NULL,
    CONSTRAINT [PK_dbo.VisionPrescriptionRes] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_IsCurrent] ON [dbo].[VisionPrescriptionRes]([IsCurrent])
CREATE UNIQUE INDEX [uq_FhirIdAndVersionId] ON [dbo].[VisionPrescriptionRes]([FhirId], [VersionId])
CREATE INDEX [ix_IsDeleted] ON [dbo].[VisionPrescriptionRes]([IsDeleted])
CREATE INDEX [ix_LastUpdated] ON [dbo].[VisionPrescriptionRes]([LastUpdated])
CREATE TABLE [dbo].[VisionPrescriptionResIndex] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceSearchParameterId] [int] NOT NULL,
    [String] [nvarchar](450),
    [DateTimeOffsetLow] [datetimeoffset](3),
    [DateTimeOffsetHigh] [datetimeoffset](3),
    [Uri] [nvarchar](450),
    [Comparator] [int],
    [Quantity] [decimal](28, 14),
    [System] [nvarchar](300),
    [Code] [nvarchar](50),
    [Unit] [nvarchar](300),
    [ComparatorHigh] [int],
    [QuantityHigh] [decimal](28, 14),
    [SystemHigh] [nvarchar](300),
    [CodeHigh] [nvarchar](50),
    [UnitHigh] [nvarchar](50),
    [ReferenceFhirId] [nvarchar](128),
    [ReferenceResourceType] [nvarchar](50),
    [ReferenceVersionId] [nvarchar](128),
    [ReferenceServiceBaseUrlId] [int],
    [ResourceId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.VisionPrescriptionResIndex] PRIMARY KEY ([Id])
)
CREATE INDEX [ix_ServiceSearchParameterId] ON [dbo].[VisionPrescriptionResIndex]([ServiceSearchParameterId])
CREATE INDEX [ix_String] ON [dbo].[VisionPrescriptionResIndex]([String])
CREATE INDEX [ix_DateTimeOffsetLow] ON [dbo].[VisionPrescriptionResIndex]([DateTimeOffsetLow])
CREATE INDEX [ix_DateTimeOffsetHigh] ON [dbo].[VisionPrescriptionResIndex]([DateTimeOffsetHigh])
CREATE INDEX [ix_Uri] ON [dbo].[VisionPrescriptionResIndex]([Uri])
CREATE INDEX [ix_System] ON [dbo].[VisionPrescriptionResIndex]([System])
CREATE INDEX [ix_Code] ON [dbo].[VisionPrescriptionResIndex]([Code])
CREATE INDEX [ix_ReferenceFhirId] ON [dbo].[VisionPrescriptionResIndex]([ReferenceFhirId])
CREATE INDEX [ix_ReferenceServiceBaseUrlId] ON [dbo].[VisionPrescriptionResIndex]([ReferenceServiceBaseUrlId])
CREATE INDEX [IX_ResourceId] ON [dbo].[VisionPrescriptionResIndex]([ResourceId])
ALTER TABLE [dbo].[AccountResIndex] ADD CONSTRAINT [FK_dbo.AccountResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[AccountResIndex] ADD CONSTRAINT [FK_dbo.AccountResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[AccountResIndex] ADD CONSTRAINT [FK_dbo.AccountResIndex_dbo.AccountRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[AccountRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[ServiceSearchParameterTargetResource] ADD CONSTRAINT [FK_dbo.ServiceSearchParameterTargetResource_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[ActivityDefinitionResIndex] ADD CONSTRAINT [FK_dbo.ActivityDefinitionResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[ActivityDefinitionResIndex] ADD CONSTRAINT [FK_dbo.ActivityDefinitionResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[ActivityDefinitionResIndex] ADD CONSTRAINT [FK_dbo.ActivityDefinitionResIndex_dbo.ActivityDefinitionRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[ActivityDefinitionRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[AdverseEventResIndex] ADD CONSTRAINT [FK_dbo.AdverseEventResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[AdverseEventResIndex] ADD CONSTRAINT [FK_dbo.AdverseEventResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[AdverseEventResIndex] ADD CONSTRAINT [FK_dbo.AdverseEventResIndex_dbo.AdverseEventRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[AdverseEventRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[AllergyIntoleranceResIndex] ADD CONSTRAINT [FK_dbo.AllergyIntoleranceResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[AllergyIntoleranceResIndex] ADD CONSTRAINT [FK_dbo.AllergyIntoleranceResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[AllergyIntoleranceResIndex] ADD CONSTRAINT [FK_dbo.AllergyIntoleranceResIndex_dbo.AllergyIntoleranceRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[AllergyIntoleranceRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[AppointmentResIndex] ADD CONSTRAINT [FK_dbo.AppointmentResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[AppointmentResIndex] ADD CONSTRAINT [FK_dbo.AppointmentResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[AppointmentResIndex] ADD CONSTRAINT [FK_dbo.AppointmentResIndex_dbo.AppointmentRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[AppointmentRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[AppointmentResponseResIndex] ADD CONSTRAINT [FK_dbo.AppointmentResponseResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[AppointmentResponseResIndex] ADD CONSTRAINT [FK_dbo.AppointmentResponseResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[AppointmentResponseResIndex] ADD CONSTRAINT [FK_dbo.AppointmentResponseResIndex_dbo.AppointmentResponseRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[AppointmentResponseRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[AuditEventResIndex] ADD CONSTRAINT [FK_dbo.AuditEventResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[AuditEventResIndex] ADD CONSTRAINT [FK_dbo.AuditEventResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[AuditEventResIndex] ADD CONSTRAINT [FK_dbo.AuditEventResIndex_dbo.AuditEventRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[AuditEventRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[BasicResIndex] ADD CONSTRAINT [FK_dbo.BasicResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[BasicResIndex] ADD CONSTRAINT [FK_dbo.BasicResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[BasicResIndex] ADD CONSTRAINT [FK_dbo.BasicResIndex_dbo.BasicRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[BasicRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[BinaryResIndex] ADD CONSTRAINT [FK_dbo.BinaryResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[BinaryResIndex] ADD CONSTRAINT [FK_dbo.BinaryResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[BinaryResIndex] ADD CONSTRAINT [FK_dbo.BinaryResIndex_dbo.BinaryRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[BinaryRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[BodySiteResIndex] ADD CONSTRAINT [FK_dbo.BodySiteResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[BodySiteResIndex] ADD CONSTRAINT [FK_dbo.BodySiteResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[BodySiteResIndex] ADD CONSTRAINT [FK_dbo.BodySiteResIndex_dbo.BodySiteRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[BodySiteRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[BundleResIndex] ADD CONSTRAINT [FK_dbo.BundleResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[BundleResIndex] ADD CONSTRAINT [FK_dbo.BundleResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[BundleResIndex] ADD CONSTRAINT [FK_dbo.BundleResIndex_dbo.BundleRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[BundleRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[CapabilityStatementResIndex] ADD CONSTRAINT [FK_dbo.CapabilityStatementResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[CapabilityStatementResIndex] ADD CONSTRAINT [FK_dbo.CapabilityStatementResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[CapabilityStatementResIndex] ADD CONSTRAINT [FK_dbo.CapabilityStatementResIndex_dbo.CapabilityStatementRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[CapabilityStatementRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[CarePlanResIndex] ADD CONSTRAINT [FK_dbo.CarePlanResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[CarePlanResIndex] ADD CONSTRAINT [FK_dbo.CarePlanResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[CarePlanResIndex] ADD CONSTRAINT [FK_dbo.CarePlanResIndex_dbo.CarePlanRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[CarePlanRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[CareTeamResIndex] ADD CONSTRAINT [FK_dbo.CareTeamResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[CareTeamResIndex] ADD CONSTRAINT [FK_dbo.CareTeamResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[CareTeamResIndex] ADD CONSTRAINT [FK_dbo.CareTeamResIndex_dbo.CareTeamRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[CareTeamRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[ChargeItemResIndex] ADD CONSTRAINT [FK_dbo.ChargeItemResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[ChargeItemResIndex] ADD CONSTRAINT [FK_dbo.ChargeItemResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[ChargeItemResIndex] ADD CONSTRAINT [FK_dbo.ChargeItemResIndex_dbo.ChargeItemRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[ChargeItemRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[ClaimResIndex] ADD CONSTRAINT [FK_dbo.ClaimResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[ClaimResIndex] ADD CONSTRAINT [FK_dbo.ClaimResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[ClaimResIndex] ADD CONSTRAINT [FK_dbo.ClaimResIndex_dbo.ClaimRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[ClaimRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[ClaimResponseResIndex] ADD CONSTRAINT [FK_dbo.ClaimResponseResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[ClaimResponseResIndex] ADD CONSTRAINT [FK_dbo.ClaimResponseResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[ClaimResponseResIndex] ADD CONSTRAINT [FK_dbo.ClaimResponseResIndex_dbo.ClaimResponseRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[ClaimResponseRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[ClinicalImpressionResIndex] ADD CONSTRAINT [FK_dbo.ClinicalImpressionResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[ClinicalImpressionResIndex] ADD CONSTRAINT [FK_dbo.ClinicalImpressionResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[ClinicalImpressionResIndex] ADD CONSTRAINT [FK_dbo.ClinicalImpressionResIndex_dbo.ClinicalImpressionRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[ClinicalImpressionRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[CodeSystemResIndex] ADD CONSTRAINT [FK_dbo.CodeSystemResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[CodeSystemResIndex] ADD CONSTRAINT [FK_dbo.CodeSystemResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[CodeSystemResIndex] ADD CONSTRAINT [FK_dbo.CodeSystemResIndex_dbo.CodeSystemRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[CodeSystemRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[CommunicationResIndex] ADD CONSTRAINT [FK_dbo.CommunicationResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[CommunicationResIndex] ADD CONSTRAINT [FK_dbo.CommunicationResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[CommunicationResIndex] ADD CONSTRAINT [FK_dbo.CommunicationResIndex_dbo.CommunicationRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[CommunicationRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[CommunicationRequestResIndex] ADD CONSTRAINT [FK_dbo.CommunicationRequestResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[CommunicationRequestResIndex] ADD CONSTRAINT [FK_dbo.CommunicationRequestResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[CommunicationRequestResIndex] ADD CONSTRAINT [FK_dbo.CommunicationRequestResIndex_dbo.CommunicationRequestRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[CommunicationRequestRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[CompartmentDefinitionResIndex] ADD CONSTRAINT [FK_dbo.CompartmentDefinitionResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[CompartmentDefinitionResIndex] ADD CONSTRAINT [FK_dbo.CompartmentDefinitionResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[CompartmentDefinitionResIndex] ADD CONSTRAINT [FK_dbo.CompartmentDefinitionResIndex_dbo.CompartmentDefinitionRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[CompartmentDefinitionRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[CompositionResIndex] ADD CONSTRAINT [FK_dbo.CompositionResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[CompositionResIndex] ADD CONSTRAINT [FK_dbo.CompositionResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[CompositionResIndex] ADD CONSTRAINT [FK_dbo.CompositionResIndex_dbo.CompositionRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[CompositionRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[ConceptMapResIndex] ADD CONSTRAINT [FK_dbo.ConceptMapResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[ConceptMapResIndex] ADD CONSTRAINT [FK_dbo.ConceptMapResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[ConceptMapResIndex] ADD CONSTRAINT [FK_dbo.ConceptMapResIndex_dbo.ConceptMapRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[ConceptMapRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[ConditionResIndex] ADD CONSTRAINT [FK_dbo.ConditionResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[ConditionResIndex] ADD CONSTRAINT [FK_dbo.ConditionResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[ConditionResIndex] ADD CONSTRAINT [FK_dbo.ConditionResIndex_dbo.ConditionRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[ConditionRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[ConsentResIndex] ADD CONSTRAINT [FK_dbo.ConsentResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[ConsentResIndex] ADD CONSTRAINT [FK_dbo.ConsentResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[ConsentResIndex] ADD CONSTRAINT [FK_dbo.ConsentResIndex_dbo.ConsentRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[ConsentRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[ContractResIndex] ADD CONSTRAINT [FK_dbo.ContractResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[ContractResIndex] ADD CONSTRAINT [FK_dbo.ContractResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[ContractResIndex] ADD CONSTRAINT [FK_dbo.ContractResIndex_dbo.ContractRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[ContractRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[CoverageResIndex] ADD CONSTRAINT [FK_dbo.CoverageResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[CoverageResIndex] ADD CONSTRAINT [FK_dbo.CoverageResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[CoverageResIndex] ADD CONSTRAINT [FK_dbo.CoverageResIndex_dbo.CoverageRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[CoverageRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[DataElementResIndex] ADD CONSTRAINT [FK_dbo.DataElementResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[DataElementResIndex] ADD CONSTRAINT [FK_dbo.DataElementResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[DataElementResIndex] ADD CONSTRAINT [FK_dbo.DataElementResIndex_dbo.DataElementRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[DataElementRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[DetectedIssueResIndex] ADD CONSTRAINT [FK_dbo.DetectedIssueResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[DetectedIssueResIndex] ADD CONSTRAINT [FK_dbo.DetectedIssueResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[DetectedIssueResIndex] ADD CONSTRAINT [FK_dbo.DetectedIssueResIndex_dbo.DetectedIssueRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[DetectedIssueRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[DeviceResIndex] ADD CONSTRAINT [FK_dbo.DeviceResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[DeviceResIndex] ADD CONSTRAINT [FK_dbo.DeviceResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[DeviceResIndex] ADD CONSTRAINT [FK_dbo.DeviceResIndex_dbo.DeviceRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[DeviceRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[DeviceComponentResIndex] ADD CONSTRAINT [FK_dbo.DeviceComponentResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[DeviceComponentResIndex] ADD CONSTRAINT [FK_dbo.DeviceComponentResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[DeviceComponentResIndex] ADD CONSTRAINT [FK_dbo.DeviceComponentResIndex_dbo.DeviceComponentRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[DeviceComponentRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[DeviceMetricResIndex] ADD CONSTRAINT [FK_dbo.DeviceMetricResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[DeviceMetricResIndex] ADD CONSTRAINT [FK_dbo.DeviceMetricResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[DeviceMetricResIndex] ADD CONSTRAINT [FK_dbo.DeviceMetricResIndex_dbo.DeviceMetricRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[DeviceMetricRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[DeviceRequestResIndex] ADD CONSTRAINT [FK_dbo.DeviceRequestResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[DeviceRequestResIndex] ADD CONSTRAINT [FK_dbo.DeviceRequestResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[DeviceRequestResIndex] ADD CONSTRAINT [FK_dbo.DeviceRequestResIndex_dbo.DeviceRequestRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[DeviceRequestRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[DeviceUseStatementResIndex] ADD CONSTRAINT [FK_dbo.DeviceUseStatementResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[DeviceUseStatementResIndex] ADD CONSTRAINT [FK_dbo.DeviceUseStatementResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[DeviceUseStatementResIndex] ADD CONSTRAINT [FK_dbo.DeviceUseStatementResIndex_dbo.DeviceUseStatementRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[DeviceUseStatementRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[DiagnosticReportResIndex] ADD CONSTRAINT [FK_dbo.DiagnosticReportResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[DiagnosticReportResIndex] ADD CONSTRAINT [FK_dbo.DiagnosticReportResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[DiagnosticReportResIndex] ADD CONSTRAINT [FK_dbo.DiagnosticReportResIndex_dbo.DiagnosticReportRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[DiagnosticReportRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[DocumentManifestResIndex] ADD CONSTRAINT [FK_dbo.DocumentManifestResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[DocumentManifestResIndex] ADD CONSTRAINT [FK_dbo.DocumentManifestResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[DocumentManifestResIndex] ADD CONSTRAINT [FK_dbo.DocumentManifestResIndex_dbo.DocumentManifestRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[DocumentManifestRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[DocumentReferenceResIndex] ADD CONSTRAINT [FK_dbo.DocumentReferenceResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[DocumentReferenceResIndex] ADD CONSTRAINT [FK_dbo.DocumentReferenceResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[DocumentReferenceResIndex] ADD CONSTRAINT [FK_dbo.DocumentReferenceResIndex_dbo.DocumentReferenceRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[DocumentReferenceRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[EligibilityRequestResIndex] ADD CONSTRAINT [FK_dbo.EligibilityRequestResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[EligibilityRequestResIndex] ADD CONSTRAINT [FK_dbo.EligibilityRequestResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[EligibilityRequestResIndex] ADD CONSTRAINT [FK_dbo.EligibilityRequestResIndex_dbo.EligibilityRequestRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[EligibilityRequestRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[EligibilityResponseResIndex] ADD CONSTRAINT [FK_dbo.EligibilityResponseResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[EligibilityResponseResIndex] ADD CONSTRAINT [FK_dbo.EligibilityResponseResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[EligibilityResponseResIndex] ADD CONSTRAINT [FK_dbo.EligibilityResponseResIndex_dbo.EligibilityResponseRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[EligibilityResponseRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[EncounterResIndex] ADD CONSTRAINT [FK_dbo.EncounterResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[EncounterResIndex] ADD CONSTRAINT [FK_dbo.EncounterResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[EncounterResIndex] ADD CONSTRAINT [FK_dbo.EncounterResIndex_dbo.EncounterRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[EncounterRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[EndpointResIndex] ADD CONSTRAINT [FK_dbo.EndpointResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[EndpointResIndex] ADD CONSTRAINT [FK_dbo.EndpointResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[EndpointResIndex] ADD CONSTRAINT [FK_dbo.EndpointResIndex_dbo.EndpointRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[EndpointRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[EnrollmentRequestResIndex] ADD CONSTRAINT [FK_dbo.EnrollmentRequestResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[EnrollmentRequestResIndex] ADD CONSTRAINT [FK_dbo.EnrollmentRequestResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[EnrollmentRequestResIndex] ADD CONSTRAINT [FK_dbo.EnrollmentRequestResIndex_dbo.EnrollmentRequestRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[EnrollmentRequestRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[EnrollmentResponseResIndex] ADD CONSTRAINT [FK_dbo.EnrollmentResponseResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[EnrollmentResponseResIndex] ADD CONSTRAINT [FK_dbo.EnrollmentResponseResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[EnrollmentResponseResIndex] ADD CONSTRAINT [FK_dbo.EnrollmentResponseResIndex_dbo.EnrollmentResponseRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[EnrollmentResponseRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[EpisodeOfCareResIndex] ADD CONSTRAINT [FK_dbo.EpisodeOfCareResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[EpisodeOfCareResIndex] ADD CONSTRAINT [FK_dbo.EpisodeOfCareResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[EpisodeOfCareResIndex] ADD CONSTRAINT [FK_dbo.EpisodeOfCareResIndex_dbo.EpisodeOfCareRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[EpisodeOfCareRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[ExpansionProfileResIndex] ADD CONSTRAINT [FK_dbo.ExpansionProfileResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[ExpansionProfileResIndex] ADD CONSTRAINT [FK_dbo.ExpansionProfileResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[ExpansionProfileResIndex] ADD CONSTRAINT [FK_dbo.ExpansionProfileResIndex_dbo.ExpansionProfileRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[ExpansionProfileRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[ExplanationOfBenefitResIndex] ADD CONSTRAINT [FK_dbo.ExplanationOfBenefitResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[ExplanationOfBenefitResIndex] ADD CONSTRAINT [FK_dbo.ExplanationOfBenefitResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[ExplanationOfBenefitResIndex] ADD CONSTRAINT [FK_dbo.ExplanationOfBenefitResIndex_dbo.ExplanationOfBenefitRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[ExplanationOfBenefitRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[FamilyMemberHistoryResIndex] ADD CONSTRAINT [FK_dbo.FamilyMemberHistoryResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[FamilyMemberHistoryResIndex] ADD CONSTRAINT [FK_dbo.FamilyMemberHistoryResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[FamilyMemberHistoryResIndex] ADD CONSTRAINT [FK_dbo.FamilyMemberHistoryResIndex_dbo.FamilyMemberHistoryRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[FamilyMemberHistoryRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[FlagResIndex] ADD CONSTRAINT [FK_dbo.FlagResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[FlagResIndex] ADD CONSTRAINT [FK_dbo.FlagResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[FlagResIndex] ADD CONSTRAINT [FK_dbo.FlagResIndex_dbo.FlagRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[FlagRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[GoalResIndex] ADD CONSTRAINT [FK_dbo.GoalResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[GoalResIndex] ADD CONSTRAINT [FK_dbo.GoalResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[GoalResIndex] ADD CONSTRAINT [FK_dbo.GoalResIndex_dbo.GoalRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[GoalRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[GraphDefinitionResIndex] ADD CONSTRAINT [FK_dbo.GraphDefinitionResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[GraphDefinitionResIndex] ADD CONSTRAINT [FK_dbo.GraphDefinitionResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[GraphDefinitionResIndex] ADD CONSTRAINT [FK_dbo.GraphDefinitionResIndex_dbo.GraphDefinitionRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[GraphDefinitionRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[GroupResIndex] ADD CONSTRAINT [FK_dbo.GroupResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[GroupResIndex] ADD CONSTRAINT [FK_dbo.GroupResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[GroupResIndex] ADD CONSTRAINT [FK_dbo.GroupResIndex_dbo.GroupRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[GroupRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[GuidanceResponseResIndex] ADD CONSTRAINT [FK_dbo.GuidanceResponseResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[GuidanceResponseResIndex] ADD CONSTRAINT [FK_dbo.GuidanceResponseResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[GuidanceResponseResIndex] ADD CONSTRAINT [FK_dbo.GuidanceResponseResIndex_dbo.GuidanceResponseRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[GuidanceResponseRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[HealthcareServiceResIndex] ADD CONSTRAINT [FK_dbo.HealthcareServiceResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[HealthcareServiceResIndex] ADD CONSTRAINT [FK_dbo.HealthcareServiceResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[HealthcareServiceResIndex] ADD CONSTRAINT [FK_dbo.HealthcareServiceResIndex_dbo.HealthcareServiceRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[HealthcareServiceRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[ImagingManifestResIndex] ADD CONSTRAINT [FK_dbo.ImagingManifestResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[ImagingManifestResIndex] ADD CONSTRAINT [FK_dbo.ImagingManifestResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[ImagingManifestResIndex] ADD CONSTRAINT [FK_dbo.ImagingManifestResIndex_dbo.ImagingManifestRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[ImagingManifestRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[ImagingStudyResIndex] ADD CONSTRAINT [FK_dbo.ImagingStudyResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[ImagingStudyResIndex] ADD CONSTRAINT [FK_dbo.ImagingStudyResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[ImagingStudyResIndex] ADD CONSTRAINT [FK_dbo.ImagingStudyResIndex_dbo.ImagingStudyRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[ImagingStudyRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[ImmunizationResIndex] ADD CONSTRAINT [FK_dbo.ImmunizationResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[ImmunizationResIndex] ADD CONSTRAINT [FK_dbo.ImmunizationResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[ImmunizationResIndex] ADD CONSTRAINT [FK_dbo.ImmunizationResIndex_dbo.ImmunizationRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[ImmunizationRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[ImmunizationRecommendationResIndex] ADD CONSTRAINT [FK_dbo.ImmunizationRecommendationResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[ImmunizationRecommendationResIndex] ADD CONSTRAINT [FK_dbo.ImmunizationRecommendationResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[ImmunizationRecommendationResIndex] ADD CONSTRAINT [FK_dbo.ImmunizationRecommendationResIndex_dbo.ImmunizationRecommendationRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[ImmunizationRecommendationRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[ImplementationGuideResIndex] ADD CONSTRAINT [FK_dbo.ImplementationGuideResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[ImplementationGuideResIndex] ADD CONSTRAINT [FK_dbo.ImplementationGuideResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[ImplementationGuideResIndex] ADD CONSTRAINT [FK_dbo.ImplementationGuideResIndex_dbo.ImplementationGuideRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[ImplementationGuideRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[LibraryResIndex] ADD CONSTRAINT [FK_dbo.LibraryResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[LibraryResIndex] ADD CONSTRAINT [FK_dbo.LibraryResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[LibraryResIndex] ADD CONSTRAINT [FK_dbo.LibraryResIndex_dbo.LibraryRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[LibraryRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[LinkageResIndex] ADD CONSTRAINT [FK_dbo.LinkageResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[LinkageResIndex] ADD CONSTRAINT [FK_dbo.LinkageResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[LinkageResIndex] ADD CONSTRAINT [FK_dbo.LinkageResIndex_dbo.LinkageRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[LinkageRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[ListResIndex] ADD CONSTRAINT [FK_dbo.ListResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[ListResIndex] ADD CONSTRAINT [FK_dbo.ListResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[ListResIndex] ADD CONSTRAINT [FK_dbo.ListResIndex_dbo.ListRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[ListRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[LocationResIndex] ADD CONSTRAINT [FK_dbo.LocationResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[LocationResIndex] ADD CONSTRAINT [FK_dbo.LocationResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[LocationResIndex] ADD CONSTRAINT [FK_dbo.LocationResIndex_dbo.LocationRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[LocationRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[MeasureResIndex] ADD CONSTRAINT [FK_dbo.MeasureResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[MeasureResIndex] ADD CONSTRAINT [FK_dbo.MeasureResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[MeasureResIndex] ADD CONSTRAINT [FK_dbo.MeasureResIndex_dbo.MeasureRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[MeasureRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[MeasureReportResIndex] ADD CONSTRAINT [FK_dbo.MeasureReportResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[MeasureReportResIndex] ADD CONSTRAINT [FK_dbo.MeasureReportResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[MeasureReportResIndex] ADD CONSTRAINT [FK_dbo.MeasureReportResIndex_dbo.MeasureReportRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[MeasureReportRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[MediaResIndex] ADD CONSTRAINT [FK_dbo.MediaResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[MediaResIndex] ADD CONSTRAINT [FK_dbo.MediaResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[MediaResIndex] ADD CONSTRAINT [FK_dbo.MediaResIndex_dbo.MediaRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[MediaRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[MedicationResIndex] ADD CONSTRAINT [FK_dbo.MedicationResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[MedicationResIndex] ADD CONSTRAINT [FK_dbo.MedicationResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[MedicationResIndex] ADD CONSTRAINT [FK_dbo.MedicationResIndex_dbo.MedicationRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[MedicationRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[MedicationAdministrationResIndex] ADD CONSTRAINT [FK_dbo.MedicationAdministrationResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[MedicationAdministrationResIndex] ADD CONSTRAINT [FK_dbo.MedicationAdministrationResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[MedicationAdministrationResIndex] ADD CONSTRAINT [FK_dbo.MedicationAdministrationResIndex_dbo.MedicationAdministrationRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[MedicationAdministrationRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[MedicationDispenseResIndex] ADD CONSTRAINT [FK_dbo.MedicationDispenseResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[MedicationDispenseResIndex] ADD CONSTRAINT [FK_dbo.MedicationDispenseResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[MedicationDispenseResIndex] ADD CONSTRAINT [FK_dbo.MedicationDispenseResIndex_dbo.MedicationDispenseRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[MedicationDispenseRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[MedicationRequestResIndex] ADD CONSTRAINT [FK_dbo.MedicationRequestResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[MedicationRequestResIndex] ADD CONSTRAINT [FK_dbo.MedicationRequestResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[MedicationRequestResIndex] ADD CONSTRAINT [FK_dbo.MedicationRequestResIndex_dbo.MedicationRequestRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[MedicationRequestRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[MedicationStatementResIndex] ADD CONSTRAINT [FK_dbo.MedicationStatementResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[MedicationStatementResIndex] ADD CONSTRAINT [FK_dbo.MedicationStatementResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[MedicationStatementResIndex] ADD CONSTRAINT [FK_dbo.MedicationStatementResIndex_dbo.MedicationStatementRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[MedicationStatementRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[MessageDefinitionResIndex] ADD CONSTRAINT [FK_dbo.MessageDefinitionResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[MessageDefinitionResIndex] ADD CONSTRAINT [FK_dbo.MessageDefinitionResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[MessageDefinitionResIndex] ADD CONSTRAINT [FK_dbo.MessageDefinitionResIndex_dbo.MessageDefinitionRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[MessageDefinitionRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[MessageHeaderResIndex] ADD CONSTRAINT [FK_dbo.MessageHeaderResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[MessageHeaderResIndex] ADD CONSTRAINT [FK_dbo.MessageHeaderResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[MessageHeaderResIndex] ADD CONSTRAINT [FK_dbo.MessageHeaderResIndex_dbo.MessageHeaderRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[MessageHeaderRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[NamingSystemResIndex] ADD CONSTRAINT [FK_dbo.NamingSystemResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[NamingSystemResIndex] ADD CONSTRAINT [FK_dbo.NamingSystemResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[NamingSystemResIndex] ADD CONSTRAINT [FK_dbo.NamingSystemResIndex_dbo.NamingSystemRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[NamingSystemRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[NutritionOrderResIndex] ADD CONSTRAINT [FK_dbo.NutritionOrderResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[NutritionOrderResIndex] ADD CONSTRAINT [FK_dbo.NutritionOrderResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[NutritionOrderResIndex] ADD CONSTRAINT [FK_dbo.NutritionOrderResIndex_dbo.NutritionOrderRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[NutritionOrderRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[ObservationResIndex] ADD CONSTRAINT [FK_dbo.ObservationResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[ObservationResIndex] ADD CONSTRAINT [FK_dbo.ObservationResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[ObservationResIndex] ADD CONSTRAINT [FK_dbo.ObservationResIndex_dbo.ObservationRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[ObservationRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[OperationDefinitionResIndex] ADD CONSTRAINT [FK_dbo.OperationDefinitionResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[OperationDefinitionResIndex] ADD CONSTRAINT [FK_dbo.OperationDefinitionResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[OperationDefinitionResIndex] ADD CONSTRAINT [FK_dbo.OperationDefinitionResIndex_dbo.OperationDefinitionRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[OperationDefinitionRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[OperationOutcomeResIndex] ADD CONSTRAINT [FK_dbo.OperationOutcomeResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[OperationOutcomeResIndex] ADD CONSTRAINT [FK_dbo.OperationOutcomeResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[OperationOutcomeResIndex] ADD CONSTRAINT [FK_dbo.OperationOutcomeResIndex_dbo.OperationOutcomeRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[OperationOutcomeRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[OrganizationResIndex] ADD CONSTRAINT [FK_dbo.OrganizationResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[OrganizationResIndex] ADD CONSTRAINT [FK_dbo.OrganizationResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[OrganizationResIndex] ADD CONSTRAINT [FK_dbo.OrganizationResIndex_dbo.OrganizationRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[OrganizationRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[ParametersResIndex] ADD CONSTRAINT [FK_dbo.ParametersResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[ParametersResIndex] ADD CONSTRAINT [FK_dbo.ParametersResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[ParametersResIndex] ADD CONSTRAINT [FK_dbo.ParametersResIndex_dbo.ParametersRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[ParametersRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[PatientResIndex] ADD CONSTRAINT [FK_dbo.PatientResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[PatientResIndex] ADD CONSTRAINT [FK_dbo.PatientResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[PatientResIndex] ADD CONSTRAINT [FK_dbo.PatientResIndex_dbo.PatientRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[PatientRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[PaymentNoticeResIndex] ADD CONSTRAINT [FK_dbo.PaymentNoticeResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[PaymentNoticeResIndex] ADD CONSTRAINT [FK_dbo.PaymentNoticeResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[PaymentNoticeResIndex] ADD CONSTRAINT [FK_dbo.PaymentNoticeResIndex_dbo.PaymentNoticeRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[PaymentNoticeRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[PaymentReconciliationResIndex] ADD CONSTRAINT [FK_dbo.PaymentReconciliationResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[PaymentReconciliationResIndex] ADD CONSTRAINT [FK_dbo.PaymentReconciliationResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[PaymentReconciliationResIndex] ADD CONSTRAINT [FK_dbo.PaymentReconciliationResIndex_dbo.PaymentReconciliationRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[PaymentReconciliationRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[PersonResIndex] ADD CONSTRAINT [FK_dbo.PersonResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[PersonResIndex] ADD CONSTRAINT [FK_dbo.PersonResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[PersonResIndex] ADD CONSTRAINT [FK_dbo.PersonResIndex_dbo.PersonRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[PersonRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[PlanDefinitionResIndex] ADD CONSTRAINT [FK_dbo.PlanDefinitionResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[PlanDefinitionResIndex] ADD CONSTRAINT [FK_dbo.PlanDefinitionResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[PlanDefinitionResIndex] ADD CONSTRAINT [FK_dbo.PlanDefinitionResIndex_dbo.PlanDefinitionRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[PlanDefinitionRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[PractitionerResIndex] ADD CONSTRAINT [FK_dbo.PractitionerResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[PractitionerResIndex] ADD CONSTRAINT [FK_dbo.PractitionerResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[PractitionerResIndex] ADD CONSTRAINT [FK_dbo.PractitionerResIndex_dbo.PractitionerRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[PractitionerRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[PractitionerRoleResIndex] ADD CONSTRAINT [FK_dbo.PractitionerRoleResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[PractitionerRoleResIndex] ADD CONSTRAINT [FK_dbo.PractitionerRoleResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[PractitionerRoleResIndex] ADD CONSTRAINT [FK_dbo.PractitionerRoleResIndex_dbo.PractitionerRoleRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[PractitionerRoleRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[ProcedureResIndex] ADD CONSTRAINT [FK_dbo.ProcedureResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[ProcedureResIndex] ADD CONSTRAINT [FK_dbo.ProcedureResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[ProcedureResIndex] ADD CONSTRAINT [FK_dbo.ProcedureResIndex_dbo.ProcedureRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[ProcedureRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[ProcedureRequestResIndex] ADD CONSTRAINT [FK_dbo.ProcedureRequestResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[ProcedureRequestResIndex] ADD CONSTRAINT [FK_dbo.ProcedureRequestResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[ProcedureRequestResIndex] ADD CONSTRAINT [FK_dbo.ProcedureRequestResIndex_dbo.ProcedureRequestRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[ProcedureRequestRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[ProcessRequestResIndex] ADD CONSTRAINT [FK_dbo.ProcessRequestResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[ProcessRequestResIndex] ADD CONSTRAINT [FK_dbo.ProcessRequestResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[ProcessRequestResIndex] ADD CONSTRAINT [FK_dbo.ProcessRequestResIndex_dbo.ProcessRequestRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[ProcessRequestRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[ProcessResponseResIndex] ADD CONSTRAINT [FK_dbo.ProcessResponseResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[ProcessResponseResIndex] ADD CONSTRAINT [FK_dbo.ProcessResponseResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[ProcessResponseResIndex] ADD CONSTRAINT [FK_dbo.ProcessResponseResIndex_dbo.ProcessResponseRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[ProcessResponseRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[ProvenanceResIndex] ADD CONSTRAINT [FK_dbo.ProvenanceResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[ProvenanceResIndex] ADD CONSTRAINT [FK_dbo.ProvenanceResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[ProvenanceResIndex] ADD CONSTRAINT [FK_dbo.ProvenanceResIndex_dbo.ProvenanceRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[ProvenanceRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[QuestionnaireResIndex] ADD CONSTRAINT [FK_dbo.QuestionnaireResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[QuestionnaireResIndex] ADD CONSTRAINT [FK_dbo.QuestionnaireResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[QuestionnaireResIndex] ADD CONSTRAINT [FK_dbo.QuestionnaireResIndex_dbo.QuestionnaireRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[QuestionnaireRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[QuestionnaireResponseResIndex] ADD CONSTRAINT [FK_dbo.QuestionnaireResponseResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[QuestionnaireResponseResIndex] ADD CONSTRAINT [FK_dbo.QuestionnaireResponseResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[QuestionnaireResponseResIndex] ADD CONSTRAINT [FK_dbo.QuestionnaireResponseResIndex_dbo.QuestionnaireResponseRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[QuestionnaireResponseRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[ReferralRequestResIndex] ADD CONSTRAINT [FK_dbo.ReferralRequestResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[ReferralRequestResIndex] ADD CONSTRAINT [FK_dbo.ReferralRequestResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[ReferralRequestResIndex] ADD CONSTRAINT [FK_dbo.ReferralRequestResIndex_dbo.ReferralRequestRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[ReferralRequestRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[RelatedPersonResIndex] ADD CONSTRAINT [FK_dbo.RelatedPersonResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[RelatedPersonResIndex] ADD CONSTRAINT [FK_dbo.RelatedPersonResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[RelatedPersonResIndex] ADD CONSTRAINT [FK_dbo.RelatedPersonResIndex_dbo.RelatedPersonRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[RelatedPersonRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[RequestGroupResIndex] ADD CONSTRAINT [FK_dbo.RequestGroupResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[RequestGroupResIndex] ADD CONSTRAINT [FK_dbo.RequestGroupResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[RequestGroupResIndex] ADD CONSTRAINT [FK_dbo.RequestGroupResIndex_dbo.RequestGroupRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[RequestGroupRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[ResearchStudyResIndex] ADD CONSTRAINT [FK_dbo.ResearchStudyResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[ResearchStudyResIndex] ADD CONSTRAINT [FK_dbo.ResearchStudyResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[ResearchStudyResIndex] ADD CONSTRAINT [FK_dbo.ResearchStudyResIndex_dbo.ResearchStudyRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[ResearchStudyRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[ResearchSubjectResIndex] ADD CONSTRAINT [FK_dbo.ResearchSubjectResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[ResearchSubjectResIndex] ADD CONSTRAINT [FK_dbo.ResearchSubjectResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[ResearchSubjectResIndex] ADD CONSTRAINT [FK_dbo.ResearchSubjectResIndex_dbo.ResearchSubjectRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[ResearchSubjectRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[RiskAssessmentResIndex] ADD CONSTRAINT [FK_dbo.RiskAssessmentResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[RiskAssessmentResIndex] ADD CONSTRAINT [FK_dbo.RiskAssessmentResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[RiskAssessmentResIndex] ADD CONSTRAINT [FK_dbo.RiskAssessmentResIndex_dbo.RiskAssessmentRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[RiskAssessmentRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[ScheduleResIndex] ADD CONSTRAINT [FK_dbo.ScheduleResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[ScheduleResIndex] ADD CONSTRAINT [FK_dbo.ScheduleResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[ScheduleResIndex] ADD CONSTRAINT [FK_dbo.ScheduleResIndex_dbo.ScheduleRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[ScheduleRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[SearchParameterResIndex] ADD CONSTRAINT [FK_dbo.SearchParameterResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[SearchParameterResIndex] ADD CONSTRAINT [FK_dbo.SearchParameterResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[SearchParameterResIndex] ADD CONSTRAINT [FK_dbo.SearchParameterResIndex_dbo.SearchParameterRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[SearchParameterRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[SequenceResIndex] ADD CONSTRAINT [FK_dbo.SequenceResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[SequenceResIndex] ADD CONSTRAINT [FK_dbo.SequenceResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[SequenceResIndex] ADD CONSTRAINT [FK_dbo.SequenceResIndex_dbo.SequenceRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[SequenceRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[ServiceDefinitionResIndex] ADD CONSTRAINT [FK_dbo.ServiceDefinitionResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[ServiceDefinitionResIndex] ADD CONSTRAINT [FK_dbo.ServiceDefinitionResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[ServiceDefinitionResIndex] ADD CONSTRAINT [FK_dbo.ServiceDefinitionResIndex_dbo.ServiceDefinitionRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[ServiceDefinitionRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[SlotResIndex] ADD CONSTRAINT [FK_dbo.SlotResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[SlotResIndex] ADD CONSTRAINT [FK_dbo.SlotResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[SlotResIndex] ADD CONSTRAINT [FK_dbo.SlotResIndex_dbo.SlotRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[SlotRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[SpecimenResIndex] ADD CONSTRAINT [FK_dbo.SpecimenResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[SpecimenResIndex] ADD CONSTRAINT [FK_dbo.SpecimenResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[SpecimenResIndex] ADD CONSTRAINT [FK_dbo.SpecimenResIndex_dbo.SpecimenRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[SpecimenRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[StructureDefinitionResIndex] ADD CONSTRAINT [FK_dbo.StructureDefinitionResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[StructureDefinitionResIndex] ADD CONSTRAINT [FK_dbo.StructureDefinitionResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[StructureDefinitionResIndex] ADD CONSTRAINT [FK_dbo.StructureDefinitionResIndex_dbo.StructureDefinitionRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[StructureDefinitionRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[StructureMapResIndex] ADD CONSTRAINT [FK_dbo.StructureMapResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[StructureMapResIndex] ADD CONSTRAINT [FK_dbo.StructureMapResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[StructureMapResIndex] ADD CONSTRAINT [FK_dbo.StructureMapResIndex_dbo.StructureMapRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[StructureMapRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[SubscriptionResIndex] ADD CONSTRAINT [FK_dbo.SubscriptionResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[SubscriptionResIndex] ADD CONSTRAINT [FK_dbo.SubscriptionResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[SubscriptionResIndex] ADD CONSTRAINT [FK_dbo.SubscriptionResIndex_dbo.SubscriptionRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[SubscriptionRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[SubstanceResIndex] ADD CONSTRAINT [FK_dbo.SubstanceResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[SubstanceResIndex] ADD CONSTRAINT [FK_dbo.SubstanceResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[SubstanceResIndex] ADD CONSTRAINT [FK_dbo.SubstanceResIndex_dbo.SubstanceRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[SubstanceRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[SupplyDeliveryResIndex] ADD CONSTRAINT [FK_dbo.SupplyDeliveryResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[SupplyDeliveryResIndex] ADD CONSTRAINT [FK_dbo.SupplyDeliveryResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[SupplyDeliveryResIndex] ADD CONSTRAINT [FK_dbo.SupplyDeliveryResIndex_dbo.SupplyDeliveryRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[SupplyDeliveryRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[SupplyRequestResIndex] ADD CONSTRAINT [FK_dbo.SupplyRequestResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[SupplyRequestResIndex] ADD CONSTRAINT [FK_dbo.SupplyRequestResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[SupplyRequestResIndex] ADD CONSTRAINT [FK_dbo.SupplyRequestResIndex_dbo.SupplyRequestRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[SupplyRequestRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[TaskResIndex] ADD CONSTRAINT [FK_dbo.TaskResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[TaskResIndex] ADD CONSTRAINT [FK_dbo.TaskResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[TaskResIndex] ADD CONSTRAINT [FK_dbo.TaskResIndex_dbo.TaskRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[TaskRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[TestReportResIndex] ADD CONSTRAINT [FK_dbo.TestReportResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[TestReportResIndex] ADD CONSTRAINT [FK_dbo.TestReportResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[TestReportResIndex] ADD CONSTRAINT [FK_dbo.TestReportResIndex_dbo.TestReportRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[TestReportRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[TestScriptResIndex] ADD CONSTRAINT [FK_dbo.TestScriptResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[TestScriptResIndex] ADD CONSTRAINT [FK_dbo.TestScriptResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[TestScriptResIndex] ADD CONSTRAINT [FK_dbo.TestScriptResIndex_dbo.TestScriptRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[TestScriptRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[ValueSetResIndex] ADD CONSTRAINT [FK_dbo.ValueSetResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[ValueSetResIndex] ADD CONSTRAINT [FK_dbo.ValueSetResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[ValueSetResIndex] ADD CONSTRAINT [FK_dbo.ValueSetResIndex_dbo.ValueSetRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[ValueSetRes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[VisionPrescriptionResIndex] ADD CONSTRAINT [FK_dbo.VisionPrescriptionResIndex_dbo.ServiceBaseUrl_ReferenceServiceBaseUrlId] FOREIGN KEY ([ReferenceServiceBaseUrlId]) REFERENCES [dbo].[ServiceBaseUrl] ([Id])
ALTER TABLE [dbo].[VisionPrescriptionResIndex] ADD CONSTRAINT [FK_dbo.VisionPrescriptionResIndex_dbo.ServiceSearchParameter_ServiceSearchParameterId] FOREIGN KEY ([ServiceSearchParameterId]) REFERENCES [dbo].[ServiceSearchParameter] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[VisionPrescriptionResIndex] ADD CONSTRAINT [FK_dbo.VisionPrescriptionResIndex_dbo.VisionPrescriptionRes_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[VisionPrescriptionRes] ([Id]) ON DELETE CASCADE
INSERT [dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])
VALUES (N'201706130247261_First', N'Pyro.DataLayer.Migrations.Configuration',  0x1F8B0800000000000400ECBDDDAE1B5792267A7F80F30E822ECFF45876B9AA6C17EC337049B22D8C557279DB8DB96BA4C8DC5BD9E6266926A9F6AE573B17E791E61526F99F992B7E57AE1F6622D040A12D46C48A8815F1F1E3476EF27FFF7FFFFFD7FFE38FC7C5B38FE5A6AE56CB6F9E7FF6C9A7CF9F95CBD96A5E2D1FBE79BEDBDEFFF72F9FFF8FFFF7FFFEBFBE7E3D7FFCE3D9BF9FED3EDFDB359ECBFA9BE71FB6DBF5DF5EBCA8671FCAC7A2FEE4B19A6D56F5EA7EFBC96CF5F8A298AF5EFCE9D34FBF7AF1D9672FCA26C4F326D6B3675FFFBC5B6EABC7F2F01FCD7FBE5C2D67E57ABB2B166F57F372519FFEBD79E4EE10F5D93F8AC7B25E17B3F29BE73F3D6D569FBC2AB6C58FC553B9F9E4D5FB83CBE15FDE1775D984DA967F6C9F3FFB7651154D7677E5E2FEF9B362B95C6D8B6D93FBDF7EADCBBBED66B57CB85B37FF502C7E795A978DDD7DB1A8CB534D7FBB9A4BCBFBF44FFBF25E5C1DCFA166BB7ABB7A5406FCECF353BF5EF4DDBDBAFEFCD2CFA6A3AF9BCE6F9FF6551FBAFACDF36F67B355731D3F97F5F367FDE3FEF672B1D99BA26D3F46FBBE5C969B625BCE3FB906FBB7675D977FBB4C4F3364FBFFFBB7672F778BED6E537EB32C77DB4DB1683C76EF17D5EC7F964FBFAC7E2B97DF2C778B453BF726FBE6B1CE3F34FFF4D366B52E37DBA79FCBFB53456FE6CF9FBDE8FABDE83B5EDC5A3EC74ADF2CB79FFFE9F9B37F348717EF17E565345A5DB9DBAE36E5A5E89F8AEDB6DC2CF731CA433B9CD3FB67D52F779B4D637B3EF2EFABD5A22C96C0A174A0EF3E549B6BE2CD58375BFBFCD9DBE28F1FCBE5C3F643B3CF7FFAF2F9B3EFAA3FCAF9F95F4E717F5D56CD92374EDBCDAE549FFBA67E552ECAA6F4A1059C4622470D3F16F5F6D7F5BC6855D1CC6AF94B034BEFEEEFEBB2B99C9F36E5AC3A019E3AFEFF7A5CFC7DB17A4F14D6FCBF310A7B5B6E3FACAE0D6DF0EF931F7EF9E5A7A6D5EFF958FF283E560F8721EF5FF9725EFEF16355376DF9B95C1C2CEA0FD5FA74C075EDFFA365F8DD66F5F8F36AD1C198EBE3FF71B7DA6D664D0ABFAC08A35F8ACDC3FE2EDA797EFDE20A6242683B040C8A6F87880672E85977E5E663352BEFCA6233FBF053B169FEB109C067C0443DAD11BA547FFECBA7A2A5A28FE922C18FABFF92418426E80FD5C38710517FDD54D1DBF172F5B86E6EB019880EACFC73571C46A1FD301DE8EC7129BCA9F3B158742ADEC3FDDDACD88FC4677F66E7E1A9DE968F44033EFF344C03E6257148902637C6DB04859CAFAA3D7F036FB333CA616EB4935DCC5B650E0A76B329CE699E1CCA8656CECA60BC50785EF37478782EDF9F97ACC890DC5178E4E939EDEFCDEBCC5F370BE7B98C8B726C92FA2910E56497BC9A64185A76602BFFD17580E8996B47D034C018A26B7409F5297C285679CE806495E79AA469C26446D473CC15EF3EECC1DE03E23688407707DE9B3F7FD28D63AC197FAAD87779309B53BF9CDFDF4F73053F6D9AE7EECD5393C4CFAB95529DD0CE94B3100367AB17CF660C3DEB8AB9439FA99573B6FFDFE48786D928E6955D59CF36D5FA28D00ED67BE8B33A1C6BFF84D31AFCE3635AA1AA19208A9A8649FBF51FEB4D59D7613AA4C6B7C333E470B9F2AE59C05DDDE9FE11330E7B797E34BC10A94DB30B852EF18CC69491934FD01BFE7894B01D594FFB7509AA5D92BCC98D70E56D2A4787BEE9BC43B0B8DE51DD93423FFF76A3DBB331B132317452F015F97EDABB0F78BFF454BC204AB45FFDD77D7EDBE9F936C3B6FAD8FCD3ABF2BE5A56FBF243BD990AC4B555C2CFB2F755ED7DD589BDAF0A2000268691A6807C44DB0F7CE315081EEE3D582CB861237A96BD1D6B6FC7DADBB1F676ACBD1D6B6FC7DADBB165A6B76331E242BC332B7291B1BBF8EFD70663ABEEBBB832761BE50D5DB49592F77695CE9A9B8CF18EEFB7F3FD1B81E5EB8F65B08F8477231A47C7CF32FDC2F48B69E917DDDD479E0B3023170B51CB9098174CA700C21AFAA1679942610A852914A6509842610A85291499140A80B2E0DA0467CCF1B7E87AC430F6E968102C4F8DA13E402D13E80E7237D92D45D11A168B72F3F0D44C7573EEA638E24208E20DC535E68D9F65BA83E90ED3D21D200440F09F3675D191B10F8F88C1F40834B861237A96A912A64A982A61AA84A912A64A982A91499540890BAE4DC85C64EC2EBA4E118EAD3A9A8590DDC6502EF0560AF40BADB3E626A36819EBF5AA5A6E1FC37D6CA213D0183A7E96A917A65E4C4BBDE8AC3EF24480D8B83888190684BB600A851BD5800F3DCBA40993264C9A3069C2A40993264C9AC8244DB88C05D724185B86BA45572186B04E4777E0E8690CC10168974069107B89EE27BEB6B06E8A0EF5410930B0516EFC2CD31A4C6B98B0D670860009FABBB60C40020E1160318E16D1896E00899E659A846912A6499826619A846912A649DC8226D1612E426D02F71152BCB45AC540D64A6B1704CD8DAE6174DBA9D53224DEAAFB8CA26DECE6D536E4B74DB4E31951C7CF3225C3948C692919EDCD479E0A6013170411BB7048174CA570821AE6A167993861E2848913264E983861E284891399C40987B0E09A046D4AB3B6E80A843FDB74F4068695C69019DC5609D405A993E466626809CD1254B33032C23994B169FC2C53104C41989482705E7A18CEDD471D9C034C82005A28B5A013CFA00D3DCB8402130A4C2830A1C08402130A4C28C8231474B80AAA11E05628398BAD0CA859645F0F2088660429A0DB165E0590D833BD8FF2DABF5A169BA7402FFECFB18C22E367D9AB7F7BF53FAD57FFE7AD4780DB7DD88539C0260CAA0553003A010DDFD0B34C023009C0240093004C023009C024804C124087ACE01A006E8633B4E82A809E4D3A3A00C138630801DDD60894008903770351B480D5FCE9AEDA06FA92845634E3CBF859A607981E302D3DE0BAF7088643062EDE8156A1F02D982ED00B6948879E65CA802903A60C983260CA802903A60C6452067A7405D70628438AAB45D707FCD8A5A311901C34864AD06F91402790B9F0B711452BD82DE78B504AC13996B167FC2CD3094C2798964E70DE7A04C7DD875DA4036CC2A05A307DA013D0F00D3DCBD40153074C1D3075C0D40153074C1DC8A40E74C80AAE0DE06638438BAE0BE8D9A4A309108C338622D06D8D400F9038703710430B7859AC8BF7D5A2F9C7BB860C96E17ECB110E6C2C1A3FCB5402530926A512C01000833C67EB6023EB10011643290B44740348F42C93194C663099C1640693194C663099218FCC403017547390FA08295E6C3522286BEDEB14629A1B41B4A0DAC92B187A6FD57DC6D13636E54F8B62194AD0B84433928E9F652A86A9181353312E7B8F3D09000600F84156A1F02D9C32D10D6948879E657284C9112647981C617284C9112647E49223BA7485D02008438AABC5571BBCD8A5AB2B501C348A98D06B91444110B9F0B7114B2BF8A52C1EC36905A768C6A0F1B34C2B30AD60725AC169EF7134770C40C473AD42E15B48ADA01DD2900E3DCBB402D30A4C2B30ADC0B402D30A4C2BC8A715B4E90AA915A08614574BA11578B04B482BC0396824ADA0D32299562070E16F238A56F061EFFDA641E6406A413B9EB168FC2CD30B4C2F98965ED0DE7C04D3611317F910BB7048174C3770821AE6A167997260CA812907A61C987260CA81290799940387B0E0DA016D4AB3B6E8FA813FDB7434048695C65011DC56097404A993E466A268098BA20A25239C42199BC6CF3205C11484692908A7A547E0DC79D4C539D72408A005530BDAF10CDAD0B34C2830A1C08402130A4C2830A1C084824C42419BABE01A016A8592B3E8CA8096453A7A004E346348019DB6085400813DD3FB98AFFDD74D71817E8EA11FD208337E966901A6054C520B382F3F8DE6AE150A81806950E00BAD1574E21A04A2679966609A816906A6199866609A8169067935830E6761B503DC9A2571A9B4046F168A690B04618DA83174DB26D71A247EC2BB8AA33D54CD7A158B378FEB4D59EF9734940001C4350A8E9F652A84A9101353210004C09E044853001E69FBF088184E99C0821B36A267993C61F284C913264F983C61F284C913B9E4098CB8101A85C845C6EEE2AB15C1D8AAAB5BC8D86D14F1026DA544C1503A6B6E328A96D1ACE111F3036918ED78C6CFF1B34CBB30ED625ADA457BF3916701D8C4C540C42E1CD205D3269CA08679E859A6499826619A846912A6499826619A44264DC2212CB816419BD2AC2DBAF6E0CF361DAD8161A5313406B755026D41EA24B999385AC2E3E36E2F5E6CC37D24A217D2D8357E96290AA6284C4C51E82E3F06F398158083A86950E00BA72E00710D02D1B34C603081C1040613184C603081C104865C0203C059088D81B366495C7CA561200B75F50696B046911CA0B6495407B99FF0AE12680FBFEFCA7A1B45823847361A8E9F654A842911535622CE18207A2A708D3998043C6260632495A213DE50123DCBC40A132B4CAC30B1C2C40A132B4CACB809B1A2435DA49A05EE24E57989158CA1EC95D13308BE1B5FD6E8B654AD6E48DC75B71A49EB689E80B68F0DCF7C55DE570D7886FCBC0518DA783C7E96A91DA6764C4DED0041007DC260AC21C4E45CA2006440C5038F6F50899E659287491E267998E4619287491E267964933C70EE42691E422F31D94BA07A8465B180EE2125BE71840FA2AD22E543EDAFBCDB58DAC7AA0EAC785C031A79C7CF329DC3748EC9E91CD7D5C79F17201B100A41C380701752BFE84535E043CF32D5C2540B532D4CB530D5C2540B532DF2A9163DC6426A15942D43DD52E812DEAC13D220487A1A4979E8B74BA637C8BC44F713475B68EE7BBD7D5BAC43490BAD7846B0F1B34C5930656162CA426BF33188074D00F083EDC2215D3855A11FD4300F3DCB440513154C543051C1440513154C54C8252AF4090BA12990A6346B8BAF2878B34D574FA059691439C16995444D103A496E269296300FFA29856B3863D5F859A624989230352561CE69C59005847B905930900BA822CCED9309262298886022828908262298886022C28D8B0873E9E712284B92B0255010FC5826A01F5064348E7C30D77F1641E623B89348DA41DD10C060CAC129981169FC2CD30D4C37989A6E705A7B14CF9DC721B8738D02415B40BDA01DD1400E3DCBD402530B4C2D30B5C0D402530B4C2DC8A616B4D90AA515A076044D4BA013E85925A011E0D4338E42D0698F481F1078B0F710491B6848EB2C9C38708E66C4193FCBD4015307A6A60E9CF71E0572D700023CC02A14BE0554083A210DE9D0B34C223089C0240293084C223089C024826C124187AE501A016E4871B5042A810FBB0474028283C6110ABA2D1229051217FE36E268051F1B1EF85086D20A2ED18C41E3679956605AC1C4B482CBDE63680E180088075985C2B7705A4137A4211D7A966905A6159856605A816905A6159856904B2BE8D215422B200C29AE165F2BF06297AE564071D0285A41AF4512AD40E4C2DF460CAD60CF705F2FCAC7607F77D00D683C1A3FCB1403530C26A51874571F8675CCC6413FD43020DC85520F80A8067CE859262098806002820908262098806002421E0101602CA886C0D932D42DB692308875F6F504969E469014A076F1AA82DC4B743F51B48526C4AC61886FEA7A17E8C308FD9046B3F1B34C5F307D615AFA426FF911AC47AD5C20C44D83025F309D018A6B10889E654A83290DA63498D2604A83290DA63464521A20CE826B0DAC354BE2A2EB0D4359A8A339F0843586EA00B64DA03B28FC847715477BD8870C253A9C6219D5C6CF32B5C1D48689A90DA7ADC700DE7918803BD7260CAA855314DA010DDFD0B34C4A3029C1A40493124C4A3029C1A4845C52429BAC101A026A8633B4F8AA819A4DBA3A01CE38A308049DD648940181037703F1B480FD13C16A19EEEF1C9CA0C69EF1B34C1D30756082EA407BFD296087ED102C448C0343605805C1896C60889E65528249092625989460528249092625E494121CD6C2680AB4BD80CEA5511906B252587760286C3401C26D9F5489907A8AEF2D9E36D1BC82D954B390C2C425A21171FC2C53254C9598A02A71D97D0AFC0123040821CB9098175689E88635F443CF3219C2640893214C863019C26408932172CA105DCAC268108431C7DFD2A80FDEEC13D61D289E1A4D74E8B54CAA3888DC64B714F36F227EDF9575D04F415C431ADFC6CF32B5C1D48609AA0DD7E5A73FDAE65AA19F05034C83025FE8BF9EE8C4350844CF32C9C12407931C4C7230C9C12407931C724A0E3DCEC2FE2D056ECD92B8547F59E1CD42B1BFB320086BC43FB7E8B64DFE5717123FE15DC5D31E7EADCBBB864A86FCB90928AE5170FC2C53214C8598A00AD14300EA49003545E011B70F8F8861950928B861237A96C913264F983C61F284C913264F983C91539E80880BA351B02E32769746AD08C25661DD8267B7D1C40BB095520543E1ACB9C9285A46553C2C57F576FF718DF56A134AC970A31A57C7CF321DC3748C69E918EEFE23CF0B94A18B8DA475681C0CA65F20A10D11D1B34CBD30F5C2D40B532F4CBD30F5C2D48B4CEA05425B70ED42E220E174D1758B30ECD4D12C445C36866281B550A057E85CE5B71745AB58CD767B41E46DB1ACEEC3FDD9871BD598397E966915A6554C4BAB70F71F7936A00C5D6424AD43E36030AD02096D88889E655A856915A6559856615A856915A65564D22A10DA826B15120709A78BAE558461A78E5621E2B231B40AAC8502AD42E72ABFBD985A451B3A02F2F37658E3E6F859A656985A3149B5A20D00F413026C89A223621E1C0C432B164E6C8345F42C932C4CB230C9C2240B932C4CB230C922AF64E1F01656B3A03D44C42E956A3198A562BA05436A230A176E1BE5CA85D457718731B48BD78BEAA17A5F2DAA3DA70DF8059B605CA3E9F859A65E987A3129F5024400F8898131752092B30F8F88A1140C3CB861237A964918266198846112864918266198849147C2C0890BAA61085D64EC2EB68A1190ADF6750C29BB8D206410ADE4950CB5B3E626A36B19F5BAE944A04F62C0818DB1E367999A616AC674D58C0B04089E20005B1A27218708B01845D1E846378044CF3249C3240D93344CD23049C3240D93346E40D2E8321799A641F808295E525563286B25750D8AE6C616367AED542A1B226FD57D46D13696B3D56ED98409A468B4C2194DC7CF321DC3748C69E918ADC5479E07400B170061B36020174C9FE8C734B843CF3255C2540953254C953055C25409532532A9127DBE826B11A42549D8A2EB0EBE2CD3D11868321A435970DA24D013843E823B89A31DCCD7AB2AD42F97B6A21995C6CF32E5C0948389290797BDC7201D3000200FB20A856FE154836E48433AF42C130D4C3430D1C04403130D4C3430D1209768D0A52B84664018525C2DBE62E0C52E5DBD80E2A051E4825E8B246A81C885BF8D385AC166B5581CBF7F22E4D74100618D53E367997A60EAC1C4D403170030A0A72C015424CD838361388501896DB0889E655283490D263598D4605283490D2635E4921A10DE42680E120F11B18BAF420462A9AE2E2122B551040AAC8D12A542E7ABB8C3D8DA45D0AF7F80E21A4DC7CF32F5C2D48BC9AA17DC9FD1D1A6244486FFEA0728780C05C3BEF8C1240C93304CC23009C3240C93304CC2188D8421FDDE07998B8CDDA5543106B2554AC748FD950F782B754A86E7173EA8230C63EEEBAA6E36F1DDFDCB62134AC6E88534968E9F650A862918D352307ACB8F3C1DA0562E1EE2A641812F985A01C5350844CF32A1C2840A132A4CA830A1C2840A132A3209151067C1350AD69A2571D19589A12CD4D12378C21A438A00DB265021147EC2BB8AA23DFCB12E96F5B143F7D52294FCE04635FA8D9F650A842910D35220DCFD47E09F32746191B40E8D83C1D40824B421227A9609122648982061828409122648982091499040680BAE49481C249C2EBA3211869D3AFA8488CBC69028B0160A540A9DABFCF62269158B6279A8FEDDFDDF1B72795F85FACA0A38B23174FC2CD32C4CB3989A66016100FACC401B4348C978C4C0C6801A061ADE50123DCB740CD3314CC7301DC3740CD3314CC7C8A663A0D485D232644E529E9740D308C95E016D43C877E3E81B784B451A87D65D77AB31B48EEF8AC76AF1F4B67C7C5F36CF520D7BDF3C85913AE0C0C6E1F1B34CE930A563524A070C01F0530567EB2025EB10011643A91C44740348F42C13394CE43091C3440E13394CE43091238FC841301754E390FA08295E6C8523286BEDEB1B629A1B41DEA0DAC9AB1B7A6FD57D46D13616C5432031E318C9C8397E96A917A65E4C4BBD38EE3C02FCFD075DB0732C4260593005A215CE500D3DCB2407931C4C7230C9C12407931C4C72C82439B4A80AAE316046182F8BAE22E8D8A3A313A0FC328630D06E894009E0CDE9AEC778ADFFFDAA588479AD7F8A64AC183FCB5EEBDB6BFD49BDD63FED3C8CD6CE830EBAB91621B02CD46BFD76384335F42C7BAD6FAFF5EDB5BEBDD6B7D7FAF65ADF5EEBE779ADDFA62AE86B7DD408E365B15FEB2BD963FFB53ECE2F23BCD6EFB4847FAD2F30A7BB1EE5B5FEA6587F7855DE570D4C35D5057AD9EF0435AE8C9F650A802900D352009CF547E09CB0739190320E0C81C1D40238B281217A960907261C987060C2810907261C987090493880590BAE2108EC05742EBAB21082953A7A8384C2C6901E90F609540895A7F8DEE26813ABDD3A9422710C65D41B3FCB7408D32126A6431C971EC3F9FEA300D8392641002D9CBED08A67D0869E65AA82A90AA62A98AA60AA82A90AA62AE452155A5C85D012302B949CC5D70D942CD2D50850A219451968B745A207F0F64CEFA3BCF6DF55F3E2B8CEEBA6BE40BF71094435DA8C9F658A802902D35204DCFD47609D3274E190B40E8D83C1D40324B421227A9609092624989060428209092624989090494840680BAE29481C249C2EBAD210869D3AFA8388CBC69022B0160A54099DABFCF66268153F94C562FB61566CCEBB1446AC80C21A37C7CF32B5C2D48A49A9151000C04F08B4A5838E8C7970300CA558A0B10D16D1B34CB230C9C2240B932C4CB230C9C2248B3C9205CA5B50CD42E6212276B1558B602CB5AF5B08496D04E1026F23AF5C687D15771843BB78F3583C34DBFAB65856F765BD0DA35CB8418DA0E367996E61BAC5A4740B77FDE1E703CACE8145D238300486D22B90C80686E859A656985A616A85A915A656985A616A451EB502612DA85621B117D0B9D83A451056DAD728441436824281B58FD727749EE27B8BA84DDC6D77F3A7A0C2C439A21171FC2C53254C9598A22A71DE7D12FC5D230C0801CB9098175889E88435F443CF3219C2640893214C863019C264089321B2CA101DCAC26910B831C7DF12A90FBEEC13D11D089E1A4F74E8B64CAC3848DC64B714476B78DC2DAB7F15E17E04A317D1D8367E96690DA6354C4C6BE8EC3E86F688118082986548CC0BA735B8610DFDD0B34C6B30ADC1B406D31A4C6B30ADC1B4865C5A834B5908AD8131E6F85B7CAD6110FB74B5068EA746D11A809649B406B19BEC96E26B0DB3D5E363B99C47531E7AF18D89E367990E613AC48475881E12489E175017063D71BF78C81947BF800E310C45CF3235C3D40C53334CCD3035C3D40C53336E41CD80088C50DB605D752C30ADEE1194EDD29A08CF92A32B2460ABB57A892288CFCDC7D152D68BB239EAC85EF75FFB19E8DB37E1C0C6FCF1B34C3D31F56462EA090401D813096D0BE025E3100116C3292468740348F42C93464C1A3169C4A41193464C1A3169249734823217421391F908295E7C1524206B75750F21CD8D2278E0ED94281D5A6FD57DC6D0367EACDE6F8A4DA0AFBEB806338A8E9F651A86691893D230AE6B0F3F03408F3BC0071A0582B6509A442FA2811C7A96E910A643980E613A84E910A643980E914787E8B115547BA0EC089A165B63F062957D2D81A49E11F4837E7B78CD40E6C1DE431C6D60F95BF110E8B30ED760469BF1B34C1B306D6062DAC079ED3114771F07C00E300A046DE1B4814E440339F42CD3064C1B306DC0B401D3064C1B306D209736D0612B843680DB11342DBE36E0C12A5D6D80A09E51B4816E7B24DA80C483BD8738DA40A81FF23C4532C28C9F65AA80A902135305881F47721E04002EE88F739EC2855302EC67384D063019C0640093014C063019C064801B960104BFBD891A61BC2CFEAB7F157B745FF727FC11CD4E4B24AFF8F53F9729F119C68F57B380DF1CD98A66EC183FCB5EF3DB6BFE69BDE6BFEE3D82DC90818B76A055287C0BA601F4421AD2A167990E603A80E900A603980E603A80E9009974801E5DC1B500CA90E26AD135013F76E9680324078DA10FF45B24D008642EFC6DC4D00ADE9645DDB0D83052C13598F167FC2C530A4C29989452705D7B18CAA1C71DB4038D02415B2895A017D1400E3DCB440213094C243091C0440213094C24C82312F4D80AAA115076044D8BAD1078B1CABE3E4052CF08F240BF3DBC3A20F360EF21AA36B05E6D02FDF1403FA45168FC2CD3094C2798A64E705A7E06D71D2B1C045DD3A0C0175C3F68C7350844CF3215C1540453114C453015C15404531132AB086DCEC26B09A8354BE292E90ABE2C14D51870C21A5369E8B44DA13708FC847715477B98574528CDE118CA88367E96690DA6354C4C6B382E3D86EEFD4701A8734C82005A382DA115CFA00D3DCB3404D3104C43300DC13404D3104C43C8A521B4B80AA11D605628398BAF152859A4AB0DA044338A26D06E8B440BE0ED99DEC77AED1FF21B0C3AF18C2AE367990A602AC0E45400E6EFCC101310F6827F934127684865C0BECDC0E40193074C1E3079C0E40193074C1EB8797940F87D068C29CDDA52A8059E6C13D20D127FB301D02A9982E0F7ED0672CF400CFBDBF963B56C7AB889A22C38D18D73E36799CE603AC34475060707B8E701C281C04CCA2B165E86D727E0230C39D1B34CAD30B5C2D40A532B4CAD30B5C2D48ADC6A054C5F04DA85C051C3FDD2E91A41D92DAE7948387154050469B1460F5185D0DF765CADE45555AFCB651DEC6B2181B8C6F2F1B34C1F317D64A2FA480B01B8E70ED094404AD83E3C2286D741FAC10D1BD1B34C013105C4141053404C013105C41490DC0A489FB808B40FD245C6EED2E91D83D92AAE71D0EC36AABAE1B452A36B089D353719FB6F487EDF9575B0EFAF74C31A5BC7CF3225C3948C892A195700E03FEAE75A929F8703CC8383618CBF36E9C4365844CF3211C3440C13314CC43011C3440C1331728B183DDE22FADB13DC4344EC52FE25CA20964AFD5D0A416A23FF794AB78DBABF5291F82AEE30AE7671D7F0CDF2B12195A1D58B766023EAF859A65F987E3151FDA20D01DC73036C4BC024E2100116C3EB184E740348F42C53324CC93025C3940C53324CC9302523B792E13017819641FB08295E3A3D23006BC5350D86E6465535DC766A740DA9B7EA3EE3681B755D3C94AFCAFBAAC1CB2ADC1771B8618DB6E36799AE61BAC6C4740D1700B0E707CA120048D23C381886D33390D8068BE859A666989A616A86A919A666989A616A462E3503E12D849621F11011BBF83A462096EA6A1822521B45C1C0DA28D12F74BE8A3B8CA85DFC5016F3721354B7B88434728E9F659A85691653D42C2ECB4F3E130056181C42A641812FB046D18D6B10889E65FA84E913A64F983E61FA84E913A64F64D527BA9C85D326086B96C425D224FC5928A2455084359E0ED16B9B588310F909EF2A86F6D0FC6FB38847200F233DF4221AEDC6CF32E5C1948749290FBDDD87211F35726010B70C8979A1540728ACA11F7A96890E263A98E860A283890E263A98E890477480280BAA39B0C61C7F8BAD380C649F7DBD81E7A911E406B065BCDAA07093DD5214ADA121B8874F53BCDB04FBA08313D318377E96E90DA6374C4B6FE86F3F82F9B8998B86846D58F40BA63B80810D07D1B34C7930E5C19407531E4C7930E5C194874CCA03485A70ED8137E7995C74FD61381B75340801738DA142C0AD13E8101A47E98DC5D022DEBDAF9BA845B86F8AE80634F68D9F652A84A910935221BAAB0F833E66E360206A1810EE42290F4054033EF42C931D4C7630D9C16407931D4C7630D9218FEC0030165473E06C19EA165B6D18C43AFB3A034B4F23880C50BB788541EE25BA9F28DAC27ACF109B53427F1B251CD828377E96690DA6354C4B6B002100417FC6D60548CE21022C06D322F0E80690E859A6499826619A846912A6499826619A44264D02672EB83621F41152BCE85A4548D6EA6817529A1B43C320DA29D032D4DEAAFB8CAA6DBCDB6D67ABC732B0B0718D6AA41D3FCB540D5335A6A96A5CF79F7972800C717004AD43E3607025A317DA10113DCB640C93314CC63019C3640C93314CC6C82C63F4680BAF61500E124E974CBD18C64E51DD82E4B231458B7E0B158A85CC557E7B51B48ACD43B1ACFE15F28F3CBA118D91E3679946611AC5B4348AEEEE23CF0098918B84A86548CC0BA64900610DFDD0B34C8F303DC2F408D3234C8F303DC2F4884C7A044059702D8233E6F85B740D6218FB74B40796A7C6D01DA096093407B99BEC9662680D97307518A5A113CF98367E96E90CA6334C4A67E86C3E8CF38889837E985D38A40BA52FB8410DF3D0B34C5D3075C1D40553174C5D3075C1D4853CEA824B58506D8131A5595B6C5D6100DBEC6B0A1C2B8DA02800ADE2F504B193E466E26809DBAA6182A18484733063D4F859A622988A303115E1BCF618A8BB8F037807180582B670CA4127A2811C7A96C906261B986C60B281C906261B986C904B36E8B0154233C0ED089A165F2DF06095AE4E4050CF282241B73D128540E2C1DE431C6DE0E9B139E31FAB6D350BF4E50BFD9046A1F1B34C27309D60623A4177F9315CC7AC0010444D83025F38FD00886B10889E652A82A908A622988A602A82A908A622E4521100CE4268099C354BE2E2EB0A0359A8AB31B084358AD200B54DA237C8FD847715517BF8B99CAD96B36A5105FC62052CB41171FC2CD3224C8B98A216E18000F96C4058635049B94401C8C05A051CDFA0123DCB340BD32C4CB330CDC2340BD32C4CB3C8AA59C0DC85D32E045E62B29748CB08C762116D43427CE3691C485BC55A87CA5F79B751B48F66C383891DE75846D9F1B34CDD3075635AEAC679EB912702F76117F6009B30A8164CA1E804347C43CF3249C2240993244C923049C2240993243249121DB2826B10B819CED0A2AB0C7A36E9E80804E38C211C745B23500A240EDC0D44D1021645F7E7364310E77E4CE3CEF859A60D9836302D6DA0BFFD08AAE3662E0E12B661D12F98760006361C44CF320DC13404D3104C43300DC13404D3103269082069C1B504DE9C6772D1B585E16CD4D11A04CC3586E600B74EA03D681CA53716458BD814B3EDE19872134889E84634FE8D9F653A84E910D3D221BABB8FE03E66E4E2206A1912F382E90F4058433FF42C531F4C7D30F5C1D407531F4C7D30F52193FA0050165C7BE08C39FE165D7718C63E1DCD81E5A9311407A86502BD41EE26BBA5E85A43737404BDE118D558377E96690EA6394C577338EEBF00F9FB86342A3AD6A171308A06D10A6D88889E653A84E910A643980E613A84E910A643DC800ED1A22D322D02739070BAA49A843F3B25B50994CBC6D627DA2D546A14BCABFCF6E26815AB59396FF8702891E21ACEB8387E96A913A64E4C4C9DB82E3E06FC9005807EA05930900BA740F4621ADCA16799F460D283490F263D98F460D283490FB9A4871E5F213407CA92246CF155064F96E9EA0A24198D2228F4DB245112643E823B89AC1DFCBE2BEB6D7009E11CD5A8357E962909A6244C554938EF3F0BF5AE2105898075681C8CA03274421B22A26799D8606283890D263698D8606283890DD9C5860E6D91680EB88384D325542086B053428F20B86C5C59A2DB42953A217195DF5E34ADA2AEC32B15ED98C6CAF1B34CA7309D627A3A457BFB89E701D80C4644C4362CFA05D5279CC08683E859A64E983A61EA84A913A64E983A61EA444675C2212DB436419BF34C2E892E318C8D829A04C35C6329126EEB847A84D4517A6351B5887ADD541EF22F2F3A418D85E367991A616AC434D588CBFA334F00801D8E89907160080CAE4874231B18A267992461928449122649982461928449129925892E6BE13509C25E40E792A912435829AA4B501436A630D16B9F429910798AEF2D9236F1B15C1647A80843C7AFF18C84E3679922618AC4D41489EBE6A3B00F99400008DA8543BA80EA432FA8611E7A96090F263C98F060C283090F263C98F0904D78E811164A73A04C69D6964069F0659B80BE40B2D238D242BF55225541E624B999185AC23FF79FA4680A5D1655A8EF97EC8734768D9F658A82290A935214FACB0FC33C6EE5E020611A14F842A90B605C8340F42C13184C603081C1040613184C603081218FC00072165463E0AD5912175B6918CC42FB7A8380B046901CE0B6F1AA83C64F785729B487807F69818536228E9F655A84691193D622E8CFB7F1D62C5486FE0B0C2C7E2CADC2FE1AC3340BD32C4CB330CDC2340BD32C4CB318936621FB9B0CB99798ECA5D63206B3584EDB48FB171B745BF55A87D75F6F78051944ED0FF3D270E6A05F76E90635128F9F657A87E91D93D23BDCF5879F23283B071A49E3C010184AD740221B18A26799A2618A86291AA66898A2618A86291A79140D84B5A05A86C45E40E762EB174158695FB31051D8086A05D63E5EA7D0798AEF2D8E36B13890C8666557CB50CA4437A45171FC2CD3254C9798982ED15D7E0CFF312B000C51D3A0C0174E8F00E21A04A267991A616A84A911A646981A616A84A911B9D40880B3105A0467CD92B8F83AC44016EA6A102C618DA240406D93E80F723FE15DC5D11E0EFAC6F79BD56E1D4A7AE84434DA8D9F65CA83290F13531E3ABB8F413E6204C020661912F3C2A90E6E58433FF42C131D4C7430D1C14407131D4C7430D12197E8E052164273608C39FE165F7118C43E5DBD81E3A951E406A06512B541EC26BBA5385A437D0877B7DDCD9F42890DDD90C6B7F1B34C6D30B561626A4377F931C0C7AC0024444D83025F38C501886B10889E659283490E263998E4609283490E2639E4921C00CE42680E9C354BE2E2AB0E0359A8AB3BB084358AF000B54DA23CC8FD847715557BD8BDFFCF7216ECFB1FFA418D7CE36799FE60FAC334F587CBFA33D80FD8E19008190786C0E03A4437B281217A962911A6449812614A842911A6449812915989E8B2165E8B20EC05742E991E318495A29A04456163AA12BDF629740991A7F8DEA2681355FDDBB7755DD6F563C31E034913FD9846C6F1B34C993065625ACA447FFB91A700DCCC0544C2362CFA055325C0C08683E859264A982861A2848912264A982861A244265102242DB826C19BF34C2EBA22319C8D3A7A8480B9C69023E0D609D4088DA3F4C662681177B30FE57CB708F4B3A0AD68C6BBF1B34C7F30FD6152FA436BEF61AC070D1CDC83AD42E15B289DA11FD2900E3DCB140653184C613085C1140653184C61C8A330F4E90AAA2D908614578BAD2778B2CBBE864073D008EA81D3225E3710BAF0B711452BE8060B241938418D4FE367997260CAC1B4940367FD118827EC5C34A48C0343603055018E6C60889E65E282890B262E98B860E282890B262E64121760D6826B0C027B019D8BAE388460A58EFE20A1B0316408A47D023542E529BEB738DAC4EFBB13500421E3976846C0F1B34C8D303562626AC465EF31C0070C00E083AC42E15B38C5A11BD2900E3DCBA406931A4C6A30A9C1A406931A4C6AC8253574E90AA131108614578BAF2A78B14B5747A038681401A1D72289722072E16F238E567088F9AABCAF1A30AB0EBFB819844FBB618D53E367997A60EAC1C4D403170030A0A72C015424CD838361388501896DB0889E655283490D263598D4605283490D2635E4921A10DE42680E120F11B18BAF420462A9AE2E2122B551040AAC8D12A542E7ABB8C328DAC56215E81B234F918C8AE3679942610AC5B4148AE3CE2370DF7FD0853AC722049605531B5AE10CD5D0B34C603081C1040613184C603081C104864C02438BAAE09A026684F1B2E8CA818E3D3AFA00CA2F634802ED96085400DE9CEE7A94D7FAEB3D6697A13E9E708D66EC183FCB5EF3DB6BFE69BDE6BFEE3D82DC90818B76A055287C0BA601F4421AD2A167990E603A80E900A603980E603A80E9009974801E5DC1B500CA90E26AD135013F76E9680324078DA10FF45B24D008642EFC6D44D10A9A3D99ED796CF0BF6A00031BAFC6CF3205C1148469290820042070CFD8BAE8C8394480C5606A031EDD00123DCB8407131E4C7830E1C18407131E4C78C8243CE0CC05D720843E428A175D9908C95A1DBD424A73634817443B052A86DA5B759F51B58DB7C53AB0A8718C68641D3FCBD40C5333A6A9661C779F7942E81BE160E85886C4BCE08A452BACA11F7A964915265598546152854915265598549159AA6851165EA3C08C39FE964C95F0639FA80E81F2D4980244BB650AE5817793DD5214AD61F7BE9E6DAA75C00F5074231ADBC6CF32ADC1B48669690DDDDD47D01E33725110B50C8979C1B40620ACA11F7A96690DA63598D6605A83690DA63598D690496B00280BAE3570C61C7F8BAE350C639F8ED6C0F2D4185A03D43281D6207793DD522CAD615B84FBD1CA5638E3D9F859A63298CA303995E1BCF838C8BB1620F20166C1402EA4B2D0896970879E65B282C90A262B98AC60B282C90A262BE493153A7C85D414704B92B0A55013BC5826A4231064349288D06D934C4190F808EE248E76B05E2F9E9A1782D5C772F3144A40E8C5345A8D9F652A82A9081353117ADB8F813C6A0640216E1B16FDC2290B5060C341F42C93174C5E3079C1E40593174C5E30792197BC009116426360CD7926175F6D18CC465DDD8167AE51C407B075120542E128BDB1785AC4CFE5EFBBB20EF5E394BD90C6C0F1B34C89302562824AC475F929E887AC102C044D83025F5815A217D720103DCB440813214C843011C2440813214C84C82942F4380BA34150D62C894BA3400C60A1B0FE4012D668F243BF6D52F541E627BCAB18DAC32F45FD5B18C9E114C968367E96290DA6344C4A6938ED3C0CEDCE830ECCB91621B02C948AD00E67A8869E65E2818907261E987860E2818907261EE4110FDA5405D50C50238C97C5560894ECB1AF07E0FC32820CD06909FFEA5F604E773DCA6BFD8398B05E6D027DC8A013CF18327E96BDEEB7D7FDD37ADDDFDE7C04BF611317F510BB7048174C0F70821AE6A167992A60AA80A902A60A982A60AA80A90299540187B0E0DA006D4AB3B6E83A813FDB7434038695C6500EDC5609F403A993E46662690977876F790CA7255CE219AFC6CF322DC1B484C9690997CDC7D11D3001B10FB20B877421B5846E50C33CF42CD3124C4B302DC1B404D3124C4B302D219F96D0252CA4964098D2AC2D8596E0C936212D8162A591B4845EAB645A82C849723331B4847F2F16BB26622025A115CD38357E96E908A6234C4A4768ED3D8CEBA0818379B055287C0BA51FF4431AD2A167997A60EA81A907A61E987A60EA81A90779D4833E5D41B503D290E26AB175034F76D9D70C680E1A4131705AC4EB054217FE36A2680507286F30BDFD139321083514D758357E96E907A61F4C4B3F801000C17ADAD44546C63E3C2206D319D0E0868DE859A63898E2608A83290EA63898E2608A4326C501252EB8F6207391B1BBE87A4438B6EA681442761B43ADC05B29D02DB4CE9A9B0CA265EC1E5BBCFDFA82E64DFDDDA278A82F4B80B3F61F165F7CB247B84F8E6CFDEFBBE57C51FEB773A47F7B7679FCEE975F3FFFE465C362AFB4FCD34FBEFAFC933F4B78F9FC8B4FFFFAD5679FFDF9CB4FFFF2974FEF679FEF31635E6E164F0DC6B4D7B77BFF6FCBC7F7E5E654DCF7AF7F79FEEC20087DF3FC5367543AA63FBDBBBBDA7EC6D8FE7A357551A763FAEAF58FAF7F797DB1FEDCBDA3E36D103704D102EFBB3A07FB6F6ED41BBAB71FCBBAFEE5C35E05915DDEDEFEDDE6F5EFBB3DEF91DDE1F79BB2E1FC9BBE17739D27AF4E6E3E77DA5AE0E353B6F785F622DDD025FE63B7FF0FE915EE5F8149EFEECC336477762808BBADBEF1E5A9F2E2E0F2E58EC37E7F5675D54AFE2FB4C3F515D8C9FEAFB4FDE1E5E5C9F40B8F513B5EEC6188EE9A59DAD50386CD897543E3F66A53DC6FA5D3F6ED6C5B7D14CFDBCFE5B6DAECC54DD9C0FDBAFC6DB9FAAF6100D125F4DE17D60E734377F5ED6CB6DA2D75B7D5ACCCABF2BE6A5EC935E94A6FEEDBF9C7A6BEF2F5C7B2751A737DDF2E16E5E6E1A929A261639BA28D050C787CBB5EAFAAE5F6B17D18031F2D97E6AED60D0D1503C9B7BB79B5ED56C64049F3B2A99A6160E21857CB627345A92F19EBD5FCE9AE8D825F31F607CE78BD4666025E16EBE27DB56866608F3B65A7C39F3133F0B2D8943F2D5A4FD89F3103B077F8A52C1EAF0ECCBDBFFCB0E7DF6F0E3AD8D9857BDA581455CB9AB9EA83B5331F9F31D7FD72D16CCBAC58BC795C37AF25EACEDA3097BF1766CECADED9859980E689F071B73C3D3B5CBD9839E8789DBE69FEBAA8DC541CB8EB61790068F8133717A767EE8E0F371AAB060ED6DBB7C5FAEAC20DC76A39EF1DC2528AE696DB78C54DC76AD900F5ACE5C00DC6AA41C5E2E13A497F62C661FFF6CAEB4577EDFEC4CCC3ABE695E96C5BCEDFD4F5AE7512330FAFCAFDEBDB2BE072ACF1607EB8C9653BB9CF99BB3FFABD2D1B227905444041029CFA43FA3973FF47AF5FEBD245AECF99417855150FCB55BDAD66C7AF52B83A3213F16A35DBED4F7A5B2CABFB4EB2CC649C1D5D1AFC3937220D1FA99657B1E8ECC64CC9EB45F5501D91DD692C332A1DD71E34FE99999BD7CB030169BD3CF9333331AF97F3C333F5D5819996D7CBCD6AB13836B35BD89F9989697BF6EB6226E6F5BAAA1BE87E77BF7F0EBB7A31E3F2FA8F75B13C6A4EABFBAAF5B4FC67665C1AC7E689F580DDEFEEFF5E2E1B106E95C94CCC77C563B5783AFED30F5543685B6CE3CFCCD8ECE9F0D5981994EF57AD17F87F6126E3FB4DB1FE003C9BFC85D51356BBEB93C25F381D6157CD8BA36EDFE37CCC6CFC50168BED875973BB2729F0EAC98CC69BC7E2A161E80E24FC85198E93DFDD7637BFDECF5F98C178737856FF57970BFC851988B6D3CFE5AC6106E572DE0BC1CC4543758E4F5307B77D975B0D62C6E4C7EAFDA6CD78FFCA894ED5F2B7F693E85F9909390AE2676366407E5CF588D45F99C1785B16F5AEB5F37F65C6E164DF7B62F92B330C6FCB79555CAD9929D85BF7CB6066E0EAF2EDFCB1D9C1BA6136DD00CC045C03BCAAEA75D9DEADBF32037075ED23F617CC285C3DDD27F92F98B178DB50F3668C00C8F982999193670309F3D613D917CCA034FFBB5FE72EB9FF8299967FEC1AA67480F94DE72C665CDEBDAF1B94EA5EE017CCD0BC5B97C72B873AC24CCFC5F7DD6EDBE0C7F5EABF60A6E6DDE6A170F0EA0B665E2EEFBFD4D757C9DCBB0CCD09EDE1F8927BA7A178DA0FD33F56DB36D47FC90CC6C96B8FA1CB594390BA657DC90CC84F4D416D736634F62FAD81ABFA92198D9FF6AF580E2EAD79FA92998DB6D3FEBDB2AB2333180DB19995F3363E7EC94CC4C5A38F055F7253B177ACEBBEDB57DC649CDD7A84E02B6E4236CD8BB96547A5FA8A198F7FEE136B7AB82CAA5643BE62C6A2E3E5A6C94CC9E105C5A658386D61C6E4F0EE6C39EFCDE457CC9C9C4EE972B2AF9819696A3ABC97D2653A5F317372F1DABDFFCFB2F51AFC2B664C9C574A9F7DCA4CC8CF55FDDBB775DD0C4957FEFA947BB764F6A119E48ED8C60C88F3EEF6C5919991BB7DDF979DA298B938B15848D9FD94198DBBC5AADD056624EED6FBCF4595EDF8CC3CDC6D37BBD95E09079363C6E2E2DC968A3EFB94198A66882EEFF9B7F44D6630F65EDB0E027CC669A2C75F767C552EAA8F658BF27EC649A39D5F846CB93173B1FF4D8996353313D7EF8E6CF930C370FD8E88960F331207BBBBB2EDC18C84FBC98C966F6F22E0B7799A055ECD8E4FC8DDF742E0CF05757379BD9C3F3B7E448472BA7E9EE4FAD1C29EFDF3676F778B6DB55E54B36AFBF4CDF3FFC7295B78D4E5433BD7A3BA1FD1EA9FF4E9279FB8A3790AB9AD8AC55EFB6C287FB5DC764C9EED3FCC553564665D2C1479F5623C937D8C7B7F7797D3FA8FBC2A9B1715FB4F602B6E429206F1113737BB4B12DD3EBEE01AF9F58BD6FCD163497ED2A8FDB6E2E1652D363CAA28D0E0629FB7EA4ED567FD167FFD6E79FCBB9A67FBF70EF71F817D59D4B362EE7E5EACD9D27998ECF15DE805E8FAF3BBE8B51E5E9D4FB02F5E3D95E485FFB94396FDE9E30232C852D4E53E3A1805EA994F1BE65DD3204F1A7485199E3EE87B1EF51EB43E16CC0F20F4676CD08C277A26001303F640BD7C03A7D86D53D299759B21A33AD7CFE1679AC9FEE789B4EC5BE40F4F2EE6AA036A590259E9B92AC52463ABBAB5319276A24435FF5046CA32EC5324289EC5E65DA009D216A056118321FDC45B928CD7D0E98214C77FA9C3AD4426E223EAD6383850EB93D14AF6C37982430E38A99E04D84373721D69722966547A3BA3E43750715A66238F916C9027C863F465E65A8EE971976E9512D682790836201553415384388AD7928618F43CBC84EBCD381889F377574A5E22F307471A755541BB30819C4C4597628AD9D5DDDA28590B5EA296BB68236519F609B219DF62F32ED0F4980D54AB84DFD07EE22D49C575987421C63360A9C3AD441EF623EBD6383850E7CFC135E487710447DCF5513D037047E6E439C2DC528CA7F06646C96C80DAB494461C22D1084F90BDA8ABCCB416D3E32B9D2225440571E0673F1535C112843889CF720698F03C2C8469CC08E9C7E12F7C86D0103C003FCF1D5F7F4C2752B8197AC2E7987C7EF99B1B3F5DE9D63888B64842651AF9A9D3194DB599D768E2F4E65CAC9AE6B88EF25DC9427B808459FAA35CEE809B710374086FD83868D1E59BF6946C88F603A7DC71513D113007E6A43CB2D4528CA6EC56464970DCD2B4BC461A21C9F04E90BC688BCCB310D3A32AED1A250C05B667A73E151F41D2836888C7520E1FED3CA483EECA28B8C6E13B7A7534037781C6B563ADC167E2988CBC82CF2AC1E0F137304636D1AD4A492424CE11C7737ACC41535FF2919F1C5F389727A00AAE2935D7890802901430FBCA651B34B7591801DE86719081C377F02BD900EE03CE65C75C05B8C4413909019F568AC1E36F619494A05B96961348BCA30EE9046981A6C0F4833F3D6270AE4FC20C5C5B72BA537103202D881C28976ED8F8E6A1077827C6C10F4EBFBAA36408941738A03D0715009387E5E40992C452CCA0E43646C915FA8569D982CC3FFAC04E9033E84ACCB104D3E30DD70A25CC01B266263D157B005383F8837A09870E731E0E41F5631C2CE2F05B7C4A0E81FB8063DA3157C13171504EF6C0A79562F6F85B182573E896A5E50D12EFA8433A41C6A02930FDE04F8F2D9CEB937005D7969CEE543C01480B6209CAA51B36BE791802DE8951F003E0C7777564411A001A5BC25783D0E21432720A6D8E0946577B7363641B548D4AEAA10F9569E4A7C750FCABCDBC4693E32E70B10222C339CA772511C5611306F669D07207DC8C2C4C48DAB091D0A24DB9FFF1432D1722BCE009EF3AE89E02A8C3B2521D4162490652701BE32435BDC2D44C46E41F7D60A748545425E658820952924B85221E025833939E8C7140A9813443BB8443873913A120FA311A16F14B593CEA5904EA858D6ADB410BCAF8619959049B58A229646F63AC2CA25398078B10F8471FD869B2084589399660922CE254A1904538D6CCA42764116E6A088BD02DE1D061CEC622D07E8C83457CD827FB665B6A7904ED078EABE3A28266E6C09C6C42965A8A7994DDCA2819855B9A965348232419DE09320B6D917916627AECA25DA3845FC0F6ECD4A7E218487A10CBF058CAE1A39D8769D05D1907D75814959666A02EE0B8B6AD55F88C1F939357B059A5183CF60646C9263A55698984C039E2784E903928EA4B3EF2D3E30BA7F22454C131A5E63A1541709382B8816ED906CD6D1E4680B6615464C0E3BBC279576A4ABDBF2C5970EC0D90859BF84E70F90D8D993C0CFA1E704D9084E33C5D727163DFF7ED73FF23261B8AEFF8C65D247B909884C8BED1DB735983CC7B567232F2EFEF7EB9A896D5AC58BC795C6FCABA6E1ED03215913F3CD798AB0EE4650964252EAA14930CAFEAD6C64961D012D53C461929CBB04F91D678169B7781264870805A452C87F4136F4932BE43A70B921EFFA50EB71299E88FA85BE3E040AB7979F754EB3F2142FB8103EEB8A8E09F393027C791A596623265B7324A4EE396A6E532D208498677829C455B649E85981E4769D728E126B03D3BF5A9B808921EC4413C9672F868E7E11C745746C2351E1F777BE6B4D54B2DAC2B3CBE80970EB7D963B3F20E69764906547A43E3641F50756A02220F92709CA7C844F475665B9109F2916E99224A82B948F6201931419304B989D7B20699F74C0C856BCF1849CAEFBBB2D67EAD99348260B63BCE03A09E48E276080C9F64FA31E66F6F0274A65BE430562389956DF0274F7534E5E65EA6A9139F73B57AFEE37A2A36260F1B0252E6499172C9432EC82D5024BC6763614AEB62B3DD7F5BDBABF2BE5A565EB28E3004B200B8B7F239439A465EB6A4CC32CD482B6F70A47C89A8524F98D4C1328EFF24399377BDD9576A8AAC092C57469B1857CDDEA4234E5CD230731AB2EC41F724177712B66D34E469557B5226CA119BF89E8FF6F9813C32332992E49668422537335602D4AFCD83F6C842241AE169121B5D9599D6629224E65AA490BA400EFCEC27A42960820839512F678009CF4644A8C68C847E34CF2DEBEDDB62AD651FA41F3CBD7D171D70D30766A51EA2D4928CA4E856C6493C9CD2D4BC431821C9F04E9174288BCCB31013A41CAD1A458C03B467A73E19DF80D303E9867E29878F7626B24176652C5C63EE2574506EC8D8CE07BC42248FCBCB330499A51946C18D8C9465CC078A1BB20009C676920C43556396559822BF98AB040DC89C9BF774E4024A0EE616DA651C3CD3B99805D192B1108BBA54FFE830E1844C6BDB5E89CDF8517909059B579A09646F62A464A253979E4A08DC238FEA244984A2C20CE33F4502712A50461F1C637AC6D3510737319838E8966FE014E7220D6833C642191AF7999E33E05EC894761C94504C1C969736F089A51942FE36464A1CBA85E99983C43FFAC04E923C684ACCB10453A40FE70A65FCC1B566263D1D8300528329847209870E732E1281F763242CE263B9291EB45F6C4F79C1A3DA75D081327558561621482CC9140A6E639C2CA257989A4588FCA30FEC145984AAC41C4B30411671A950C422006B66D293B10828359045689770E830676211443F46C1225E15DBE2F5A27C54BF85C13942030BF868D0993D3223A390E6966028A53733465E01D5A6A416F2108946787A1C435F65A6B5981CD3E81629201B98033FFB8928079A20B01F5ECB1960C2B3700FAE31E3A01FCD78CCB6E5FC4D5DEF944A06EF0ACE30E4A54270FED89C34449C5D8A0915DFD028A908589D968C2882241CE70952128F3AB3ADC8F46849AF4C0931415D247B908A9CE04942F4C46F5983CC7B1E8AC2B667242465BF4B5A7682FAC0F3DB36D701387E505622C2A6956400D95B1827F5E894A5E61C02EFA8433A457AA12830FDE04F90509CEA133109C7969CEE64DCC14D0B240DBAA51B36BE996802DA8911F183C357722CF5EFA3089CF17175FCF4A8CC1C9D9D43C8F24B36A6B29B1A2FAB70EBF3A217D23089477BAACC435B69C67599281769172A2625B0936C2792D214245194AF782C6FA0E9CFC860E8268D88CABC2DB79B6AE6C363084F7CAABB4E7A98A70ECD4E5F04C9251B50C1ED8C97B8F48AF3622DA218C90679AA64455566AEE598284DB95429E6288087600392B2132845949A689734C4A0672425446F46C448BC7E038F77A57440EF1FFF121C9B9D95DCC8EFDCC96F68BCBC64E02FDB6982241CE7A972939BFBF53A9FFB1F2D3B51FD5E1DEE22D983C4EFF2C87E9ACE735983CC7BD6B77E46FE2B74C7327EADCBBB6DB1F5F9631A993F3ED790AB1EE4F904B21317718AC986577C6BE3A53060895E3C461129CBB04F95D678149B7781264A707AB58A590EEA27DE92A47C074F17253D7E4B1D6E2532D21FB65BE3E04055F1B05CD5DBBDD8B45E6DB40C48E20D0E3BE2A87A42101D9E93FB68124C31B79ADB1A25EFC10AD4B21E5D9CE4033E41BEE3576ACEA5991ED7712B95301DCA4BB819A9580E992AC471BC9738D412E4E137923E8D83DDAC66BB3D3F7B5B2CAB7BFD3B51126F70C4114715F88B0ECFC96E3409A6985ACD6D8D92DD60056AD98D2E4EF2019F20BBF12B35E7D24C8FDDB8954AD80DE525DC8C54EC864C156237DE4B1C6A09F2B01B499F46C56E2E4F547EF48676A786DCF1F4C17FE6F81B6038B20C138EAEECC6C6CC71DC0A3D498E345086319F2ECFD1D69A757526CB74DAA52AA80EEC26DD8FC464074996603B1ECB1C6C17B2F21DBA55A3203CAF17D543F5BE5A54FBAC3C3E5A2CF487661D77D53C194813C8487A9429261860E5AD8D91F610252A798F3A5296619F1EF5F12E36EF024D8EFC80B50AD80FE327DE9244FC874B17D8A4214B1D6E25B2502061B7C6C781EAF5FE571507902022003BF25D5FEF67062A855BE141821C538FB1E0E646CF847A350EA142A25099467EE26C48556DE6359A361FBA14AB254480A37C5772502228618E1369973BE066E4674544C3C6418B96B3D56ED96C9A920C916EE08CF73D54CF02F47139E98E28B3145329BA9151521BA7322DA111064830B613A42CCA1AB3ACC2F4E849AB44092901CDB9794F4540E0E420DAA15FC6C1339D8762902D1909B198AF5795F64FC3492F785EBB0E3A78A60ECB4A2A0489251943C16D8C9352F40A53330A917FF4819D229D50959863092648262E158AB80460CD4C7A322601A5061209ED120E1DE64C3482E8C74858C466B5581C3F86E3F3C115913B3CBC88A70EAF45C767651A9A0C938CACE6C6C6C93DB00AD524441728C3984F919FF8D59A757526C858DC5245D4857293EE47323243260BB21AEF650EB60B99788EA455A3233C5E9F5291F973B33EE00D7B610237427A6EE4132ABA5B1B3BED19F8F9146DA42CC33E6DEA73739F4DF19D8991931FD52753683FF19664E03FD28FA50C58EA702B919D028DFE3329EBAA5ECDCB77F72F8B8D96FEB0AEE098435EAAE701FED89C7C479C5D8A4115DFD028590E589D96E02882241CE709321A8F3AB3ADC8F4784CAF4C0985415D247B908AB8E049429CC56F5983CC7B1EA6C2B6671C24E58F75B1AC9BFF6E72BBAF165A9E22F106671A7154C1BBE8F09C844593608A91D5DCD628690B56A096B9E8E2241FF0095218BF52732ECDF4888C5BA984CB505EC2CD48C568C8542152E3BDC4A196200FB591F4692CEC66512C0FFFF2EEFEEFE5B2BCAFB41FBD914640461D75563E110893C8CB767449A69964DDED8D94F5E045EA998F3656B6C19F240BF22D37F7324D910D41D5CA1811EDA9D89874CC884919664703963CE482E46249B29E8D82297D573C568BA7B7E5E3FB72F34393FC6AF3A4234AD200D0F013BE9A670B710A19599236C70483ACBDB9317224AA462545D287CA34F2D3E347FED5665EA3C9B123B8580139E21CE5BB92881AB10903FB3468B9036E46165E246DD83868D1A27850F220CC039CEC96B10AF6D14372521B2EA914C3C7757F94E4A55D9496ADF0BED106738204445E5EEA619F1EC5385627E1147D4B62A253B10627258826A8966CC8C0E62102580F46F1CCFFFDAA58E89EF9510F681CDBC61A80C50FC9F8CCCF269560DAD8EE8FF199BF5394F2995FE01B6D30A7F7CCAF282FF5B04FEE99FF549DE099DFB124263AD133BF9B1230F5BA251B32B0599EF9D11E8CE3997F53AC3FBC2AEFAB65B5FF572509103883430AFBA9105872744E96A0C82FC5902A6E6A94DC01A94F4B235461128FF604798657A519D7657AECC3295442440827D94EA4A22754A21053F15DDE40D39F87BF089A34122AB3DAADB504067381E7B865AD4374F498AC1485CB2AC9F47137304E3AD2AE4A4D4278E788E339459A21AF2FF9C84F90521CCB131189BE2935D7C948839314481554CB36686E33D102AC0DE32003BB6A5E1C7F00DAE31BD944DEE0AC228E2A38161D9E933868124C31AA9ADB1A259DC00AD4320B5D9CE4033E41EAE1576ACEA5991E21712B957013CA4BB819A9180B992A445EBC9738D412E4A134923E8D82DDFC50168BED8759B1393F43E9E88DCC1D1A72D45383FFC2E333321C5D86094657776363E43878854A92A30D9461CCA7C7737C6BCDBA3A93633A50A902AA43BB49F72311D96192057668C03207DB852C7C47D6AA51109E378FC543B57C785B2CAB7BF52F0A499CA12947FC34CF01A2A333121D4D7E0926567353632439587D4A8AA30B9378B4A7476EFC2ACDB82E9323366EA1025A4339C9762211A5211305F6C67B79034D7F16322369D298A8CCDD7637577EEB08EB494C75C7C903E68943F3D3173EB97403CADFCE88894BB7383FD62289916C90274B563465E65A8EA9D2947395728EE27A0836202D3B0152C4A9897249430C7A4E5282F766248CE471B7ACFE55E8FF0088F584C7D875D2013977685646224C2EC9740A6F679C8C04284ECD48C431920DF2141989BACC5CCB314146D2A952C448100FC106246324588A2023F159D210839E899130BD19212399AD1E1F9B1307F313360E3FE250087FC8E713BA1926234E35F98C8B6F75FC2C072C7510E75144BC89E5983A3BF228FA36166EE2CCA957B39A47A1FEEAADCAC2B1F0F459C6E5070AE157E906D818DBC59170B3F5A2DCFF68F5E11FF79FA9567EFA581A005E0DD457F74C234C212BFFD2E598649C7537374EC685D7A8A65ADA5099467E8AACCAB7DACC6B34411E05152B2250B4A37C579251262661902B0D58EE809B91891DC91A360A5AF463F57E53687F47887282E6BB67AFC17FF2A88C34479257825994DCC418E94CBF2E258591B9471ED5E9D1135D8519C67F7234E45AA0807A40C6F48C27A2186062C01EA8976FE01467A10F543346421996BF150F4AF584728267B463AFC361E2A8AC9481CF2BC9FCF137314ECAD0AD4B4D1924EE9147758A9441536186F19F2065381728A20CAE313DE3C928039018481994CB37708A335106BC1923A10CDA3F7E463DE0E9F4FB5B50FC90AC3421FF1F34B3DD1F2741F0FFD365816FB4C19C2229B8A53F4756DCED28E980F40F8F1D4B62A293B100C1DF15EB966CC8C0667AF21FF39F0DFFB89A797C0096F402C7B2E7A0025BF2B09C4C4092588A0994DCC6281941BF302D2B90F9471FD80932045D893996607A4CE15AA1842D40D6CCA4A7620D606A1073502FE1D061CEC320A87E8C8245BC2D8B7AB751BEE540394183DAB3D720327954460621C92BC1004A6E628CFCA15F97923EC8DC238FEAF4B883AEC20CE33F39E6702D50401C20637AC613D1063031600FD4CB37708AB37006AA19E3A20CEBD546F9DE03EF4ACE6BDBCB0B99F1636F814AB0D9A59C4EF686464D2B3AD5F9920B419084E33C61BAA1A833DB8A4C977A9CCAD41010C745B207A9C9889B24454974CB1A64DEF3D213B43D232129F3AAD09213CC059EDE96B50EBDD163B292102EAB24B3C7DDC0384947BB2A35D9E09D238EE7144985BCBEE4233F4112712C4F441EFAA6D45C27230B4E522049502DDBA0B9CD440AB0368C860CF87C5882F1C3E6D3FFFD67EEC0CC04E1363E3421BC95B15285611F9C10474832BCD3A40FB7F6010AF59D8F9448683E4481D8B3539F9057083F4AE1B394C3473B1BCD18FF072ACE357C3B7FAC96D53ED810E62188420F351CC00FD825C9DC044751249A74AE15B7396EFE8214EACD6654F1B22FC494798F57C9B7B06413E6444EC52A8644782B3729397BA25227B9942F08845E9ECC3C4BD0BF91B1AE5755DD9C56AB3FD12AF2A7D7A1EFEAF79442277013EC4A9462D23916DDDAB8199553A237971246CA32EC53664ECA62F32ED084D952AB56154F02FDC45B929C1BC1E992AC48BFD4E15622331322BB35320EF473F9FBAEFDF3DFEA37BB70774E40ED78FABE7B401C7F13FC47926162B994BFB171B39F7E8503DE169304CA30E653663EBA5AB3AECE8479CFB554E51B68AE9B743F32BC9D0624CBBCABA65CE660BB90FD3D36BC5523233C77DB627BF8E2785FCA4307A0A7DDF1F57B3E6052B809E223CB31E914CB6E6EDCE4C7ADD19BFE4843651AF92993206DB599D768C244A85DAC8A0AC18EF25D494E8790844942E4B1DC0137233329A21B36125A54D7C543F9AABCAF9695CF478F24EEF0CC239EBA6707D1F159E99026C324D3ABB9B1715221AC423511D205CA30E653A4407EB5665D9D09D21FB75411F9A1DCA4FB918CF890C982B4C77B9983ED4226CA2369D59808CF0F65332E1B2FB243B81213DEF5F2407FEAD8FC0447905DBA3915DCD088894DAF3A3F52230A92709C274B645475665B91A912984B9972F202B848F6202D698192C4098B765983CC7B4EA242B4671424A5F9DF6AF970F7546FCB471D47613DA159869C3490CE1F9A91A088934B309EE2DB19233D018B53B213458C64833C3D6AE25166AEE5981C31E95529E025A887600312B1123C45604BFC9634C4A067A1246C6FC6C14876DBCD41F979B751EB26025F70944137159C0B0ECEC94CE4E9A59853F92D8D929DC0E569F989264AD2A19E204BF12934DFA24C8FA9F4EB947015DC47B40DA9F80A9126C4583C9736CCD8E7612D7C8746C15BDEBDAF9BADEA7EB78388B4708ED038033E1A64678FCCC855A4B925184DE9CD8C91A540B529298A3C44A2119E1E33D15799692D26C749BA450A0809E6C0CF7E222A822608EC87D7720698F02C0C846BCC38E84793D0F12FC63D3F602B0D00CE33EEABC274690A39E98932C714F3ABBCB951D215A2462D6D5187CA34F213A433DED5665EA3E9D11BB05809CD611CE5BB928AF6700943F467C87207DC8C3C7448D8B071D1A277BBED6CF5A8FCFE3D913739F13D47AFA706F2F05BA0429204530EAEE4B6464D82FA05FA3220599CE4033E61E2A32B35E7D24C97F25C2BD5F01DC84BB819A9990E982A4573D44B1C6A09F2121CAA4FE360379B876259FDCBE74D27CE131C6DC04905F8ECA139D98C34B914132ABD9D51B218A8382D8391C74836C813642DFA32732DC7F4D84AB74A0953C13C041B908AA1A02942ECC46B49430C7A1E56C2F566148CE4B238B58E8F307ED008BB2E1A08E70ECCC84484A9259849E1AD8C918500A5293988384292E19D1EFB501799672126C73C3A350A780762CF4E7D22CE81A5076C86CF520E1FED2C6C83E9CA48B8C6B62AB55FAE4B39C123DBB1D7A1347154567EC1E7956404F99B1827B3E8D6A5A61512F7C8A33A4536A1A930C3F84F90479C0B149108D7989EF164F401480CE40ECAE51B38C5995803DE8C915086A7FDB7E8FE63B56D16454B1C3857785E012F1D32B3C766A512D2EC924CA7F486C6492BA0EAD4E4421E24E1384F916EE8EBCCB62213A41EDD324504047391EC4132328226095212AF650D32EF99E809D79E3191949FCBD9AAA97B51797CBC431E82986ED8DB03ED2569E427318A2CD3CDB2E206474C6A902AFDC88D2A58C6F19F2CE9F1AA37FB4A4D950439E5CAC910E1AAD99BB4E4884A1A2749BECB1E744F72922641DBC6419ECA4DAD664BB80F38E71D73D5130271504E02C4A7956210F95B1825C5E996A5E53412EFA8433A419AA22930FDE04F8F889CEB93300FD7969CEE54DC02480B2213CAA51B36BE79E802DE8971F08345E1FD1529025F7058413715240B0ECEC91FE4E9A59850F92D8D924FC0E5697985264AD2A19E20DFF02934DFA24C8F7FF4EB94F010DC47B40DA978099126C44F3C9736CCD8E7E12B7C87C6C15B36453327FB7FD07E293EEB090E34E0A40277F6D09C7C459A5C8AF994DECE28B90A549C96A9C863241BE40972147D99B996637AFCA45BA5849D601E820D48C54CD014215EE2B5A421063D0F27E17A333E46D2D435809560DEEC38B71CBD411D3DFC56180A9760EA89E56E6BF44CA55DE010B6C2C7493EE013672EF252732ECDB419CCB1522D8BE97B093723079B7152E5188D6A89432D417E6683F56924EC66352BE7BB8D9AD6506EF050F73C74384F1E9795C148324B3292921B192767E957A6262BB20009C6768ABC4457639655982013B99628A220903937EFC94807981CC836D4CB3878A633F10BAA25632316BFEFCA5AFBF525126F667E3B8E9EB04D1C7E1BA4834F30EDB8F2B735720AD22DD09F8948E2241FF049D3134DA9399766CA64E55CA98EB3B85EC2CD48CF6080546922A35CE2504B909BD6E07D1A0FBBA96B7F6E43FBA2E3EDB8A9619F393837AB91A5976A5665B7345A46E396E7C367A451920EF544998CB6D07C8B324D16D3AE53CA61601FD136A4E42F489A187BF158DA30639F8FB9D01D1A176FA9D74D249F377D186772ACBB7E5E284F1D7D0BDC45905FCA7115DCD4A8D94BAF3E5FFA220A9378B427CC605495665C97E972984BA11A120338C97622358D8112A5788C7679034D7F5E264334692C54E663B92C96EA2FB8A5FD9089EEB928019E3C302F6D91A496662C25B73252B2D22F4DCF536411920CEF248989AEC83C0B31453A72AD51C644207B76EAD3F10F303D987AA89772F868E7221C545746C135FEB9577D9AFF5C1695F693B2BC2B34BEA09706B705C766E41DF2EC120CA8FC86C6C83EE0EA9404441324E1384F8F89F8D4996D4526C747FA650A2809EE22D98344C4844812D815CF650D32EF59180ADF9E5192148F7778E42124D3ED2D892BD2B821127313EFFCE86F700AA466D0BB403EC1328EFFF449CF8DBD3B34643E26408214EF14F1AE9ABDC9448E64EF1D0D5CF6A07B7213A469E4EF261D426D8A85D7277A25CED0E4237E9AE70AD1D119499226BF0453ABB9A9311223AC3E2525D285493CDAD323407E95665C97C9911EB75001DDA19C643B9188E29089027BE3BDBC81A63F0BA1913469245466516CCBB9CF2F04F1AEF05C035E3AA4678FCD4A61A4D9259952E90D8D93BE40D5A9C98B3C48C2719E226DD1D7996D45264859BA658A080BE622D9836464054D12A42A5ECB1A64DE33D114AE3D2321290796F5FD66B55B6B390AE309CFB2EBA48374EED0AC0445985C92F114DECE38E909509C9A9D8863241BE42952137599B9966382C4A453A58897201E820D48C64AB0144152E2B3A421063D1325617A331246521F16E86EBB9B3F692909E70A0F32E0A5C372F6D8ACAC449A5D921195DED0387909549D9A98C883241CE72972137D9DD9566482ECA45BA6889E602E923D484650D0244186E2B5AC41E63D1347E1DA332E92B27BFF9FE54CFD3115DE999CE8AE9F17B65347DF025911E497725A0537356AC2D2ABCF97B288C2241EED09131755A519D765BAE4E552A886BE004EB29D484D61A0442912A35DDE40D39F97C8104D1A0795A9EADF9A7F2DEBFAB109A86432BC2F38D9A09B0AEC0507E7A431F2F4528CAAFC96464962E0F2B41C461325E9504F90C0F8149A6F51A6475FFA754AD80BEE23DA8654DC854813A22E9E4B1B66ECF31017BE43A3E02D77B30FE57CA7FD1D68D20B1AE4BE8306D0E9C332F2135162096651741B63E4244E614A3622F48F3EB0D3E31ECA12732CC1E4F846AB4201D300AD99494FC42EE0D4A06D502FE1D061CEC225C87E8C8345745744492604CEE0E0C27E2AA4961C9D936128F24B31A88A9B1A25DF40EAD3D20E5598C4A33D412EE25569C675991E33710A951014C249B613A9E80A9528B8379ECB1B68FAF3701841934642657EDF95EAAFE127BDE069EE3AE8A09D3A2C2B5D112496641805B7314E82D22B4CCD4C44FED107768A244455628E259820EDB85428E21B803533E9C91806941AB80DDA251C3ACC99C804D18F91B088C3A6BC2AEFAB65B5FF772D9D90B8C3C38B78EAF05A747C56A6A1C930C9C86A6E6C9CDC03AB504D427481328CF914F9895FAD595767828CC52D55445D2837E97E24233364B2F80EF92C73B05DC8C47324AD1A07E159AC949F7A453DC0796E19AB201E3D242779E1924A317A5CF7474951DA45695909EF1B6D30274837E4E5A51EF6E9918A6375121ED1B724263A155B705282A65EB5644306360F0DC07A308E67FE7539AB1E4BADC241798163D97350812D79584E2620492CC5044A6E63948CA05F989615C8FCA30FEC041982AEC41C4B303DA670AD50C216206B66D253B1063035681BD44B387498F33008AA1FE36011DBCD6EB6DD6DFCDF321106000718F755A1B634859C8C4399638AE155DEDC28790851A39692A843651AF9097216EF6A33AFD1F4980C58AC84D4308EF25D494575B884A17D1AB2DC0137230F1712366C5CB4E86DA1FC6279D6939CF49693D7D3017AE82D501F2EB99443CADDCEA8C94EBB385F96C3C74836C8132634F232732DC77429CCB14A0D77E97B083620355B7152A4688A6A49430C7A5E6282F5661C8C64F7BE9E6DAAB58742C37982630C38A9809C3D342723912697623AA5B7334A460215A76524F218C90679828C445F66AEE5981E23E956296124988760035231123445684BBC9634C4A0E761245C6F46C348B685FE4F7649376C803B1E5AFC268ECBCC42F8CC128D237F2363E51FDDCA3CC887244082B19D26E7D0D498651526C936CE250AA9866BCECD7B4292012487300CE5320E9EE96CDC026FC94888C57ABD786AC6A3FA586E943FA227F085671772D301367F7056B2214E2FC9908A6F699CB4032C4FCD3D1451920EF514A98847A1F9166582A4A457A78899A03EA26D48C651F03441A2E2B7B461C63E1365613B3422DE72FA1D631FDA42B9E223DDF3D2E33B796C76CE22C92ED9904A6E68BC8CA55F9D176191054938CE53652BBA3AB3ADC844B9CAB54C3155815C247B9094A88049A23C45BDAC41E63D234BA1DA330A92F24B51FFA6E326A80734BB6D630D74E3876424206C5209C68EEDFE18E946A72825CB10F8461BCCE951094579A9877D72C4E1549D802F3896C4442762076E4AC0D4EB966CC8C066A100680FC6F1CC7FE02DEBD546A94D307EE0683A2E2AC8650ECCC90864A9A59845D9AD8C921DB8A5693982344292E19D206BD016996721A6C720DA354A78046CCF4E7D2A4E81A407310B8FA51C3EDA795806DD95D1708DBBC3475CF55C83F0C306B7EBA2856BEAC0CC5C43905AA28914DCCA58B946AF340FAE218A906478A7C9355445E6598849728D4B8D42AE01D8B3539F906B40E9215C43BB94C3473B1BD720BA320AAEF1EFC562D76C8D9269905ED0D0F61D34404D1F96916388124B3087A2DB1823BF700A53B20BA17FF4819D1EAF509698630926C7295A150A180568CD4C7A223601A7066C837E09870E73161E41F6631C2CA2AA9BFFF869537A7ECB86D01F1C5FD45505D9C20472B20D5D8A29E656776BA3642078895A2EA28D9465D827C8547C8BCDBB40D3632F50AD121E43FB89B72415B761D28558CE80A50EB71279988FAC5B37C8815E373EDBA7C667DB78949B53123F3D6D56AFDEEFFFB5FCA3B9E4D9AEDEAE1E8BE572B53D04F8DBAF75F972B1D9DF7DFDCDF3ED66573A63BF8FDA50C153BC6F67B3D56ED9443A3ED01A9AD32387C176801E0C721EAABD0711EE34784CCC3EE97102F60D64F19C67132CAE63E815FF385EE7C981FA22F1135CC0B6FAD8FCCBF5BB7DC11BE81BC9EE16F0A2AE1933E74F9A7F2C3775F9FA6309CF63EB6151E25D7B2265C0908FBE58949B87A737CB6D03339BFD1FF443911D2351E29017913E6ACE9FB45EAF1A347A441A7E7D549476C79CC8D7B553C65E37380AB6DBB5D2277E769316D0B1E7CFDACDAB2D3AE197074569B7AD896C1D33367203A9D50C0875F877496A67433CAB8E051FAF5A169B2728CCE101514A674B22A78E091F71357FBAABB6D0209E1F122576B52552EB19F15177CBF9024CEDF08028B1B3259156C7848DF8B25817EFABC5FEDF1AB65222B0035849D285DDF0DC097BC1599BF2A745013DC99E1F92A57CB1A5F2EC1A89A2FE52168F48ACFD43D2E44EB674726D233EEA873DB179D3F41B8A7679509460DB9A48D131E3232F8A0ACC6FFFEFA2D44E8644566D0B713CEC89AFF3B82641FEC90EB414C46FC8DFAC58BC795C37AFBC6A988FBA46B2D4012F2A7FCC9C3F69352FEF9E6A64562F0F8A926E5B13C93A6682C88F8FBB7D8508E9EF3C2E4BB5EB40650B586AE31FFE5C930F7EFD5B5B8FF09A2A7A7F2FCB9FB62E36072A48BEF402ED84E5808E643DB887E8BC554D95717A549AFCD59C4EB9672788DDBCD0596FDF166B30E0F941599A2D6B2ACBBE9924F21CEFE5E931618A73491F7B5692B835C2C28E8F0893AB59B6D5B591C4DC6E8A1992D9E121616A675B32B78E9120EAC7E685F603F84C7C7A4896DCC5964AAE6BC4467D556C8BD70B8C5CB71E95A4D835C7B304ECF8D8E5B69C6DCBF99BBADE41ADEC3C2E4AB6E740A40B590AE2EF853A30DCFE01598A274B2AB7B68930E2014197C895772DE469B65DB87C1D5BE1196FCBED06D41ADA0FCB53BED873F9760DC5F786B195CEE39A41E0F90968298CFF6B5D52AFB45D2379EA3D2F2E7FC89C3FA92A1E96AB7ABBBFA8FDDFDB40D17B26A2025C1F227DC4983F6535DBEDAB7D5B2CAB7B646A7A26A2E45D1F2279C4587CCAE5C31244F08B8D26FDB6139FBF63CD9EF37A513D54477907DF5AD7485202E885D7809BEB4E425FFC0356EA3204420061CF9FB53CBCF707BEDD76794C9474CB9848B56F25883B3F68FA60B0E343B2F42EB654765D2341D4CD6AB138EE013ACA7D1B59BAAE13953762AD3A071F63C7485B8264885173FEA47555AFE6E5BBFBBDE609856E3F2E4ABDE740640D59F2F1FF5817CBE3871F56F715F86640DF4494B6EB43648E184B4E5914CB8326F3EEFEEFE5B2BCAFC0B107CC8445407E6421A8037BDA77C563B5787A5B3EBE2F373F54F57605BE970558494A81DDF04A087BFEAC45F100856CFE5994EAD18EC8AD65C046FB7E55401F0BD9FFB32499931D9E4CDB808FB629D61F4809B067214AD17121B2856D0567AC76908476F877599247432AB596051F6F57CD4F1F62C09E2AFA26A2345D1F2263C4983DE587B2586C3FCC1A983E7DAC0708EED848D2879CF0FC516BF69C378FC543B57C205EB4F42C24C9BB2E78EA88ADF48CBBED6E0E816BFB6145CA677B36DF8EA120FAFE2D877F61EFD9B41F9625DBB1A792750D95D167ABC7863ECD65A9B78DF585F4BCA565416E8293D747F9F2E0B6DF7F6875012B5959901B550F6ACF9EF563F57E037F56E6F48824E1AB299E64CF461073F91BAC999F1E91257636A512EBD808628238B7FF67594A0CA2B50DF8682BF49DDCF343A2A45682F76FFB466CD4B76551EFC0173FA74724A95D4DF1CC7A36F298884AD8795C9524AB0F829682F8F3AA00A335FF2E4BF0684825D6B210C54327EFFAA03435C1F4B9668AC8DFCE1F1BA2BBFF303D9B72D7545780E32B290776529CFAAAAAD725CC7C5D235D412D2F49297D73D5DD63529563A31D2A5EAA42AD15E7506F9C0056BA22646F9D10F682B3EABA7916245F923A36B2225C27AA04C45A7A4EF352660EEAC69DC715895F1CD8A4BB966CFCE67FF72F04B00F8CB51F96A4DBB3C7B3850CF9E8BBEDE6701FEF36707BBB06A284FB1E44CAA0297BC2BBF775F3721683FCD6A39274BBE678AE801D1F7B5D1ED19F5C3FC04A9438E8461480DBCBCF7AB7DB36AFABA0A7A4BE89AA84AB8F20FF9E317FCAE6A1205E65B71F1625DDB52712060CD9E897BFFC82225E1F9424DAB1C6D374CD0491B715FC8C787A4496DED994CAAD632388F9B47F76FCC76A0B6B6E9DC76549761DA854014B69FCBD5AB19C558B0A1B52D04E5180E3C816027BF0E73573045770784094F2D992C8B163C2475C143404770D4449F63D88644153FE84FD67110F2EE01373FB6151C25D7B225DC050177D05BEC9D8375127BD62DE64C48C05A7AC66E51C56342E8FC9D2BD1A5379F6AC3471B157537D1365BAFC6B29CC58764A5D33A95F0CC489B73D98B41D53F909E89B4F3D0B55DA82B79E105BC9191FCB25F277C8D70785E95EADC94C7B666CE47FEEEFA2D9D36551814BD7795C926ADF01CF16B454C7C78602B4F329801F10D2833DEFF049BACDFE8D6D6C2B7B1692225C173C7DC45670C6A2D896739466741E9725DD75A052062C05F10F0562EFAFB71F96A5DBB1A7B2750D05D1EBC3F74F606F9F761E97A5DB75A0F2052CE5F177EFFFB304FF4CA467A14AFAE22248BB6BCB9F51D5BF7D5BD70DC423DA62D7409476DF83C81A34654FB89B7D682800C8EECE0F49126DD9E229F68DF8A8826F74E9588852755C888C615BC119CDA6C24FD8E78764A95E6CA91CBB4682A8870F8E90AF9E1C1B59BAAE13953762CD9FB35841EBB5FF67519A473B22B396011F6D5DCEAA66E5A038A78744495D6D89C47A467CD4ED6637DB360C9FBE6CD74A9432E846648FDBCBCF82FF2AB4FDB02A75EE2F4321433EFAEEFDE52BC9A098AD8745C976ED8964014351F42DF2E2E2F29834CD2DFBD2C2B112C4DDFFFAEFAB72517D2CC14FBF740D64A9F63CA87C2153E1093815777F685A135090B19684EF7F60110876F9A54B813B9955F7F729B96897DF618222757F2E4B1C8A4E0FF8912B41E4E30F3820F15ABFB3210EC526D9FF750C26F2F9DBA181689DAFEE168621D373BF709B8BEA7C81231415FE3E4E75683A75E25B347B27B5BED2F17A5CEF1B10BBDF5BFDACE5723A8FB4EF9C77A8EDFCFDA094DBE5BB4C2FAD00BFBCF18567F4F3578FB6A233DFD2F8A2DB294117C9AFD4FDF9F48589FB5B3B7EAECF6DAB2E00DE09551CA8F1B22F9A1C70267E1DDCB7540EBEA5FE9860B5F2532FF9126C724299EFBE0EB609CC175BAB2F7E50D75B5F7B4CF618FB7A64A452E05B91DDFE09BB067C65B1E62EBCDA837D37A9008B65AE54E1A208705FA9AF60259B2D3B33056E13B968C0411BC4AB391AC8087F3537012440761CA6D02ECA567048E37EDFB1B6D91CFEC82FD6A7C1C0770EF320C43A112DE07CC136235FA14CB59A3D2709D84059286046E1AE6C85025A0235FF16E0A49B170324A8B1B870063C3ADF332E6F270318A2EBF2691EFAFDDE3C60085D8916C822806D26BFC69C6ABBF0CC244082E7A280137510AFE628A025C2D5DC02CC40D93160C3B8285BC1000FF09B01DA663320A4B8589F06BB5FDDCF6310E743348071057B0CFF0A01D566EE9424380324A10018B9B7AE0F0A4809D2F75B00914E5A0C7A60B6D2AA19BC68FF3C87B8930C4248EE6970DB3A1F4A534204E12B6D011E821F5DE71378E2C613A7A687906E32BE50228AE2D71F5F6809753F370735E7F4349003F868BB2186A09F2F1F7F55775C0349CCFDFAB4D9F9051C1E911817A201B427D863F0877CA826336724411B370705C8889D554D50404A8096DF0280B4B3627003311596CCA044EB57ADA44D64304170411E0DEBFCEC148B0284355E24EE0475CEF9A52CA27D44E4141BDF3D5EBEEC223F69D5F215F7EFEC0D2CF639217AA7012BBE467A934F3FFD26E815BDBF4CF77D5AD2F975367E770973A238DC0BEC96F3A37254E388D849F6B77BBE6281458EE2C2152B3CA0BDB7B0C4E78C982D06CC0465327B7CFAC54449C3984D662EC1A731BD5F33E4979974204AA4FCC0B6013FC648B5908C9F64A9FB1928D65AE8AA285FB1DA031B7D0BEB7DCD895970D050542CB3E4975F2095B58E5974F64A7C9AD4F985507ED10973A244DC0B6C9BF3C3A654FB88D84916BC7BBE62BD458EE2C215AB3DA0BDB7B0D6E78C98A506CC0465320B7DFAD55E49C39865662EC1A331C40FE6B27B2DF6C50B978680FACAFC3630D16EF1A929B0804A460E0C1E51FCFA23878C38F773036002A747230BEBA3ED068D39E08F72AB3B4EA391EA7EBDDADCFD8D6C011E510E54F1841FDC5DF727BEC9E652F1D3604C2F030DB0C85C15E56B206458A36F022C2E39710801198A8AE5B0E0FCBBF6B2D6715BCF5D896793DABF382F5A75DC812E13F5C39AD776104C201E3FD5AA7732D0ADBAC45551BE6ED58734FA4656FD9413BFEAAEA1A8587ED5F786D2D6F1AB4E5F894F933EEC0F7AD3FA5A637ED91917A254DA136CA1E3C24D22734692A5777350ACBDD859D504C5EA0768F92DAC7F3B2B0600105361C90C085C4CE54D64804070413E0D5B14950205706BA248D409EC5CDB9A9B413C72928DEF1CAF5876899FB46AC58A7B77F61616FB9410B3D3AE155F23B3C97B2B51AF98FDA5BB3FA025BA8F040BBCF852751F0306BD840398F9A3BF701AFA551FF8715F4D98B83770435020FB582F612DAF5D00113F4B3EC44BC4252023FC07775F2EAA65352B166F1ED79BB2DE7FF98E023F64AE54134411E04E63AEEC30CBCE4C8329682E1A60D106F16A8E0662C25FCD4D800D901D8738B48BB2151CF6F45DF4CDE650487EB13E0D5ECDCBEE4F2CF110C4B810E5D39E60831D176E9E993392408C9B83025AC4CEAA2628A02440CB6F013ADA59319081980A4B6620E2622A6F220309820BF26AD8E1E786BBBF5D294003D68B2A9A73863B0A78B133CA9E940619A03434E0A0F0D776430311A16EE02680A29B188715A8B5BC760E315AD6AA9E72B821BAB5E12DEC7CF9AE164108677123F018826976BE64587E01C4B919D0A59B8D37C888C278B6C81B72825DD2ED01D0393F150E014EEA862850E9F2DDDEFAB6AB308AB966BF66AF8BCDE18FB23DBE2E53E14D36461804B907DC9BDF04E9C989F08A48470558FA38BE5D524156A49BBA0DD0021364518BF3D2F784C52DD7CBABF72C72696EDBB3E5AB5A0F58A40FDD06CA156B76CF4730E8E429A980A89F840E7E84DEBA3EE8A06678DF6F0456AE69F16002DA4AABE681E364ABE8240F12EC3D79B5ADD996F5B6F53B3D0264A05DA882494FB8977D17763CE933D2A08293830614A4CEAA2668206178CB6F02105A597178009B0A4BE6D0E06C2A6F228705FC05F9356CAEE508A407592CE1887471AE7B96224F488402737F6620F4D57440050103BB7D1B003097F201D052562FBBFD73091300E3C1BBCFDD8C5FAB6AD55FAF52F66499A81BD2BCB63D3F8478F4440BDF4940B5EE124F79EDAA551FD0E3DB58F35AF457A4909DA45276C16BF62F44A158F072D377E1D79EEDA698A9769B70208BC4FD90CE751CF8D123E227DAEF6E06AA0517B92ACA57ADF8A046DFC6929F7362B71C301415CBEEF9C150DA3A76D3992BF16AD2C772533C283E534E3A5065127E70F3BA0EEC0452F1D3AC7A2F03CDAACB5C15E56B567D58A36F62D52F3971AB0E198A8AE556FD68286D1DB7EADC957834E955B12D5E2F745F39C3FAE0C572AE5017011F661AD953526C3E94847CF915DEBA3EC821204CDF6F0008BA69D15880DA4AABA611A165ABE8248D0BA27BF2695BD3FED9B69CBFA9EB9D9C0A08BC88B25967B0A9901737AAFC494940024C4301131A7F6D37145011EC066E012E7A893180815BCB6B6740A36DADEA29031CB25BF36AE1FE6A1498819B53C5A25E7017DBE6EC70E2B1D3E042E77C0D20481CC5856B20C0BFBD37B1F4A78CB86D77CD046572FBBD3793358CDB68FA12BC1B73F8D4C052F52241E2C7154CBBE3BD74FC44F3C89C966EEFDD44B400208EA0EF89161242DDC5CD80443B35095A20F69A0E48F0E362AFECAE04510477E8DDCEB7E576A3F8E518DE892B9EF0C5BBDB75128D30754E3A2CE965A1051299BBB2155A0819DEFC9B018F4B5E12E4808CC5854B30E368AC69A7042DB8EB1A40CF747FD725F0E22997EE2FB9402F211BCEFCB75B701AFA971E03FF5A4B1326EE0DDC0C6848FF228BB096D72EC10DC91F5F117189572EE1FFDCEA18F9D7BAD47FB7BED4956B021B01EF34E42A1A66FECC749802E6A205164D10AFE6682126ECD5DC0CD8F4B293200EEEA26C85047BDA2EFA664B504876B13E0DAE8A87E5AADEEEC9D17AB5510091C8916885C41F6C39E2C8CDB9E8BC24008465A2801F65088FB628A027F085DC02ECB8B931A0433AA89AC0004ECF41DB62066CC457E9D3D4D56CB7C7AFB7C5B2BA57BD661239126D90F883CD461CB9C9169D97046AB04C1450A30CE1D11605D404BE905B801A3737066A4807551318A8E939685BCC408DF82A0734F5B2706AAC613CF946D001A87E3B9EC2E9664E4C89376E2A7AC011C7F0E98C1E72C2DDCA0D814E3B3919EA201EBA3EC870E7E2A1EEB30C790437EAD1DAD78BEAA13AFEFC99561B96BAE2CD104680BA8EBB32832E3D3305FE10B9C801481FC4AB3972088A71353700426076340A712ECA56D038E4BAE89B4D2391E662873658F9930C625F6143943FCF40F86A663EF74F3550C97802D2D09F6DD0074B773FB7064AC29F73607DB4DD50E092E0071ED83338648AF0630FAF97B3D56ED95C991C90680FA27CD2116C70DF831B69FA842440E3A4A08017A9AFA6030A2819DCED5B808D56520C58C096B27A1960385B8AFBC780007F335EAD9AAF5795E22D6FDA812A94F083FBD7756007918A9F66EB7B1968965EE6AA285FB3F2C31A7D130B7FC989DB77C850542CB7ED474369EBB85DE7AEC4AB499BD56271D45A945288CC932A5C1200EE2BE2C94EA9E8C434B880A5A20108650C9FCE682023F4ADDC0488B8C97168427AE8FAC0E14BCF43DD670E71C4373AB0B55AE943E82A6B8656F8405D15839E5DF6C073F103A0C1A2873656AAABB93110920A1E8C8BB215721C92A81DCC090C12C5D03AD655BD9A97EFEE5F161B050AF15E44135867B0D3901737DBFC494910074C4301361A7F6D37141013EC066E01587A893198825BCB6B6790A46DADEA29831FB25BF369E11FEB62B9FF79CB9F36ABFB6AA1400F9123D100893FD863C4911B62D179499004CB440126CA101E6D51404AE00BB90560717363B0857450358141989E83B6C50CCE88AFD2AFA98B6279F8C777F77F2F97E57DA5906BC4CE643B643190C6A3CEFCA40BCF4D043F78362A085287F16C910A8AA25CD26D4012941F0B4B8C93BA212C3C394E3E6D67614A71CD1ECDFEAE78AC164F6FCBC7F7E5E6872689D5E6498C54625FBC29D210D00D10BECC06884F4D815254327290F288E2D71F3944C5B99F1B0028383D1A9F581F6D376874027C3C3A4E6393EA7E7DDABC281EE458841A1345633E60475BC6DCF8A27193E049FB74058008DC84252B20C2B3A9B70002C77C98AD778CD80299BD6E8C246D6236976CBB4733BE5F150BF1AAE2C67859A80FD4A4B631335578DC14ABDA395DBEAA123761C9F255F56DEA0DACEA291F7A555D23B6407A55F7469236D1AB4AB7DDA7199B62FDC1E387A9457E44B10277B08BB01F378192D3926C38928862D97511F43D514040D0BBB805607052633082B2D77480418EAEBDB2BB0C9E48EFD0AB9DAB9DFCE761096BAA5CCC096E64CB9A1D5334721AA0681FAF8107819FB46A0D14F876F626D6FE9810B7EC8E155F23B7D88D95A857DC1293DDF769C9AE9A17C73FDFD57DC04BE648142CF1077B893872C3283A2FC9C6639928965F19C2A32D0A48087C21B700146E6E0C66900EAA263048D273D0B698C117F1557A34F587B2586C3FCC8A4D79BA3731D6083DF146C80240FD463D99E9169E98026FF054E480A38EE1D31939E484BF951B001D28391A75180F5D1F68DC713CD47DA6914771A31EAD7DF3583C54CB07F597A689FCF03648DCA166237ECC708B4E4B0138582272B85146D0F7440E3561EFE20660C64D8D0619D25ED3011A607AF6CAEED2E022BE43FF76DE6D7773F907287827B678DC97E86EC74936C2C43909B1A49B851A4844EECA56A8216470F36F073CCE798990033016172EC28C83B1A69D22B460AECBAB798FBB65F5AF42F5F60BEF4495CDF8C24D759DD869E5CE49031540161AA890BB2B5BA1818A30CDBF09A8E8E4C54105662C2E9C838AABB1A69D1C5448AE6B70F366ABC7C772391F021C7C08694BD848FC5C43215453CEE7901E70C09C7CE147136C50D37CA129CE15DE1C6CF5B2D48018EEEAD92239C0755DFD2F45037EB281F0BA90F5F147D00FFFBE57A8E5C2B1D8976A902C047C27A82FBB2BC253D3E01C9E8C06E0D451FCFAA381B418F773132006A5C7A117E3A3ED0687578E8F47C7398452DCAF479B7FACDE6F0AC5DFCD90F678E9941BD4DA9E3D33CA64F414F0D24F400E29424F79ED72E818D6E31B80886B4A342C8076924AE9F53FD909BB46AF397B175EED59FE563CC89906694F9588BBC16DEBD8B36347444FB3DADD0434AB2DF294D7AE59ED213DBE89D53EA7C4AD366027A9945BED839DB06BDC6A3377E1D51EC53BC0B831559CE2BDDEB6313B6A39DFD5ED9CAE59E421EFDF0ABC4336F5269657F09EAC6BC416C8ED2CF396AB1B05DCD6C06FAEFEB89AE9444FDA81288FF2031BD673E0A68C8C9F647DFB19285658E8AA285FB1CA031B7D0B2B7DCD89596BD050542CB3DE274369EB983567AFC4A3496FCBA2DE29BEDA8FB4C78BA4DCA0CEF5EC99E923A3A7D8F27E02F225177ACA6B97AFF8B01EDFC0825F53A2F71BB493544A6FF7C94ED8357AB7D9BB18D21ED56F630BBC04E5AA7E151BF4928E63DEDFC386D3F058FF61BF84AD0913F7066E091644BF7E4D58CB6B170185E047AF89B8146804FFB9EBB7E5BC2A1490815A53A5624E700B5BD6EC60A291D34042FB780D1408FCA4556B56DFB7B337B1EAC784B81577ACF81AB9956EAC44BDE25698ECBE674B94AFDE3917BA48E52B78D7453074B95FC50339E8167BE82B79718C582DBF916517BEA2C74C8525F3BB2F785D8F45445020CA6BFB73D86FE78FD5B2397CE30B0C9200925608E2D02D870388E759727E5A404132F281175DA801EDF2819E38177753B0E4E4280529CAD1AB395200EB3AFA5E8514DCA42330E8125E55F5BAD47CA386D455D21A32027D157D57F166D067A6053327171F189306F16A8E0F7485BB9A9B82AB567652A0825D94AD9082D3D945DF6C2920F1173B90A6EA7E3852E829A39CBA1F8E443D15AF1432FF70249E8ADF4BB5813F1CA90D95E6566E0A80A43F1CC978E8FA20451FC90F4732F199577AE17F38F21AFD6E5B6CCBD3AFC269C187F195B4830E4137DEF1150F3B736A5A107293F181217114BFFEF84051C8FBB929386AA7270524C447DB0D29285D7C3C3A2E0526C1FD7AB5B9AE8B87D2E38B90859E543B2401E0C6239EECC88B4E4C0348582A1A3852C6F0E98C068A42DFCA4DC0909B1C0742A487AE0F1C00F53CD47DE6C0477CA3FEADFDA12CE6E5460B3B9417DB02C2996873D74B36D4D4490961A697861A6264FEDA6EA8A125C00DDC0EA45C1213C109642DAF5D0423476B554F45F0C1DD9A470B9BFFDD7F25D153DD30223172F04E78E1AC2FD457C889195AFE9C14A8016621070D8DBBB21572C808D5FC1B008C5E5E345EE0C6E2C269B4681B6BDA496385ECBA7C9AB7DB6E0EDCE5DD464333246E44E9BC37D85AD08D9B5AC159494003CE43011BAA00EA8628A023E035DC027CF433630084305794CF8048C75CD75806488497E7D1C877EFEBE68E3A6F92B338C2FAE08573AE505F011F666ED95352600794841C3814DEBA3EC821234CDF6F002CBA69D14881DA4AABA631A265ABE8248D0EA27BF269DBBA3C7E7AC6434815FB122D108600DB8CFB72232C3D35098410C928A0441FC5AF3F0A6889723FB70035607A0CE4703EDA6E3010E4FA78749C8124CDFD0E69F3BBDD76B67A947F004FE6286806E54F76BDE7281D77F2BCA458D4CFC4038884213CDAE20141812EE496C0E79A9B10794007551384987372D0B6588836EC55FA3475F350A8BFD19D7722CAE77CC106034EDC24B3E7248115280B05A428DC95AD504049A0E6DF028474F362E003351617CEC046CB58D34E062E44D7E5D1BCCB45D462A0E05CF092194FA89DAE0B33A5DC19290002C8410E0F72675513E4D010A2E537000B9DAC6850C04C8525D38070359537910603C90579356C5B693E114BDA5385E26E70FF3AF6EC2C12D1D3EC7E3701CDE28B3CE5B56B567E488F6F62D9CF29719B0ED8492AE576FC6027EC1AB7DDCC5D78B5E769FF89D57FACB695E2F76D055E54B99C33DC48C08B1D47F6A4348B0FA5A1597F85BFB61B1A2808750337010BDDC4387040ADE5B57340D1B256F594030DD1ADF9B770FF4B2ACB59B5A874A282C29B6D852008D172D85B36D8929313420C928E1A6A74717CBBA4869E0837753B50E424288224CA4BDF13114475BDBC7A2F822CE96DFBB4BC7985A4C12AC29C281EF702BBDB31E7869A889D046FBAE72B0046E4282E5C012103DA7B0B2071CE884105C04C5026B3F7073359C398CD662EC1A7318BC2E7231D1237A25CDE1B6C24E8C6CDA2E0AC242B0FE7A1587D55007543145010F01A6E011AFA99311041982BCA6720A363AE6B2C0321C2CBF369E4A6986D0F61151F43E79D88D2395FB0B5801337BBEC39490004CA42011F0A77652B14D011A8F9B7001BDDBC18D0408DC5853380D132D6B493010BD1750D6D5E93971F5CA08EC2F2317F76725B8E9AE945CF4B0E1FED4C3C214410C2A32D9E5012E0426E0D528EB92960C5715035410E2F7B076D8B1530435EA5575357B372AEF9A519C6832A9C7284FBDAF360A7973C210D8EF453D00088D057D3010D640CEDF64D80C435290E1D404B59BD1C1E9C2CC5FDE31080BD9961ADD27D1FA2CC5154B8EEDB103147F9A066FE2E4434132F9018F84D88CA48292EE4B60044F62D88B483AA094254917C05221D9DC698F05F8078085ED75E40C3B8312DA0BDD1363B6E928966CE4A06306E1E4A781107503744092D81AEE15660A59D990054107345F90240B998EB1A2B0013C1E50D6964BD5E69BE4E5EE4276800E14EF6B8EB279D63EAB4A478D24BC403506411F43DF180942077714BA072494D882A90BDA603425C39DA2BBB2B4416EE0EFDDAF9B15C164BCD47551917B270CA13E96BCF851F5DF28C4408D2CF41051E42675513549031B8E5B70114D7AC588C004D8525B3C87032953791C503F6823C1AF6CF3D6F69FE6559540A6954E08517CD3B431D05BD9819159C940219E034E4E0A0F2D776430E11E16EE00680A29F188D1584B5BC761A313AD6AA9ED2B821BCB5002DD4BD4C5178CB5BA17BC9427A2B073BF3CB173A1D7FA819F852C6275CDA9BBA412892BDC41178E97BA28028D18B1EC13902C80AFF02E8B09F9B62A1D569457E783B24EE50E3113F66F045A7A500272C11392C2923E87B2287A2B0777103F0E3A646030F69AFE9000D363D7B6577698011DFA1573B17C5B69C2BFF3446E04595CF39C30D06BCD831664F4A0328501A1A3851F86BBBA181925037701330D24D8C0311D45A5E3B07202D6B554F39F010DD9A570B0F70F4FD66B55B2B908373A20A677CE1BEBA4EECD072E7A4410D200B0D68C8DD95ADD0404698E6DF046074F2E2F002331617CEA1C5D558D34E0E2B24D7E5D5BCFA702177DBDDFC498115AC175538E70CF715F06227963D290D5E4069680043E1AFED86063242DDC04D804637310E35506B79ED1C6EB4AC553DE59043746B435AB87BFF9FE54CA37D08FC04E513EE6483BB7ED201A64E4B0A22BD443C60441641DF130F28097217B7042797D4848002D96B3A200495A3BDB2BB4260E1EED0A79D55FD5BF34059D7AA5FFE96B8110DE0BDC11E836EDC280BCE4A822A701E0A505105503744012901AFE11600A59F19832784B9A27C064D3AE6BAC6325822BC3C8F46DECD3E94F39DE22F826907BC64D20F6A67DF8199553A7E0AB0703290C384D45551BE1C1A8636FA06E0A095130D04B0A1A8587AF9CF86D2D6D10BCF5F894F93BA6D976FBCC48F285AE00E7614F6E3A653725A123440125180822E82BE270A88087A17B700184E6A0C6E50F69A0E302842172A8F0DF65278875EEDFC7D576A3EE64E3B5045137E7047BB0EECC852F1D3E0462F030D60C85C15E56B206258A36F02142E39716800198A8AE5F6FF68286D1DB7F1DC957835E9D07D8FEF30147A52854B02C07D453CD929159D980617B0543400A18CE1D3190D6484BE959B001137390E4D480F5D1F387CE979A8FBCC218EF8467D5ABB58C9C54EDC982818F3017BD932E606168D9B0439DAA72BC042E0262C5901099E4DBD85C53FE6C3ECBA63C416C86C7463246913B3B764DB7D9AB12E67D563A92007A403511EE50736ACE7C04D19193FC9FAF63350ACB0D05551BE62950736FA1656FA9A13B3D6A0A1A85866BD4F86D2D6316BCE5E894F93B69BDD6CBBDB78BD2490FA12C50B4380DDC57DB969959E9A042188641460A18FE2D71F058444B99F5B0016303D0663381F6D3718E4717D3C3ACEE091E67E87B4F96D21FFA037EF246802E64B76BAE5241D6FF49CA4B8D3CEC2037004EECA567840CCC0E6DF12A81CF312A289632C2E5C881F8DB1A69D42C420AFCBA779BBF7F56C53AD75F4857522CAE67CC1A6024EDCB4B2E724810A280B055428DC95AD504045A0E6DF025474F362A002351617CE4045CB58D34E062A44D7E5D9BCADEA4BBD180FBA60DC11EBE556F1F552CC09A9B061EBF97D5E625F4D07749030ACDB3702065BD157792196B27A790CD8B2DFE385C443B69FB919AF56ADD78BA757E5A2FA586EE47F0F2671A38A66BDE18E426EEC80F267A5C104300F0D306802A81BA2818870D7701360D1CB8C430CDC5C513E871D6D735D633914915D9E7723B55F8C23F0E28AD77E290EE8259ADFEC5F8803A7A10591C15F86A30913F7066E0640A45F824358CB6B97A087E4EB6F88B82876C4F8EA9B5F8AFA373162E0C678A1A80FD4BFB631339478DC1468D0395D0E02123761C9F295F76DEA0D2CF8291F7AAF5D23B6407A8BF7469236D13B4BB7DDA71987DD5FAF36F2A778CE852891F604DBE6B870D3C69C916491DD1C14EB2C76563541B1DA015A7E0B6BDECE8A5976C4545832B3F8175379131910105C9067C3EE0E82A40A0A2817BA5CC2136B64D7453097D419A9A0A097830E0A64CEAA26E8A06068CB6F040A2E59F15000990A4BE6A1E0682A6F220F05DC057934ECDF8BC5AEB9073910D00E78A9A41FD4C2BE03338F74FC1400E064205F7FA9ABA27CF9EA0F6DF40DAC7D2B277AE9614351B1F4C29F0DA5ADA3979DBF129F265575F3DF3F6D4AFDA70BA4AE44E9B208606B51576E5285672601073C17054CA883783547011D11AEE616E004CA8E0116C645D90A066C1C177DB31900525C2CD1E0AF5F1C63BE5C2DB745B52C3797C7BE7EB1FF6289C7E2F40F5FBF684C66E57ABB2B166F57F372519F1F785BACD7D5F2A1BE7A9EFEE5D9DDBA9835D5BDFCEF77CF9FFDF1B858D6DF3CFFB0DDAEFFF6E2457D085D7FF258CD36AB7A75BFFD64B67A7C51CC572FFEF4E9A75FBDF8ECB3178FC7182F6675FB66BEEE657B3969BBDA140F65EFD1E6E826D3EFAA4DBD7D556C8BF7C5FE97115ECE1F1DB39F9E36AB57EFF7FF50FED19B84AF2F3D3F9F759CC06F67B3D56E098DCDDEFC97A77579B6DFFFFFA71FC26A8EF9649FC98FC553B9F9E4D5FB43233F39E7763AFF9353E8E63EFBD1AFBDFDAE2977FFFD3E87CACBD65C50CE8DFBDDAC58149B9F36AB75B9D93E9D6A79336FDAB25AEC1E97D7FFEE4F2BE15DBFDC6D36876F31EA04B9FEB33CD6771FAA4D3F9BF3BF69327A552E1AA4E99775FD6779AC7F2F37FB45EB27D5FA6779AC1F8B7AFBEB7A5E3899751E90C7FB5F8F8BBF2F56EFBBB12EFF288FF3B6DC7E58F5523AFF9B1BE5EB17BD19ECAFC00B67077A68D45F29CDC2B5502EEAEA1D0E19B47F4884384B083FD3F663E2568A93B69BA6FE5EDCD3BFC9A3348D2F7FA91ECB77F7F775B9FD71F55FDD80C0C3BEB17FA81E3E50C18F8FCBA3FFBAA9BAE10EFF20F77FB97A5C379D6FC6A61BA6FDEFF268FFDC1587D9EBC6BAFEABE25E9FEA6DF9D8BBD7D3BF69AA9B97FDBAE6C0E7B488FE2EABDE33C9F15F7C3AECDE7DFF317DA7DD98DD47B41D77E3B5FF5DD779A8DEF3BFEA6EC08D74FD5779A4CB8B38E879DD79D0236E03B307F2BD077A247AD7C4E30C8401408F7B44EFBE8E450F71CD34671D3BE006BFFEFBCD3CCDF75ED747788EA74F103CC57301E23CC31F548EEEF38E237B90A7D7FBBC9B59FD69533D169BA7C6FDE7D5CA21ED88D1ADCD072FA3849A13E624F9BCB081E2CCCD79CBE1DDD744DAFF6F37CAF15FFE4F7B6FD7E4B871756BFE1585AEE64C9CB0ECF73D1333E390274256CB52C7B8DDB24A7EE3DC395024AA1A16BF04901D2A4FCC7F3F20AB482213F90922810DF0B991DD859DB9736FAE8DB5163F87C3F0BBE6F3298AA4733DD162DFAF4D1BB12CF13F7FCCF61A51BEFD297C8FEF7EDB957955B58A6AFE3D66CE5FFD51CBFC5EFE1CA3F5B3FDA1D2B5FEEBDFC6B3BDED2F2734D29B23ECE65C6F9C1F94F0122BFC1EFAFA24E3F9D449EC7548E2DE6EB0BE6DA76EC45DDAD72D79477B06675F7CAE2F34BE2420C953387A96AE4FA406EDC373AA3CA73AE1E7540D184FFAF4AA2D5F5F03CA93AE8E5D78D295275D79D295275D79D295275D551DB03C3EE7977FF7394FF48E86C6FE1DD5B86F0774383A7CBA3A5C45774A056EC874FB38A2BA1DBBA0BA51DDA86E5437AA1BD5ADB2FE6A9597CF2FEF37FB6DFD7F4EDF679582F15B593A2AF0B07DD0E1E8F0E9EA7013C653AA716BBEBE061465EED805658E324799A3CC51E628735507EC76DB62B35FA77A3AFCBA7D472DEED900118E089FAE0857C09D527DB713DD3C8BE86DC72EE86DF4367A1BBD8DDE466F3B287FB7DD54699E0A6FA7E9437FDB374287A3C367A2C3CF201F4C8F2B097B9B51F4B96317F439FA1C7D8E3E479FA3CF5529705816FB74EF0EBFECDE518DBBD723C211E1D315E14D6CA7D4DEAD3CB70E224ADBB10B4A1BA58DD24669A3B451DA0ADFD715168B14047FDAB89BBEB62F455A23AD272BADCFB04EA8AA9514374C1E5ADAB10B5A1A2D8D96464BA3A5D1D22AC1179BAC7C49C2EBA79D3BAA69FB5AE434727ABA72FA8CEB947A5AC971CBF0A1A81DBBA0A851D4286A14358A1A45AD72FC76F9F250EC93BC39FBBC774755ED5A8DAE46574F57575F919D52596B596E1B41D4B56317D435EA1A758DBA465DA3AE55A63F6C96AB34DAFAB47347656D5F8BAE46574F57579F719D52552B396E193E14B5631714358A1A458DA24651A3A8158EFF36DB658FC5EA78695FDFA7537D9F9F214D37AD1DBA11C21BE13D59E16D06794215EE48D8DB8CA2CF1DBBA0CFD1E7E873F439FA1C7DAE498132FF719525F91DF8F3DE5D95B86335F21BF93D61F97D417652CDAD66B96D0451D78E5D50D7A86BD435EA1A758DBA6E31FDCF79B64EC5EFC7BDBBAB6BEB6AD435EA7AD2EAFA0DD989D57533CB6D2388BA76EC82BA465DA3AE51D7A86BD4B5CAF49FB2F2397F7FBCEDA460F8CBEE1D15B67B3D1A1B8D3D5D8DDDC4764A95DDCA73EB20A2B41DBBA0B451DA286D94364A1BA5ADF2FD2A2BD288ECE3C61DF5B57529D21A693D5D69FD06EB94AABA99E286C9434B3B76414BA3A5D1D26869B4345ADA48F0C97E635D49709BB6E677D5D1D833D6D803FCA2BA31550F1389F676EC82F6467BA3BDD1DE686FB4B746FCC5A6A8AB78BFDE9579756C6C1ACED7B37455E141FB20C591E21396E2068C27D5E3B67C7D0D28CADCB10BCA1C658E324799A3CC51E6AA0EA801FB76DB49C1FA97DD3B2A71F77A14380A7CBA0ABC89ED94CABB95E7D64144693B764169A3B451DA286D94364A5BE3FBF5FA707CDA6A9FEAE9EF6682AE7ADBB705921BC93D61C9ADC23BA9EA36A4EA6122D1DE8E5DD0DE686FB437DA1BED8DF67611FFAF87BC4AF37338863CBD2871FB4E087204F95C04F919E5C3E97225637F638A4A77EC824A47A5A3D251E9A87454BAAE06EA01DD1F13BECB9F8A1A74E99E296F27EAACD303B742A823D4A72CD48D304FABD4ED297B9C54B4BA6317B43A5A1DAD8E5647ABA3D55B82605B2555E86FDB77D7E5AE0D50E3A8F149ABF12BB8136B702DD1CDB388DE76EC82DE466FA3B7D1DBE86DF4B646F975B5BBE31FD3F0FC79F7AE6ADBB91EB18DD89EB0D86E603BA9D6D6F3DC3A88286DC72E286D94364A1BA58DD24669EB7CBF4CF8BCF6DBE69D75B66339321B993D6599BD1CE4196D2DCD8D5388C676EC82C64663A3B1D1D8686C34B64EF6D5513AA621F8E3D69DF5B57531EA1A753D6575FD06ECB4DABA99E4A6F943573B764157A3ABD1D5E86A7435BA5AA7F97D992D5209EBD3DE9D95B57D35D21A693D65697D46765A6DAD64B96D0451D78E5D50D7A86BD435EA1A758DBAD698FE735E274CF3E3F16F7B7755D78ED5A86BD4F584D5F505D949D5B59AE5B611445D3B76415DA3AE51D7A86BD435EA5A61FA23277FB7CAD789DE17D2D8BE9BC6F66D80CC46664F5666ABE04EA8B40D896E9E45F4B66317F4367A1BBD8DDE466FA3B755CAAF1969516BA2F7557548F294B692A0A3E6F66E81EA46754F57756BF04EA9BB4DA97A9848B4B76317B437DA1BED8DF6467BA3BD35E23FD69986E78F3B7755DBD6B5C86C64F68465F61BAE93EAEB668E5B860F45EDD805458DA24651A3A851D4286A03C79F7E696293EA1D246A8A5B34B67B13C436627BE262BB09F0E4AABB95AC97B944873B764187A3C3D1E1E87074383ADC40FFB52A298B453AC67FDDFF1605EED801F98DFC9EB8FCBEA03BB9F65633DD3E8EA86EC72EA86E5437AA1BD58DEA46751B5FE1FEF59057099FFB7E4B70DBBB4BEC5B20BC11DE1317DE57780FF05E1325550F1389F676EC82F6467BA3BDD1DE686FB4B781F8FF51E50FFBFA369DECEB4B5A596E51E1DE7D90E248F1894B710DE3C9F5B8295F5F038A3277EC82324799A3CC51E6287394B9AA038AEC79B3ADF6C7179677DB328D2ED7727454E521BBA0C9D1E4D3D5E46D84A754E4966CFD8C266ADCB10B6A1C358E1A478DA3C651E3AA02D82E0EC76C1FB24DF194EA6D2A5A8E8E6A3C6417D4386A7CBA6ABC8DF0946ADC92AD9FD1448D3B76418DA3C651E3A871D4386ADCA8002E95A724FE26486E207DF736087204F9E4057913E20328F256BA9EA6134DEED8054D8E264793A3C9D1E4687245047CB72A9E8BC762555F4BF851CE76966EAA3C701F6439B27CB2B2DC88F184BADC9EAFAF0145993B764199A3CC51E628739439CADCAE03AADD76532579BEDC90A6076DEED808718E389F8738BF807C2875AE26EC6D46D1E78E5DD0E7E873F439FA1C7D8E3E57A5C066B13DD4245D26A1FDF3E61DB5B873390A1C053E5D05DE80764ADDADA7B9710AD1D88E5DD0D8686C34361A1B8D8DC6D6C87EB9DB1669BEDDF0BC775785ED588DC046604F58605F909D545FAB596E1B41D4B56317D435EA1A758DBA465DA3AE35A62FB7ABD5EBE7A8D2BDF55B4FD2556F876C83F046784F5878B7219E54815BD2F5349D6872C72E687234399A1C4D8E2647935B4540C2377DB7B2DCAECA79CB37B27CEEB27C90777C5BF3F535A02873C72E28739439CA1C658E324799AB3A60575435663F3E7D9B956944793341473DEEDD02298E149FAE14D7E09D52859B52F53091686FC72E686FB437DA1BED8DF6467BABC4FFDB2EDB1CFB5917F154ACD2C86F2D4747051EB20B221C113E5D11DE46784A1D6EC9D6CF68A2C61DBBA0C651E3A871D4386A1C35AE2B8055B6C9F675473F3EFD39DFE44F459AB78E1BF27456E5613BA1CC51E65356E62694A755E7D68CFD8D292ADDB10B2A1D958E4A47A5A3D251E98A1AF84BB62E562F1FF2F5635E8F68550FEA4B0A096048D34DA3876E844447A24F56A29B419E50A13B12F636A3E873C72EE873F439FA1C7D8E3E479FAB5260953D2761FC7ADF8E0ADCB612C98DE49EAEE47E45754A8DDDC8D07DEC50D18E5D50D1A86854342A1A158D8A56D8FDFB6DB64AC1E9C77DBBA968EB4A54342A7AB22AFA0DD50955743343F7B143453B764145A3A251D1A86854342A5A65F732DB7D7A973F1535DCEAAE26A1773545476D1DB009321B993D5D99DD02784AC56D4ED6CB5CA2C31DBBA0C3D1E1E87074383A1C1DAED1FFF6B04B43F5F5C65D35B76D294A1BA53D61A5FD0AEBA4FABA91E286C9434B3B76414BA3A5D1D26869B4345A5A25F843B1CC5E1FB664BFA3A3E7E8A8B04376416C23B6A72BB6DB084FA9BB2DD9FA194DD4B86317D4386A1C358E1A478DA3C61505F0439EADF69F1659792E3905F1B79274D3E361DB20C811E49315E426882754E4D6743D4D279ADCB10B9A1C4D8E264793A3C9D1E48A0878BFCE9EEB7F7DC836C5535E25F90A6F2D45373D1EB2096A1C353E5935DE0678422D6E49D6CB5CA2C31DBBA0C3D1E1E87074383A1C1D6EA2FF87FD6199E42BBA9BFBDFA4C0ED3B20BF91DF5397DF6774A7D7DE4AA6DBC711D5EDD805D58DEA4675A3BA51DDA86E8DF5D7874DF1EF2CD5179E34F7EFAABA3D3BA0BA51DD1356DD0ABA93AAEE76A6DBC711D5EDD805D58DEA4675A3BA51DDA86E07EB2FB6EB3AF572200DDECCD68722F7EE873E479FCF449F6B581F4CAD9BF2F63DB82879C72E2879943C4A1E258F9247C96BFA60B7CA8FE94E347AFCA284249FE934A4E9AADDC33642B423DA272CDA4D204FAAD6AD097B9B51F4B96317F439FA1C7D8E3E479FA3CF1529F0D7E2B1CCCA246F287FDBBA9B0E772D467BA3BD27ABBDAFC04EA8B7B52437CD1FBADAB10BBA1A5D8DAE4657A3ABD1D51ACD6F7EC99E933CD7FDB675575D6D5F8CAE46574F58579F819D54572B496E9A3F74B563177435BA1A5D8DAE4657A3AB359A4FF31584C77DBB2A6ABE6C10393D3F399DFA1B069B19BA8F1D2ADAB10B2A1A158D8A4645A3A251D12ABB6F17C93E4D79DEBBA39A76AD4651A3A8A7ABA8AFC84EA9AAB52CB78D20EADAB10BEA1A758DBA465DA3AE51D70AD37FC8B3EA502679EFC7DBD6DDB4B56B31D21A693D59697D05764265AD25B969FED0D58E5DD0D5E86A7435BA1A5D8DAE36D3FC6E5B2679138892E0468D6DDD02A58DD29EBED27E83F7107ABB99AA8789447B3B76417BA3BDD1DE686FB437DA5B23FE6591A5A1F97AE3AE5ADBB6148D8DC69EB0C67E8575526DDD4871C3E4A1A51DBBA0A5D1D26869B4345A1A2DDD22F874EFBFBEEEDE5D55F31E6CA4F55CA5F510EFC26EE7B9751051DA8E5D50DA286D94364A1BA58DD2B6F0FD37CB75B129AA7D3980EE5673DDAAC203764393A3C967A0C95B481F44A19BB3F63BB2A877C72EA877D43BEA1DF58E7A47BD5B94C1BBA2DAE59B2AD1472AF52CB72A76E73E6875B4FA0CB47A03E383A8743D5F5F038A3277EC82324799A3CC51E6287394B9F575F45F0F799AAFE46E25B9FDFD2CF66D90E5C8F219C8F22BC4077A778B92AEA7E944933B764193A3C9D1E4687234399ADC22021EF6F57DFA98382DF95FD2DCAACBDD1BA1CC51E63350E64D900FA2CD5B097B9B51F4B96317F439FA1C7D8E3E479FA3CF35295055D973FE2E7F2A6AC0257B13BA96A4AB360FD906658E329FB0326F433CA92EB7A4EB693AD1E48E5DD0E4687234399A1C4D8E263789801FF26C99970969FF35C14D5ADCB1053A1C1D3E751D7E81777A0DAEA6EA6122D1DE8E5DD0DE686FB437DA1BED8DF65688BFFE6FFD8FB71B4F02B66FEEDF4D797B77407823BC272BBC357427D4DDA64CB78F23AADBB10BAA1BD58DEA4675A3BA51DD2AEB1F6A2E39BE66FCB14CF494B79AA1A3F2F6EF81F6467B4F577BEBF84EA9BE8DB9FA184A14B8631714380A1C058E024781A3C015EEFFF858D5A526FB1AF2C6F6DDB4B76F038437C27BB2C25B057742D56D4874F32CA2B71DBBA0B7D1DBE86DF4367A1BBDAD527E7DF2D76FFD4DFAC94B439A8EFA3B702374383A7CBA3ADC08F2947ADC9EB0B719459F3B76419FA3CFD1E7E873F439FADC2C053E1EF68BED3AC96FFCE8396E54E6AE5D90E5C8F2E9CBF22BC287D0E45AB67E461335EED805358E1A478DA3C651E3A871550194CFD9A6F877BAB7A734F6EFA8C27D3BA0C051E0D355E02ABA53AA6F43A6DBC711D5EDD805D58DEA4675A3BA51DDA86E85F52FAC9484E9AFBB7753DC9EF5E86DF4F664F5B682ED846ABB9DE7D64144693B764169A3B451DA286D94364A5BE3FB7D91A7F965CCB7ADBB6A6CFB620436027BC202FB0CECA4EA5A4972D3FCA1AB1DBBA0ABD1D5E86A7435BA1A5DADD1FCCB31D9DFB6FBBADC3414DF48D05563FBB64069A3B427ACB4557827D5DB86543D4C24DADBB10BDA1BED8DF6467BA3BDD1DE26E2FF295F6C378B6255247BF3B631D14D5A3C602B34399A7CEA9ABC05F3F4DADC9CB2C74945AB3B7641ABA3D5D1EA6875B43A5A5D150475371389F3D3CE1DD5B87D2DF21BF93D5DF97DC6754ABDADE4B865F850D48E5D50D4286A14358A1A458DA256397E9525FE6A6F35434785EDDF03A58DD29EAED2D6F19D52711B73F531942870C72E287014380A1C058E024781ABDC5F668BFD8942D3FCA27C73FF8EEADBB703DA1BED3D5DEDADA23BA5F23664BA7D1C51DD8E5D50DDA86E5437AA1BD58DEAB6B3FE7695E643975A8E1ED4B76D1714380A7C1E0AFC15E143A9F046B67E461335EED805358E1A478DA3C651E3A8714D016C17F9F2502692E16F9B77D5DFAEE5086F84F78485F715DA4915B796E6C62944633B764163A3B1D1D8686C34361ADB46F6BF1EF22ACD97786B396E56DCF65D10DE08EF3908EF33C287D1DF4AB67E461335EED805358E1A478DA3C651E3A8F1B602A8AAD45AFC92E10625EEDE031D8E0E9FB60E6FE23BB50A6FE5EA632851E08E5D50E0287014380A1C058E0237737FB5DB6EAA74EF3CB9A6B851833B36418423C2A72FC22F001F4285ABC97A994B74B8631774383A1C1D8E0E4787A3C375FAFF9C6FB24DA21FBEBCECDE597DBBD623BC11DE5316DE576CA7D5DC5A9E5B0711A5EDD805A58DD24669A3B451DA286D85EFFF7E7CBDB86EE7262BD27CD25249D04D6FFBB7407223B9272BB975782754DDC6543D4C24DADBB10BDA1BED8DF6467BA3BDD1DE4EE24FF69E1363A27EB438EF3F4193DF81261FE05D28CE943D4E2A5ADDB10B5A1DAD8E5647ABA3D5D1EA8A2038555C66AB841FCED45274D3E7219BA0CC51E69355E66D8027D4E49664BDCC253ADCB10B3A1C1D8E0E4787A3C3D1E11AFDAF8EF2E8C7BAA9697E9A5E49D05583FBB64081A3C027ACC0557827D5DF86543D4C24DADBB10BDA1BED8DF6467BA3BDD1DE1AF19F9EBBFABEDC1E7669D8FEBA7F57E5EDD901E18DF09EB0F056D09D5477B733DD3E8EA86EC72EA86E5437AA1BD58DEA46756BAC5F9DD8E9617F58BEA421FB4682AEBADBB705C21BE13D61E1ADC23BA9F236A4EA6122D1DE8E5DD0DE686FB437DA1BED8DF63613FFE1F15FF922D1BBBE951437EA6FC726287014F8F415F805E043687035592F73890E77EC820E4787A3C3D1E1E87074B84AFF45F5CB37559557D5316712CE57327454E1FE3D10E188F0E98A701DDF2935B831571F43890277EC82024781A3C051E0287014B8C2FD0F8B4FF9F2B04AF2F584E7BDBBA96EE76AF4367A7BB27ABB81EC844A5BCF72DB08A2AE1DBBA0AE51D7A86BD435EA1A75AD32BDCA4D49685E4DD1516B076C82E446724F5772B7009E52799B93F53297E870C72EE87074383A1C1D8E0E47876BF4FFEB214FF4ABF3E7BDBB2A6FC76A2437927BC292FB82ECA45A5BCD72DB08A2AE1DBBA0AE51D7A86BD435EA1A75AD31FDA9D077F9535103AE48F3FDDDAD245DF576C836086F84F78485771BE24915B8255D4FD3892677EC82264793A3C9D1E4687234B92A0256DB249FA73CEEDB5179DB5622B611DBD315DBAFA84EA9AF1B19BA8F1D2ADAB10B2A1A158D8A4645A3A251D12ABBEFF2457D6F4EF384F6DBDE1DD5B46B358A1A453D5D457D45764A55AD65B96D0451D78E5D50D7A86BD435EA1A758DBA56997E5F1E16FB4399FA9D23ED341D3577E046C86FE4F774E5B711E42995B83D616F338A3E77EC823E479FA3CFD1E7E873F4B9590AD47F4ECAFCF50E372A72DB0E4871A4F8F4A5F82BBA87D0E08D4CB78F23AADBB10BAA1BD58DEA4675A3BA51DD2AEB1F1EAB4559EC923D1DDED8BFA3EAF6ED80EA46754F5775ABE84EA9BA0D996E1F4754B763175437AA1BD58DEA4675A3BA5BACBFCF527D45E079F3EE7ADBBE1CB18DD89EB4D83E433BB1D256D2DC3885686CC72E686C34361A1B8D8DC646636B64BFDBAD5E6AB9567CCECB97343CDFCCD0556D7BF7407223B9272CB9357C27D5DDA65C7D0C250ADCB10B0A1C058E024781A3C051E006EEFFE9F88317559AAF076C26B8457FBBB6407E23BF272EBFAFF04EAEBEB5543D4C24DADBB10BDA1BED8DF6467BA3BDD1DE0AF1FF9C55BFA460F9E3BEDD94B67525021B813D5981FD86EA84BABA99A1FBD8A1A21DBBA0A251D1A86854342A1A15ADB2FBE929A8DDB64CF2F4F575F78E8ADABD1E5D8DAE9EAEAE6E623BA5BA6EE5B9751051DA8E5D50DA286D94364A1BA58DD26EF1FDC3E97B0552B1FCEBEEDD95B6633D4A1BA53D69A57DC17662A5ADE6B9751051DA8E5D50DA286D94364A1BA58DD256F8FEBFB2D5A1AE3689CE3EEFDD4D653B57A3B1D1D893D5D80D642754D87A96DB461075EDD805758DBA465DA3AE51D7A86B95E98B63337F2CF3A4DFAADDCED2517187ED83F6467B4F577B9B309E52855BF3F535A02873C72E28739439CA1C658E32BF4B657EBE7864E3ACD8E4A51E72C9FEF697CBBFABF31F8E1C9C3DE72776AFAEEB1E169FF27576AABCDA658BB711F84B5156FBB304780DF9F28BBA4D9F8B655E9E27EEA4117EF7F0EBEADB557112B6E7800FD9A678CAABFDCFDB5FF2CD9FBEFC8FDFFFE13FBEFCE29B559155474A5D3D7DF9C56FEBD5A6FAE3E250EDB7EB6CB3D9EEB3A308F8D3979FF6FBDD1FBFFAAA3A65AC7EB72E16E5B6DA3EED7FB7D8AEBFCA96DBAFEABDFEF3AB3FFCE1AB7CB9FE4A5FFEB66DD02EBFFFBFCFBB54D572D5541D0DB1F486876F168BED61D37EFEFEEBFF377FD11FE433946A203674CA57DA23AD2FFCDAA06D8E07F8D397C5B1AF27F9F47D5E3FEC4749FC63B6AF45C8E61895BFB1D6DF0EAB55F6B8AAE39FB255D51ADBD6F6572FF29AE5F148187A3BFF7812647FFAF2FF3BADFAE317C56FFFBC2CFCE2FF8F4E7ABE6BBD66DC7C3E4AAAACF4A73DFCFACFD7A5DF6C96975BC77FFFE2635903ED8F5FFCFEBF7FF1BEAA6FB5BF1EEAD09FCB437E3CD987ECB7BFE69BE7FDA73F7DF987FFF8BF3AB4E7628C62DBF3B6B0437B1A77C57E3BF487041D520CDAEB718FFFD8D722717B128941ED6AEC723C536D0716275FF0A72FFF33FA44179BA736EF7F5B67BFFDB7E8CDCE66AF3182CE1D9AB7F6C03B89C1EC4CF6766277498DA40178B0EDD304F05F8E07EA305E67C7153B5BC7639D961A0FD118A3FFF17FFCBE79A87D3D68BE33194C5BE7596AED653CAF6DC4E24FFBAA6C7B3AEE71B3DECF7BB2991D1EEE7A5D82C7BAE9568DB795904DAE36F5ADF17577D6D94AE9D3F16E7E54B5F5E53FFC8FD80467FFDA654A4E4B7D9DFBCFDF77E8DCD10F7738D171A1EF3CF10FE4ABB9D68F736B89AAC9BE1920CA74A6014933457F7D389B6FC7BEDD1EB204DBB6FC78078C6A7BF8E0AA69B5A853AABE3E4D271C22B6A72ADABE3E4E635837F2888CB0435E9F1F8838D5FBFFF9CFEBCAABB1F18A9C60D5A9963A13D179ACA41BBDAF3C864863F740CB786C728DFE1FCBFA665BBED4597EDA6E557FDDEB83A989E4993CA8E739E8E481CF8B6B177CFC5BF053041D1EEEE37F7B3DA3CFA47738A371406E342C8D97FF7D463B64BF2615F95DB6C1F4D7886BB17AA7937CF7DBAECCAB2AA4B0C0FBC1EB4BB11D9E427A5BD88FE9CDF6872ADA869F56F5913FE069A28628FD3F3B3CF1A0DC04DBFCDB97FCB0247A933BB765BBF1CEFF73563E9FDED8FA7AE39C070FF4F28C52ADABECCF2805AB2C3B49C5DDBD229E23DC179FEB3FBDCB9F8ADAB898DEBC34D9C795171E78E181171EEC9B257CE1C17053E135085E83E035085E83E035085E83E035085E83E035085E8348F51AC437CBE3B3E3F9779F73DE48879FC5CFE267FBBC9DE06471B238599C2C4E16278B93C5C9E26471B2C99CEC6A9597CF2FEF37FB6DFD7FB2572CCC447BE267F1B3F859FB66E9FCACE9A682ABC5D5E26A71B5B85A5C2DAE16578BABC5D52673B5BBDDB63EC99A9767B1B3D859EC6C9F77137C2C3E161F8B8FC5C7E263F1B1F8587C2C3E76181FBBDB6E2A5E9EC5CFE267F1B3FDDF55F0B5F85A7C2DBE165F8BAFC5D7E26BF1B5F8DA64BEF6B02CF67C7A163B8B9DC5CEF67A33C1C5E26271B1B8585C2C2E16178B8BC5C5E26253B9D8BAC6628181C5C0626031B03DDC47F0AE7857BC2BDE15EF8A77C5BBE25DF1AE78D764DEB5D864E50BE615F38A79C5BCF67123C1BDE25E71AFB857DC2BEE15F78A7BC5BDE25E93B9D7EDF2E5A1D8F36158FC2BFE15FFDAD3AD04078B83C5C1E26071B038581C2C0E16078B834DE6600F9BE50AFF8A7FC5BFE25F7BB991E05E71AFB857DC2BEE15F78A7BC5BDE25E71AFA9DCEBB7D92E7B2C56F51F1FEA13E4FCCE0E56162B8B954D7257C1D7E26BF1B5F85A7C2DBE165F8BAFC5D7E26BD3F9DA32FF71956D30B39859CC2C66B69F5B090E16078B83C5C1E26071B038581C2C0E16079BD2C1FE9C676B1C2C0E16078B83EDE7568283C5C1E26071B038581C2C0E16078B83C5C12673B0F503F09CBFAF87160F8B87C5C3E261FBBA99E06271B1B8585C2C2E16178B8BC5C5E26271B1C95CEC2A2B30B018580C2C06B68FFB08DE15EF8A77C5BBE25DF1AE7857BC2BDE15EF9ADABBEEB69B8AAF28C6C3E261F1B07DDE4FF0B27859BC2C5E162F8B97C5CBE265F1B278D9745EB6D814F5B4BF5FEFCABC3A3E40185A0C2D861643DBF74D05578BABC5D5E26A71B5B85A5C2DAE16578BAB4DE66AEBB17A1D5ADC2C6E16378B9BEDEB66828BC5C5E26271B1B8585C2C2E16178B8BC5C5A673B1EBF5E1F842CA9E976531B218598C6CBFF713BC2C5E162F8B97C5CBE265F1B27859BC2C5E76202F5B9758EDB1B4585A2C2D96B6FFDB0ACE16678BB3C5D9E26C71B6385B9C2DCE16679BD0D9D6B797FDBA9677EFF2A7A29E065EADC5DA626DB1B669EE2B785BBC2DDE166F8BB7C5DBE26DF1B6785BBC6D4A6FBBAD70B4385A1C2D8EB6DFBB093E161F8B8FC5C7E263F1B1F8587C2C3E161F9BCEC7D6F5EEF61FB21D36161B8B8DC5C6F67533C1C5E26271B1B8585C2C2E16178B8BC5C5E26213BAD825AFC5626231B198D83EEF2578583C2C1E160F8B87C5C3E261F1B078583C6C420F5BD5D20E078B83C5C1E2607BB993E05FF1AFF857FC2BFE15FF8A7FC5BFE25FF1AF09FDEBBECC1618580C2C061603DBD3AD04078B83C5C1E26071B038581C2C0E16078B834DE7603FD752EF39C7C1E26071B038D87E6E2538581C2C0E16078B83C5C1E26071B038581C6C2A075B936DF6DD2A5FF33E624C2C261613DBE7DD041F8B8FC5C7E263F1B1F8587C2C3E161F8B8F4DE6636B19B5A895DEFBAA3AF0722C4E16278B93EDF37E8297C5CBE265F1B27859BC2C5E162F8B97C5CBA6F3B2C74A31B198584C2C26B68F1B09EE15F78A7BC5BDE25E71AFB857DC2BEE15F79AD6BD1E6F32DB0DEF2AC6C66263B1B17DDF51F0B3F859FC2C7E163F8B9FC5CFE267F1B3F8D9B47EB616B765B1C0CC626631B398D9FE6E2738599C2C4E16278B93C5C9E26471B238599C6CEAF715D7B555BC2E8B95C5CA6265FBBC9FE065F1B27859BC2C5E162F8B97C5CBE265F1B269BDEC3FAAFCA13E005F5F8CA1C5D0626893DC5470B5B85A5C2DAE16578BABC5D5E26A71B5B8DA64AEB6C89E37DB6A7F7C6BE06E5BE269F1B4785A3C6DCFB7141C2D8E16478BA3C5D1E26871B4385A1C2D8E3699A3DD2E0EC717523E649BE289B71DE36871B438DADE6F29385A1C2D8E16478BA3C5D1E26871B4385A1C6D6A47DB84C24CA42796164B8BA5B56F96DCD236EF29785A3C2D9E164F8BA7C5D3E269F1B4785A3C6D2A4FFBDDAA782E1E8B5571D4917C3D14A616538BA94D7253C1D5E26A71B5B85A5C2DAE16578BABC5D5E26A0771B5D56EBBA978AD165B8BADC5D6F67F57C1D7E26BF1B5F85A7C2DBE165F8BAFC5D7E26B93F9DACD627BD8D4520A378B9BC5CDE2667BBA97E061F1B078583C2C1E160F8B87C5C3E261F1B0E93CEC72B72DF8D51E2C2C16160BDBD7AD04078B83C5C1E26071B038581C2C0E16078B834DE760CBED6AF5FAAD2D7C64162B8B95C5CAA6B8A7E069F1B4785A3C2D9E164F8BA7C5D3E269F1B443785A3E308BA9C5D4626AD3DC5470B5B85A5C2DAE16578BABC5D5E26A71B5B8DA64AE765754F5647D7CFA362B31B4185A0C2D86B6CFFB095E162F8B97C5CBE265F1B27859BC2C5E162F9BCCCBFEB6CB36C7C7A53EEF53B1C2CE6267B1B3D8D99E6F29385A1C2D8E16478BA3C5D1E26871B4385A1C6D4247BBCA36A7DC1F9FFE5CEBBEA7828FD2E26A71B5B8DA04B7159C2DCE16678BB3C5D9E26C71B6385B9C2DCE3695B3FD4BB62E562F1FF2F5635EDF60EAC3942F185B8C2DC61663DBFB5D055F8BAFC5D7E26BF1B5F85A7C2DBE165F8BAF4DE66B57D9334616238B91C5C8DE7E1BC1B9E25C71AE38579C2BCE15E78A73C5B9E25C5339D7EFB7D90AE78A73C5B9E25C6FBF8DE05C71AE38579C2BCE15E78A73C5B9E25C71AEC99C6B99ED3EBDCB9F8A7A0EEAFC98584C2C261613DBEB1D053F8B9FC5CFE267F1B3F859FC2C7E163F8B9F4DE767B7871D2E16178B8BC5C5F6701FC1BBE25DF1AE7857BC2BDE15EF8A77C5BBE25D9379D743B1CC5E11B0DB6E2A7E83071B8B8DC5C6F67C4BC1D1E26871B4385A1C2D8E16478BA3C5D1E2685339DA1FF26CB5FFB4C8CA73D1585A2C2D96164BDBF33D054F8BA7C5D3E269F1B4785A3C2D9E164F8BA74DE569DFAFB3E75AC17CC836C5535EF193B2385A1C2D8EB6DF3B0A7E163F8B9FC5CFE267F1B3F859FC2C7E163F9BD8CF3EEC0F4B7E4616338B99C5CCF6783BC1C9E26471B238599C2C4E16278B93C5C9E264D339D9F56153FC3BE38B8C71B238599C6CBFB7139C2C4E16278B93C5C9E26471B238599C2C4E761827BBD8AED7F96689AFC5D7E26BF1B5496F2EB85C5C2E2E17978BCBC5E5E27271B9B85C5C6E3A97BB5BE5B5F87C4D7FFCAA52BE1F0A7B8BBDC5DEF67F57C1D7E26BF1B5F85A7C2DBE165F8BAFC5D7E26B53F9DABF168F6556F2615ABC2C5E162FDBCF9D04FF8A7FC5BFE25FF1AFF857FC2BFE15FF8A7F4DE75F37BF64CFBC168B7FC5BFE25FFBB993E05FF1AFF857FC2BFE15FF8A7FC5BFE25FF1AFE9FC2B3FCB8379C5BC625EFBB88DE05C71AE38579C2BCE15E78A73C5B9E25C71AEC99CEB76C1B73CE15E71AFB8D71E6F2538581C2C0E16078B83C5C1E26071B038581C6C2A07FB21CFAA43C97B8731B018580C6C3F7712FC2BFE15FF8A7FC5BFE25FF1AFF857FC2BFE35B97FDD6D4BDE448C8BC5C5E262FBBC9FE065F1B27859BC2C5E162F8B97C5CBE265F1B2E9BCECB2C8F0B078583C2C1EB687FB08DE15EF8A77C5BBE25DF1AE7857BC2BDE15EF9AD2BBF259580C2C061603DBEFCD04178B8BC5C5E26271B1B8585C2C2E16178B8B4DEF62BF59AE8B4D51ED4B3C2D9E164F8BA74D786BC1E1E27071B8385C1C2E0E17878BC3C5E1E270D33BDC7745B5CB37155FFD84B7C5DBE26D7BBFA9E06A71B5B85A5C2DAE16578BABC5D5E26A71B543BCFBB8AE8F9F93C5D4626A31B5BDDF53F0B4785A3C2D9E164F8BA7C5D3E269F1B478DAF49EF6A13E41BEAE651EAE16578BABC5D5F67E57C1D7E26BF1B5F85A7C2DBE165F8BAFC5D7E26BD3F9DAAACA9EF377F953514F021FAEC5D5E26A71B5FDDF53F0B4785A3C2D9E164F8BA7C5D3E269F1B478DAC49EF6873CAB77C6CFE267F1B3F8D91EEF277859BC2C5E162F8B97C5CBE265F1B27859BC6C2A2F5BFFB71630AF638B95C5CA6265B1B2FDDD4E70B238599C2C4E16278B93C5C9E26471B238D9644EF6502B9863E6D3D67859BC2C5E162FDBE70D05378B9BC5CDE26671B3B859DC2C6E16378B9B4DE5663F3E5675B1E7DF8C9C89E8C4CA6265B1B2F6CD925959F56E828FC5C7E263F1B1F8587C2C3E161F8B8FC5C726F3B1BBA3D2AB33F30D50F859FC2C7E36E15D055F8BAFC5D7E26BF1B5F85A7C2DBE165F8BAF4DEE6B3F1EF68BED3AC7D4626A31B598DA7E6F29385A1C2D8E16478BA3C5D1E26871B4385A1C6D32475B3E679BE2DFBCE518378B9BC5CDF67C3BC1C9E26471B238599C2C4E16278B93C5C9E2645339D98B94AAF0B1F8587C2C3EB6AF9B092E16178B8BC5C5E26271B1B8585C2C2E16179BCEC5EE8B5ADA6161B1B058582C6C2F7712FC2BFE15FF8A7FC5BFE25FF1AFF857FC2BFE359D7F7D59D7D2EE6FDB7DB1E0E3B1B8585C2C2EB6CFFB095E162F8B97C5CBE265F1B27859BC2C5E162F9BD8CBFE942FB69B45B12AF8902C9E164F8BA74D755FC1DBE26DF1B6785BBC2DDE166F8BB7C5DBE26D9379DBFA51C1CC626631B398D97E6E24B857DC2BEE15F78A7BC5BDE25E71AFB857DC6B32F7BACAF869595C2C2E16179BE886829BC5CDE26671B3B859DC2C6E16378B9BC5CD2673B365B6D89F84675EE265F1B27859BC6C7FB7139C2C4E16278B93C5C9E26471B238599C2C4E761027BB5DF10550B859DC2C6EB6E75B0A8E16478BA3C5D1E26871B4385A1C2D8E16479BCED16E17F9F2506265B1B25859AC6C5FF7123C2C1E160F8B87C5C3E261F1B078583C2C1E76000F5B9757F1E3B25859AC2C56B6E75B0A8E16478BA3C5D1E26871B4385A1C2D8E16479BD4D156157E163F8B9FC5CF26B8A1E06671B3B859DC2C6E16378B9BC5CDE26671B3C9DD6CB5DB6E2ADE698C9DC5CE6267FBBDA3E067F1B3F859FC2C7E163F8B9FC5CFE267F1B309FDECE77C93BD6260269A132B8B95C5CADA374B6965AF37135C2C2E16178B8BC5C5E26271B1B8585C2C2E36958BFDFBF19D8075E24D56F0ED4F18598C2C46B6D7FB095E162F8B97C5CBE265F1B27859BC2C5E162F3B9497E57DC6785A3C2D9E36D57D056F8BB7C5DBE26DF1B6785BBC2DDE166F8BB74DE56D4F3597D98A2F83C2D5E26A71B529EE28F859FC2C7E163F8B9FC5CFE267F1B3F859FC6C3A3FBB3A09BDFAC1D96E70B3B859DC2C6EB6C7FB095E162F8B97C5CBE265F1B27859BC2C5E162F9BCECB9E5E41F9BEDC1E765859AC2C56162BDBDFED04278B93C5C9E26471B238599C2C4E16278B934DE764AB93A47AD81F962F5859AC2C56162BDBE3FD042F8B97C5CBE265F1B27859BC2C5E162F8B974DEE650F8FFFCA177C6216378B9BC5CDF67B47C1CFE267F1B3F859FC2C7E163F8B9FC5CFE26793F9D9A2FAE59BAACAAB6A5D2B3CEC2C76163B8B9DEDF386829BC5CDE26671B3B859DC2C6E16378B9BC5CDA672B30F8B4FF9F2B0E2E779F0B1F8587C6C4FB7121C2C0E16078B83C5C1E26071B038581C2C0E3699835505154616238B91C5C8F67A47C1CFE267F1B3F859FC2C7E163F8B9FC5CFE267D3F9D9BAAA5704CC4471626431B21859FB66098DECE5568283C5C1E26071B038581C2C0E16078B83C5C1A673B0A752DFE54F453D0905BF2B8B95C5CA62657BBFA7E069F1B4785A3C2D9E164F8BA7C5D3E269F1B4C93CED6ACB773D6163B1B1D8D81E6E2338579C2BCE15E78A73C5B9E25C71AE38579C6B32E7BA3BDE02725E84C5BDE25E71AF3DDD4A70B038581C2C0E16078B83C5C1E26071B038D8640EB63EFC627F287947316616338B994D7957C1D7E26BF1B5F85A7C2DBE165F8BAFC5D7E26B93FBDA0FD90E438BA1C5D06268FBBB9DE06471B238599C2C4E16278B93C5C9E26471B2C99CECE1B15A94C58E976671B238599C6CBFB7139C2C4E16278B93C5C9E26471B238599C2C4E36A593DD67FCFC0E36161B8B8DEDEF5E8287C5C3E261F1B078583C2C1E160F8B87C5C3A6F3B0BBDDEAA53627C5E7BC7CC1C8626431B218D93E6F28B859DC2C6E16378B9BC5CDE26671B3B859DC6C5A37FB535ED756F1133C9859CC2C66B6CFFB095E162F8B97C5CBE265F1B27859BC2C5E162F9BCACBFE9C55BF6061B1B058582CECEDB7119C2BCE15E78A73C5B9E25C71AE38579C2BCE3599733DBD58B2DB96BC048B7FC5BFE25F7BBB99E06271B1B8585C2C2E16178B8BC5C5E26271B1295DECC3E99B4571B1B8585C2C2EB6AF9B092E16178B8BC5C5E26271B1B8585C2C2E16179BCAC5FE57B63AD4F5E261F1B078583C6C4FB7121C2C0E16078B83C5C1E26071B038581C2C0E3699833D4D7D3DFEFC6A2C5E162F8B974D7653C1D5E26A71B5B85A5C2DAE16578BABC5D5E26A7B72B5DF54D576519C52BD1DEC9BC5627BD85C5E4CB936A1AE5CD3A0DF6D965FFCB45D5D55DD5B83CE153DE4ABA7DFE9973E1C56FB62B72A16F569FEF4E5EF7FF7BB3FB45A75DD573B8CB271EB9ABAF3FFDEDAF6AD927D91ADBEDD6EAA7D99D52D6F8BE862B32876D9CA5C99161EA8BA8FFDBF6CAC5F7997EFF2CD514E5B6A0E49E9807CFB2497849A33F0F5E7EBAF1A687183C8ACCEFFF973563E9F5EA7BBDC5CFE5A547B1FAAB45D4CE86A85A858F883DEC4AF3F6E5E8DF817DF2CF62796FB36AB16D9B23DB6F5DC2CE3CEA71619705A7D414A1CEB8D1A00CF4145879CC36E1D47C1B87EA30CE9F084C02DE6D63B0264BBDC82C5A2F39FA71A9C37DA6BB0E561BE1BCC354A168AB3A6701C0959FBE273DDF377F953519BA5C65394636B45DBB9341CD9C366A320AD254E514C3A00373BCE150DE15198F826288B2365433541FC6C58E787C49DA3D6DC13F9A01D9FE1979FF3B2CABFFB9C8B791EC87022155CC680B9F0B9A9B84932B9095873E37079501D83B7BB42561A63AB758470B5BAC2F5D0DF2122F50E4886E2F83CBC5AE5E5F3CBFBCDBE2EA4CC5E5F9793C0C6D673A9B07284CD8599ED254E929FED809B1B4BCB86F0188C7D1B94A5F1B6A99A10F636ADF343E2CE516BEE897CD08ECFF0BBDDB65EBC9663B4DB0752A165BA3E173237D436491637806A6EF42D0DA663107647B84A636AA58C108A5616381EF6BBC3A256BE600C0A23DE5DBD9B146F6D3F9803555ADC2C0959AD71FAC4AC826ED6042D10C6A313763C9C4513F7B99C68023F2F0C80C5DD63D7D2960960777CC23F2C8BBDA457B45BE751B165B83C17566F973649326F036A6E1C2E0BA263307637A84A23EA661521FCDC8CB73FE4778642B576B9E01B9D69EB1B73B19041B2CA51946DB52B33A156B5AA29B2AA0A9E9911AA08388E40A3F1B014C6A0E70202C8F31C6A7C78EF0267976245226B7C7A2C3659F922841F95B3A848D12ECD8521D5B22649912A80E6C691322039064BC643531A4D9E2B08E1C973ACF921BE13B45DEB9509B0F1D972BB7C7928F6425E9CD54FA302A675712E9CA9173649D6D4813437DE9403CD31B8B30B44A5B1E7B58610FEBC46DB1EEA3B425EB36AA9701B9F4B0F9BE54A0A932A675121A35D9A0B8BAA654D92435500CD8D416540720CF68C87A634EE3C5710C29CE758F3437C2768BBD62B1360A3B3E5B7D92E7B2C5675CF1FF6D93E97F3111DC7C19424CEB89990AAABC62932AC0B7433A35BF1301E81886F85B3305636971340D1E68501B0B87BEC5ADA3201EC0A20FC32FF719509F9364BFD341AAEF48BB3E173ADB06992B806A4D931B718688EC2D11D202A8E982F3504B1F125DAF650DF11F29A554B859B082EFD39CFD672B8B4799A166CD48B33E252A5B0A972A902A41972A910688EC4A5D11015C8A56F350472E95BB4EDA1BE23E435AB960AB7F1B9F4D3F1A772DED7965A089BB6CEA342C770792E8CDA2E6D929CDA06D4DC58551644C760D66E5095C6ADCD2A42D8B5196F7FC8EF0C856AED72C1373ED3AEB2420AC9368FA2C246BD32176A55AA9A24AB2AE0991BA14A80E318341A0D4B690CFA56400879BE851A1FDEBBC0D9A55891C812438F82BE2DD17824236EE6F90D89E6EAA64C9FB3FE564491701D915627FF1D887A2111346BFCDEC3F6C53BC465AB09A2112980968B4DB1C856EFD7BB32AFAA42CAEFF1DACFA521CB1E361B96B696384DAAB6026E767C2D1AC2A330F74D501647DF866A8238DCB0CE0F893B47ADB927F2413B3EC36F97F9C34B25E715E0D6795460192ECF85C9DBA54D92C1DB809A1B73CB82E8184CDD0DAAD218BA5945083337E3ED0FF99DA150AD5D2EF80430ED7A7D386A85BD1C1B6D3A92062363C46C28D754DD3459D704AED911AF40B88E42BF5D612B8E81D5428248585DE27CF8EF1297AD268846A4345AFEF5905752BE8CC3713217BAB4C07972B55AE40C285B05DEBC995B2294C7E7F17848CBA6F3733DF1AC7E5E19020D106CEDDE14202C81FF775979FAF5C177F953B12944D973FBD174D0B922E723011C554E540338C0373F11201FCEE3C8801B612D4F07180B0A1302C6A541F000C7AE0E4E02C922E4C0B6122602B403B530D6BA3E23C2D76B9B2ACDEBA09A21B98B82E94844DE05AE02E9FB5A4620695F17381EF6BBC3A256BE600C0A20DEFA7EBDDB7FC8765278573F8F86A1F6E5D9B06EABB469926E0B50B3E35C51101D85713B41551CE136AA08E2DB46BCFD21BF3314AAB5CB059F04A65D8A32B8DA7174F8E857E743B3CB39585B1D4CF3235939F01C87623BC0541EC32EA30CED35DCFA70DF15FE94C2C5A24E02B556B9981F73520FA3E346BD361F5255EA9A28A52A209A1FA1CA80E538641A0D4F7954FA56421891BE055B1EE6BBC15CA364A13893409EF5F2851CF6544EA36346BB381FFE540B9B2881AA409A1F834A81E6381C1A0F5179247AAE218C45CFD1B687FA8E90D7AC5A2ADC0470E9E7BCCC9EA57C95A6761A0D36FAC5D970A956D834B95403D2ECB8540C3447E1D20E1015C7A5971A82B8F4126D7BA8EF0879CDAAA5C26D742E7D97EDB3EF56EA0FA68F4AA78603299B1BAFCF84544DB54D91574DA09A19B58A83E90804DB15AEC238562D238066D5058E87FDEEB0A8952F1883E3136FFDA82FF6F9F27D551D843859E39154249923E642BFC6EA2649C04670CD8D8225C2750C1AEE0C5B6944AC151242C5DA12E7C37F97B86C3541342205D0F27122A4F071F32C1A82D44BB36160A5AC6952AF02A0D971AE08488EC2B2D1D01447AF6F1504F1EA5BACF921BE13B45DEB950930216C79FA58EE46CE33C8E64319E06388991591B6EB9B2EA3B641364B6A1508DBD1C8B61B7C45B26EB39460FA6D2EF2C0E06E316A6885707C0A21ED0FF9BE2C1692185B3D9101537AC0ACB85A2B6EBA44AD016B962C2D0AAAA3F17307C88A24E74B1DC1CC7C59E17AE8EF10917A07244351080F8BFA5506E3918CCFBBCCF37718CCD54D978B67FECB0B22E13AE273D393FF9105BD908867AA8D3FABD0BE7887B86C3541342285D0F23FAAFC619FED25BD31DA7A2E03B2CC61B362696389D3A56A23E066C9D762213C1A737786B248FAD6AA09E6706D9D1F12778E5A734FE483767C862FB2E7CDB6DA1F9F30D86D4B29FC6E39950A326BD05CB8DD56E02499DD06B4B9F1BA5CE88EC1E9B740581AA3B76B09E1F3F62A1F14EE18A9A66E4887E9F81CBE5D1C8ECAE343B6299EE43C7F6E39950A2F6BD05C38DC56E02439DC06B4B971B85CE88EC1E1B740581A87B76B09E1F0F62A1F14EE18A9A66E4887A9180EBFDCF2659178EB58468019A26646E3ED0AA7CCE36DB0CD94C845C277442AEF0663A15CDE2C2682CC9BCBBC70B86BBC1A1B221EADA353FA77ABE2B9782C56C5F15482DED8663F9792C315361356779438455A77006E66BC2E1CC22330FB8D501646EDC66A02B8DDB8CE0F893B47ADB927F2412B8BE1ABDDF1B7380452BC7A303BD4F4B83992BC56E3E4595E03DD9C695E228CC726FA0E7096CCF4977262A9FEB2300016778F5D4B5B2680DDF1097FB3D81E36F5BC08A179FD382AB2DA57E742E9ADCA2649E42D30CD8DBE25C1730CAAEE04536904DD282284961BE1D687FBAEF0A7142E167502A875B9DB16523E60A69F46438E7E7136BCAA15364D5AD580343B561503CD5138B50344C551EAA5862046BD44DB1EEA3B425EB36AA97013C0A5E576B57A7DE95CD20BCFB6636940B246CD86666D154E936F6D609B1DF10A86EF28547C0B8CC57172BB9820726E2FF3C2E1AEF16A6C8878B48AA27451AF345BCF6545D95C5F67B69738755A9FF9ABCCB2213C32B3CFE02566533591DC6E7981D91C71D7A835F7443E68C767F85D516D97F9C7A76FB3520AB99B8EA4C2CB1C31174A375637493637826B6E442E11AE63D07767D84A636EAD9010D2D696381FFEBBC465AB09A211393E2DFFB6CB3655FDEFFA6C4FC54A0A335B4EA5A2CA1A34177EB61538498AB6016D6E2C2D17BA6370F52D109646D7ED5A4218BBBDCA07853B46AAA91BD2612A81C357D9E6F4978F4F7FCE37F95321E52571C7C974983902E7C3E7F62227CAE976E0CD8FD7A543791C7EBF0DD2F238DE544F18CF9B56864003045BBB3705088FCEFF7FC9D6C5EAE543BE7ECCCB1F6A8C6ECB1719F4EF389892C4193713F277D53845EE77816E66D42F1EC62310FFAD7016C6FBE6720268DFBC300016778F5D4B5B2680DDF1097F953D0B61F8C649543C2917E6C2E1CDA22649DA4DE0CC8DA5C787E2183C1C0B4969C4FB7AFE10A67D8D343DB47780B073A51221353A1F7EBFCD5632F8B079126557F5C24CF850296A8A7CA80067667C28008A23F061342485F1E1DBF903F8F02DD2F4D0DE01C2CE954A84D4F87C5866BB4FEFF2A762531CFF2A841ACD875281638B990B615AEA9B24775A4036371A950ADB31C8F506F84AE3D956292194DB5AE481C1DD62D4D00AE1F81440DADBC34E0A55378EA2A148B9321B5A6E56354D326E826776142C008EA3D06D2C2CC591EC6B0141D4FA1A6A7C78EF0267976245226B7C7A3C14CBECF547B2047D3F88ED542A7AAC4173E14F5B8193A4521BD0E6C6AA72A13B06D7DE026169B4DBAE258481DBAB7C50B863A49ABA211DA6A373F80F79B6DA7F5A64E5F95E2F83C4ADC7525238A26642E3F60AA7C8E376B0CD8CC845C377042ABF0DC6C2B8DC544C00999B9679E170D7783536443C5A47A7F4F7EBECB9D83C7FC836C593986FE2B61C4A49608D990999DBEA9B2295DB40363322170BDB1148FC16F80AA3F076290104DE5EE481C1DD62D4D00AE1F89442DA0FFBC352C827854D2732614A0B981757ABC54D98A85560CD93A52541753C7E8E87AC4C723ED711CECCE715AE87FE0E11A97740321405F0F0FAB029FE9DC97993B6E9441A944C01B3E1614371D3E46103B066C7C3E2A03A0A0F7784AC381E56EA08E2616585EBA1BF4344EA1D900C45613CBCD8AED77546B1AC6C3A9F0366E6F05932B6B1D4E9F3B71190B36673F1101F9DE93B435D34EF6B5545AB006D7D386440B9433DE8BD9A0ED805288BDD2A3FFE68D7E98FC777EF0979CF9BE3601A041D71B31111F61AA7A91EECA09B9D6C100EE35184C26D7016A7104CE5044903D3C20058DC3D762D6D9900764727FCBF168F6526E5FBB7B5C3281BB7AECD84CCF5BAA648E03A886646DA62603902397781A73042BE961040C2D760CBC37C37986B942C146702C873F34BF62CC4216B87D110A35D9B0D79AA754D933C5510CD8E3C85C07214F28C87A738F23C9710449EE760CBC37C37986B942C146702C853CAC7AF9A27D1B032C30F5A29454D9330E7FB912A01501C8527A7FD89A9B7F3073164FBB35197BFCD1E61E74A25426A7C3EDC2E04BD854B3F8D0A95D6C5B970A35ED824F95107D2DC38520E34C7E0CA2E1095C697D71A4238F31A6D7BA8EF0879CDAAA5C26D742EFD9067D5A114F2C4AC761865E3D6B59910A95ED714795407D1CC68540C2C4720D12EF014C6A1D7120228F41A6C7998EF06738D9285E24C0E79EEB6A59067688D4732A3478D981B9D2AD54D9A541570CD955A25C1754C9A8D86AD54B27D2B248672DF96381FFEBBC465AB09A211298096974526858E1B47D1F0A35C990DFD36AB9A26ED36C1333BBA1500C751E8351696E268F5B580203A7D0D353EBC7781B34BB1229125821E25BD80DA3E4F0B31337D11D550DA542973DE2FA40A83E8480C3AFD9753952A02B9D4FC92AA76E5AE50A8D62E177C8298F69BE5BAD814C7CD24F2AEF9741670D98267C7C99642A7CDD01620CE96AFC5437B542EBF01E26299BD555314CFB756874205641BF441BB4B5381B720EDF0AEA8EA6C527E17D97E2E0BF4DA61B3530AAD12A7AD115A809BAD3A1009E151154127288BD5028D6AA25440639D1F12778E5A734FE4835610C3FF94FF7A10F3138BD663599F6CD2A26647EF7A85D366771D6CB3257781F01DF989FB78188B65F66B31914FE39F9779E170D7783536443C5A0551FAC33EDB9FBEEE521AA9B70E66C199216E76C4DEAE71DAD4DE06DD6CC95D288C4725F86E70164BF1CD72A248BEB9300016778F5D4B5B26805D01845F55D973FE2E7F2A3685A497F62DC7D290668D9A0DD5DB2A9C26D1DBC0363B9A170CDF5128FE16188B23F8763141F4DE5EE685C35DE3D5D810F1689542E93FE4350A4A5174AE1EC9842D3D625E34AE5537610AD7C0354FFA9605D7F168BB036C6552F6A59070BABE2C713EFC7789CB5613442372745AAEFF5B6C9E1F5EAA7DBE96C1CAA61329BB9B0366C2C9C6E2A648C94660CD8C91054275043EEE0C596174ACD511C0C6DA0AD7437F8788D43B20198AE3F3F0615F9E5CFDC7528C3F369F49859325642E6C6C2E6F927C6C06D8DC18592664C760E5EED095C6CB7A2521CCACAF7143E04ED1D9EE836C608ECED21F1FAB7A36047DD8DC70206573E3F59990B3A9B62932B3095433A36571301D8190BBC255181BAB650450B1BAC0F1B0DF1D16B5F20563707CE2AD0FF4FA9934616F09731C4C45952B6E2E84ECA87192C4EC00DDDC085A3A8CC720EC1BE12C8DB88DE58410B87161002CEE1EBB96B64C00BB7208FFE361BFD8AE857C4B8BED54669CB582E6C6F37A819326791D6873657879D01D93DBBB40582AB15F6B8961F5EB2A1F14EE18A9A66E4887E9F81C5E3E679BE2DF929E2E379C48859531602EBC6D2A6E929C6D02D6DCF85A1E54C7E0E9AE9095C6D16A1D21FCACAE703DF4778848BD0392A1383A0F5FE05FC960E1F67994BD4D9767C2C086D2A6C8BF0640CD8C7D85417404E6ED085561BCAB5411C0BA4ABCFD21BF3314AAB5CB059F00A6DD17B9942F27D30EA34147BB361B8255EB9A26BBAA209A1DB50A81E528A41A0F4F718C7A2E21884ECFC19687F96E30D7285928CE0490E7CBF19BCAFEB6DDD7709742A1862369E83146CC864E4DD54D93544DE09A1DB50A84EB2834DB15B6E2C8562D248872D525CE87FF2E71D96A8268444AA1E59FF2C5B6AE7555087A39D7793413BE6C91F3A26B4B9513A66D0BF8E649DFB2E13C1E9DDF006B99B4DE2A289CDE5B4B83E0018E5D1D9C0492C79703795989E17FE52C2AB2B44B736178B5AC4952BA0AA0B971B80C488EC1D2F1D09446CBE70A4278F81C6B7E88EF046DD77A65026C7CB65C65E23EB26C3E930A1E4BC85C58D45CDE24D9D40CB0B9B1AA4CC88EC1B2DDA12B8D6DF54A4258575FE386C09DA2B3DD07D9C01C9FA5CBAC7EF88F7F90F2D59BA613A9803206CC859F4DC54D929D4DC09A1B37CB83EA18BCDC15B2D25859AD238493D515AE87FE0E11A97740321465F1705D8B402E6E9CCA0E2925688E9CDC2C70F2BCDC04DA9CB9591674C7E6E858084BE6E9D75A62B9FA75950F0A778C545337A4C35400876F17F9F2508A216FED381AA05A576743D77A65D3E4691D4CB3236841F01C8592BBC0541C175F8B0822E16BB8F5E1BE2BFC29858B459D246AFDF59057523E666C39950D495AD0FCF8562D70E2B4AB026DBEEC2B0DBAE372713C84E552F2B99638663EAFF241E18E916AEA867498CAE0F0AA92C7E0AD33B5A1650899137BB7CB9B2C77B7013647E69607D9B158BB1B74257276B39250C66EAE7143E04ED1D9EE836C60CA61E96A57EF24E9A9ECF6A1CCB0D263E646D45A7D93666A0D6473A56A69B01D93AC3BC0572A5B5F4A89A1EBCB220F0CEE16A3865608C7A704D2FE9C6FB28D982F0F6B9D47C753EBF27C585A2F6DA204AD036A7EDC2C09A2E3307217A8CA23E36B15613C7C8DB73FE4778642B576B9E01B9D69FF7E74F4F53F375921E57D5EC62329DB5B226642B9E6EAA6C8BA6670CD8C7845C27504FAED0E5B610CAC171240C2FA12E7C37F97B86C35413422C5D1B2A0E7AE9D4773E26B9ECF63BBAB9C036DCFFA39ED49C059009D4FFE596E5B411DE8DDF88CB73D081CDB3B3809248F2E074E5B95D94AD47BCD2C87521258636642FEB6FAA648FB3690CD8CF0C5C2760492BF05BEC2E8BD5D4A00B1B717796070B71835B442383E0590F62ADBE74B49DFB26D3C92862A63C46CE8DA54DD34C9DA04AED951B540B88E42D35D612B8EA4D54282285A5DE27CF8EF1297AD268846A4005A3E6989EFCBED61278595DB27D2D0640A980D271B8A9B26251B80353B461607D551F8B82364C5D1B15247101B2B2B5C0FFD1D2252EF8064280AE0E1EA34060FFBC3F2450A111B8EA481C918311B2A3655374D2E36816B76642C10AEA3D07157D88AE363B59020425697381FFEBBC465AB09A2112987960F8FFFCA17625E6A361ECA8C293D666EE4ACD537697AD6403657829606DB3149BA037CA5D2F4A59418A2BE2CF2C0E06E316A6885707C8E4FDA45F54BFDD7BCAA5E7F935A04671BCFA4E2CA123217C636973749C236036C6E7C2D13B263B07577E84A236BBD9210AED6D7B82170A7E86CF74136304767E987C5A77C7990F25B58FA69D49D5B1767C2C9ADC2A6C8C62D20CD8C8705417304EEED045161ACDBA821806F1BD1B687FA9E90D7A85A2ADCC6E75215E84228D57C282D8125662E046BA96F923C6B01D9DCE8562A6CC720DF1BE02B8D835BA58450716B910706778CD1562B84E3530069FF7AC8C57CA9A77E1A6D67FDE26CF8592B6C9AC4AC0169768C2C069AA3707007888A23DF4B0D41AC7B89B63DD47785BC6BD552E126804B4F787F973F159BD32F4C4B2155CBB14C294C51B3A1595B85D3E45B1BD86647BC82E13B0A15DF0263719CDC2E26889CDBCBBC7000AF7A43C4A3757C4A5F6D85BC77AB79127557E5C25CB8BA59D424E9B9099CB931F2F8501C83776321298D6A5FCF1FC2AEAF91A687F61E10F656A944488DCF87BB7C51AC7329CE563B8DBA73EBE25CB8512F6C92FCA803696E1C29079A63706517884AE3CB6B0D219C798DB63DD4F784BC46D552E1363E97EECBC3627F28E53D616C3F989AC4153717B275D43849DE75806E6E142C1DC66310F38D7096C6D1C67242E8DAB830001660D7DC960960570EE17FC8847CCDA5E944667C290173E3F666719326F526B0E6CAE672A03A267FC742562A71BFD611C3D8AF2B5C0FFD3D2252EB8064288ECFC387C76A51163B418EDB7022757763C05C78D854DC2479D804ACB9F1B03CA88EC1C35D212B8D87D53A4278585DE17AE8EF11915A07244351040FEF33391F3ED28FD30291767546F4AB563655EE55C13443E21503CF9128371EA602F9F65C4420D99EC3AD0FF77DE1AF59B858D409A0D6DD6EF5523FEAC5E7BC14F2530EE63369283287CC86698DE54D936E8D009B1DE78A84EC28ECDB19BAE22858AB248887B5356E08DC2B3A5B7D900D4C212CADFFB8BB009276FDC8B525625614DDEDC7AD2532B40EAE5912B430B88E46CF5D602B929DAF850493F37589F3E1BF4F5CEA4D108DC8D169F9E7ACFA45061B374FA2ECAA5E9809F72A454D917215E0CC8C69054071045E8D86A4303A7D3B7F008BBE459A1EDA3B40D8B95289901A9F0F4F0CBEDB96423C6AFB3C2A5C0C97E7C290EDD226C9936D40CD8D2D6541740CE6EC065569FCD9AC2284459BF1F687FCCE50A8D62E177C2298F6E1F4662E394CAB9EA70520FDF28C98562B6DAA4CAB016A864C2B08A223316D07A80A64DA4B15814C7B89B73FE4778642B576B9E01B9D69FF2B5B1D6AEC0BE159FD34CACEED8B33E1D856615364D8169066C6AF82A03902B77682A830666DD410C0AB8D68DB437D47C86B562D156EE3736951D5FFF8B1CC857DAAD67E2E154A8EB0B930ADBDC44972AE1D7073635FD9101E83916F83B2346E365513C2D2A6757E48DC396ACD3D910FDA8119FEBB7ACDFEA55EB3AF57E4E5DB21BEDD2EF3BF1465B57F97EDB3C79A015AE03CAEAAC5CB5BFC378BC5F6B079D58BAFD71A0F7DF3E2F1D78ED7D99FBE5C3E6E6B78648F2B6D718BDF6D79DEA0E348F616E1CEF816E449AB2B9356563DC094548F09CBD9A2225BEE56A0E30CADD84E67F9392B9F4FF2F584D7E093E9CBC2CFA9AFF482655F7CAEFFA27DA79F0132C63833708CA15D0E6207B03D38F84861B0FE66F9392FABFCBBCFB97574F508E309F4A0B8B4D64618C3020E1058FC6A9597CF2FEF37FBFAAE5D5E3E5EDB3E8639CE780E73689783589BE2080E3E52608376BB6D4D226B3B38B400637E2D262AA7B509A6287FF62E65EF6A32B501C312E83FC835B6D359C2DAA245879F2AB04D8765B177DD39D4EBC6F46A484C426B0B0C41DED46105D7BC5D2CCCB55E2F99725DAF0666B015A75D77E50A2CA9D8646F9F616C27BB5E3326BA5E0E4D622D4B0B70A60B2C6CBB7C7928F696C155AE1AB33503C253590B6C857892061679D82C57B612AFD78CB9AE974393588BD3029CE9C20AFB36DB658FC5EAF8B77DB6CFED04640B349DC116DBE92CB66638A3C34F15DAA632FF71955944AD72D59CBA11109ECA5EBA1EE2491A5EE4CF79B6B61779B96ACB7709084FE52A520DF1240D2CF2D3D1D8BCAF1F7F4B99EA75634E352426A1B5584390377560C1ABACB0D57AB964CC75B91A98C15A9C7ADD952BAE2487606C87B8D2068B447D81AFE400616809F51EA436A08B6CF57EBD2BF3AAB2FA6D4B9CF920C6D02E07B1B7C51E1C7CA4C0066D97F9C34B659F73F5BA31BB1A1293D0DA004390377568C1EBF5E1D82DFB932FED10736E3D2A32B3BD78635CC8193AB5E0FAD164DF51AE910187B906773B4E607BB4F0888305376B97952743EA7BD2CE1E6A399525BAE3891C0D73C5C79C2DBC65DBCAD3A86680ED08CD98A89CAE56B4A2FCD943CBDE2CF2DDFEFC1DF086E4CA75735A252426A1BDE47690377570C14BE7A3DCBC6CC9B98C7884AFC18E62F5185FDEE0522BBBE76B5CB4A4BB5C0FCEE328518D70670C2E6F5F660B7B7DD7AB9674D780F0548E12B5104FD2D0223FE765F66C53C2CDABE67C8D80F054F622F5104FD2B0228F2F8E7EB7723C41A10798B2EA3151396D051BA3FCD903CBCEF7F9629F2FDF57D5C1F200B7438CC95B519199ADE59BE342CE10DA82E3CB93B6DA2FD7CC092F974393D8CB54039CE9620A3B31F2C60E6B43903DB71A179DDF5DBC2132EC2431EDF890EF4BDB73FFAD087BFA46505C5A770BF4B08003C481DCE159DA212E0C06BB147D816F00027C892534E820FFA872CF33D19638FB415AA15D0EE26E8B3938F848810D2AB2E7CDB6DA1F6175F9BC73FB40A628E3494C81F147B036C61A1A7898C0A66C178763173F649BE2C93E3BA628E3394C81F147B036C51A1A7898B8A65CDE5FECEE8A1AE63A891AD9E114BEC6186243CF13D69AEF56C573F1FA3290F36E6B89331DC612DAE520B6F6B882838FD4A141AEA7D86D81DEF3843FDD6E5E16D4A490A7DE9D0B7C47DB9CDED6989796E628978DC99588886CD6F2DB31BEBCA1A52E4FEF5DB155DAB86A4ED808084F652F530FF1240D2DB2DCAE56AFF714D76DC118663E8129B2C329EC8DB0C6869E27BE35CE1B8239CE779888DB816955487B826E068E78DFB97645B55DE61F9F8EAF465B7AD30A319EA1151599D9DA0C735CC819025BF0DB2EDBBCBE177FFB54D8DE2A638C321EC214187F046B3BACA18187096ECA2ADB9C5E9DF9F8F4E77C933F15B6DB8A2DD2721E7370B7E3389AE4088F385858B3FE92AD8BD5CB877CFD98973F14D57E6B7BB79C2DD074225B6CA7B3D81AE58C0E3F55609B56D9B3A52FE72BC694E78B61DB5B4B552E3B128515F3FD365B998BB95C31E5B85C0CDBDE568C7AD99128B09832DB7DF2BD946A0A326636C445E7B7166E8B0C3B49683BB607CB0B86D74BE684E7AB8119EC652AD75DB9024B3A14CBB7B7F53B649031CA98DC14187F046BF9D6D0C0C38435E5873C5BED3F2D6AB1F0F641227357CC61A69398233B9CC2D618476CE879C25AF37E9D3D179B67F75353A620D3314C71D1F96D2DB146869D24AA1D0FFBC3D242EDAD0847FA6B505C5A4F0BB4B0800384167F7CABCEBF1DEFCE6A4598736B417169EDC59BC2020ED0A5F8C5765DDBAC65702B5AF1FE73B596DC72C0B0A69917451F35B4A1BBD717924FCB8EF76ECB6DD716683E9739B6D359EC4D7344879F2AAC4D7F2D1E4BEBA76E9A174D899BD783F3D8CA6E45B8338696B7F9C5FABE8FE64573B2EBF5E03CF6F2B40877C6D0F26C9C79B9624E13C68E6F71F6927C3CA846F8B26D5DEFCC55AE1A736DC3DF8FDB88B516D70AF1240D2BF2439E5507DB5360CD8BA66CCDEBC1796C05B622DC1923CBB3BFFADA0E71260E7DDD555FE02DDBFF8AAB25D47B906591D94A3F5F32A73B5F0DCC602F51B9EECA155E926B36B5EBB684E1F3A944BBCA0C9951535C70FE6F96EBDAD61FBFC124A47C43B4FB448605DD8FE66F946D49E421639BF8AEA876B9F5D9004B9CFB4C4A689783F89BD50E0E3E52FC58395E503387F9901EFC829A6951C8C805BCA0E6080F3E94E7AD4EB640F771A2DEEC645EE66F51E0DB9D9C0BBC47ABAA5A2FFA9E523587990F638AEC700A7B7BACB1A1E7896ACD0F79B6B4BD03A11DE23842232A32B3A7157A5CC819C25A50FFF7F8248CE3237EAD0853F256505C5A5BF9E6B0800304167FD89727C47C2CAD0030C418F3B7C362935B9B60090C3A4658233E3E5679F9D9215FF400536E3D262AA7AD7863943F7B60D9BBFC55AFF86E8EB640E3412CB19DCE626D8B2B3AFC54916DFA78D82FB66B8B443346398FD20C8C3F82B735ADD0C0C30436A57CCEDCCF44B7228CF9F5A0B8B4D62618C3020E1056FCE5FBED2A73E9DA75535E2D2426A1AD685390377568C1FBC2AA2F9B17CDF9AED783F3D88BD422DC1943CB7B396ACABF6DF7D6571EDB21E6C47A5464667BD9C6B8903344B5E0F84AC26651AC0AC760DB431DC73144773C91A745B6F898B305B6AC9E206B8FAED78C89AF97439358CBD6029CE9020B5B655E49608831666E87C526B7166E090C3A4660238E9FA03D2DB1C9E3568431BB1E1497D6DA006358C0013A14BFB5BD19D318E53DC336ECCD98863541CDD8FADE8C698FF69E68BBC897D65727D4CBE6CCCD88886CF6C25B31BEBCD1A53A9E793346790E10FCBC9B614D401B029E75B347879CA8AAFC2D5163AC6750C362933B9B61080C3A4664235C6F62330539CF10FE16B6F6126F3342DEC0660DF61FE773BEB17F27B176DD92BA191293D0517A2BC89B3AACE0BF1FD152DF3F375961BB19B6434CB9DB5191996DC55BE242CED0AD058E41B087861C2778286C0B435B1430209E259E039E3E69591EDF0EEDB87F9A824C4731C545E7B7B5C61A197692D076ACB27DBE7419897688F9007A5464667B1B8C712167086DC1A9658EF779B722CCC9B5A0B8B4F6F24D610107082DBE3AFD5E82E3CDACED1073763D2A32B3BD01C6B8903344B6E0F0F8AFDCF6154BA620E7111A71D1F9BDADD023C34E12D88EA2FAE59BAAAA2588FDF55C438CF108EDB0D8E4D6565802838E11D688E356CB83CD752A574D599580F054B682DB219EA48145AABF9662A9D51064CC6E888BCE6F6D802D32EC24A1EDA8EFA15609AD5C35A76D0484A7B297AC877892861679FAF887EFF9357398F904A6C80EA7B037C21A1B7A9EC0D6ACB6965BDEE58A31E1F962D8F6D63295CB8E4481C5ECF24551DFF22C0535AF1A733503C253598B6B8578920616B92F0F8BFDA1F4C3D912683C8525B6D359AC0D7145879F2AB24DD66F3F6D45388F10F80DA85ABCB715DE6F413547FA4E7178547FE4B07D003DC2985B0F8A4B6B2DDE18167080F0E2F7F6A785D4CBB6ACFBD027859AC1AE82F7FEA7840C61DEE4BBDDEAE55DBE2A3EE7B64FCB1862CCC95B61B1C9EDE59B03838E11D308E7531CED107BFE88A737F405EE26043DB56109F51CE4E7ACFAC55CF9E58A29D9E562D8F6B6F2D4CB8E4481C59C2AB77F5A43BB6ECCA786C424B4166908F2A60E2FF8E174ABB317DCB86ECBDA088949E82A580FF2A60E2BB8F93BF2EDC4CA55534625203C95ADD0768827696091E69F1C6EA737C719CF600EED72106B331CC1C1473237A8F1FBBAD7C3693F34FBCFCB77039E7E01B6B1E4ED7CCE7825DFA9134BF38FCC7F71E951FBD257F65D2C3FAE7BDAC6F78BB95FA9E507B4C6FC13AFFF547FE3F5F8D09D7E1BDBD0ABB80DBCCDB3FCD06EB3899E9FCD0DD8D5FC93B98E1C9E9FBC8D6FBB8E305B697E6C86FD2C7CF2460F8BDAEB8E8D1F6E7736CBF603EF96222CE717D502DB0F0E07DCDEC296A6BFD3F97E90F9AD77C13FADDC6B1B6366327693E1C75368AB7DF3EB5E1259B0BF56F94D34FCC8B67FE0BD8B928FBAE3C7C65F9B16F2E3E13DB52B62B023960F3ED2325AEA19606B707061AE9A6436C8FA63EFFE410D5C9A7C5C1DBF57DF6C60F8CFDAF7DAC688018EDE64F03196DA6ACF607B964416ECAF557E1377A7AF155F4711B36F4DF2416F1F40ED98E97A925645CC74F8EAC18759403B3D736B8B0D2DCA518FF8D628EF6B8D1C4EC7DA6187D4F8FE5F430BDD6FE2EDB7955D8737689771875856BB6386DBB026B6E8807AA7D0CAC3B2D8473A66CF92E423DFCAAFF6CB7039459B22E63A78F1E0E33C762B3D336B090D2CC85E8BB8A6D4B8BFFEECA177021DD1A9874F49AD6CA25DE9B925E1D316B46EE8411BBE6DEEC93244F90F6F3CB794B28B4DE33B80FD13E4084F3E424A6EB52BDAA5BEDB123145410B071FA3315AE7992443584001E6B3CB297EBB7C7928F6E186D0BD20F94869D9D5E6B42EF6DF9E88C10A5C3AF8688DD742CF801903830AB1D520AB1187CD721531688EF0E463A6E4561BA35DEABB2D110316B470F0F11AA3759EC132840514603EBB98E2BFCD76D9EB8FD3B6BE3AD73B5BC16B530F9AE320CA96CEB8A4AD0C9FC70EBB0C3D9C92DBED9E61EF9AD8A203EA9D442BCBFCF815681193EF5A907EDCD5EC5AA7F48BFDB727669AC3960E3FC2A3B5D037A1A6C0A0426C35886BC4CF79B68E1A35FB822146AD99BDD51EF562FFED891BB590A5638CDA482DF48F5A3B30A8105B0DB21AF1E9F8518BF78D6FBCF70F9B6749F2716BE5579B64B89CA24D114317BC78F0B11BBB959EE1B384061664AF455E535659113181F6E8E4C3D74CADF645BDD2734B22A62D64DDE0833678DB3C93D58EF21FDE786E6165C7BDE52C60D55003657FB38E252251CBE2074DE49BCAE4B4356C10A3DE3CA62F72D625B64DC5A65864ABF7EB5D9957C7CF9B474C6DD8D2F4A36B3B87D6417B58CA36C64C72EC26C38FB3D056FBA6DBBD24B2607FADF29BB85DE6EA2FACF9C7DDB324F998B7F2ABED325C4ED1A688710E5E3CF8188FDD4ACFB85A42030BB2D722B029EBF561A3FD5C71C0247A57A51F46C311B47E192312B52C662A23D60F3F9852DAEA9B506B747871CEBAA6D126E59BE462E7D6B178E0F1357EC79EA98FEE6FCEEBB99D9D673A689B91475B5ACBA3E6DDB028BAF0909AA7D2D05D569E3EC4D5E14B8922560F7053B01F45EFA82B32714BA3EE0BF1FB8C706310DE76EFBDC1B72ABEF8A0BA27D4D66D157F5B70AE19E266A01DA0D5B4D6F524AD8A1BF7C0D5630CF9D8EDF48FB13136B428473D225B530FD26EDFF8F2F78099742F493F927A7EAD4FEDCB29DA14338FA18B871FC7915BE99B4573686041F65A24366519CB8CCE15030CE1D275AF6A5D4DD0A2A8090C5B3BC2008ED846EFF49922C38AB1D621AF1D55D4E7675CF1030C5D33B9DE1CF55AEFAD891AB79095230CDB28EDF38E593B2EA408CBF965B5607FFC55F698E9722C1860BC94EC7A77B48BFDB7276AC282968E306263B5D03B6586C0A0426C35086BC4E7BCCC9E23DE6BE85C907ED4D4EC5A7BF48BFDB72766D4C2960E3F6AA3B5D0376AA6C0A0426C35886AC4BB6C9F7DB78AFBD8B5774DEA81331C40D9CA783D49ABC2272F62F5D0C327A19DEE29B4C68616E5A847626BEA876CB1CF97EFABEA104E8201AB920FA6E9086AC3CC11895A16319E31EB071F50316DF58CA93D3ABC38675D62DB747C482326D51E9E7E449BB9B5EEA897FA6E4BCC34862C1C7E0C47689D6FE2DA61010598CF2EACF8D36B849B28611AB26E98016B1DC2D031434CB2D6C5CE5EF00EE30CA19CF686CCA7253EA6484F7DE25BF621DF9711DF98EC5F34CC18AB2730744C0F48D3AED8E90D5B3ECEE88EDED2908935050717E6AA49708362DFF91EB06A28316B7F9FB0252251CBE215AEC8B7B5CB696B98FA8D7AEBBABEC85997E836FDA3CAE3BF333374E930A36B3A87A183E6B0946D8C9DE4984DC6196781AD0E996EFB92C882FDB5CA6F62913D6FB6D5FE48FEBB6D1931F4410B938FBCE5146A03AD41E9DA1731EC915B0C3EEAF25AEC1972E782A8427D35CA6EDC767138DE2D3E649BE2294A85072D4C3EDA9653A8EDB306A56B5FC468476E31F868CB6BB167B49D0BA20AF5D53889C65D06327AB63D2B871AEED6318C1D3444256C61FC7C07EF31D680CB6A73D88C5B56C415EBAD5378FBBE5B15CFC5EB97E4C73E9716BA34F5A8DBCFA1ECE80A4BD9C6F0698FDF64E87117DB6AF7C4FB964416ECAF755A4D8CFC92D4E0B5830EBEE32B2B9D71495BD971F6657E85AAE47647CC7FDC57AB9A9706D43B85566E16DBC3A67ED8C347DFBD22F9C0EBE9D566B5AF266851C44887AE1D7C90476DA36754CD9161C558EB10D78EE56E5B44BC00E65E907EECD4EC5A7FF48BFDB72766E6C2960E3F72A3B5D0376FA6C0A0426C35086B44B95DAD5EDD73A4BD0D5B997EF82CC7D03A678D4AD8C298B98CDC63F80195D866DFEC3A57C415EBAD7342ED8B35B4814B871C7597297084A56C63B76917EA65A5B63A7CE2237DAC69A5BF56F94DDC15D576997F7C3AFE165EF8C4FB57251F76D311D4BE992312B52C62BA63D60F3ED862DAEA99647B747871CEBAA4B6E9B75DB639FE88C88FE5F6A95845CC6CD0C2E4636B3985DA3B6B50BAF645CC6FE416838FB0BC167B66D9B920AA505F8DD21BB7CA36A73F7E7CFA73BEC99F8A08BB1DBC788011B79E446FA523306D3BA3C63D7A9B11465E72CBBDE3EF59145D7848CD9368E85FB275B17AF990AF1FF3F287BA15DBF225F88E10BC36F50DC17110654B675CD25686DF0D3AEC32F4CD4072BBDD7702EF9AD8A203EA9D422B57D973F8D45B83938F7923B3DA1DE542BFED8898DC8065838FEAB02DF34C5F2BC87B70D3994514FCFD365B058F8C3D38F5C834332B7BA817FA6D47F8C8842C1B7A64066E997B64DA41DE839BCE2CA3E032DB7DEAF0C35741EB920F92F9106ABF6C31C95A173169713B0C3E74C2DAEB994A577C4C919EFA44B76C7B08FF411C4774FAC16DA4D69AA35CE9B92531A319B06EF8811CBA6DBE916B45F90F6F3CB794B20FC5327BFDA850DC9B21C216261F2BCB29D49E5983D2B52F62EE22B7187C04E5B5D833A3CE055185FA6A14DDB81FF26CB5FFB4C8CAFCED510F9EEDC095A987DB7A0C65434754C21686CF77F41E430FB8CC36BB67DCB322AE586F9DC2DBF77E9D3D179BE7E8AFD7085A977AC82D8750B6B3C6246B5DF87847EE30F4704B6BAF7BAC9DF131457AEA93DFB287FD6119FE12A87FD14063AC9CC0D4312D204DBBA2A73768F948A33B764B8326D6101C5C98AB26A10D5A1F36C5BFB3A8A78FFD8BD28F68FB045ABB4C0169DA1533A2E1CB871F51112DF58DA82D38B830574D1368D062BB5EE79BE52D03EBDF62D8F1359DC7D15873F8106DEE3AE8319B8D3BF6137828626E10F6A51D1B12DE8B09367DF7FA0369A7BF1F9FCB0B7F922D786DFA1B8BF5205A471D71495B19730F89DE65F89B87DC76FBEE139E35B14507D43B8156FEB5782CB388F72B3BE3530FBB965CD9A675ADF7D6840F72E0CAA18777ACF6B907D318175284E5FCA25AB0F925E6D7B29DF1E9874B49AEB546BBD67B6B62862B68E5F0C3354EFB7CC365880B29C2727E512D8878B5C81E9C7EAC2CCFC2AB17FA6D47CC34C97BD967E096F92628FCA59CB758D3996514BC5DC43D8DE45E907C74B4EC6A6B5A17FB6F4FC418052E1D7C94C66BA167AC8C814185D86A10D5880F79561D22BEACC5199F7AD0B4E4CA36AD6BBDB7267CCA02570E3D6463B5CF3D61C6B890222CE797D882A8DFDA0A5835D8A0597FC9C81291A8651D464FE28F6BC9696BE048C6FCA096BEC85997D8362D8B2C6250ADD1E907B4915A6B8D72A5E796C40C62C0BAE10770E8B6F906AD15E53FBCF1DC82CA8EF46EBE25438C9243739B2EA76853DC64C97471A3B7D23F6D716E4E5961AF457053BE59AE8B4D5D64D975284336186E44CDA7B134D4169CBEBD5D86396EABF1465BFC43107A13702DECD488D01E4CB4D1EF8A6A97C77C7A3574E970B70FFD1C9666B6C352B6B1CBCD227493F16E13C25A1D7A53302F892CD85FEB849A18FB531D812B8794F5F61F417044256C6137AD2FF2A73A64B639DC0744FD548769A1B7CEC9B4EF619FEDF3B75F06881D75CFDAE186BD75104B230D71495BD965E48377196FE8E5B53B74F42D6B628B0EA87712ADACAAEC39EFF0856D812BD3DF002CC7D09A688D4AD8C298D18FDC63F8C197D866DFC83B57C415EBAD731AEDFB21CF9611BF341BB06AA001578F606A9B1E91A865D1431DB67EA48116D0D6A02136458717E7AC4B689BEAFF1E3F5CFF52D59C1F3CAFFE45A9C7D57402652F73409A7685CF6ACCF2A14755484BDD736A0F0E2ECC5593CC061DF6E589A73F9631A41AB22CF9981ACFA036CD1292AA6D11C31AB5C1E0E32AA9B59EA175844714E8AE4D6CB33E3E56F5A3ABBEE8EA9B5DEF9AD4836B3880B295F17A925685CF6BC4EAA18755423BDD336A8D0D2DCA518FC4D6ECF2D757B23B3C2515BC36F990DA0FA2B6D01597B49511C31BBFCBE0432CB8DD9EE1F6AD892D3AA0DE29B5F2E361BFD8AEC3DF7812B670B0F1D74E61EE602B285DFB3A4C7DE016A38DBC9C16074EBA714154A1BE1A6537AE7CCEA2BFDDD1BF28F9481B4EA0B6CC1890A65D11631CB17CF01196D152CFD85A83830B73D524B2419787AF0A1E50DF92D4E3D9CEAFEC64BA9CA24DE18319BE78E8B11CBD95EE81B485061664AF456053F645CC7BB29CF1E9075049AE7547BBD67B6B62E62E68E5F043374EFB7CB366880B29C2727E512D7839BE93EA6FDB7D11F1CB3D01ABD20F9AE1085AB38C11895A16337A11EB871F40296DF58DA4353ABC38675DB2DB74FCAEE1CDA2581571063262F540036C3E8AA995B6C8C42D8D1EECB87D461A70C16D0F1A7CD7AAF8E283EA9E4A5B6BF51D7347708427BF0528B9D52E6997FA6E4BC454072D1C7C8CC7689D67320D61010598CF2EA7F855D6E525D89065C9C7CB7806B55D9690546D8B18BBA80D061F3F49ADF58CA5233CA240776D729B55668BFD69D3883726FA17251F5DC309D4861903D2B42B626823960F3EB2325AEA19566B707061AE9AE437A83E49B731B52E1C74541BA7B0B74E094AD7BE8E631BB0C5A8A32BA3C51163DC5A1055A8AF46E18DDB2EF265CCB72B7B56A41F662DBDD6A9D6D5042D8A99DBC0B5C30FEC986DF4CDA63132AC186B1D72DB11F7DD35610B071C43FB7782D883D2B5AFD36C8AFCDA1A812D0E9EDBA8AFAC31ACF3D528BF7155D569B03DCB0619EBD619DA8D3384A46A5BE440076F30CA384B696DC0205BC2230A74D726BF59D56E1BF3559241EB061B60F510E6CEE931C95AD76186C376186D8885B437708E4DF131457AEA93DDB2CFF926DBC4BC75CAB3648011D6F2EBBD6A5D4ED1A6A8990D5C3CC2B88EDB4AEF7C1A43030BB2D722AE297F3F7274FD974D56443CD514B02AF5301A8FA06C668948D4B2F0A98C5A3FF460CA69AB7B421DD1E1C539EB9A489BE2A470C4EAA107D82E423C91895BDA7DB0450A65F96D8F1BFC28016D5B1C54F744DA7A1AE2325BC53ECB15B42EF54DC17208653B6B4CB2D685DF022277187AF8A5B5D73DEACEF898223DF5896ED92ADBE7CBC8372607AC4A3FC88623684D3346246A59CC0847AC1F7E80A5B4D537BAD6E8F0E29C75896DD3E916F07DB93DEC22E6D5B728FDB8B64FA0F5CB1490A65D31B31ABE7CF85115D152DF9CDA82830B73D524B441D5E9617CD81F962F1133EA5D957E480D47D03A668C48D4B298398D583FFCA04A69AB6F56ADD1E1C539EB92DEA6C3E3BFF2458CA30D5837D8D0AA8730374E8F49D6BA0EA31BB6C368C32BA4BD81236C8A8F29D2539FE49615D52FF585BCAAA27E2D2C6459F251369E41ED9B252455DB22E6386A83C1C758526B3D33EC088F28D05D9BD8663D2C3EE5CB43C4278DDC0B528FAC9E5DDDA775B1FFF6840F68E8D2A14773C416BA07D11C185488AD06598D501FA4F0890B59977CF0CC87D0B6B3C4246B5DC434C6ED30F8500A6BAF67525DF131457AEA13DDB25F0F79CC9B1DDD0BD28FAF9A5DDB47BFD87F7B6226356CE9F0233A5A0B7DD3680A0C2AC45683B0469C1EAB0EDF3C13B832FDF0598E61DA30C9577FD81B113397917B0C3FA012DBEC9B5DE78AB862BD754A6FDF6A1BFE04923D38F9383732AB7B2817FA6D47C49C062C1B7C34876D9967E65A41DE839BCE2CA3E05DBE28D67904253A17241F1D2DBBBA4FEB62FFED8918A3C0A5838FD2782DF48C953130A8105B0DB21AB12F0F8BFDA1EC244443D7261F40FB41D42D5D71495B1931A1F1BB0C3EAC82DBED9966DF9AD8A203EA9D522B3F64E16F07F42F1A6CEC1B2730774D0948D3AE0E131EB07CB4D11EB7A58153DC0A0E2ECC5593CC061D1EAB4559ECE208DABB28F9881A4EA0EE650C48D3AE88118D583EF888CA68A96744ADC1C185B96A12DBA07DD4574578560C319C7BEB07F90D5713B4286E2683D68E3190E3B5D13F8786C8B062AC75886BC76EB77A7997AF8ACF7919FE5EF99065E947D07406AD63E690546D8B99C8980D861F4B41ADF54DA93D3CA240776DC29B15FB41F08055C30CAFEB23B79688442D8B9D5CA11FFF96D3D690A98DFCD8B7BEC85997D036FD9C55BF04CFA93D38F57836332B7BA817FA6D47F80C862C1B7AF4066E997BBEDA41DE839BCE2CA3E0D304EEB66538C1F996241F9F567EB54186CB29DA143150C18B071FABB15BE919344B686041F65A4436E5E1F4D44FD418BA960C31866AFE569BF4CB29DA143786618BC718C3515BE91F4353686041F65AC435E5BFB2D5A17EE4C287D0BD20F508EAD9957DDA17FB6F4FF8F0852E1D7AF4466CA17BE8CC814185D86A90D588A2AAFFFD6399C7BF7A18BA34F9F859CFA136CF1196B28D11C319BDC9E0632AB5D59E21F62C892CD85FAB98267EFDD5EB8EDF6E37FBACD8E4E5E5DAD75F1D3FECB9CEDEFE50FF73BF2DB3E7FCC37699AFAAD35FBFFEEAA743BD7A9DBFFEEB5D5E15CFD72DBEAEF7DCE48B63CEEBA6E798F79BA7ED8FE5769797A76A9A273A879C2FBF3DAC1FF27DB6CCF6D937E5BE78CA16FBB7EFEC2F36CF5F7E71BAEFFDE9CBEFD68FF9F2FDE6E361BF3BECEB92F3F5E3EAA5D98CAFBF72E7FFFAABD699BFFE786A6DD54709F5318BBA84FCE3E6CF8762B5BC9CFB2FD9AACAD507CDB6C5B775F7BFCFEBBFBF3E96FBFA7FF3E797CB4E7FDB6E02377A6BDFBB7C97D790D9EC7FCED7BBE377C5551F370FD9E7BCCBD9FE51E57FCD9FB3C5CBF12BDC8BE5F15661DBC4FF40A86DFFFA5D913DD737A0EA6D8FEBFAFA9F358697EBDFFE9FFF05813C12AFCCA21F00 , N'6.1.3-40302')
