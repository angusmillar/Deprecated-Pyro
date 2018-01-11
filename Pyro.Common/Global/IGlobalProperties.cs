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
  }
}