using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.Common.Global
{
  public static class WebConfigPropertiesDefaults
  {
    public static bool FHIRApiAuthentication { get; } = true;
    
    public static string ThisServersEntityCode { get; } = "ThisServersEntityCode_HasNotBeenSet";
    
    public static string ThisServersEntitySystem { get; } = "http://ThisServersEntitySystem.HasNot/BeenSet";
    
    public static string ThisServersManagingOrganizationResource { get; } = "http://ThisServersEntitySystem.HasNot/BeenSet";

    public static bool ApplicationCacheServicesActive { get; } = true;

    public static string ApplicationVersionInfo { get; } = System.Diagnostics.FileVersionInfo.GetVersionInfo(typeof(GlobalProperties).Assembly.Location).ProductVersion;
    
    public static bool FhirAuditEventLogRequestData { get; } = true;

    public static bool FhirAuditEventLogResponseData { get; } = true;

    /// <summary>
    /// This setting sets the default number of Resource returned for one page of search results. 
    /// i.e The number of resource returned in a search bundle. 
    /// Users can modify this per call with the _count search parameter
    /// up to the MaxNumberOfRecordsPerPage value and not beyond.
    /// If this is not set in the web config file then it defaults to the SystemDefaultNumberOfRecordsPerPageString
    /// </summary>
    /// <returns>NumberOfRecordsPerPage integer</returns>
    public static int NumberOfRecordsPerPageDefault { get; } = 50;

    /// <summary>
    /// This setting sets the maximum number of Resource returned for one page of search results. 
    /// i.e The number of resource returned in a search bundle. 
    /// Users cannot modify this per call. If the _count search parameter is greater than this maximum then
    /// the MaxNumberOfRecordsPerPage value is used.
    /// Furthermore, the Web Config file cannot set this value beyond the absolute max value that is 
    /// set here in code at 5000.
    /// up to the MaxNumberOfRecordsPerPage value and not beyond.
    /// </summary>
    /// <returns>NumberOfRecordsPerPage integer</returns>
    public static int AbsoluteMaxNumberOfRecordsPerPage { get; } = 5000;

    public static int SystemDefaultMaxNumberOfRecordsPerPage { get; } = 500;
    
    /// <summary>
    /// Enable the HI Service Connectivity
    /// Default: False
    /// </summary>
    /// <returns></returns>
    public static bool HIServiceConnectivityActive { get; } = false;

    /// <summary>
    /// The HI Service Certificate serial number from the windows certificate manager's personal store for the active user
    /// </summary>
    /// <returns></returns>
    public static string HIServiceCertificateSerialNumber { get; } = string.Empty;

    /// <summary>
    /// The HI Service Endpoint where the HI Service is found
    /// </summary>
    /// <returns></returns>
    public static string HIServiceEndpoint { get; } = string.Empty;

    /// <summary>
    /// The HI Service ProductName as registered with and provided by Medicare for the HI Service connection
    /// This would most likely be something like 'PyroServer' or the product name that was accredited for HI Service connectivity
    /// </summary>
    /// <returns></returns>
    public static string HIServiceProductName { get; } = string.Empty;

    /// <summary>
    /// The HI Service ProductVersion as registered with and provided by Medicare for the HI Service connection
    /// This would be version of the PyroServer or at least the version that was accredited for HI Service connectivity
    /// </summary>
    /// <returns></returns>
    public static string HIServiceProductVersion { get; } = string.Empty;

    /// <summary>
    /// The HI Service VendorId as registered with and provided by Medicare for the HI Service connection
    /// This would be an id for the client using the Pyro Service for there HI Serevice connectivity
    /// </summary>
    /// <returns></returns>
    public static string HIServiceVendorId { get; } = string.Empty;

    /// <summary>
    /// The HI Service VendorIdQualifier as registered with and provided by Medicare for the HI Service connection
    /// This would be a IdQualifier for the client using the Pyro Service for there HI Serevice connectivity
    /// It will most likley be 'http://ns.electronichealth.net.au/id/hi/vendorid/1.0'
    /// </summary>
    /// <returns></returns>
    public static string HIServiceVendorIdQualifier { get; } = string.Empty;

    public static int HIServiceIHIValidationPeriodDays { get; } = 1;


  }
}
