namespace Pyro.Common.Global
{
  public interface IGlobalProperties
  {
    string ServiceRootUrl { get; }

    bool ApplicationCacheServicesActive { get; }

    string ApplicationVersionInfo { get; }

    int NumberOfRecordsPerPageDefault { get; }
    int MaxNumberOfRecordsPerPage { get; }

    bool FhirAuditEventLogRequestData { get; }
    bool FhirAuditEventLogResponseData { get; }

    bool HIServiceConnectivityActive { get; }
    string HIServiceCertificateSerialNumber { get; }
    string HIServiceEndpoint { get; }
    string HIServiceProductName { get; }
    string HIServiceProductVersion { get; }
    string HIServiceVendorId { get; }
    string HIServiceVendorIdQualifier { get; }
    int HIServiceIHIValidationPeriodDays { get; }
    


  }
}