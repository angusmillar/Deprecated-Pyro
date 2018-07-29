using System;
using System.Configuration;
using Pyro.Common.Tools;
using Pyro.Common.Exceptions;

namespace Pyro.Common.Global
{
  public static class WebConfigProperties
  {
    public static string ServiceBaseURL()
    {
      Uri ServiceBaseURL = WebConfigPropertiesNames.ServiceBaseURL
        .AppSettingAsUriOrDefault(null);

      if (ServiceBaseURL == null)
      {
        string Msg = $"The Web.Config file of the server has an invalid '{WebConfigPropertiesNames.ServiceBaseURL}' property value, it must conform to a Uri format.";
        throw new PyroException(System.Net.HttpStatusCode.InternalServerError,
          Common.Tools.FhirOperationOutcomeSupport.Create(Hl7.Fhir.Model.OperationOutcome.IssueSeverity.Fatal, Hl7.Fhir.Model.OperationOutcome.IssueType.Exception, Msg), Msg);
      }
      else
      {
        return ServiceBaseURL.ToString();
      }      
    }
    
    public static bool FHIRApiAuthentication()
    {
      return WebConfigPropertiesNames.FHIRApiAuthentication
        .AppSettingAsBoolOrDefault(WebConfigPropertiesDefaults.FHIRApiAuthentication);
    }

    public static string AuthenticationServerUrl()
    {
      return WebConfigPropertiesNames.AuthenticationServerUrl
        .AppSettingAsStringOrDefault(WebConfigPropertiesDefaults.AuthenticationServerUrl);
    }    

    public static string ThisServersEntityCode()
    {
      return WebConfigPropertiesNames.ThisServersEntityCode
        .AppSettingAsStringOrDefault(WebConfigPropertiesDefaults.ThisServersEntityCode);            
    }

    public static string ThisServersEntitySystem()
    {
      return WebConfigPropertiesNames.ThisServersEntitySystem
        .AppSettingAsStringOrDefault(WebConfigPropertiesDefaults.ThisServersEntitySystem);
    }

    public static string ThisServersManagingOrganizationResource()
    {
      return WebConfigPropertiesNames.ThisServersManagingOrganizationResource
        .AppSettingAsStringOrDefault(WebConfigPropertiesDefaults.ThisServersManagingOrganizationResource);
    }

    public static bool LoadFhirDefinitionResources()
    {
      return WebConfigPropertiesNames.LoadFhirDefinitionResources.AppSettingAsBoolOrDefault(WebConfigPropertiesDefaults.LoadFhirDefinitionResources);
    }

    public static bool ApplicationCacheServicesActive()
    {
      return WebConfigPropertiesNames.ApplicationCacheServicesActive
        .AppSettingAsBoolOrDefault(WebConfigPropertiesDefaults.ApplicationCacheServicesActive);      
    }

    public static bool FhirAuditEventLogRequestData()
    {
      return WebConfigPropertiesNames.FhirAuditEventLogRequestData
        .AppSettingAsBoolOrDefault(WebConfigPropertiesDefaults.FhirAuditEventLogRequestData);      
    }

    public static bool FhirAuditEventLogResponseData()
    {
      return WebConfigPropertiesNames.FhirAuditEventLogResponseData
        .AppSettingAsBoolOrDefault(WebConfigPropertiesDefaults.FhirAuditEventLogResponseData);      
    }

    /// <summary>
    /// This setting sets the default number of Resource returned for one page of search results. 
    /// i.e The number of resource returned in a search bundle. 
    /// Users can modify this per call with the _count search parameter
    /// up to the MaxNumberOfRecordsPerPage value and not beyond.
    /// If this is not set in the web config file then it defaults to the SystemDefaultNumberOfRecordsPerPageString
    /// </summary>
    /// <returns>NumberOfRecordsPerPage integer</returns>
    public static int NumberOfRecordsPerPageDefault()
    {      
      return WebConfigPropertiesNames.NumberOfRecordsPerPageDefault
        .AppSettingAsIntOrDefault(WebConfigPropertiesDefaults.NumberOfRecordsPerPageDefault);      
    }

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
    public static int MaxNumberOfRecordsPerPage()
    {      
      int MaxNumberOfRecordsPerPage = WebConfigPropertiesNames.MaxNumberOfRecordsPerPage
        .AppSettingAsIntOrDefault(WebConfigPropertiesDefaults.SystemDefaultMaxNumberOfRecordsPerPage);

      if (MaxNumberOfRecordsPerPage > WebConfigPropertiesDefaults.AbsoluteMaxNumberOfRecordsPerPage)
      {
        return WebConfigPropertiesDefaults.AbsoluteMaxNumberOfRecordsPerPage;
      }
      else
      {
        return MaxNumberOfRecordsPerPage;
      }
    }

    /// <summary>
    /// Enable the HI Service Connectivity
    /// Default: False
    /// </summary>
    /// <returns></returns>
    public static bool HIServiceConnectivityActive()
    {
      return WebConfigPropertiesNames.HIServiceConnectivityActive
        .AppSettingAsBoolOrDefault(WebConfigPropertiesDefaults.HIServiceConnectivityActive);      
    }

    /// <summary>
    /// The HI Service Certificate serial number from the windows certificate manager's personal store for the active user
    /// </summary>
    /// <returns></returns>
    public static string HIServiceCertificateSerialNumber()
    {
      return WebConfigPropertiesNames.HIServiceCertificateSerialNumber
        .AppSettingAsStringOrDefault(WebConfigPropertiesDefaults.HIServiceCertificateSerialNumber);      
    }

    /// <summary>
    /// The HI Service Endpoint where the HI Service is found
    /// </summary>
    /// <returns></returns>
    public static string HIServiceEndpoint()
    {
      return WebConfigPropertiesNames.HIServiceEndpoint
        .AppSettingAsStringOrDefault(WebConfigPropertiesDefaults.HIServiceEndpoint);      
    }

    /// <summary>
    /// The HI Service ProductName as registered with and provided by Medicare for the HI Service connection
    /// This would most likely be something like 'PyroServer' or the product name that was accredited for HI Service connectivity
    /// </summary>
    /// <returns></returns>
    public static string HIServiceProductName()
    {
      return WebConfigPropertiesNames.HIServiceProductName
        .AppSettingAsStringOrDefault(WebConfigPropertiesDefaults.HIServiceProductName);      
    }

    /// <summary>
    /// The HI Service ProductVersion as registered with and provided by Medicare for the HI Service connection
    /// This would be version of the PyroServer or at least the version that was accredited for HI Service connectivity
    /// </summary>
    /// <returns></returns>
    public static string HIServiceProductVersion()
    {
      return WebConfigPropertiesNames.HIServiceProductVersion
        .AppSettingAsStringOrDefault(WebConfigPropertiesDefaults.HIServiceProductVersion);      
    }

    /// <summary>
    /// The HI Service VendorId as registered with and provided by Medicare for the HI Service connection
    /// This would be an id for the client using the Pyro Service for there HI Serevice connectivity
    /// </summary>
    /// <returns></returns>
    public static string HIServiceVendorId()
    {
      return WebConfigPropertiesNames.HIServiceVendorId
        .AppSettingAsStringOrDefault(WebConfigPropertiesDefaults.HIServiceVendorId);      
    }

    /// <summary>
    /// The HI Service VendorIdQualifier as registered with and provided by Medicare for the HI Service connection
    /// This would be a IdQualifier for the client using the Pyro Service for there HI Serevice connectivity
    /// It will most likley be 'http://ns.electronichealth.net.au/id/hi/vendorid/1.0'
    /// </summary>
    /// <returns></returns>
    public static string HIServiceVendorIdQualifier()
    {
      return WebConfigPropertiesNames.HIServiceVendorIdQualifier
        .AppSettingAsStringOrDefault(WebConfigPropertiesDefaults.HIServiceVendorIdQualifier);      
    }

    public static int HIServiceIHIValidationPeriodDays()
    {      
      return WebConfigPropertiesNames.HIServiceIHIValidationPeriodDays
        .AppSettingAsIntOrDefault(WebConfigPropertiesDefaults.HIServiceIHIValidationPeriodDays);      
    }
    
    private static int AppSettingAsIntOrDefault(this string Key, int Default)
    {
      int Result;
      string KeyValue = Key.AppSetting();
      if (int.TryParse(KeyValue, out Result))
      {
        return Result;
      }
      else
      {
        return Default;
      }
    }
    private static bool AppSettingAsBoolOrDefault(this string Key, bool Default)
    {
      string KeyValue = Key.AppSetting();
      if (StringSupport.StringIsBoolean(KeyValue))
      {
        return StringSupport.StringToBoolean(KeyValue);
      }
      else
      {
        return Default;
      }
    }
    private static Uri AppSettingAsUriOrDefault(this string Key, Uri Default)
    {
      string KeyValue = Key.AppSetting().TrimEnd('/');
      Uri Temp;
      if (Uri.TryCreate(KeyValue, UriKind.Absolute, out Temp))
      {
        return Temp;
      }
      else
      {
        return Default;
      }      
    }
    private static string AppSettingAsStringOrDefault(this string Key, string Default)
    {      
      string Value = Key.AppSetting();
      if (string.IsNullOrWhiteSpace(Value))
      {
        return Default;
      }
      else
      {
        return Value.Trim();
      }
    }
    private static string AppSetting(this string Key)
    {
      string Result = string.Empty;
      if (ConfigurationManager.AppSettings[Key] != null)
        Result = ConfigurationManager.AppSettings[Key];
      return Result;
    }

  }
}