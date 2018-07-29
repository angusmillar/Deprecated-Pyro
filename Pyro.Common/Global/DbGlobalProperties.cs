using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.Common.Tools;
using Pyro.Common.Interfaces.Service;

namespace Pyro.Common.Global
{
  public sealed class DbGlobalProperties : IGlobalProperties
  {
    private readonly IServiceConfigurationService IServiceConfigurationService;
    private Dictionary<string, string> GlobalPropertiesDictionary;
    
    public DbGlobalProperties(IServiceConfigurationService IServiceConfigurationService)
    {
      this.IServiceConfigurationService = IServiceConfigurationService;
      GlobalPropertiesDictionary = this.IServiceConfigurationService.GetServiceConfigrationDictionary();      
    }
    
    public string ServiceBaseURL { get { return GetStringPropertyValueOrDefault(WebConfigPropertiesNames.ServiceBaseURL, string.Empty); } }
    
    public bool FHIRApiAuthentication { get { return GetBoolPropertyValueOrDefault(WebConfigPropertiesNames.FHIRApiAuthentication, WebConfigPropertiesDefaults.FHIRApiAuthentication); } }

    public string AuthenticationServerUrl { get { return GetStringPropertyValueOrDefault(WebConfigPropertiesNames.AuthenticationServerUrl, WebConfigPropertiesDefaults.AuthenticationServerUrl); } }

    public string ThisServersEntityCode { get { return GetStringPropertyValueOrDefault(WebConfigPropertiesNames.ThisServersEntityCode, WebConfigPropertiesDefaults.ThisServersEntityCode); } }

    public string ThisServersEntitySystem { get { return GetStringPropertyValueOrDefault(WebConfigPropertiesNames.ThisServersEntitySystem, WebConfigPropertiesDefaults.ThisServersEntitySystem); } }
    
    public string ThisServersManagingOrganizationResource { get { return GetStringPropertyValueOrDefault(WebConfigPropertiesNames.ThisServersManagingOrganizationResource, WebConfigPropertiesDefaults.ThisServersManagingOrganizationResource); } }
    
    public bool LoadFhirDefinitionResources { get { return GetBoolPropertyValueOrDefault(WebConfigPropertiesNames.LoadFhirDefinitionResources, WebConfigPropertiesDefaults.LoadFhirDefinitionResources); } }

    public bool ApplicationCacheServicesActive { get { return GetBoolPropertyValueOrDefault(WebConfigPropertiesNames.ApplicationCacheServicesActive, WebConfigPropertiesDefaults.ApplicationCacheServicesActive); } }
    
    public string ApplicationVersionInfo { get { return WebConfigPropertiesDefaults.ApplicationVersionInfo; } }
    
    public int NumberOfRecordsPerPageDefault { get { return GetIntPropertyValueOrDefault(WebConfigPropertiesNames.NumberOfRecordsPerPageDefault, WebConfigPropertiesDefaults.NumberOfRecordsPerPageDefault); } }
    
    public int MaxNumberOfRecordsPerPage { get { return GetIntPropertyValueOrDefault(WebConfigPropertiesNames.MaxNumberOfRecordsPerPage, WebConfigPropertiesDefaults.SystemDefaultMaxNumberOfRecordsPerPage);} }
    
    public bool FhirAuditEventLogRequestData { get { return GetBoolPropertyValueOrDefault(WebConfigPropertiesNames.FhirAuditEventLogRequestData, WebConfigPropertiesDefaults.FhirAuditEventLogRequestData); } }
    
    public bool FhirAuditEventLogResponseData { get { return GetBoolPropertyValueOrDefault(WebConfigPropertiesNames.FhirAuditEventLogResponseData, WebConfigPropertiesDefaults.FhirAuditEventLogResponseData); } }
    
    public bool HIServiceConnectivityActive { get { return GetBoolPropertyValueOrDefault(WebConfigPropertiesNames.HIServiceConnectivityActive, WebConfigPropertiesDefaults.HIServiceConnectivityActive); } }
    
    public string HIServiceCertificateSerialNumber { get { return GetStringPropertyValueOrDefault(WebConfigPropertiesNames.HIServiceCertificateSerialNumber, WebConfigPropertiesDefaults.HIServiceCertificateSerialNumber); } }
    
    public string HIServiceEndpoint { get { return GetStringPropertyValueOrDefault(WebConfigPropertiesNames.HIServiceEndpoint, WebConfigPropertiesDefaults.HIServiceEndpoint); } }
    
    public string HIServiceProductName { get { return GetStringPropertyValueOrDefault(WebConfigPropertiesNames.HIServiceProductName, WebConfigPropertiesDefaults.HIServiceProductName); } }
    
    public string HIServiceProductVersion { get { return GetStringPropertyValueOrDefault(WebConfigPropertiesNames.HIServiceProductVersion, WebConfigPropertiesDefaults.HIServiceProductVersion); } }
    
    public string HIServiceVendorId { get { return GetStringPropertyValueOrDefault(WebConfigPropertiesNames.HIServiceVendorId, WebConfigPropertiesDefaults.HIServiceVendorId); } }
    
    public string HIServiceVendorIdQualifier { get { return GetStringPropertyValueOrDefault(WebConfigPropertiesNames.HIServiceVendorIdQualifier, WebConfigPropertiesDefaults.HIServiceVendorIdQualifier); } }
    
    public int HIServiceIHIValidationPeriodDays { get { return GetIntPropertyValueOrDefault(WebConfigPropertiesNames.HIServiceIHIValidationPeriodDays, WebConfigPropertiesDefaults.HIServiceIHIValidationPeriodDays); } }

    private string GetStringPropertyValueOrDefault(string Parameter, string Default)
    {
      if (GlobalPropertiesDictionary.ContainsKey(Parameter))
      {
        return GlobalPropertiesDictionary[Parameter];
      }
      else
      {
        return string.Empty;
      }
    }

    private bool GetBoolPropertyValueOrDefault(string Parameter, bool Default)
    {
      if (GlobalPropertiesDictionary.ContainsKey(Parameter))
      {
        return StringSupport.StringToBoolean(GlobalPropertiesDictionary[Parameter]);
      }
      else
      {
        return Default;
      }
    }

    private int GetIntPropertyValueOrDefault(string Parameter, int Default)
    {
      if (GlobalPropertiesDictionary.ContainsKey(Parameter))
      {
        int Temp;
        if (Int32.TryParse(GlobalPropertiesDictionary[Parameter], out Temp))
        {
          return Temp;
        }
        else
        {
          return Default;
        }
      }
      else
      {
        return Default;
      }
    }

  }

}
