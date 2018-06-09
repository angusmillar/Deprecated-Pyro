using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.Common.Global
{
  public static class WebConfigPropertiesNames
  {
    public static string ServiceBaseURL { get; } = "ServiceBaseURL";
    public static string FHIRApiAuthentication { get; } = "FHIRApiAuthentication";    
    public static string ThisServersEntityCode { get; } = "ThisServersEntityCode";    
    public static string ThisServersEntitySystem { get; } = "ThisServersEntitySystem";    
    public static string ThisServersManagingOrganizationResource { get; } = "ThisServersManagingOrganizationResource";
    public static string ApplicationCacheServicesActive { get; } = "ApplicationCacheServicesActive";
    public static string FhirAuditEventLogRequestData { get; } = "FhirAuditEventLogRequestData";
    public static string FhirAuditEventLogResponseData { get; } = "FhirAuditEventLogResponseData";    
    public static string NumberOfRecordsPerPageDefault { get; } = "NumberOfRecordsPerPageDefault";
    public static string MaxNumberOfRecordsPerPage { get; } = "MaxNumberOfRecordsPerPage";    
    public static string AbsoluteMaxNumberOfRecordsPerPage { get; } = "AbsoluteMaxNumberOfRecordsPerPage";
    public static string SystemDefaultMaxNumberOfRecordsPerPage { get; } = "SystemDefaultMaxNumberOfRecordsPerPage";    
    public static string HIServiceConnectivityActive { get; } = "HIServiceConnectivityActive";    
    public static string HIServiceCertificateSerialNumber { get; } = "HIServiceCertificateSerialNumber";    
    public static string HIServiceEndpoint { get; } = "HIServiceEndpoint";
    public static string HIServiceProductName { get; } = "HIServiceProductName";
    public static string HIServiceProductVersion { get; } = "HIServiceProductVersion";    
    public static string HIServiceVendorId { get; } = "HIServiceVendorId";    
    public static string HIServiceVendorIdQualifier { get; } = "HIServiceVendorIdQualifier";
    public static string HIServiceIHIValidationPeriodDays { get; } = "HIServiceIHIValidationPeriodDays";    
  }
}
