using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.Common.Cache;

namespace Pyro.Common.Global
{
  public sealed class GlobalProperties : IGlobalProperties
  {
    public GlobalProperties()
    {
      _ServiceRootUrl = WebConfigProperties.ServiceBaseURL();

      _ThisServersEntityCode = WebConfigProperties.ThisServersEntityCode();
      _ThisServersEntitySystem = WebConfigProperties.ThisServersEntitySystem();
      _ThisServersManagingOrganizationResource = WebConfigProperties.ThisServersManagingOrganizationResource();

      _ApplicationCacheServicesActive = WebConfigProperties.ApplicationCacheServicesActive();

      _ApplicationVersionInfo = System.Diagnostics.FileVersionInfo.GetVersionInfo(typeof(GlobalProperties).Assembly.Location).ProductVersion;

      _NumberOfRecordsPerPageDefault = WebConfigProperties.NumberOfRecordsPerPageDefault();
      _MaxNumberOfRecordsPerPage = WebConfigProperties.MaxNumberOfRecordsPerPage();

      _FhirAuditEventLogRequestData = WebConfigProperties.FhirAuditEventLogRequestData();
      _FhirAuditEventLogResponseData = WebConfigProperties.FhirAuditEventLogResponseData();

      _HIServiceCertificateSerialNumber = WebConfigProperties.HIServiceCertificateSerialNumber();
      _HIServiceConnectivityActive = WebConfigProperties.HIServiceConnectivityActive();
      _HIServiceEndpoint = WebConfigProperties.HIServiceEndpoint();
      _HIServiceProductName = WebConfigProperties.HIServiceProductName();
      _HIServiceProductVersion = WebConfigProperties.HIServiceProductVersion();
      _HIServiceVendorId = WebConfigProperties.HIServiceVendorId();
      _HIServiceVendorIdQualifier = WebConfigProperties.HIServiceVendorIdQualifier();
      _HIServiceIHIValidationPeriodDays = WebConfigProperties.HIServiceIHIValidationPeriodDays();
    }

    private string _ServiceRootUrl;
    public string ServiceRootUrl
    {
      get { return _ServiceRootUrl; }
    }

    private string _ThisServersEntityCode;
    public string ThisServersEntityCode
    {
      get
      {
        return _ThisServersEntityCode;
      }
    }
    private string _ThisServersEntitySystem;
    public string ThisServersEntitySystem
    {
      get
      {
        return _ThisServersEntitySystem;
      }
    }
    private string _ThisServersManagingOrganizationResource;
    public string ThisServersManagingOrganizationResource
    {
      get
      {
        return _ThisServersManagingOrganizationResource;
      }
    }

    private bool _ApplicationCacheServicesActive;
    public bool ApplicationCacheServicesActive
    {
      get
      {
        return _ApplicationCacheServicesActive;
      }
    }

    private string _ApplicationVersionInfo;
    public string ApplicationVersionInfo
    {
      get
      {
        return _ApplicationVersionInfo;
      }
    }

    private int _NumberOfRecordsPerPageDefault;
    public int NumberOfRecordsPerPageDefault
    {
      get
      {
        return _NumberOfRecordsPerPageDefault;
      }
    }

    private int _MaxNumberOfRecordsPerPage;
    public int MaxNumberOfRecordsPerPage
    {
      get
      {
        return _MaxNumberOfRecordsPerPage;
      }
    }

    private bool _FhirAuditEventLogRequestData;
    public bool FhirAuditEventLogRequestData
    {
      get
      {
        return _FhirAuditEventLogRequestData;
      }
    }

    private bool _FhirAuditEventLogResponseData;
    public bool FhirAuditEventLogResponseData
    {
      get
      {
        return _FhirAuditEventLogResponseData;
      }
    }

    private bool _HIServiceConnectivityActive;
    public bool HIServiceConnectivityActive
    {
      get
      {
        return _HIServiceConnectivityActive;
      }
    }

    private string _HIServiceCertificateSerialNumber;
    public string HIServiceCertificateSerialNumber
    {
      get
      {
        return _HIServiceCertificateSerialNumber;
      }
    }

    private string _HIServiceEndpoint;
    public string HIServiceEndpoint
    {
      get
      {
        return _HIServiceEndpoint;
      }
    }

    private string _HIServiceProductName;
    public string HIServiceProductName
    {
      get
      {
        return _HIServiceProductName;
      }
    }

    private string _HIServiceProductVersion;
    public string HIServiceProductVersion
    {
      get
      {
        return _HIServiceProductVersion;
      }
    }

    private string _HIServiceVendorId;
    public string HIServiceVendorId
    {
      get
      {
        return _HIServiceVendorId;
      }
    }

    private string _HIServiceVendorIdQualifier;
    public string HIServiceVendorIdQualifier
    {
      get
      {
        return _HIServiceVendorIdQualifier;
      }
    }

    private int _HIServiceIHIValidationPeriodDays;
    public int HIServiceIHIValidationPeriodDays
    {
      get
      {
        return _HIServiceIHIValidationPeriodDays;
      }
    }
    
  }



}
